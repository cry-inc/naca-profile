using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace naca_profile
{
    /*
     * http://www.ppart.de/aerodynamics/profiles/NACA4.html
     * NACA4415
     * points: 100
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
    }
}
