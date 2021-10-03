using System;
using System.Collections;


namespace LinearAlgebra
{
    /// <inheritdoc cref="IMathVector"/>
    public class MathVector : IMathVector
    {
        double[] array;
        int currentIndex;

        /// <summary>
        /// Create the object of class MathVector with setted amount of coordinats in vector.
        /// </summary>
        /// <param name="size">Amount of coordinats.</param>
        public MathVector(int size)
        {
            if (size <= 0)
                throw new Exception("Wrong size value");
            else
            {
                array = new double[size];
                currentIndex = 0;
            }
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
        /// Is thrown, when the element isn't in the array.
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

        public double this[int i]
        {
            get
            {
                if (i < array.Length && i >= 0)
                    return array[i];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < array.Length && i >= 0)
                    array[i] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Overloads the operator+. Adds two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns>The result of addition of two vectors.</returns>
        public static IMathVector operator +(MathVector v1, MathVector v2)
        {
            return v1.Sum(v2);
        }

        /// <summary>
        /// Overloads the operator-. Substructs two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns>The result of substruction of two vectors.</returns>
        public static IMathVector operator -(MathVector v1, MathVector v2)
        {
            return v1.Substruction(v2);
        }

        /// <summary>
        /// Overloads the operator*. Multiply two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns>The result of multiplication of two vectros.</returns>
        public static IMathVector operator *(MathVector v1, MathVector v2)
        {
            return v1.Multiply(v2);
        }

        /// <summary>
        /// Overloads the operator/. Divides two objects of the MathVector class.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns>The result of division of two vectros.</returns>
        public static IMathVector operator /(MathVector v1, MathVector v2)
        {
            return v1.Division(v2);
        }

        /// <summary>
        /// Overloads the operator%. Count the scalar multiplication of two objects of the MathVector class.
        /// The angle between vectors is 0.
        /// </summary>
        /// <param name="v1">The first operand.</param>
        /// <param name="v2">The second operand.</param>
        /// <returns>The result of the scalar multiplication of two vectros.</returns>
        public static double operator %(MathVector v1, MathVector v2)
        {
            return v1.ScalarMultiply(v2);
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
            else
                throw new Exception("Sizes are not equival");
            return newVector;
        }

        /// <summary>
        /// Does the component-by-component substruction of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <exception cref="ArithmeticException">Is thrown, 
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <returns>The result vector of component-by-component substuction.</returns>
        public IMathVector Substruction(IMathVector vector)
        {
            IMathVector newVector = new MathVector(Dimensions);
            if (Dimensions == vector.Dimensions)
            {
                for (int i = 0; i < Dimensions; i++)
                    newVector[i] = this[i] - vector[i];
            }
            else
                throw new Exception("Sizes are not equival");
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
            else
                throw new Exception("Sizes are not equival");
            return newVector;
        }

        /// <summary>
        /// Does the component-by-component division of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <exception cref="ArithmeticException">Is thrown, 
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <exception cref="DivideByZeroException">Is thrown, 
        /// when the second operand of the division operation is zero.</exception>
        /// <returns>The result vector of component-by-component division.</returns>
        public IMathVector Division(IMathVector vector)
        {
            IMathVector newVector = new MathVector(Dimensions);
            if (Dimensions == vector.Dimensions)
            {
                for (int i = 0; i < Dimensions; i++)
                {
                    if (vector[i] != 0)
                        newVector[i] = this[i] / vector[i];
                    else
                        throw new DivideByZeroException("Division by zero");
                }
            }
            else
                throw new Exception("Sizes are not equival");
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
            else
                throw new Exception("Sizes are not equival");
            return Math.Sqrt(sum);
        }

        public double ScalarMultiply(IMathVector vector)
        {
            IMathVector newVector = new MathVector(Dimensions);
            newVector = Multiply(vector);
            double result = 0.0;
            for (int i = 0; i < newVector.Dimensions; i++)
                result += newVector[i];
            return result;
        }
    }
}

