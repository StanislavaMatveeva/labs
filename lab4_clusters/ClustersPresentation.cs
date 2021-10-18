using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using Clustering;
using LinearAlgebra;

namespace ClustersPresentation
{
    public partial class ClustersPresentation : Form
    {
        KMeansClusterer kMeans;
        string fileName;

        public ClustersPresentation()
        {
            InitializeComponent();
            buttonCreateChart.Enabled = false;
            richTextBoxGetAmount.Enabled = false;
            richTextBoxIterations.Enabled = false;
            richTextBoxErrors.Visible = false;
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            CleanAll();
            kMeans = new KMeansClusterer(3);
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            try { kMeans.CheckFile(fileName); }
            catch(Exception ex) { TellAboutError(ex); return; }
            richTextBoxFileName.Text = "You choosed " + fileName;
            MakeEnabled();
        }

        private void buttonCreateChart_Click(object sender, EventArgs e)
        {
            DrawCharts();
        }

        private void CleanAll()
        {
            chartClustering.Series.Clear();
            buttonCreateChart.Enabled = false;
            richTextBoxErrors.Visible = false;
            richTextBoxGetAmount.Text = "";
            richTextBoxIterations.Text = "";
        }

        /// <summary>
        /// Makes the button "choose file",
        /// text boxes for entering amount of clusters and iterations enabled.
        /// </summary>
        private void MakeEnabled()
        {
            buttonCreateChart.Enabled = true;
            richTextBoxGetAmount.Enabled = true;
            richTextBoxGetAmount.Text = "";
            richTextBoxIterations.Enabled = true;
            richTextBoxIterations.Text = "";
        }

        /// <summary>
        /// Makes text box for errors visible, cleanse all charts and text boxes,
        /// send messege about the problem.
        /// </summary>
        /// <param name="ex">Catched exception.</param>
        private void TellAboutError(Exception ex)
        {
            chartClustering.Series.Clear();
            richTextBoxErrors.Visible = true;
            richTextBoxErrors.Text = "Error: " + ex.Message;
        }

        /// <summary>
        /// Gets amount of clusters.
        /// </summary>
        /// <exception cref="Exception". Is thrown, when read data is invalid.
        /// <returns>Amount of clusters.</returns>
        public int GetAmountOfClusters()
        {
            int a;
            try { a = Convert.ToInt32(richTextBoxGetAmount.Text); }
            catch { throw new Exception("Invalid amount of clusters"); }
            if (a > 30)
                throw new Exception("Amount of clusters shouldn't be more than 30");
            return a;
        }

        /// <summary>
        /// Gets amount of iterations.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when the value of iterations
        /// is invalid.</exception>
        /// <returns>Amount of iterations.</returns>
        public int GetAmountOfIterations()
        {
            int a;
            try { a = Convert.ToInt32(richTextBoxIterations.Text); }
            catch { throw new Exception("Invalid amount of iterations"); }
            if (a < 0)
                throw new Exception("Amount of iterations can't be negative");
            else if (a > 15)
                throw new Exception("Amount of iterations shouldn't be more than 15");
            else if (a == 0)
                a = 1;
            return a;
        }

        /// <summary>
        /// Creates chart of clusters' dots.
        /// </summary>
        public void CreateClustersChart(KMeansClusterer kMeans)
        {
            var color = KnownColor.PaleGoldenrod;
            for (int i = 0; i < kMeans.Amount; i++)
            {
                chartClustering.Series.Add(i.ToString());
                chartClustering.Series[i.ToString()].ChartType = SeriesChartType.Point;
                chartClustering.Series[i.ToString()].Color = Color.FromKnownColor(color);
                for (int j = 0; j < kMeans[i].Length; j++)
                    chartClustering.Series[i.ToString()].Points.AddXY(kMeans[i][j][0], kMeans[i][j][1]);
                color++;
            }
        }

        /// <summary>
        /// Creates chart of clusters' centers.
        /// </summary>
        public void DrawCentres(KMeansClusterer kMeans)
        {
            chartClustering.Series.Add("centers");
            chartClustering.Series["centers"].ChartType = SeriesChartType.Point;
            chartClustering.Series["centers"].Color = Color.Black;
            foreach(Cluster c in kMeans.Clusters)
                chartClustering.Series["centers"].Points.AddXY(c.ClusterCenter[0],
                    c.ClusterCenter[1]);
        }

        /// <summary>
        /// Draws charts of clusters' points and centers.
        /// </summary>
        public void DrawCharts()
        {
            int amount;
            int iterations;
            int check = 0;
            chartClustering.Series.Clear();
            try { amount = GetAmountOfClusters(); }
            catch (Exception ex) { TellAboutError(ex); return; }
            try { kMeans = new KMeansClusterer(amount); }
            catch (Exception ex) { TellAboutError(ex); return; }
            try { iterations = GetAmountOfIterations(); }
            catch (Exception ex) { TellAboutError(ex); return; }
            try { kMeans = kMeans.CreateClusters(kMeans, fileName, iterations, ref check);}
            catch (Exception ex) { TellAboutError(ex); return; }
            richTextBoxIterations.Text = check.ToString();
            try { CreateClustersChart(kMeans); }
            catch (Exception ex) { TellAboutError(ex); return; }
            try { DrawCentres(kMeans); }
            catch (Exception ex) { TellAboutError(ex); return; }
        }
    }
}
