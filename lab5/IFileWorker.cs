using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOperations
{
    public interface IFileWorker
    {
        string FileName { get; set; }

        /// <summary>
        /// Checks if file is valid or not.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when file's extension is not ".txt"
        /// or it's volume or bigger than available RAM and virtual memory of the computer.</exception>
        void CheckFile();

        /// <summary>
        /// Deletes extra probels from string.
        /// </summary>
        /// <param name="s">String, from which probels are deleted.</param>
        /// <exception cref="Exception">Is thrown, when string is empty.</exception>
        string DeleteProbels(string s);

        /// <summary>
        /// Gets data from file.
        /// </summary>
        /// <returns>Array of String, that contains file's data.</returns>
        string[] GetDataFromFile();

        /// <summary>
        /// Checks if file consists necessary headers or not.
        /// </summary>
        /// <param name="data">Array of string, that contains file's data.</param>
        /// <returns>True if file contains necessary headers and false if doesn't.</returns>
        void CheckHeaders(string[] data);
    }
}
