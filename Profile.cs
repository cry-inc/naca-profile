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
        private VectorF normalVector;

        public int Index
        { get { return index; } }

        public VectorF NormalVector
        { get { return normalVector; } }

        public Probe(int index, VectorF normalVector)
        {
            this.index = index;
            this.normalVector = normalVector;
        }
    }

    class Profile
    {
        private List<PointF> points;
        private List<Probe> probes;
        private IFormatProvider format = CultureInfo.GetCultureInfo("en-US").NumberFormat;
        private float maxX, maxY, minX, minY;
        private PointF centroid;
        private float area;

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

        public PointF Centroid
        { get { return centroid; } }

        public float Area
        { get { return area; } }

        public Profile(string profileFile, string probeFile)
        {
            points = ReadPointsFromFile(profileFile);
            probes = ReadProbesFromFile(probeFile);
            FindMinMax();
            CalculateAreaAndCentroid();
        }

        public void CalculateAreaAndCentroid()
        {
            if (points.Count < 1)
                throw new InvalidOperationException("Found no points!");

            float sumX = 0, sumY = 0, a = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                float tmp = points[i].X * points[i + 1].Y - points[i + 1].X * points[i].Y;
                sumX += (points[i].X + points[i + 1].X) * tmp;
                sumY += (points[i].Y + points[i + 1].Y) * tmp;
                a += tmp;
            }

            area *= 0.5f;
            float factor = 1 / (6 * a);
            centroid = new PointF(sumX * factor, sumY * factor);
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
                int index;
                if (!Int32.TryParse(line, out index)) continue;
                if (index < 0 || index >= points.Count) continue;
                VectorF normalVector = EstimateNormalVector(index).Norm();
                probes.Add(new Probe(index, normalVector));
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

        private PointF GetRelativePoint(int index, int offset)
        {
            int pos = index + offset;
            while (pos >= points.Count) pos -= points.Count;
            while (pos < 0) pos += points.Count;
            return points[pos];
        }

        private VectorF EstimateNormalVector(int index)
        {
            if (index < 0 || index >= points.Count)
                throw new IndexOutOfRangeException();

            PointF p1 = GetRelativePoint(index, +1);
            PointF p2 = GetRelativePoint(index, -1);
            return VectorF.CalculateNormalVector(p1, p2);
        }

        public PointF InterpolateBetweenPoints(int indexBefore, int indexAfter, float ratio)
        {
            if (indexAfter != indexBefore + 1)
                throw new ArgumentException("The two points must be adjacent!");

            VectorF vector = VectorF.Vector(points[indexBefore], points[indexAfter]);
            float length = vector.Length();
            return points[indexBefore] + vector * ratio;
        }

        public PointF InterpolateNewPoint(int index1, int index2, float ratio)
        {
            if (index2 <= index1)
                throw new ArgumentException("index2 must be greater than index1!");

            PointF p1 = points[index1];
            PointF p2 = points[index2];

            float sum = 0;
            for (int i = index1; i < index2; i++)
                sum += VectorF.Vector(points[i], points[i + 1]).Length();
            float pos = sum * ratio;

            int j = index1;
            sum = 0;
            while (true)
            {
                float tmp = VectorF.Vector(points[j], points[j + 1]).Length();
                if (sum + tmp > pos) break;
                else sum += tmp;
                j++;
            }

            int indexBefore = j;
            int indexAfter = j + 1;
            float rest = pos - sum;
            float length = VectorF.Vector(points[indexBefore], points[indexAfter]).Length();
            return InterpolateBetweenPoints(indexBefore, indexAfter, rest / length);
        }


    }
}
