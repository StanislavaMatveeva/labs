using System;
using System.Collections;


namespace LinearAlgebra
{
    /// <inheritdoc cref="IMathVector"/>
    public class MathVector : IMathVector
    {
        double[] array;
        int currentIndex;

        public MathVector() { }
        /// <summary>
        /// Create the object of class MathVector with setted amount of coordinats in vector.
        /// </summary>
        /// <param name="size">Amount of coordinats.</param>
        public MathVector(int size)
        {
            array = new double[size];
            currentIndex = 0;
        }
        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns>The link to the IEnumerator interface.</returns>
        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }
        /// <summary>
        /// Gets the object in the sequence, that the pointer indicates.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Raised, when the element isn't in the array.
        /// </exception>
        public object Current
        {
            get
            {
                if (currentIndex == -1 || currentIndex >= array.Length)
                    throw new InvalidOperationException();
                return array[currentIndex];
            }
        }
        /// <summary>
        /// Moves the pointer to current element to the next position in the sequence.
        /// </summary>
        /// <returns>True, if the sequence isn't ended. False, if the sequence is ended.</returns>
        public bool MoveNext()
        {
            if (currentIndex < array.Length - 1)
            {
                currentIndex++;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// Returns the pointer to the starting position.
        /// </summary>
        public void Reset() { currentIndex = -1; }

        public int Dimensions { get { return array.Length; } }

        public double this[int i] { get { return array[i]; } set { array[i] = value; } }
        /// <summary>
        /// Overloads the operator+. Adds two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns></returns>
        public static IMathVector operator +(MathVector v1, MathVector v2)
        {
            return v1.Sum(v2);
        }
        /// <summary>
        /// Overloads the operator-. Substracts two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns></returns>
        public static IMathVector operator -(MathVector v1, MathVector v2)
        {
            IMathVector newVector = new MathVector(v1.Dimensions);
            if (v1.Dimensions == v2.Dimensions)
            {
                for (int i = 0; i < v1.Dimensions; i++)
                    newVector[i] = v1[i] - v2[i];
            }
            return newVector;
        }
        /// <summary>
        /// Overloads the operator*. Multiply two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns></returns>
        public static IMathVector operator *(MathVector v1, MathVector v2)
        {
            return v1.Multiply(v2);
        }
        /// <summary>
        /// Overloads the operator/. Divides two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns></returns>
        public static IMathVector operator /(MathVector v1, MathVector v2)
        {
            IMathVector newVector = new MathVector(v1.Dimensions);
            if (v1.Dimensions == v2.Dimensions)
            {
                for (int i = 0; i < v1.Dimensions; i++)
                {
                    if (v2[i] != 0)
                        newVector[i] = v1[i] / v2[i];
                    else
                        Console.WriteLine("ERROR: division by 0");
                }
            }
            return newVector;
        }
        /// <summary>
        /// Overloads the operator%. Count the scalar multiplication of two objects of the MathVector class.
        /// The angle between vectors is 0.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns></returns>
        public static double operator %(MathVector v1, MathVector v2)
        {
            return v1.Length * v2.Length;
        }

        public double Length
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < Dimensions; i++)
                    sum += this[i] * this[i];
                return Math.Sqrt(sum);
            }
        }

        public IMathVector SumNumber(double number)
        {
            IMathVector newVector = new MathVector(Dimensions);
            for (int i = 0; i < newVector.Dimensions; i++)
                newVector[i] = this[i] + number;
            return newVector;
        }

        public IMathVector MultiplyNumber(double number)
        {
            IMathVector newVector = new MathVector(Dimensions);
            for (int i = 0; i < newVector.Dimensions; i++)
                newVector[i] = this[i] * number;
            return newVector;
        }

        public IMathVector Sum(IMathVector vector)
        {
            IMathVector newVector = new MathVector(Dimensions);
            if (Dimensions == vector.Dimensions)
            {
                for (int i = 0; i < Dimensions; i++)
                    newVector[i] = this[i] + vector[i];
            }
            return newVector;
        }

        public IMathVector Multiply(IMathVector vector)
        {
            IMathVector newVector = new MathVector(Dimensions);
            if (Dimensions == vector.Dimensions)
            {
                for (int i = 0; i < Dimensions; i++)
                    newVector[i] = this[i] * vector[i];
            }
            return newVector;
        }

        public double CalcDistance(IMathVector vector)
        {
            double sum = 0;
            IMathVector newVector = new MathVector(vector.Dimensions);
            if (Dimensions == vector.Dimensions)
            {
                for (int i = 0; i < vector.Dimensions; i++)
                    sum += (this[i] - vector[i]) * (this[i] - vector[i]);
            }
            return Math.Sqrt(sum);
        }

        public double ScalarMultiply(IMathVector vector, double angle)
        {
            return Length * vector.Length * Math.Cos(angle);
        }
    }
}

