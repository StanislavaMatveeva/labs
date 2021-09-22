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

        [TestMethod]
        public void DimesionsPropertyTest()
        {
            // arrange
            var vector = new MathVector(3);
            vector[0] = 1; vector[1] = 2; vector[2] = 3;
            int expected = 3;

            // act
            int result = vector.Dimensions;

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the property "double MathVector.Length{get;}".
        /// </summary>
        [TestMethod]
        public void LengthPropertyTest()
        {
            // arrange
            var vector = new MathVector(3);
            vector[0] = 1; vector[1] = 2; vector[2] = 3;
            double expected = Math.Sqrt(vector[0] * vector[0] + vector[1] * vector[1] + vector[2] * vector[2]);

            // act
            double result = vector.Length;

            // assert
            Assert.AreEqual(result, expected);
        }


        /// <summary>
        /// Checks the work of the method "IMathVector Mathvector.SumNumber(double number)".
        /// </summary>
        [TestMethod]
        public void SumNumberMethodTest()
        {
            // arrange
            double number = 2;
            var vector = new MathVector(3);
            vector[0] = 1; vector[1] = 2; vector[2] = 3;
            var expected = new MathVector(3);
            expected[0] = 1 + number; expected[1] = 2 + number; expected[2] = 3 + number;

            // act
            IMathVector result = new MathVector(3);
            result = vector.SumNumber(number);
            
            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.MultiplyNumber(double number)".
        /// </summary>
        [TestMethod]
        public void MultiplyNumberMethodTest()
        {
            // arrange
            double number = 2;
            var vector = new MathVector(3);
            vector[0] = 1; vector[1] = 2; vector[2] = 3;
            var expected = new MathVector(3);
            expected[0] = 1 * number; expected[1] = 2 * number; expected[2] = 3 * number;

            // act
            IMathVector result = new MathVector(3);
            result = vector.MultiplyNumber(number);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Sum(IMathVector vector)".
        /// </summary>
        [TestMethod]
        public void SumMethodTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);
            expected[0] = 1 + 5; expected[1] = 2 + 6; expected[2] = 3 + 7;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Sum(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "IMathVector MathVector.Multiply(IMathVector vector)".
        /// </summary>
        [TestMethod]
        public void MultiplyMethodTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);
            expected[0] = 1 * 5; expected[1] = 2 * 6; expected[2] = 3 * 7;

            // act
            IMathVector result = new MathVector(3);
            result = vector1.Multiply(vector2);

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.ScalarMultiply(IMathVector vector, double angle)".
        /// </summary>
        [TestMethod]
        public void ScalarMultiplyMethodTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            double angle = Math.PI / 6;
            double expected = vector1.Length * vector2.Length * Math.Cos(angle);

            // act
            double result = vector1.ScalarMultiply(vector2, angle);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the work of the method "double MathVector.CalcDistance(IMathVector vector)".
        /// </summary>
        [TestMethod]
        public void CalcDistanceMethodTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            double expected = Math.Sqrt(Math.Pow(vector1[0] - vector2[0], 2) + Math.Pow(vector1[1] - vector2[1], 2)
                + Math.Pow(vector1[2] - vector2[2], 2));

            // act
            double result = vector1.CalcDistance(vector2);

            // assert
            Assert.AreEqual(result, expected);
        }

        /// <summary>
        /// Checks the overload of the operator+.
        /// </summary>
        [TestMethod]
        public void OperatorAddingOverloadTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);
            expected[0] = 1 + 5; expected[1] = 2 + 6; expected[2] = 3 + 7;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 + vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator-.
        /// </summary>
        [TestMethod]
        public void OperatorSubstructionOverloadTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);
            expected[0] = 1 - 5; expected[1] = 2 - 6; expected[2] = 3 - 7;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 - vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator*.
        /// </summary>
        [TestMethod]
        public void OperatorMultiplyOverloadTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);
            expected[0] = 1 * 5; expected[1] = 2 * 6; expected[2] = 3 * 7;

            // act
            IMathVector result = new MathVector(3);
            result = vector1 * vector2;

            // assert
            Assert.AreEqual(result[0], expected[0]);
            Assert.AreEqual(result[1], expected[1]);
            Assert.AreEqual(result[2], expected[2]);
        }

        /// <summary>
        /// Checks the overload of the operator/.
        /// </summary>
        [TestMethod]
        public void OperatorDivisionOverloadtest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 0; vector2[1] = 6; vector2[2] = 7;
            var expected = new MathVector(3);

            try
            {
                expected[0] = vector1[0] / vector2[0]; expected[1] = vector1[1] / vector2[1];
                expected[2] = vector1[2] / vector2[2];
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("ERROR: division by 0 exception.");
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
        /// Checks the overload of the operator%.
        /// </summary>
        [TestMethod]
        public void OperatorProcentOverloadTest()
        {
            // arrange
            var vector1 = new MathVector(3);
            vector1[0] = 1; vector1[1] = 2; vector1[2] = 3;
            var vector2 = new MathVector(3);
            vector2[0] = 5; vector2[1] = 6; vector2[2] = 7;
            double expected = vector1.Length * vector2.Length;

            // act
            double result = vector1 % vector2;

            // assert
            Assert.AreEqual(result, expected);
        }
    }
}
