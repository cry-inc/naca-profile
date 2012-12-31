using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NacaProfile
{
    class ProfilePanel : Panel
    {
        private Profile profile;
        private RectangleF rect = new RectangleF(-0.25f, -0.75f, 1.5f, 1.5f);

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public ProfilePanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.White, 0, 0, Width, Height);
            if (profile != null)
            {
                DrawProfile(e.Graphics, profile);
            }
        }

        private PointF ToScreenCoords(PointF p)
        {
            float xd = Width / rect.Width;
            float yd = Height / rect.Height;
            float ox = (0 - rect.X) * xd;
            float oy = (0 - rect.Y) * yd;
            return new PointF(p.X * xd + ox, -p.Y * yd + oy);
        }

        private void DrawProfile(Graphics g, Profile profile)
        {
            PointF[] points = new PointF[profile.Points.Count];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = ToScreenCoords(profile.Points[i]);
            }
            g.FillPolygon(Brushes.Green, points);
            g.DrawPolygon(Pens.Black, points);

            PointF[] probeNormalPoints = new PointF[profile.Probes.Count];
            for (int i = 0; i < probeNormalPoints.Length; i++)
            {
                probeNormalPoints[i] = ToScreenCoords(profile.Probes[i].NormalPoint);
                int index = profile.Probes[i].Index;
                g.FillEllipse(Brushes.Red, new RectangleF(points[index].X - 3, points[index].Y - 3, 6, 6));
                Pen pen = new Pen(Color.Red);
                pen.EndCap = LineCap.ArrowAnchor;
                g.DrawLine(pen, points[index], probeNormalPoints[i]);
            }
        }
    }
}
