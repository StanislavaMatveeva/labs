using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demographic
{
    public static class Probability
    {
        private static readonly Random _random = new Random();
        private static readonly Random _randomDeath = new Random();
        private static readonly Random _randomBirth = new Random();
        private static readonly Random _randomGender = new Random();

        /// <summary>
        /// Checks if event was happened or not.
        /// </summary>
        /// <param name="eventProbability">Probability of event.</param>
        /// <returns>True, if event was happend and false, if not.</returns>
        public static bool IsEventHappenedDeath(double eventProbability) 
        {  
            return _randomDeath.NextDouble() <= eventProbability;
        }

        public static bool IsEventHappened(double eventProbability)
        { return _random.NextDouble() <= eventProbability; }

        public static bool IsEventHappenedBirth(double eventProbability)
        {
            return _randomBirth.NextDouble() <= eventProbability;
        }

        public static bool WasBoyBorn(double eventProbability)
        { return _randomGender.NextDouble() <= eventProbability; }
    }
}
