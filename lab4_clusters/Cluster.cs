using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinearAlgebra;

namespace Clustering
{
    public class Cluster
    {
        /// <summary>
        /// Creates an object of Cluster class.
        /// </summary>
        /// <param name="clusterCenter">Coordinats of cluster's center.</param>
        /// <param name="id">Index (number) of cluster.</param>
        public Cluster(IMathVector clusterCenter, int id)
        {
            if (clusterCenter.Dimensions == 0)
                throw new Exception("This vector is empty");
            else if (id < 0)
                throw new Exception("Wrong value of cluster's index");
            else
            {
                Id = id;
                ClusterCenter = clusterCenter;
            }
        }

        /// <summary>
        /// Gets index (number) of cluster.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets coordinats of cluster's center.
        /// </summary>
        public IMathVector ClusterCenter { get; }
    }
}
