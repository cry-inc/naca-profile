using System;
using System.Drawing;

namespace NacaProfile
{
    class Spline
    {
        public static PointF[] CreateSplinePath(PointF[] points, int segments = 50)
        {
            double[,] xy = new double[points.Length, 2];
            for (int i = 0; i < points.Length; i++)
            {
                xy[i,0] = points[i].X;
                xy[i,1] = points[i].Y;
            }

            alglib.pspline2interpolant s;
            alglib.pspline2build(xy, points.Length, 2, 2, out s);

            float stepSize = 1.0f / segments;
            PointF[] path = new PointF[segments + 1];
            float pos = 0;
            for (int i = 0; i < segments; i++)
            {
                double x, y;
                alglib.pspline2calc(s, pos, out x, out y);
                path[i] = new PointF((float)x, (float)y);
                pos += stepSize;
            }
            path[segments] = points[points.Length - 1];
            return path;
        }
    }
}
