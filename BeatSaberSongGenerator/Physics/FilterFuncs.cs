﻿using BeatSaberSongGenerator.Extensions;
using BeatSaberSongGenerator.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeatSaberSongGenerator.Physics
{
    public static class FilterFuncs
    {
        public static IEnumerable<double> MovingAverage(this IList<double> data, int windowSize)
        {
            if (windowSize.IsEven())
                throw new ArgumentException("Window size must be odd");
            if (data.Count == 0)
                yield break;

            var buffer = new CircularBuffer<double>(windowSize);
            var halfWindowSize = (windowSize - 1) / 2;
            var paddedData = Enumerable.Repeat(data.First(), halfWindowSize)
                .Concat(data)
                .Concat(Enumerable.Repeat(data.Last(), halfWindowSize))
                .ToList();
            paddedData.Take(windowSize - 1).ForEach(x => buffer.Put(x));
            for (int dataIdx = 0; dataIdx < data.Count; dataIdx++)
            {
                buffer.Put(paddedData[windowSize - 1 + dataIdx]);
                yield return buffer.Average();
            }
        }

        public static IEnumerable<Point2D> MovingAverage(this IList<Point2D> data, double windowSize)
        {
            if (data.Count == 0)
                yield break;

            var orderedData = data.OrderBy(p => p.X).ToList();
            var slidingWindow = new SlidingWindow<Point2D>(orderedData, p => p.X, windowSize, WindowPositioningType.CenteredAtPosition);
            foreach (var point in orderedData)
            {
                slidingWindow.SetPosition(point.X);
                yield return new Point2D(point.X, slidingWindow.Average(p => p.Y));
            }
        }

        public static IEnumerable<double> MedianFilter(this IList<double> data, int windowSize)
        {
            if (windowSize.IsEven())
                throw new ArgumentException("Window size must be odd");
            if (data.Count == 0)
                yield break;

            var buffer = new CircularBuffer<double>(windowSize);
            var halfWindowSize = (windowSize - 1) / 2;
            var paddedData = Enumerable.Repeat(data.First(), halfWindowSize)
                .Concat(data)
                .Concat(Enumerable.Repeat(data.Last(), halfWindowSize))
                .ToList();
            paddedData.Take(windowSize - 1).ForEach(x => buffer.Put(x));
            for (int dataIdx = 0; dataIdx < data.Count; dataIdx++)
            {
                buffer.Put(paddedData[windowSize - 1 + dataIdx]);
                yield return buffer.Median();
            }
        }

        public static IEnumerable<Point2D> MedianFilter(this IList<Point2D> data, double windowSize)
        {
            if (data.Count == 0)
                yield break;

            var orderedData = data.OrderBy(p => p.X).ToList();
            var slidingWindow = new SlidingWindow<Point2D>(orderedData, p => p.X, windowSize, WindowPositioningType.CenteredAtPosition);
            foreach (var point in orderedData)
            {
                slidingWindow.SetPosition(point.X);
                var medianY = slidingWindow.Median(p => p.Y);
                yield return new Point2D(point.X, medianY);
            }
        }
    }
}