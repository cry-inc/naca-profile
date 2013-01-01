using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace NacaProfile
{
    /*
     * http://www.ppart.de/aerodynamics/profiles/NACA4.html
     * NACA4415
     * points: 50
     * distribution: 2
     * 
     * TODO:
     * - PNG-Export
     * - Anzeige Max/Min-Werte
     * - Negativ andere Farbe als Positiv
     */

    enum ParseResult
    {
        Success,
        InvalidCount,
        InvalidFormat
    }

    public partial class MainForm : Form
    {
        private Thread udpThread;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Profile profile = new Profile("profile.txt", "probes.txt");
            profilePanel.Profile = profile;
            profilePanel.SetDummyData((float)numericUpDown1.Value);

            udpThread = new Thread(new ThreadStart(UdpThread));
            udpThread.IsBackground = true;
            udpThread.Start();
        }

        private void checkBoxFields_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowField = checkBoxFields.Checked;
        }

        private void checkBoxNormals_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowNormals = checkBoxNormals.Checked;
        }

        private void checkBoxProbes_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowProbes = checkBoxProbes.Checked;
        }

        private void checkBoxValues_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowValues = checkBoxValues.Checked;
        }

        private void checkBoxCentroid_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowCentroid = checkBoxCentroid.Checked;
        }

        private void checkBoxAntiAlias_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.AntiAliasing = checkBoxAntiAlias.Checked;
        }

        private void buttonValues_Click(object sender, EventArgs e)
        {
            string text = richTextBoxValues.Text;
            ParseResult result = ParseData(text);
            if (result == ParseResult.InvalidCount)
                MessageBox.Show("Anzahl der Messwerte entspricht nicht der Anzahl der Messpunkte!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (result == ParseResult.InvalidFormat)
                MessageBox.Show("Konnte Daten nicht als Zahl interpretieren!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private ParseResult ParseData(string text)
        {
            text = text.Replace(",", ".");
            text = text.Replace(";", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\t", " ");
            text = text.Replace("\r", " ");
            string[] splitted = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length != profilePanel.Profile.Probes.Count)
                return ParseResult.InvalidCount;

            float[] data = new float[splitted.Length];
            IFormatProvider format = CultureInfo.GetCultureInfo("en-US").NumberFormat;
            for (int i = 0; i < splitted.Length; i++)
            {
                double tmp;
                if (!Double.TryParse(splitted[i], NumberStyles.Any, format, out tmp))
                    return ParseResult.InvalidFormat;
                data[i] = (float)tmp;
            }

            profilePanel.Data = data;
            return ParseResult.Success;
        }

        private void buttonExportPng_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG-Grafik|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(profilePanel.Width, profilePanel.Height);
                profilePanel.DrawToBitmap(bmp, new Rectangle(0, 0, profilePanel.Width, profilePanel.Height));
                ((Image)bmp).Save(dialog.FileName);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            profilePanel.SetDummyData((float)numericUpDown1.Value);
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBezier.Checked)
                profilePanel.FieldMode = FieldMode.Bezier;
            else if (radioButtonSpline.Checked)
                profilePanel.FieldMode = FieldMode.PSpline;
            else
                profilePanel.FieldMode = FieldMode.Polygon;
        }

        private void UdpThread()
        {
            UdpClient udpClient = new UdpClient(10001);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10001);
            while (true)
            {
                byte[] data = udpClient.Receive(ref endPoint);
                string text = System.Text.ASCIIEncoding.ASCII.GetString(data);
                Invoke(new StringDelegate(SetData), new object[] { text });
            }
        }

        delegate void StringDelegate(string txt);

        private void SetData(string data)
        {
            ParseData(data);
        }
    }
}
