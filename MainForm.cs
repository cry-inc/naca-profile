using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Profile profile = new Profile("profile.txt", "probes.txt");
            profilePanel.Profile = profile;
            profilePanel.SetDummyData((float)numericUpDown1.Value);
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
            text = text.Replace(",", ".");
            text = text.Replace(";", " ");
            text = text.Replace("\n", " ");
            text = text.Replace("\t", " ");
            text = text.Replace("\r", " ");
            string[] splitted = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length != profilePanel.Profile.Probes.Count)
            {
                MessageBox.Show("Anzahl der Messwerte entspricht nicht der Anzahl der Messpunkte!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            float[] data = new float[splitted.Length];
            IFormatProvider format = CultureInfo.GetCultureInfo("en-US").NumberFormat;
            for (int i = 0; i < splitted.Length; i++)
            {
                double tmp;
                if (!Double.TryParse(splitted[i], NumberStyles.Any, format, out tmp))
                {
                    MessageBox.Show("Konnte " + splitted[i] + " nicht als Zahl interpretieren!", "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                data[i] = (float)tmp;
            }

            profilePanel.Data = data;
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
    }
}
