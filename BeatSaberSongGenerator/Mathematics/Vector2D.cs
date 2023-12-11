namespace BeatSaberSongGenerator.Mathematics
{
    public class Vector2D : Vector
    {
        public Vector2D() : base(2)
        {
        }

        public Vector2D(params double[] data) : base(2, data)
        {
        }

        public double X
        {
            get { return Data[0]; }
            set { Data[0] = value; }
        }

        public double Y
        {
            get { return Data[1]; }
            set { Data[1] = value; }
        }

        public static implicit operator Point2D(Vector2D v)
        {
            return new Point2D(v.X, v.Y);
        }
    }
}