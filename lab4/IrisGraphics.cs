using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LinearAlgebra;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace IrisGraphics
{
    public partial class IrisGraphics : Form
    {
        IrisClass ir = new IrisClass();
        Executor ex = new Executor();
        string fileName;

        public IrisGraphics()
        {
            InitializeComponent();
            CleanAll();
            richTextBoxErrors.Visible = false;
            richTextBoxErrors.Enabled = false;
        }

        private void buttonSepalLength_Click(object sender, EventArgs e)
        {
            sepalLengthChart.Series.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_SEPAL_LENGTH_CHART, "Sepal length", sepalLengthChart);
        }

        private void buttonSepalWidth_Click(object sender, EventArgs e)
        {
            sepalWidthChart.Series.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_SEPAL_WIDTH_CHART, "Sepal width", sepalWidthChart);
        }

        private void buttonPetalLength_Click(object sender, EventArgs e)
        {
            petalLengthChart.Series.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_PETAL_LENGTH_CHART, "Petal length", petalLengthChart);
        }

        private void buttonPetalWidth_Click(object sender, EventArgs e)
        {
            petalWidthChart.Series.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_PETAL_WIDTH_CHART, "Petal width", petalWidthChart);
        }

        /// <summary>
        /// Creates a pie chart for distances between average irisis' vectors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDistance_Click(object sender, EventArgs e)
        {
            CreatePieChart();
        }

        private void buttonChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.ShowDialog();
            fileName = openFileDialog1.FileName;
            try { ir.CheckFile(fileName); }
            catch (Exception ex) { TellAboutError(ex); return; }
            try { ir.IsValidData(File.ReadAllLines(fileName)); }
            catch (Exception ex) { TellAboutError(ex); return; }
            richTextBoxFileName.Text = "You choosed " + fileName;
            MakeEnabledChartsTrue();
        }

        private void MakeEnabledChartsTrue()
        {
            buttonSepalLength.Enabled = true;
            buttonSepalWidth.Enabled = true;
            buttonPetalLength.Enabled = true;
            buttonPetalWidth.Enabled = true;
            buttonPieChart.Enabled = true;
            richTextBoxErrors.Visible = false;
        }

        private void CleanAll()
        {
            sepalLengthChart.Series.Clear();
            sepalWidthChart.Series.Clear();
            petalLengthChart.Series.Clear();
            petalWidthChart.Series.Clear();
            pieChart.Series.Clear();
            buttonSepalLength.Enabled = false;
            buttonSepalWidth.Enabled = false;
            buttonPetalLength.Enabled = false;
            buttonPetalWidth.Enabled = false;
            buttonPieChart.Enabled = false;
        }

        /// <summary>
        /// Makes text box for errors visible, cleanse all charts and text boxes,
        /// send messege about the problem.
        /// </summary>
        /// <param name="ex">Catched exception.</param>
        private void TellAboutError(Exception ex)
        {
            richTextBoxErrors.Visible = true; 
            CleanAll();
            richTextBoxErrors.Text = "Error: " + ex.Message;
        }

        /// <summary>
        /// Creates a pie chart for distances between irisis' average vectors.
        /// Shows values of distances, that are rounded up to five decimal places.
        /// </summary>
        private void CreatePieChart()
        {
            IrisClass[] iris;
            double[] values;
            try { iris = ir.CreateData(fileName); }
            catch(Exception ex) { TellAboutError(ex); return; }
            try { values = ex.ExecuteOperation(iris, Executor.Opearations.CREATE_PIE_CHART); }
            catch(Exception ex) { TellAboutError(ex); return; }
            var headers = new string[] { "Setosa and VersiColor","Setosa and Virginica",
                    "Versicolor and Virginica" };
            pieChart.Titles.Add("Distances");
            pieChart.Palette = ChartColorPalette.SeaGreen;
            pieChart.Series.Add(new Series("distances"));
            pieChart.Series["distances"].ChartType = SeriesChartType.Pie;
            for (int i = 0; i < values.Length; i++)
            {
                pieChart.Series["distances"].Points.AddXY(headers[i], Math.Round(values[i], 5));
                pieChart.Series["distances"].IsValueShownAsLabel = true;
            }
        }

        /// <summary>
        /// Creates a bar chart for choosed metric.
        /// </summary>
        /// <param name="chartNumber">Chart's number.</param>
        /// <param name="chartHeader">Chart's header.</param>
        /// <param name="chart">Choosed chart.</param>
        private void ChooseBarChart(Executor.Opearations chartNumber, string chartHeader, Chart chart)
        {
            IrisClass[] iris;
            double[] values;
            try { iris = ir.CreateData(fileName); }
            catch (Exception ex) { TellAboutError(ex); return; ; }
            try { values = ex.ExecuteOperation(iris, chartNumber); }
            catch (Exception ex) { TellAboutError(ex); return; }
            var headers = new string[] { "Setosa", "VersiColor", "Virginica" };
            chart.Palette = ChartColorPalette.SeaGreen;
            chart.Titles.Add(chartHeader);
            for (int i = 0; i < values.Length; i++)
            {
                var series = chart.Series.Add(headers[i]);
                series.ChartType = SeriesChartType.Bar;
                series.Points.Add(values[i]);
            }
        }
    }
}