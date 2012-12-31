using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace naca_profile
{
    class Profile
    {
        private List<PointF> points;

        public List<PointF> Points
        {
            get { return points; }
        }

        public Profile(string file)
        {
            points = ReadPointsFromFile(file);
        }

        private List<PointF> ReadPointsFromFile(string file)
        {
            string[] lines = File.ReadAllLines(file);
            List<PointF> points = new List<PointF>();
            foreach (string line in lines)
            {
                string[] splitted = line.Split(' ');
                if (splitted.Length != 2) continue;
                double x, y;
                if (!Double.TryParse(splitted[0], out x)) continue;
                if (!Double.TryParse(splitted[1], out y)) continue;
                points.Add(new PointF((float)x, (float)y));
            }
            return points;
        }
    }
}
