using System;
using System.Drawing;

namespace NacaProfile
{
    class Bezier
    {
        public static PointF[] CreateBezierPath(PointF[] points, int segments = 50)
        {
            float stepSize = 1.0f / segments;
            PointF[] path = new PointF[segments + 1];
            float pos = 0;
            for (int i = 0; i < segments; i++)
            {
                path[i] = EvaluateBezierPointPoint(points, pos);
                pos += stepSize;
            }
            path[segments] = points[points.Length - 1];
            return path;
        }

        public static PointF EvaluateBezierPointPoint(PointF[] points, float pos)
        {
            while (points.Length > 1)
                points = ReduceBezierPointPoint(points, pos);
            return points[0];
        }

        public static PointF[] ReduceBezierPointPoint(PointF[] points, float pos)
        {
            if (points.Length == 0)
                throw new ArgumentException("No points supplied!");
            else if (points.Length == 1)
                return points;
            else
            {
                PointF[] newPoints = new PointF[points.Length - 1];
                for (int i = 0; i < points.Length - 1; i++)
                {
                    VectorF vector = VectorF.Vector(points[i], points[i + 1]);
                    newPoints[i] = points[i] + vector * pos;
                }
                return newPoints;
            }
        }
    }
}
