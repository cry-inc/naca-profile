using System;
using System.Drawing;

namespace NacaProfile
{
    class VectorF
    {
        private float x;
        private float y;

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public VectorF(PointF point)
        {
            x = point.X;
            y = point.Y;
        }

        public VectorF(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public VectorF Norm()
        {
            float length = (float)Math.Sqrt(x*x + y*y);
            return new VectorF(x / length, y / length);
        }

        public PointF ToPoint()
        {
            return new PointF(x, y);
        }

        public static VectorF operator +(VectorF v1, VectorF v2)
        {
            return new VectorF(v1.X + v2.X, v1.Y + v2.Y);
        }

        public static VectorF operator *(VectorF v, float s)
        {
            return new VectorF(v.X * s, v.Y * s);
        }

        public static PointF operator +(PointF p, VectorF v)
        {
            return new PointF(p.X + v.X, p.Y + v.Y);
        }

        public static VectorF CalculateNormalVector(PointF p1, PointF p2)
        {
            float dx = p1.X - p2.X;
            float dy = p1.Y - p2.Y;
            return new VectorF(dy, -dx);
        }
    }
}
