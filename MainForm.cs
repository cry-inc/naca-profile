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
        }
    }
}
