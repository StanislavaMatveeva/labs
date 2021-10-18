using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LinearAlgebra;
using System.Globalization;
using System.Management;

namespace IrisGraphics
{
    public class IrisClass
    {
        public MathVector[] values;


        /// <summary>
        /// Contains the enumeration of different values, that are used for working with IrisClass.
        /// </summary>
        public enum Numbers
        {
            SETOSA = 1,
            VERSICOLOR = 2,
            VIRGINICA = 3,
            SEPAL_LENGTH = 4,
            SEPAL_WIDTH = 5,
            PETAL_LENGTH = 6,
            PETAL_WIDTH = 6,
            IRIS_SIZE = 50,
            IRIS_ARRAY_SIZE = 3,
            METRICS_AMOUNT = 4
        }

        /// <summary>
        /// Creates an object of IrisClass.
        /// </summary>
        public IrisClass()
        {
            values = new MathVector[(int)Numbers.METRICS_AMOUNT];
            for (int i = 0; i < values.Length; i++)
                values[i] = new MathVector((int)Numbers.IRIS_SIZE);
        }

        /// <summary>
        /// Gets an amount of metrics in iris.
        /// </summary>
        public int Length { get { return values.Length; } }

        /// <summary>
        /// Overloads the operator[].
        /// </summary>
        /// <param name="i">Index of the current metric.</param>
        /// <returns>A MathVector, that contains values of the current iris's metric.</returns>
        public MathVector this[int i] { get { return values[i]; } }

        /// <summary>
        /// Checks if file consists necessary headers or not.
        /// </summary>
        /// <param name="file">Array of string, that contains file's data.</param>
        /// <returns>True if file contains necessary headers and false if doesn't.</returns>
        public void IsValidData(string[] file)
        {
            string check;
            try { check = file[0]; }
            catch { throw new Exception("This file is empty"); }
            if (!check.Contains("sepal_length,sepal_width,petal_length,petal_width,species"))
                throw new Exception("This file doesn't contains necessary headers");
        }

        /// <summary>
        /// (Available only for Windows OS) Checks if file is valid or not.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when file's extension is not ".txt"
        /// or it's volume or bigger than available RAM and virtual memory of the computer.</exception>
        /// <param name="fileName">Name of file.</param>
        public void CheckFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var createFile = new string[] { "New", "File" };
                File.WriteAllLines(fileName, createFile);
            }
            else if (new FileInfo(fileName).Extension != ".txt")
                throw new Exception("Wrong format of file");
            else
            {
                int memory = 0;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject result in results)
                {
                    var obj = result["FreePhysicalMemory"];
                    memory += Convert.ToInt32(obj);
                    obj = result["FreeVirtualMemory"];
                    memory += Convert.ToInt32(obj);
                }
                if (new FileInfo(fileName).Length > memory)
                    throw new Exception("This file is too big");
            }
        }

        /// <summary>
        /// Creates an iris: fills it with data for the current iris.
        /// </summary>
        /// <param name="iris">The current iris.</param>
        /// <param name="array">Array of string, that contains file's data.</param>
        /// <param name="irisNumber">A number of the current iris.</param>
        /// <returns>An array of MathVector, that contains the current iris's values.</returns>
        public MathVector[] CreateIris(IrisClass iris, string[] array, int irisNumber)
        {
            if (iris.Length == 0)
                throw new Exception("This iris is empty");
            else if (irisNumber < 0)
                throw new Exception("The number of vector can't be negative");
            else
            {
                int k;
                for (int i = irisNumber * 50 + 1; i < (irisNumber + 1) * 50; i++)
                {
                    k = 0;
                    var currentString = array[i].Split(',');
                    for (int j = 0; j < (int)Numbers.METRICS_AMOUNT; j++)
                    {
                        var s = currentString[j];
                        try { iris[j][k * 4] = double.Parse(s, new NumberFormatInfo { NumberDecimalSeparator = "." }); }
                        catch { throw new Exception("Wrong value of data"); }
                        k++;
                    }
                }
            }
            return iris.values;
        }

        /// <summary>
        /// Gets an average value of one iris's metric.
        /// </summary>
        /// <param name="vector">A MathVector, that contains values of one iris's metric.</param>
        /// <returns>An anerage score of one iris's metric.</returns>
        public double GetAvgValue(MathVector vector)
        {
            if (vector.Dimensions == 0)
                throw new Exception("This vector is empty");
            else
            {
                double avgValue = 0;
                for (int i = 0; i < vector.Dimensions; i++)
                    avgValue += vector[i];
                return avgValue /= vector.Dimensions;
            }
        }

        /// <summary>
        /// Creates a MathVector, that contains average values of all iris's metrics.
        /// </summary>
        /// <param name="iris">An array of irisis.</param>
        /// <returns>A MathVector, that contains average values of all iris's metrics.</returns>
        public MathVector CreateAvgVector(MathVector[] iris)
        {
            if (iris.Length == 0)
                throw new Exception("This array is Empty");
            else
            {
                var avgVector = new MathVector((int)Numbers.METRICS_AMOUNT);
                for (int i = 0; i < avgVector.Dimensions; i++)
                    avgVector[i] = GetAvgValue(iris[i]);
                return avgVector;
            }
        }

        /// <summary>
        /// Creates an array of MathVectors, that contains average vectors of all irisis.
        /// </summary>
        /// <param name="iris">An array of irisis.</param>
        /// <returns>An array of MathVectors, that contains average vectors of all irisis.</returns>
        public MathVector[] CreateAvgIris(IrisClass[] iris)
        {
            if (iris.Length == 0)
                throw new Exception("This iris is empty");
            else
            {
                var avgIris = new MathVector[(int)Numbers.IRIS_ARRAY_SIZE];
                for (int i = 0; i < avgIris.Length; i++)
                    avgIris[i] = CreateAvgVector(iris[i].values);
                return avgIris;
            }
        }

        /// <summary>
        /// Creates an array of irisis and fills it with file's data.
        /// </summary>
        /// <param name="fileName">File's name.</param>
        /// <returns>An array of irisis, filled with file's data.</returns>
        public IrisClass[] CreateData(string fileName)
        {
            var array = File.ReadAllLines(fileName);
            var irisArray = new IrisClass[(int)Numbers.IRIS_ARRAY_SIZE];
            for (int i = 0; i < irisArray.Length; i++)
            {
                irisArray[i] = new IrisClass();
                irisArray[i].values = CreateIris(irisArray[i], array, i);
            }
            return irisArray;
        }

        /// <summary>
        /// Gets an array of distances between irisis average vectors.
        /// </summary>
        /// <param name="iris">An array of irisis.</param>
        /// <returns>An array of distances between irisis average vectors.</returns>
        public double[] GetDistancesArray(IrisClass[] iris)
        {
            var newIris = CreateAvgIris(iris);
            var values = new double[newIris.Length];
            for (int i = 0; i < newIris.Length - 1; i++)
                values[i] = newIris[i].CalcDistance(newIris[i + 1]);
            values[values.Length - 1] = newIris[0].CalcDistance(newIris[values.Length - 1]);
            return values;
        }
    }
}