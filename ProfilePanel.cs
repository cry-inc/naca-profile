using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace naca_profile
{
    class ProfilePanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, 0, 0, Width, Height);
        }

        private void DrawProfile(Graphics g, Profile profile)
        {
            PointF[] points = profile.Points.ToArray();
            g.FillPolygon(Brushes.Black, points);
        }
    }
}
