using System;
using System.Collections.Generic;

namespace MasterLinq
{
    public static class RandomStream
    {
        public static IEnumerable<double> Generate()
        {
            var random = new Random();
            while (true)
            {
                yield return random.NextDouble();
            }
        }
    }
}