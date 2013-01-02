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
     * TODO:
     * - Anzeige Max/Min-Werte
     * - Zoom/Resize
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
        private Point mouseDownPos;
        private bool mouseDown = false;

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

            MouseWheel += new MouseEventHandler(ZoomHandler);
        }

        private void checkBoxFields_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowFields = checkBoxFields.Checked;
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
                try
                {
                    Invoke(new StringDelegate(SetData), new object[] { text });
                }
                catch { }
            }
        }

        delegate void StringDelegate(string txt);

        private void SetData(string data)
        {
            ParseResult result = ParseData(data);
            if (result == ParseResult.Success)
                panelStatus.BackColor = Color.Green;
            else
                panelStatus.BackColor = Color.Red;
            timerStatus.Enabled = true;
        }

        private void trackBarNormals_ValueChanged(object sender, EventArgs e)
        {
            profilePanel.NormalFactor = trackBarNormals.Value / 1000f;
        }

        private void trackBarValues_ValueChanged(object sender, EventArgs e)
        {
            profilePanel.ValueFactor = trackBarValues.Value / 100f;
        }

        private void checkBoxValuesText_CheckedChanged(object sender, EventArgs e)
        {
            profilePanel.ShowValuesText = checkBoxValuesText.Checked;
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            timerStatus.Enabled = false;
            panelStatus.BackColor = DefaultBackColor;
        }

        private void ZoomHandler(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            float centerX = profilePanel.Rectangle.Width * 0.5f + profilePanel.Rectangle.X;
            float centerY = profilePanel.Rectangle.Height * 0.5f + profilePanel.Rectangle.Y;
            float factor = (e.Delta < 0) ? 1.1f : 0.9f;
            float newWidth = profilePanel.Rectangle.Width * factor;
            float newHeight = profilePanel.Rectangle.Height * factor;
            float newX = centerX - newWidth * 0.5f;
            float newY = centerY - newHeight * 0.5f;
            profilePanel.Rectangle = new RectangleF(newX, newY, newWidth, newHeight);
        }

        private void profilePanel_MouseDown(object sender, MouseEventArgs e)
        {
            profilePanel.Focus();
            mouseDownPos = e.Location;
            mouseDown = true;
        }

        private void profilePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && e.Location != mouseDownPos)
            {
                float factorX = profilePanel.Rectangle.Width / profilePanel.Width;
                float factorY = profilePanel.Rectangle.Height / profilePanel.Height;
                float xd = (e.Location.X - mouseDownPos.X) * factorX;
                float yd = (e.Location.Y - mouseDownPos.Y) * factorY;
                PointF location = new PointF(
                    profilePanel.Rectangle.X - xd,
                    profilePanel.Rectangle.Y - yd
                );
                RectangleF rectangle = new RectangleF(
                    location.X, location.Y,
                    profilePanel.Rectangle.Width, profilePanel.Rectangle.Height
                );
                profilePanel.Rectangle = rectangle;
                mouseDownPos = e.Location;
            }
        }

        private void profilePanel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void MainForm_MouseLeave(object sender, EventArgs e)
        {
            mouseDown = false;
        }
    }
}
