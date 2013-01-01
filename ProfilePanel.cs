﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NacaProfile
{
    class Segment
    {
        public int FirstIndex;
        public int LastIndex;
        public bool Negative;

        public Segment(int firstIndex, int lastIndex, bool negative)
        {
            FirstIndex = firstIndex;
            LastIndex = lastIndex;
            Negative = negative;
        }
    }

    class ProfilePanel : Panel
    {
        private Profile profile;
        private RectangleF rect = new RectangleF(-0.25f, -0.75f, 1.5f, 1.5f);
        private float[] data = new float[0];
        private bool showFields = false;
        private bool showProbes = false;
        private bool showValues = false;
        private bool showNormals = false;
        private bool showCentroid = false;
        private bool antiAlias = false;

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public float[] Data
        {
            get { return data; }
            set { data = value; }
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

        public bool ShowCentroid
        {
            get { return showCentroid; }
            set { showCentroid = value; Invalidate(); }
        }

        public bool AntiAliasing
        {
            get { return antiAlias; }
            set { antiAlias = value; Invalidate(); }
        }

        public ProfilePanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void SetDummyData(float sinusIntervall)
        {
            data = new float[profile.Probes.Count];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (float)Math.Sin(i * sinusIntervall);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (antiAlias)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            else
                e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

            e.Graphics.FillRectangle(Brushes.White, 0, 0, Width, Height);

            if (profile != null)
            {
                DrawProfile(e.Graphics, profile);
            }
        }

        private void DrawDot(Graphics g, Color c, PointF pos, int radius = 3)
        {
            g.FillEllipse(new SolidBrush(c), new RectangleF(pos.X - radius, pos.Y - radius, radius * 2, radius * 2));
        }

        private void DrawArrow(Graphics g, Color c, PointF p1, PointF p2, int thinkness = 1)
        {
            Pen pen = new Pen(c, thinkness);
            pen.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(pen, p1, p2);
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
            // Draw profile polygon
            PointF[] points = new PointF[profile.Points.Count];
            for (int i = 0; i < profile.Points.Count; i++)
            {
                points[i] = ToScreenCoords(profile.Points[i]);
            }
            g.FillPolygon(Brushes.Green, points);
            g.DrawPolygon(Pens.Black, points);


            PointF[] probes = new PointF[profile.Probes.Count];
            VectorF[] normals = new VectorF[profile.Probes.Count];
            PointF[] valuePoints = new PointF[profile.Probes.Count];
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                // Probe position
                int index = profile.Probes[i].Index;
                if (showProbes) DrawDot(g, Color.Red, points[index], 3);

                // Normal vector at probe position
                normals[i] = profile.Probes[i].NormalVector.Norm() * 0.15f;
                PointF normalPoint = profile.Points[index] + normals[i];
                normalPoint = ToScreenCoords(normalPoint);

                // Draw normal vector
                if (showNormals) DrawArrow(g, Color.Red, points[index], normalPoint);

                // Draw value Points
                if (data.Length > i)
                {
                    float value = data[i];
                    if (value < 0) value *= -1;
                    PointF valuePoint = profile.Points[index] + normals[i] * value;
                    valuePoints[i] = ToScreenCoords(valuePoint);
                    if (showValues) DrawDot(g, Color.Blue, valuePoints[i], 2);
                }
            }

            // Create polygon for fields
            if (showFields && data != null && data.Length == profile.Probes.Count)
            {
                List<Segment> segments = new List<Segment>();
               
                int i = 0;
                int first = i;
                int last = i;
                bool negative = data[i] < 0;
                i++;

                while (i<data.Length)
                {
                    if (negative != data[i] < 0)
                    {
                        segments.Add(new Segment(first, last, negative));
                        first = last = i;
                        negative = data[i] < 0;
                    }
                    else
                    {
                        last = i;
                    }
                    i++;
                }
                segments.Add(new Segment(first, last, negative));

                for (int j = 0; j < segments.Count; j++)
                {
                    List<PointF> segmentPoints = new List<PointF>();
                    segmentPoints.Add(InterpolateFieldBorder(segments, j));
                    for (int k = segments[j].FirstIndex; k <= segments[j].LastIndex; k++)
                    {
                        segmentPoints.Add(valuePoints[k]);
                    }
                    segmentPoints.Add(InterpolateFieldBorder(segments, j+1));

                    if (segments[j].Negative)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(125, Color.LightPink)), segmentPoints.ToArray());
                    else
                        g.FillPolygon(new SolidBrush(Color.FromArgb(125, Color.LightBlue)), segmentPoints.ToArray());
                }
            }

            // Draw centroid
            if (showCentroid) DrawDot(g, Color.Black, ToScreenCoords(profile.Centroid), 3);
        }

        private PointF InterpolateFieldBorder(List<Segment> segments, int segment)
        {
            if (segment == 0 || segment == segments.Count)
                return ToScreenCoords(profile.Points[0]);
            else
            {
                int before = segments[segment - 1].LastIndex;
                int after = segments[segment].FirstIndex;

                int i1 = profile.Probes[before].Index;
                int i2 = profile.Probes[after].Index;
                
                float sum = Math.Abs(data[before]) + Math.Abs(data[after]);
                float ratio = Math.Abs(data[before]) / sum;

                return ToScreenCoords(InterpolateWithRatio(i1, i2, ratio));
            }
        }

        private PointF InterpolateWithRatio(int i1, int i2, float ratio)
        {
            PointF p1 = profile.Points[i1];
            PointF p2 = profile.Points[i2];

            float sum = 0;
            for (int i = i1; i < i2; i++) {
                sum += VectorF.Vector(profile.Points[i], profile.Points[i+1]).Length();
            }
            float pos = sum * ratio;

            int j = i1;
            sum = 0;
            while (true)
            {
                float tmp = VectorF.Vector(profile.Points[j], profile.Points[j + 1]).Length();
                if (sum + tmp > pos)
                    break;
                else
                    sum += tmp;
                j++;
            }

            int indexBefore = j;
            int indexAfter = j+1;
            float rest = pos - sum;
            VectorF vector = VectorF.Vector(profile.Points[indexBefore], profile.Points[indexAfter + 1]);
            float length = vector.Length();
            float vectorRatio = rest / length;
            return profile.Points[indexBefore] + vector * vectorRatio;
        }
    }
}
