namespace BeatSaberSongGenerator.Extensions
{
    public static class MathExtensions
    {
        public static bool IsEven(this int i)
        {
            return i % 2 == 0;
        }

        public static bool IsOdd(this int i)
        {
            return !i.IsEven();
        }

        public static bool IsNegativeInfinity(this double value)
        {
            return double.IsNegativeInfinity(value);
        }

        public static bool IsPositiveInfinity(this double value)
        {
            return double.IsPositiveInfinity(value);
        }
    }
}