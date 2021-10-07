using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using LinearAlgebra;
using System.Globalization;

namespace IrisGraphics
{
    class IrisClass
    {
        public MathVector CreateIris(int vectorNumber)
        {
            var vector = new MathVector(200);
            if (vectorNumber <= 0)
                throw new Exception("Wrong value of vectorNumber");
            else
                vector = CreateArray(vector, vectorNumber);
            return vector;
        }

        public string[] GetValues()
        {
            string fileName = @"C:\Users\Стася\source\repos\IrisGraphics\iris.txt";
            if (!File.Exists(fileName))
            { 
                string[] createFile = { "New", "file" };
                File.WriteAllLines(fileName, createFile);
            }
            return File.ReadAllLines(fileName);
        }

        public MathVector CreateArray(MathVector vector, int vectorNumber)
        {
            if (vector.Dimensions != 200)
                throw new Exception("Wrong size of vector");
            else if (vectorNumber <= 0)
                throw new Exception("The number of vector can't be negative or zero");
            else
            {
                string[] array = GetValues();
                string[] currentString = new string[5];
                int k = 0;
                for (int i = (vectorNumber - 1) * 50 + 1; i < vectorNumber * 50; i++)
                {
                    currentString = array[i].Split(',');
                    for (int j = 0; j < 4; j++)
                    {
                        string s = currentString[j];
                        try
                        {
                            vector[k * 4 + j] = double.Parse(s, new NumberFormatInfo { NumberDecimalSeparator = "." });
                        }
                        catch
                        {
                            throw new Exception("Wrong value of data");
                        }
                    }
                    k++;
                }
            }
            return vector;
        }

        public double GetAverageValue(MathVector vec, int metricNumber)
        {
            if (vec.Dimensions == 0)
                throw new Exception("This vector is empty");
            if (metricNumber <= 0)
                throw new Exception("Wrong value of metric number");
            else
            {
                double avgNumber = 0;
                metricNumber--;
                for (int i = metricNumber; i < vec.Dimensions; i += 4)
                    avgNumber += vec[i];
                return avgNumber /= vec.Dimensions / 4;
            }
        }

        public MathVector CreateAverageVector(MathVector vector)
        {
            if (vector.Dimensions == 0)
                throw new Exception("This vector is Empty");
            else
            {
                for (int i = 0; i < vector.Dimensions; i++)
                    vector[i] = GetAverageValue(vector, i + 1);
                return vector;
            }
        }

        public double CreateData(int irisNumber, int metricNumber)
        {
            if (irisNumber <= 0 || metricNumber <= 0)
                throw new Exception("Wrong value of irisNumber or metricNumber");
            else
            {
                var vector = CreateIris(irisNumber);
                return GetAverageValue(vector, metricNumber);
            }
        }
    }
}
