using System;

namespace BingoGame.Core.Utils
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random Rnd = new Random();
        private const int MIN = 1;
        private const int MAX = 52;

        /// <summary>
        /// Generate random number between 1 to 52.
        /// </summary>
        /// <returns>Random number</returns>
        public int Generate()
        {
            return Rnd.Next(MIN, MAX);
        }

        /// <summary>
        /// Generate random number between MIN to MAX
        /// </summary>
        /// <param name="min">Min value of random number</param>
        /// <param name="max">Max value of random number</param>
        /// <returns>Random number</returns>
        public int Generate(int min, int max)
        {
            return Rnd.Next(min, max);
        }
    }
}
