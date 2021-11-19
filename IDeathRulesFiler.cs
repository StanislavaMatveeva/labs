using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public interface IDeathRulesFiler : IFileWorker
    {
        /// <summary>
        /// Gets ages of people of different genders.
        /// </summary>
        /// <param name="data">Array, that contains data from file
        /// with death probabilities of death for each age and gender.</param>
        /// <returns>Array, that contains ages of people of different genders.</returns>
        int[][] GetAgesFromDeathRulesFile(string[] data);

        /// <summary>
        /// Gets probabilities of death for men.
        /// </summary>
        /// <param name="data">Array, that contains data from file
        /// with death probabilities of each age and gender.</param>
        /// <returns>Array, that contains probabilities of death for men of all ages.</returns>
        double[] GetDeathProbabilityForMen(string[] data);

        /// <summary>
        /// Gets probabilities of death for women.
        /// </summary>
        /// <param name="data">Array, that contains data from file
        /// with death probabilities of each age and gender.</param>
        /// <returns>Array, that contains probabilities of death for women of all ages.</returns>
        double[] GetDeathProbabilityForWomen(string[] data);

    }
}
