using System;

namespace BeatSaberSongGenerator
{
    public static class StaticRandom
    {
        public static Random Rng { get; } = new Random();
    }
}