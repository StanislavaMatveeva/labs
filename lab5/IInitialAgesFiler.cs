using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public interface IInitialAgesFiler : IFileWorker
    {
        /// <summary>
        /// Gets ages from file with start ages.
        /// </summary>
        /// <param name="data">Array, that contains start ages.</param>
        /// <returns></returns>
        int[] GetAgesFromInitialAgeFile(string[] data);

        /// <summary>
        /// Gets amount of people of each age.
        /// </summary>
        /// <param name="data">Array, that contains amount of people of each age.</param>
        /// <returns></returns>
        double[] GetAmount(string[] data);
    }
}
