using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LinearAlgebra;
using System.Management;

namespace Clustering
{
    /// <inheritdoc cref="IClusterer"/>
    public class KMeansClusterer : IClusterer
    {
        MathVector[][] clustersArray;
        Cluster[] clusters;

        /// <summary>
        /// Creates an object of KMeansClusterer class.
        /// </summary>
        /// <param name="k">Amount of clusters.</param>
        /// <exception cref="Exception">Is thrown, when size of clusters' array
        /// is negative or zero.</exception>
        public KMeansClusterer(int k)
        {
            if (k <= 0)
                throw new Exception("Wrong value of cluster array's size");
            else
            {
                clustersArray = new MathVector[k][];
                clusters = new Cluster[k];
                for (int i = 0; i < k; i++)
                {
                    clustersArray[i] = new MathVector[] { };
                    var newDot = new MathVector(2);
                    clusters[i] = new Cluster(newDot, i);
                }
            }
        }

        public IEnumerable<Cluster> Clusters { get { return clusters; } }

        /// <summary>
        /// Gets amount of clusters.
        /// </summary>
        public int Amount { get { return clustersArray.Length; } }

        /// <summary>
        /// Gets current cluster.
        /// </summary>
        /// <param name="i">Index of current cluster.</param>
        /// <exception cref="IndexOutOfRangeException">Is thrown, when cluster's index is
        /// out of array.</exception>
        /// <returns></returns>
        public MathVector[] this[int i]
        {
            get
            {
                if (i < 0 || i > clustersArray.Length)
                    throw new IndexOutOfRangeException();
                else
                    return clustersArray[i];
            }
        }

        /// <summary>
        /// Checks if file is valid or not.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when file's extension is not ".txt"
        /// or it's volume or bigger than available RAM and virtual memory of the computer.</exception>
        /// <param name="fileName">Name of file.</param>
        public void CheckFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                var createFile = new string[] { "New", "File" };
                File.WriteAllLines(fileName, createFile);
            }
            else if (new FileInfo(fileName).Extension != ".txt")
                throw new Exception("Wrong format of file");
            else
            {
                int memory = 0;
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
                ManagementObjectCollection results = searcher.Get();
                foreach (ManagementObject result in results)
                {
                    var obj = result["FreePhysicalMemory"];
                    memory += Convert.ToInt32(obj);
                    obj = result["FreeVirtualMemory"];
                    memory += Convert.ToInt32(obj);
                }
                if (new FileInfo(fileName).Length > memory)
                    throw new Exception("This file is too big");
            }
            try { var check = File.ReadAllLines(fileName); var str = check[0]; }
            catch { throw new Exception("This file is empty"); }
        }

        /// <summary>
        /// Gets data from file.
        /// </summary>
        /// <param name="fileName">Name of file.</param>
        /// <returns>Array of String, that contains file's data.</returns>
        public string[] GetData(string fileName)
        {
            return File.ReadAllLines(fileName);
        }

        /// <summary>
        /// Deletes extra probels from string.
        /// </summary>
        /// <param name="s">String, from which probels are deleted.</param>
        /// <exception cref="Exception">Is thrown, when string is empty.</exception>
        public string DeleteProbels(string s)
        {
            if (s == "")
                throw new Exception("This string is empty");
            else
            {
                var newString = s.Trim(' ');
                while (newString.Contains("  "))
                    newString = newString.Replace("  ", " ");
                return newString;
            }
        }

        /// <summary>
        /// Converts data from array of String to array of dots (MathVector).
        /// </summary>
        /// <param name="array">Array of string, that contains file's data.</param>
        /// <exception cref="Exception">Is thrown, when file's data array is empty.</exception>
        /// <returns>Array of MathVector, that contains file's data.</returns>
        public MathVector[] ConvertData(string[] array)
        {
            if (array.Length == 0)
                throw new Exception("This file is empty");
            else
            {
                string[] tmpArray;
                var dotsArray = new MathVector[array.Length];
                for (int i = 0; i < array.Length; i++)
                {
                    var newDot = new MathVector(2);
                    string str = array[i];
                    str = DeleteProbels(str);
                    tmpArray = str.Split(' ');
                    for (int j = 0; j < tmpArray.Length; j++)
                    {
                        string s = tmpArray[j];
                        try { newDot[j] = Convert.ToDouble(s); }
                        catch { throw new Exception("Invalid data"); }
                    }
                    dotsArray[i] = newDot;
                }
                return dotsArray;
            }
        }

        public Cluster[] InitClusters(MathVector[] dotsArray, int amountOfClusters)
        {
            if (dotsArray.Length == 0)
                throw new Exception("This array is empty");
            else if (amountOfClusters <= 0)
                throw new Exception("Wrong value of amount of clusters");
            else
            {
                var newClusters = new Cluster[amountOfClusters];
                for (int i = 0; i < amountOfClusters; i++)
                {
                    newClusters[i] = new Cluster(dotsArray[i * dotsArray.Length / amountOfClusters], i);
                }
                return newClusters;
            }
        }

        public Cluster DetermineClusterMembership(IMathVector vector, KMeansClusterer kMeans)
        {
            if (vector.Dimensions == 0 || kMeans.Amount == 0)
                throw new Exception("This array is empty");
            else
            {
                double distance;
                double minDistance = double.MaxValue;
                int centerIndex = 0;
                var center = new MathVector(2);
                for (int i = 0; i < kMeans.Amount; i++)
                {
                    distance = vector.CalcDistance(kMeans.clusters[i].ClusterCenter);
                    if (distance < minDistance)
                    {
                        center = (MathVector)kMeans.clusters[i].ClusterCenter;
                        centerIndex = kMeans.clusters[i].Id;
                        minDistance = distance;
                    }
                }
                return new Cluster(center, centerIndex);
            }
        }

        /// <summary>
        /// Gets cluster of current number.
        /// </summary>
        /// <param name="dotsArray">Array of all dots.</param>
        /// <param name="kMeans">Array of clusters.</param>
        /// <param name="clusterNumber">Number of the current cluster.</param>
        /// <exception cref="Exception">Is thrown, when dots' or clusters' array is empty.</exception>
        /// <exception cref="Exception">Is thrown, when cluster's number is negative.</exception>
        /// <returns>Current cluster.</returns>
        public MathVector[] GetCluster(MathVector[] dotsArray, KMeansClusterer kMeans, int clusterNumber)
        {
            if (dotsArray.Length == 0 || kMeans.Amount == 0)
                throw new Exception("This array is empty");
            else if (clusterNumber < 0)
                throw new Exception("Wrong value of cluster's number");
            else
            {
                int clusterIndex = 0;
                int amountOfDots = 0;
                var newCluster = new MathVector[dotsArray.Length];
                for (int i = 0; i < dotsArray.Length; i++)
                {
                    var center = DetermineClusterMembership(dotsArray[i], kMeans);
                    if (center.Id == clusterNumber)
                    {
                        newCluster[clusterIndex] = dotsArray[i];
                        kMeans.clusters[clusterNumber] = center;
                        clusterIndex++;
                        amountOfDots++;
                    }
                }
                Array.Resize(ref newCluster, amountOfDots);
                return newCluster;
            }
        }

        /// <summary>
        /// Divides array of dots by clusters.
        /// </summary>
        /// <param name="dotsArray">Array of dots.</param>
        /// <param name="kMeans">Array of clusters.</param>
        /// <exception cref="Exception">Is thrown, when dots' or clusters' array is empty.</exception>
        /// <returns></returns>
        public MathVector[][] DivideArrayByClusters(MathVector[] dotsArray, KMeansClusterer kMeans)
        {
            if (dotsArray.Length == 0 || kMeans.Amount == 0)
                throw new Exception("This array is empty");
            else
            {
                for (int i = 0; i < kMeans.Amount; i++)
                    kMeans.clustersArray[i] = GetCluster(dotsArray, kMeans, i);
                return kMeans.clustersArray;
            }
        }

        /// <summary>
        /// Copies data from the first cluster to the second.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when clusters' array is empty.</exception>
        /// <returns>Array of clusters.</returns>
        public KMeansClusterer CopyClusterers(KMeansClusterer kMeans)
        {
            if (kMeans.Amount == 0)
                throw new Exception("This array is empty");
            else
            {
                var newKMeans = new KMeansClusterer(kMeans.Amount);
                Array.Copy(kMeans.clustersArray, newKMeans.clustersArray, kMeans.Amount);
                Array.Copy(kMeans.clusters, newKMeans.clusters, kMeans.Amount);
                return newKMeans;
            }
        }

        /// <summary>
        /// Recalculates centers of clusters.
        /// </summary>
        /// <param name="kMeans">New array of clusters' centers.</param>
        /// <exception cref="Exception">Is thrown, when clusters' array is empty.</exception>
        public void ResetCenters(KMeansClusterer kMeans)
        {
            if (kMeans.Amount == 0)
                throw new Exception("This array is empty");
            else
            {
                double sumX;
                double sumY;
                for (int i = 0; i < kMeans.Amount; i++)
                {
                    sumX = 0.0;
                    sumY = 0.0;
                    for (int j = 0; j < kMeans.clustersArray[i].Length; j++)
                    {
                        sumX += kMeans.clustersArray[i][j][0];
                        sumY += kMeans.clustersArray[i][j][1];
                    }
                    var newCenter = new MathVector(2);
                    newCenter[0] = sumX / kMeans.clustersArray[i].Length;
                    newCenter[1] = sumY / kMeans.clustersArray[i].Length;
                    kMeans.clusters[i] = new Cluster(newCenter, i);
                }
            }
        }

        /// <summary>
        /// Check if arrays of clusters are equal or not.
        /// </summary>
        /// <param name="clusterer1">The first array of clusters.</param>
        /// <param name="clusterer2">The second array of clusters.</param>
        /// <exception cref="Exception">Is thrown, when one of clusters' array is empty.</exception>
        /// <returns>True if arrays of clusters are equal and false if not.</returns>
        public bool AreEqualClusterers(KMeansClusterer clusterer1, KMeansClusterer clusterer2)
        {
            if (clusterer1.Amount == 0 || clusterer2.Amount == 0)
                throw new Exception("This array is empty");
            else
            {
                int check = 0;
                if (clusterer1.Amount != clusterer2.Amount)
                    return false;
                for (int i = 0; i < clusterer1.Amount; i++)
                {
                    if (clusterer1.clustersArray[i].Length != clusterer2.clustersArray[i].Length)
                        return false;
                    else
                    {
                        for (int j = 0; j < clusterer1.clustersArray[i].Length; j++)
                            if (clusterer1.clustersArray[i][j] != clusterer2.clustersArray[i][j])
                                check++;
                    }
                }
                if (check == 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Creates clusters, when amount of iterations is equal to zero.
        /// </summary>
        /// <param name="kMeans">Array of clusters.</param>
        /// <param name="dotsArray">Array, that contains all dots.</param>
        /// <param name="count">Amount of iterations, that will be done in this method.</param>
        /// <returns>Final array of clusters.</returns>
        public KMeansClusterer CreateClustersForZeroIterations(KMeansClusterer kMeans, MathVector[] dotsArray, ref int count)
        {
            var newKMeans = CopyClusterers(kMeans);
            var check = 0;
            count = 0;
            while (check != 1)
            {
                ResetCenters(newKMeans);
                newKMeans.clustersArray = DivideArrayByClusters(dotsArray, newKMeans);
                if (!AreEqualClusterers(kMeans, newKMeans))
                {
                    ResetCenters(kMeans);
                    kMeans.clustersArray = DivideArrayByClusters(dotsArray, kMeans);
                    count++;
                }
                else
                    check = 1;
            }
            return newKMeans;
        }

        /// <summary>
        /// Creates clusters, when amount of iterations is fixed.
        /// </summary>
        /// <param name="kMeans">Array of clusters.</param>
        /// <param name="dotsArray">Array, that contains all dots.</param>
        /// <param name="iterations">Amount of iterations, that have to be done.</param>
        /// <returns>Final array of clusters.</returns>
        public KMeansClusterer CreateClustersForKnownIterations(KMeansClusterer kMeans, MathVector[] dotsArray, int iterations)
        {
            var newKMeans = CopyClusterers(kMeans);
            var count = 0;
            while (count != iterations)
            {
                ResetCenters(newKMeans);
                newKMeans.clustersArray = DivideArrayByClusters(dotsArray, newKMeans);
                count++;
            }
            return newKMeans;
        }

        /// <summary>
        /// Creates clusters array and recalculates centers while clusters won't stop changing.
        /// </summary>
        /// <param name="kMeans">Array of clusters.</param>
        /// <param name="fileName">Name of file.</param>
        /// <returns>Final array of clusters.</returns>
        public KMeansClusterer CreateClusters(KMeansClusterer kMeans, string fileName, int iterations, ref int count)
        {
            string[] array = GetData(fileName);
            var dotsArray = ConvertData(array);
            kMeans.clusters = InitClusters(dotsArray, kMeans.Amount);
            kMeans.clustersArray = DivideArrayByClusters(dotsArray, kMeans);
            if (iterations != 0)
            {
                count = iterations;
                return CreateClustersForKnownIterations(kMeans, dotsArray, iterations);
            }
            else
                return CreateClustersForZeroIterations(kMeans, dotsArray, ref count);
        } 
    }
}
