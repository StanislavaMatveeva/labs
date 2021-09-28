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
        /// Gets the amount of coordinats in vector.
        /// </summary>
        int Dimensions { get; }

        /// <summary>
        /// Overloads the [].
        /// </summary>
        /// <param name="i">The index of the element in vector.</param>
        /// <returns>Index of the element or set the value to the element by the index.</returns>
        double this[int i] { get; set; }

        /// <summary>
        /// Gets the vector's Length.
        /// </summary>
        double Length { get; }

        /// <summary>
        /// Adds a vector with a number.
        /// </summary>
        /// <param name="number">The number, with wich the vector is added.</param>
        /// <returns>The new vector, wich coordinates are equivalent to addition
        /// of vector's coordinats and number.</returns>
        IMathVector SumNumber(double number);

        /// <summary>
        /// Multiplies a vector by a number.
        /// </summary>
        /// <param name="number">The number, by wich the vector is multiplied.</param>
        /// <returns>The new vector, wich coordinates are equivalent to multiplication
        /// of vector's coordinats and number</returns>
        IMathVector MultiplyNumber(double number);

        /// <summary>
        /// Adds two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is added.</param>
        /// <exception cref="ArithmeticException">Is thrown,
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <returns>The result of component-by-component addition.</returns>
        IMathVector Sum(IMathVector vector);

        /// <summary>
        /// Does the component-by-component substruction of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <exception cref="ArithmeticException">Is thrown, 
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <returns>The result vector of component-by-component substuction.</returns>
        IMathVector Substruction(IMathVector vector);

        /// <summary>
        /// Multiplies two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is multiplied by.</param>
        /// <exception cref="ArithmeticException">Is thrown, 
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <returns>The result of the component-by-component multiplycation.</returns>
        IMathVector Multiply(IMathVector vector);

        /// <summary>
        /// Does the component-by-component division of two vectors.
        /// </summary>
        /// <param name="vector"></param>
        /// <exception cref="ArithmeticException">Is thrown, 
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <exception cref="DivideByZeroException">Is thrown, 
        /// when the second operand of the division operation is zero.</exception>
        /// <returns>The result vector of component-by-component division.</returns>
        IMathVector Division(IMathVector vector);

        /// <summary>
        /// Count the scalar product of two vectors.
        /// </summary>
        /// <param name="vector">The vector, wich is multiplied by.</param>
        /// <returns>The scalar product of vectors.</returns>
        double ScalarMultiply(IMathVector vector);

        /// <summary>
        /// Count the Euclidian number for two vectors.
        /// </summary>
        /// <param name="vector">The vector, with wich the Euclidian numer is counted.</param>
        /// <exception cref="ArithmeticException">Is thrown,
        /// when the lengthes of two vectors are not equivalent.</exception>
        /// <returns>The Euclidian number for two vectors.</returns>
        double CalcDistance(IMathVector vector);
    }

}
