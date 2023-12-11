using System.Linq;

namespace BeatSaberSongGenerator.Extensions
{
    public static class EnumExtensions
    {
        public static bool InSet<T>(this T value, params T[] set)
        {
            return set.Contains(value);
        }
    }
}