using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void buttonValues_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Noch nicht verfügbar!");
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
    }
}
