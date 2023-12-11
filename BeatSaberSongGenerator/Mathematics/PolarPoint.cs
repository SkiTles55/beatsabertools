using System.Runtime.Serialization;

namespace BeatSaberSongGenerator.Mathematics
{
    [DataContract]
    public class PolarPoint
    {
        public PolarPoint()
        { }

        public PolarPoint(double angle, double distanceFromCenter)
        {
            Angle = angle;
            DistanceFromCenter = distanceFromCenter;
        }

        [DataMember]
        public double Angle { get; set; }

        [DataMember]
        public double DistanceFromCenter { get; set; }
    }
}