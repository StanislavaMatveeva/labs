using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrisGraphics
{
    public class Executor
    {
        IrisClass ir = new IrisClass();

        /// <summary>
        /// The enumeration, that contains types of opearstions with irisis.
        /// </summary>
        public enum Opearations
        {
            CREATE_SEPAL_LENGTH_CHART = 0,
            CREATE_SEPAL_WIDTH_CHART = 1,
            CREATE_PETAL_LENGTH_CHART = 2,
            CREATE_PETAL_WIDTH_CHART = 3,
            CREATE_PIE_CHART = 4
        };

        /// <summary>
        /// Calls the function depending on operation type.
        /// </summary>
        /// <param name="iris">An array of irisis.</param>
        /// <param name="op">Type of operation.</param>
        /// <returns>An array of double, that contains average values of irisis' metrics
        /// or distances between them.</returns>
        public double[] ExecuteOperation(IrisClass[] iris, Opearations op)
        {
            var newIris = ir.CreateAvgIris(iris);
            var values = new double[iris.Length];
            switch (op)
            {
                case Opearations.CREATE_SEPAL_LENGTH_CHART:
                    for (int i = 0; i < newIris.Length; i++)
                        values[i] = newIris[i][(int)Opearations.CREATE_SEPAL_LENGTH_CHART];
                    break;
                case Opearations.CREATE_SEPAL_WIDTH_CHART:
                    for (int i = 0; i < newIris.Length; i++)
                        values[i] = newIris[i][(int)Opearations.CREATE_SEPAL_WIDTH_CHART];
                    break;
                case Opearations.CREATE_PETAL_LENGTH_CHART:
                    for (int i = 0; i < newIris.Length; i++)
                        values[i] = newIris[i][(int)Opearations.CREATE_PETAL_LENGTH_CHART];
                    break;
                case Opearations.CREATE_PETAL_WIDTH_CHART:
                    for (int i = 0; i < newIris.Length; i++)
                        values[i] = newIris[i][(int)Opearations.CREATE_PETAL_WIDTH_CHART];
                    break;
                case Opearations.CREATE_PIE_CHART:
                    values = ir.GetDistancesArray(iris);
                    break;
            }
            return values;
        }
    }
}
