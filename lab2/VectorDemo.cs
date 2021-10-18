using System;
using System.Collections;
using LinearAlgebra;

namespace VectorDemo
{
    class Program
    {
        /// <summary>
        /// Displays the vector's coordinats.
        /// </summary>
        /// <param name="vector"></param>
        public static void OutputCoordinats(IMathVector vector)
        {
            Console.Write("{ ");
            int i = 0;
            foreach (double a in vector)
            {
                Console.Write($"{vector[i]} ");
                if (i != vector.Dimensions - 1)
                    Console.Write($"; ");
                i++;
            }
            Console.WriteLine("}");
        }

        static void Main(string[] args)
        {
            /*IMathVector v1 = new MathVector(3);
            IMathVector res = new MathVector(3);
            OutputCoordinats(res);
            res = v1.SumNumber(5);
            OutputCoordinats(res);

            IMathVector v2 = new MathVector(10);
            v2 = v2.SumNumber(4);
            //res = v1.Sum(v2);
            //res = v1.Multiply(v2);
            //res = v1.Division(v2);

            IMathVector v3 = new MathVector(v1.Dimensions);
            //res = v1.Division(v3);

            MathVector v4 = new MathVector(v1.Dimensions);
            v4[0] = 2; v4[1] = 2; v4[2] = 2;
            MathVector v5 = new MathVector(5);
            //res = v4 + v5;
            //OutputCoordinats(res);*/

            var vecc = new MathVector(-5);


            int size = 3;
            IMathVector firstVector = new MathVector(size);
            firstVector[0] = 1.0; firstVector[1] = 2.0; firstVector[2] = 3.0;
            Console.WriteLine("coordinats of vector 1:");
            OutputCoordinats(firstVector); 

            Console.WriteLine($"length of vector 1: {firstVector.Length}"); // output length of vector

            double number = 2.0;
            IMathVector summNumberVector = new MathVector(firstVector.Dimensions);
            summNumberVector = firstVector.SumNumber(number); // summurizing vector with number
            Console.WriteLine("new vector after adding vector 1 with a number = 2:");
            OutputCoordinats(summNumberVector);
            Console.WriteLine("coordinats of vector 1:");
            OutputCoordinats(firstVector);

            number = 3.0;
            IMathVector multNumberVector = new MathVector(firstVector.Dimensions);
            multNumberVector = firstVector.MultiplyNumber(number); // multiplying vector by number
            Console.WriteLine("new vector after multiplication vector 1 by a number = 3:");
            OutputCoordinats(multNumberVector);
            Console.WriteLine("coordinats of vector 1:");
            OutputCoordinats(firstVector);

            IMathVector secondVector = new MathVector(size);
            secondVector[0] = 5.0; secondVector[1] = 6.0; secondVector[2] = 7.0;
            Console.WriteLine("coordinats of vector 2:");
            OutputCoordinats(secondVector);

            Console.WriteLine($"length of vector 2: {secondVector.Length}");

            IMathVector resultVector = new MathVector(size);
            resultVector = firstVector.Sum(secondVector); // summurizing two vectors
            Console.WriteLine("new vector after adding vector 1 with vector 2:");
            OutputCoordinats(resultVector);
            resultVector = firstVector.Multiply(secondVector); // multiplying two vectors
            Console.WriteLine("new vector after multiplication vector 1 with vector 2:");
            OutputCoordinats(resultVector);

            double scalarMult = firstVector.ScalarMultiply(secondVector); // scalar multiplying of vectors
            Console.WriteLine("scalar product of vectors:");
            Console.WriteLine(scalarMult);
            double distance = firstVector.CalcDistance(secondVector); // calculate the Euclidian number
            Console.WriteLine("the Euclidian number:");
            Console.WriteLine(distance);

            MathVector v1 = new MathVector(size);
            v1[0] = 1.0; v1[1] = 2.0; v1[2] = 3.0;
            Console.WriteLine("new vector 1:");
            OutputCoordinats(v1);

            MathVector v2 = new MathVector(size);
            v2[0] = 5.0; v2[1] = 6.0; v2[2] = 7.0;
            Console.WriteLine("new vector 2:");
            OutputCoordinats(v2);

            resultVector = v1 + v2;
            Console.WriteLine("result after operator+ :");
            OutputCoordinats(resultVector);
            
            resultVector = v1 - v2;
            Console.WriteLine("result after operator- :");
            OutputCoordinats(resultVector);

            resultVector = v1 * v2;
            Console.WriteLine("result after operator* :");
            OutputCoordinats(resultVector);

            resultVector = v1 / v2;
            Console.WriteLine("result after operator/ :");
            OutputCoordinats(resultVector);

            scalarMult = v1 % v2;
            Console.WriteLine("result after operator% :");
            Console.WriteLine(scalarMult);

            IEnumerator ie = firstVector.GetEnumerator();
            double cur = 0.0;
            while (ie.MoveNext())
            {
                cur = (double)ie.Current;
                Console.WriteLine($"current element: {cur}");
            }
            ie.Reset();
            Console.WriteLine("after reseting:");
            while (ie.MoveNext())
            {
                cur = (double)ie.Current;
                Console.WriteLine($"current element: {cur}");
            }
        }
    }
}
