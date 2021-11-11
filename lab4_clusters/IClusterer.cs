using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace Clustering
{
    interface IClusterer
    {
        /// <summary>
        /// Creates random centers of clusters.
        /// </summary>
        /// <param name="dotsArray">Array of dots.</param>
        /// <param name="amountOfClusters">Amount of clusters.</param>
        /// <exception cref="Exception">Is thrown, when dots' array is empty.</exception>
        /// <exception cref="Exception">Is thrown, when amount of clusters is negative or zero.</exception>
        /// <returns></returns>
        Cluster[] InitClusters(MathVector[] dotsArray, int amountOfClusters);

        /// <summary>
        /// Gets an enumerator on one clusters' array.
        /// </summary>
        IEnumerable<Cluster> Clusters { get; }

        /// <summary>
        /// Determins which cluster does dot belong.
        /// </summary>
        /// <param name="vector">Coordinates of dot.</param>
        /// <param name="kMeans">All clusters.</param>
        /// <exception cref="Exception">Is thrown, when vector or clusters' array is empty.</exception>
        /// <returns>Object of Cluster class, that contains coordinats and index (number) of current cluster's center.</returns>
        Cluster DetermineClusterMembership(IMathVector vector, KMeansClusterer kMeans);
    }
}
