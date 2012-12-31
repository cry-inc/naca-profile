using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace NacaProfile
{
    class Probe
    {
        private int index;
        private PointF normalPoint;

        public int Index
        { get { return index; } }

        public PointF NormalPoint
        { get { return normalPoint; } }

        public Probe(int index, PointF normalPoint)
        {
            this.index = index;
            this.normalPoint = normalPoint;
        }
    }

    class Profile
    {
        private List<PointF> points;
        private List<Probe> probes;
        private IFormatProvider format = CultureInfo.GetCultureInfo("en-US").NumberFormat;
        private float maxX, maxY, minX, minY;

        public List<PointF> Points
        { get { return points; } }

        public List<Probe> Probes
        { get { return probes; } }

        public float MaximumX
        { get { return maxX; } }

        public float MaximumY
        { get { return maxY; } }

        public float MinimumX
        { get { return minX; } }

        public float MinimumY
        { get { return minY; } }

        public Profile(string profileFile, string probeFile)
        {
            points = ReadPointsFromFile(profileFile);
            probes = ReadProbesFromFile(probeFile);
            FindMinMax();
        }

        private List<PointF> ReadPointsFromFile(string file)
        {
            List<PointF> points = new List<PointF>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (line.StartsWith("#")) continue;
                string[] splitted = line.Split(' ');
                if (splitted.Length != 2) continue;
                double x, y;
                if (!Double.TryParse(splitted[0], NumberStyles.Any, format, out x)) continue;
                if (!Double.TryParse(splitted[1], NumberStyles.Any, format, out y)) continue;
                points.Add(new PointF((float)x, (float)y));
            }
            return points;
        }

        private List<Probe> ReadProbesFromFile(string file)
        {
            List<Probe> probes = new List<Probe>();
            string[] lines = File.ReadAllLines(file);
            foreach (string line in lines)
            {
                if (line.StartsWith("#")) continue;
                string[] splitted = line.Split(' ');
                if (splitted.Length != 3) continue;
                int index;
                double x, y;
                if (!Int32.TryParse(splitted[0], out index)) continue;
                if (index < 0 || index >= points.Count) continue;
                if (!Double.TryParse(splitted[1], NumberStyles.Any, format, out x)) continue;
                if (!Double.TryParse(splitted[2], NumberStyles.Any, format, out y)) continue;
                probes.Add(new Probe(index, new PointF((float)x, (float)y)));
            }
            return probes;
        }

        private void FindMinMax()
        {
            if (points.Count < 1)
                throw new InvalidOperationException("Found no points!");

            minX = maxX = points[0].X;
            minY = maxY = points[0].Y;

            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X > maxX) maxX = points[i].X;
                if (points[i].Y > maxY) maxY = points[i].Y;
                if (points[i].X < minX) minX = points[i].X;
                if (points[i].Y < minY) minY = points[i].Y;
            }
        }

        public PointF GetRelativePoint(int index, int offset)
        {
            int pos = index + offset;
            while (pos >= points.Count) pos -= points.Count;
            while (pos < 0) pos += points.Count;
            return points[pos];
        }

        public PointF EstimateNormalVector(int index)
        {
            if (index < 0 || index >= points.Count)
                throw new IndexOutOfRangeException();

            PointF pb = GetRelativePoint(index, -1);
            PointF pa = GetRelativePoint(index, +1);

            float dx= pa.X - pb.X;
            float dy = pa.Y - pb.Y;

            return new PointF(dy, -dx);
        }
    }
}
