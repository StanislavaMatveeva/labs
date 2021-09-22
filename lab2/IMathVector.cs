using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinearAlgebra
{
    /// <summary>
    /// Interface for working with mathematical vector.
    /// </summary>
    public interface IMathVector : IEnumerable
    {
        /// <summary>
        /// Gets amount of coordinats in vector.
        /// </summary>
        int Dimensions { get; }
        double this[int i] { get; set; }
        /// <summary>
        /// Gets the vector's Length.
        /// </summary>
        double Length { get; }
        /// <summary>
        /// Adds a vector with a number.
        /// </summary>
        /// <param name="number">The number, with wich the vector is added.</param>
        /// <returns></returns>
        IMathVector SumNumber(double number);
        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        /// <param name="number">The number, by wich the vector is multiplied.</param>
        /// <returns></returns>
        IMathVector MultiplyNumber(double number);
        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is added.</param>
        /// <returns></returns>
        IMathVector Sum(IMathVector vector);
        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is multiplied by.</param>
        /// <returns></returns>
        IMathVector Multiply(IMathVector vector);
        /// <summary>
        /// Count the scalar product of two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is multiplied by.</param>
        /// <param name="angle">The angle between vectors.</param>
        /// <returns>The scalar product of vectors.</returns>
        double ScalarMultiply(IMathVector vector, double angle);
        /// <summary>
        /// Count the Euclidian number for two vectors.
        /// </summary>
        /// <param name="vector">The vector, with wich the Euclidian numer is counted.</param>
        /// <returns>The Euclidian number for two vectors.</returns>
        double CalcDistance(IMathVector vector);
    }

}
