using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LinearAlgebra;

namespace MathVectorTest
{
    /// <summary>
    /// Checks the work of the MathVector's class public methods.
    /// </summary>
    [TestClass]
    public class MathVectorTest
    {
        /// <summary>
        /// Checks the work of the property "int MathVector.Dimensions{get;}".
        /// </summary>
        [TestMethod]
        public void DimesionsPropertyTest()
        {
            // arrange
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            int expected = 3;

            // act
            int result = vector.Dimensions;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the property "double MathVector.Length{get;}",
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void LengthPropertyTest1()
        {
            // arrange
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            double expected = Math.Sqrt(14.0);

            // act
            double result = vector.Length;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the property "double MathVector.Length{get;}",
        /// when all coordinates are negative.
        /// </summary>
        [TestMethod]
        public void LengthPropertyTest2()
        {
            // arrange
            var vector = new MathVector(3);
            vector[0] = -1.0; vector[1] = -2.0; vector[2] = -3.0;
            double expected = Math.Sqrt(14.0);

            // act
            double result = vector.Length;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the overload of the operator+,
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void OperatorAddingOverloadTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 6.0; expected[1] = 8.0; expected[2] = 10.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 + vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator+,
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void OperatorAddingOverloadTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = -4.0; expected[1] = -4.0; expected[2] = -4.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 + vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator+,
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void OperatorAddingOverloadTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 1.0; expected[1] = 2.0; expected[2] = 3.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 + vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator+,
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void OperatorAddingOverloadWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -7.0; vector2[2] = -9.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 + vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator-,
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void OperatorSubstructionOverloadTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = -4.0; expected[1] = -4.0; expected[2] = -4.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 - vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator-,
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void OperatorSubstructionOverloadTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = 6.0; expected[1] = 8.0; expected[2] = 10.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 - vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator-,
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void OperatorSubstructionOverloadTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 1.0; expected[1] = 2.0; expected[2] = 3.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 - vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator-,
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void OperatorSubstructionOverloadWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 - vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator*,
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void OperatorMultiplyOverloadTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 5.0; expected[1] = 12.0; expected[2] = 21.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 * vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator*,
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void OperationMultiplictaionOverloadTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = -5.0; expected[1] = -12.0; expected[2] = -21.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 * vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator*,
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void OperationMultiplicationOverloadTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 * vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator*,
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void OperationMultiplicationOverloadWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 * vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator/,
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void OperatorDivisionOverloadTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 1.0 / 5.0; expected[1] = 2.0 / 6.0;
            expected[2] = 3.0 / 7.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 / vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator/,
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void OpearatorDivisionOverloadTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = 1.0 / -5.0; expected[1] = 2.0 / -6.0;
            expected[2] = 3.0 / -7.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 / vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator/,
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        /// <exception cref="DivideByZeroException">Is thrown,
        /// when the second operand of the division operation is zero.</exception>
        [TestMethod]
        public void OperatorDivisionOverloadTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);

            try
            {
                expected[0] = vector1[0] / vector2[0]; expected[1] = vector1[1] / vector2[1];
                expected[2] = vector1[2] / vector2[2];
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException();
            }

            // act
            IMathVector result = new MathVector(3);
            result = vector1 / vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator/,
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void OperatorDivisionOverloadWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 / vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator%,
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void OperatorProcentOverloadTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = 38.0;

            // act
            double result = vector1 % vector2;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the overload of the operator%,
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void OperatorProcentOverloadTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            double expected = -38.0;

            // act
            double result = vector1 % vector2;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the overload of the operator%,
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void OperatorProcentOverloadTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            double expected = 0.0;

            // act
            double result = vector1 % vector2;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the overload of the operator%,
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void OperatorProcentOverloadWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = 0.0;

            // act
            double result = vector1 % vector2;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector Mathvector.SumNumber(double number)",
        /// when the added number is positive.
        /// </summary>
        [TestMethod]
        public void SumNumberMethodTest1()
        {
            // arrange
            double number = 2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = 3.0; expected[1] = 4.0; expected[2] = 5.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.SumNumber(number);
            
            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector Mathvector.SumNumber(double number)",
        /// when the added number is negative.
        /// </summary>
        [TestMethod]
        public void SumNumberMethodTest2()
        {
            // arrange
            double number = -2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = -1.0; expected[1] = 0.0; expected[2] = 1.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.SumNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector Mathvector.SumNumber(double number)",
        /// when the added number is zero.
        /// </summary>
        [TestMethod]
        public void SumNumberMethodTest3()
        {
            // arrange
            double number = 0.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = 1.0; expected[1] = 2.0; expected[2] = 3.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.SumNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector Mathvector.SumNumber(double number)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void SumNumberMethodWrongTest()
        {
            // arrange
            double number = 2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = -1.0; expected[1] = 0.0; expected[2] = 1.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.SumNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.MultiplyNumber(double number)",
        /// when the multiplied number is positive.
        /// </summary>
        [TestMethod]
        public void MultiplyNumberMethodTest1()
        {
            // arrange
            double number = 2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = 2.0; expected[1] = 4.0; expected[2] = 6.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.MultiplyNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.MultiplyNumber(double number)",
        /// when the multiplied number is negative.
        /// </summary>
        [TestMethod]
        public void MultiplyNumberMethodTest2()
        {
            // arrange
            double number = -2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = -2.0; expected[1] = -4.0; expected[2] = -6.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.MultiplyNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.MultiplyNumber(double number)",
        /// when the multiplied number is zero.
        /// </summary>
        [TestMethod]
        public void MultiplyNumberMethodTest3()
        {
            // arrange
            double number = 0.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.MultiplyNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.MultiplyNumber(double number)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void MultiplyNumberMethodWrongTest()
        {
            // arrange
            double number = 2.0;
            var vector = new MathVector(3);
            vector[0] = 1.0; vector[1] = 2.0; vector[2] = 3.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector.MultiplyNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Sum(IMathVector vector)",
        /// when all coordinats of vectors are positive.
        /// </summary>
        [TestMethod]
        public void SumMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 6.0; expected[1] = 8.0; expected[2] = 10.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Sum(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Sum(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary
        [TestMethod]
        public void SumMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -7.0; vector2[2] = -9;
            var expected = new MathVector(3);
            expected[0] = -4.0; expected[1] = -5.0; expected[2] = -6.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Sum(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Sum(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void SumMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 1.0; expected[1] = 2.0; expected[2] = 3.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Sum(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Sum(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void SumMethodWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Sum(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Substruction(IMathVector vector)",
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void SubstructionMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = -4.0; expected[1] = -4.0; expected[2] = -4.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Substruction(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Substruction(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void SubstructionMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = 6.0; expected[1] = 8.0; expected[2] = 10.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Substruction(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Substruction(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void SubstructionMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 1.0; expected[1] = 2.0; expected[2] = 3.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Substruction(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Substruction(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void SubstructionMethosWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Substruction(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Multiply(IMathVector vector)",
        /// when all coordinates of vectors are positive.
        /// </summary>
        [TestMethod]
        public void MultiplyMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 5.0; expected[1] = 12.0; expected[2] = 21.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Multiply(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Multiply(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void MultiplyMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = -5.0; expected[1] = -12.0; expected[2] = -21.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Multiply(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Multiply(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void MultiplyMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Multiply(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Multiply(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void MultiplyMethodWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Multiply(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Division(IMathVector vector)",
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void DivisionMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 1.0 / 5.0; expected[1] = 2.0 / 6.0; expected[2] = 3.0 / 7.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Division(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Division(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void DivisionMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            var expected = new MathVector(3);
            expected[0] = 1.0 / -5.0; expected[1] = 2.0 / -6.0; expected[2] = 3.0 / -7.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Division(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Division(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        /// <exception cref="DivideByZeroException">Is thrown,
        /// when the second operand of the division operation is zero.</exception>
        [TestMethod]
        public void DivisionMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            var expected = new MathVector(3);
            try
            {
                expected[0] = vector1[0] / vector2[0]; expected[1] = vector1[1] / vector2[1];
                expected[2] = vector1[2] / vector2[2];
            }
            catch
            {
                throw new DivideByZeroException();
            }

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Division(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Division(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void DivisionMethodWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            var expected = new MathVector(3);
            expected[0] = 0.0; expected[1] = 0.0; expected[2] = 0.0;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Division(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.ScalarMultiply(IMathVector vector)",
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplyMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = 38.0;

            // act
            double result = vector1.ScalarMultiply(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.ScalarMultiply(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplyMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            double expected = -38.0;

            // act
            double result = vector1.ScalarMultiply(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.ScalarMultiply(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplyMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            double expected = 0.0;

            // act
            double result = vector1.ScalarMultiply(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.ScalarMultiply(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void ScalarMultiplyMethodWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = 0.0;

            // act
            double result = vector1.ScalarMultiply(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.CalcDistance(IMathVector vector)",
        /// when all coordinates are positive.
        /// </summary>
        [TestMethod]
        public void CalcDistanceMethodTest1()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = Math.Sqrt(48.0);

            // act
            double result = vector1.CalcDistance(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.CalcDistance(IMathVector vector)",
        /// when the second vector's coordinates are negative.
        /// </summary>
        [TestMethod]
        public void CalcDistanceMethodTest2()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = -5.0; vector2[1] = -6.0; vector2[2] = -7.0;
            double expected = Math.Sqrt(200.0);

            // act
            double result = vector1.CalcDistance(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.CalcDistance(IMathVector vector)",
        /// when the second vector's coordinates are zeroes.
        /// </summary>
        [TestMethod]
        public void CalcDistanceMethodTest3()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 0.0; vector2[1] = 0.0; vector2[2] = 0.0;
            double expected = Math.Sqrt(14.0);

            // act
            double result = vector1.CalcDistance(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.CalcDistance(IMathVector vector)",
        /// when the expected result is wrong.
        /// </summary>
        [TestMethod]
        public void CalcDistanceMethodWrongTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1.0; vector1[1] = 2.0; vector1[2] = 3.0;
            var vector2 = new MathVector(3);
            vector2[0] = 5.0; vector2[1] = 6.0; vector2[2] = 7.0;
            double expected = 0.0;

            // act
            double result = vector1.CalcDistance(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }
    }
}
