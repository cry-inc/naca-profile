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
        private bool showFields = false;
        private bool showProbes = false;
        private bool showValues = false;
        private bool showNormals = false;

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public bool ShowField
        {
            get { return showFields; }
            set { showFields = value; Invalidate(); }
        }

        public bool ShowProbes
        {
            get { return showProbes; }
            set { showProbes = value; Invalidate(); }
        }

        public bool ShowValues
        {
            get { return showValues; }
            set { showValues = value; Invalidate(); }
        }

        public bool ShowNormals
        {
            get { return showNormals; }
            set { showNormals = value; Invalidate(); }
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

        private void DrawDot(Graphics g, Color c, PointF pos, int radius)
        {
            g.FillEllipse(new SolidBrush(c), new RectangleF(pos.X - radius, pos.Y - radius, radius * 2, radius * 2));
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
            PointF[] values = new PointF[profile.Points.Count];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = ToScreenCoords(profile.Points[i]);

                PointF normalVector = profile.EstimateNormalVector(i);
                float length = (float)Math.Sqrt(normalVector.X * normalVector.X + normalVector.Y * normalVector.Y) * 5;
                normalVector.X /= length;
                normalVector.Y /= length;
                PointF normalPoint = new PointF(profile.Points[i].X + normalVector.X, profile.Points[i].Y + normalVector.Y);
                normalPoint = ToScreenCoords(normalPoint);
                Pen pen = new Pen(Color.Red);
                pen.EndCap = LineCap.ArrowAnchor;
                if (showNormals) g.DrawLine(pen, points[i], normalPoint);

                float value = (float)Math.Sin(i/5.0f);
                if (value < 0) value *= -1;
                PointF p = new PointF(profile.Points[i].X + normalVector.X * value, profile.Points[i].Y + normalVector.Y * value);
                values[i] = ToScreenCoords(p);
                if (showValues) DrawDot(g, Color.Blue, values[i], 2);

            }

            if (showFields) g.FillPolygon(new SolidBrush(Color.FromArgb(125, Color.LightBlue)), values);
            g.FillPolygon(Brushes.Green, points);
            g.DrawPolygon(Pens.Black, points);

            PointF[] probeNormalPoints = new PointF[profile.Probes.Count];
            for (int i = 0; i < probeNormalPoints.Length; i++)
            {
                probeNormalPoints[i] = ToScreenCoords(profile.Probes[i].NormalPoint);
                int index = profile.Probes[i].Index;
                if (showProbes) DrawDot(g, Color.Red, points[index], 3);
            }
        }
    }
}
