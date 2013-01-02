using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace NacaProfile
{
    enum FieldMode
    {
        Polygon,
        Bezier,
        PSpline
    }

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
        private Dictionary<string, Color> colors = new Dictionary<string, Color>();
        private Profile profile;
        private RectangleF rect = new RectangleF(-0.25f, -0.75f, 1.5f, 1.5f);
        private float[] data = new float[0];
        private bool showFields = true;
        private bool showProbes = true;
        private bool showValues = true;
        private bool showValuesText = false;
        private bool showNormals = true;
        private bool showCentroid = false;
        private bool antiAlias = true;
        private FieldMode fieldMode = FieldMode.PSpline;
        private float normalFactor = 0.15f;
        private float valueFactor = 1.0f;

        public Profile Profile
        {
            get { return profile; }
            set { profile = value; }
        }

        public RectangleF Rectangle
        {
            get { return rect; }
            set { rect = value; Invalidate(); }
        }

        public float[] Data
        {
            get { return data; }
            set { data = value; Invalidate(); }
        }

        public bool ShowFields
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

        public bool ShowValuesText
        {
            get { return showValuesText; }
            set { showValuesText = value; Invalidate(); }
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

        public FieldMode FieldMode
        {
            get { return fieldMode; }
            set { fieldMode = value; Invalidate(); }
        }

        public float NormalFactor
        {
            get { return normalFactor; }
            set { normalFactor = value; Invalidate(); }
        }

        public float ValueFactor
        {
            get { return valueFactor; }
            set { valueFactor = value; Invalidate(); }
        }

        public ProfilePanel()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            colors.Add("profile_bg", Color.LightGray);
            colors.Add("profile_border", Color.Black);
            colors.Add("probes", Color.Red);
            colors.Add("normal_arrows", Color.Red);
            colors.Add("value_points_positive", Color.Blue);
            colors.Add("value_points_negative", Color.Red);
            colors.Add("value_text_positive", Color.Black);
            colors.Add("value_text_negative", Color.Black);
            colors.Add("fields_positive", Color.LightBlue);
            colors.Add("fields_negative", Color.LightPink);
            colors.Add("centroid", Color.Black);
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
                PointF[] profilePoints = CalculateProfilePoints();
                PointF[] probePoints = CalculateProbePoints(profilePoints);
                VectorF[] probeNormals = CalculateProbeNormals();
                PointF[] valuePoints = CalculateValuePoints(probePoints, probeNormals, data);

                if (showFields) DrawFields(e.Graphics, data, valuePoints);
                DrawProfile(e.Graphics, profilePoints);
                if (showProbes) DrawProbes(e.Graphics, probePoints);
                if (ShowNormals) DrawProbeNormals(e.Graphics, probePoints, probeNormals);
                if (showValues) DrawValues(e.Graphics, valuePoints, data);
                if (showCentroid) DrawDot(e.Graphics, colors["centroid"], ToScreenCoords(profile.Centroid), 3);
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

        private PointF[] CalculateProfilePoints()
        {
            PointF[] profilePoints = new PointF[profile.Points.Count];
            for (int i = 0; i < profile.Points.Count; i++)
            {
                profilePoints[i] = ToScreenCoords(profile.Points[i]);
            }
            return profilePoints;
        }

        private PointF[] CalculateProbePoints(PointF[] profilePoints)
        {
            PointF[] probePoints = new PointF[profile.Probes.Count];
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                int index = profile.Probes[i].Index;
                probePoints[i] = profilePoints[index];
            }
            return probePoints;
        }

        private VectorF[] CalculateProbeNormals()
        {
            VectorF[] normals = new VectorF[profile.Probes.Count];
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                normals[i] = profile.Probes[i].NormalVector.Norm() * normalFactor;
            }
            return normals;
        }

        private PointF[] CalculateValuePoints(PointF[] probePoints, VectorF[] normals, float[] data)
        {
            PointF[] valuePoints = new PointF[profile.Probes.Count];
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                float value = 0;
                if (data.Length > i) value = data[i] * valueFactor;
                if (value < 0) value *= -1;
                int index = profile.Probes[i].Index;
                valuePoints[i] = ToScreenCoords(profile.Points[index] + normals[i] * value);
            }
            return valuePoints;
        }

        private void DrawProfile(Graphics g, PointF[] profilePoints)
        {
            g.FillPolygon(new SolidBrush(colors["profile_bg"]), profilePoints);
            g.DrawPolygon(new Pen(colors["profile_border"]), profilePoints);
        }

        private void DrawProbes(Graphics g, PointF[] probePoints)
        {
            for (int i = 0; i < probePoints.Length; i++)
                DrawDot(g, colors["probes"], probePoints[i], 3);
        }

        private void DrawProbeNormals(Graphics g, PointF[] probePoints, VectorF[] normals)
        {
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                int index = profile.Probes[i].Index;
                PointF normalPoint = profile.Points[index] + normals[i];
                DrawArrow(g, colors["normal_arrows"], probePoints[i], ToScreenCoords(normalPoint));
            }
        }

        private void DrawValues(Graphics g, PointF[] valuePoints, float[] data)
        {
            for (int i = 0; i < profile.Probes.Count; i++)
            {
                Color pointColor = colors["value_points_positive"];
                Color textColor = colors["value_text_positive"];
                if (data[i] < 0)
                {
                    pointColor = colors["value_points_negative"];
                    textColor = colors["value_text_negative"];
                }
                DrawDot(g, pointColor, valuePoints[i], 2);
                if (showValuesText)
                {
                    PointF position = valuePoints[i];
                    position.X += 5;
                    position.Y -= 5;
                    string str = String.Format(new System.Globalization.CultureInfo("en-US"), "{0:N}", data[i]);
                    g.DrawString(str, DefaultFont, new SolidBrush(textColor), position);
                }
            }
        }

        public void DrawFields(Graphics g, float[] data, PointF[] valuePoints)
        {
            if (data != null && data.Length == profile.Probes.Count)
            {
                List<Segment> segments = CreateDataSegments();
                DrawSegments(g, valuePoints, segments);
            }
        }

        private void DrawSegments(Graphics g, PointF[] valuePoints, List<Segment> segments)
        {
            for (int j = 0; j < segments.Count; j++)
            {
                // Create segment points for polygon
                List<PointF> segmentPoints = new List<PointF>();
                segmentPoints.Add(InterpolateFieldBorder(segments, j));
                for (int k = segments[j].FirstIndex; k <= segments[j].LastIndex; k++)
                {
                    segmentPoints.Add(valuePoints[k]);
                }
                segmentPoints.Add(InterpolateFieldBorder(segments, j + 1));

                // Draw the polygon
                DrawFieldSegment(g, segments[j].Negative, segmentPoints.ToArray());
            }
        }

        private void DrawFieldSegment(Graphics g, bool negative, PointF[] segmentPoints)
        {
            Brush brush = new SolidBrush(colors["fields_positive"]);
            if (negative)
                brush = new SolidBrush(colors["fields_negative"]);

            if (fieldMode == FieldMode.Bezier)
                g.FillPolygon(brush, Bezier.CreateBezierPath(segmentPoints));
            else if (fieldMode == FieldMode.PSpline)
                g.FillPolygon(brush, Spline.CreateSplinePath(segmentPoints));
            else
                g.FillPolygon(brush, segmentPoints);
        }

        private List<Segment> CreateDataSegments()
        {
            List<Segment> segments = new List<Segment>();
            int i = 0;
            int first = i;
            int last = i;
            bool negative = data[i] < 0;
            i++;
            while (i < data.Length)
            {
                if (negative != data[i] < 0)
                {
                    segments.Add(new Segment(first, last, negative));
                    first = last = i;
                    negative = data[i] < 0;
                }
                else last = i;
                i++;
            }
            segments.Add(new Segment(first, last, negative));
            return segments;
        }

        private PointF InterpolateFieldBorder(List<Segment> segments, int segment)
        {
            if (segment == 0 || segment == segments.Count)
                return ToScreenCoords(profile.Points[0]);
            else
            {
                int before = segments[segment - 1].LastIndex;
                int after = segments[segment].FirstIndex;

                int index1 = profile.Probes[before].Index;
                int index2 = profile.Probes[after].Index;
                
                float sum = Math.Abs(data[before]) + Math.Abs(data[after]);
                float ratio = Math.Abs(data[before]) / sum;

                return ToScreenCoords(profile.InterpolateNewPoint(index1, index2, ratio));
            }
        }
    }
}
