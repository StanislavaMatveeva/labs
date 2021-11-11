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
        IrisClass ir = new IrisClass((int)IrisClass.Numbers.METRICS_AMOUNT);
        Executor ex = new Executor();
        string fileName;

        public IrisGraphics()
        {
            InitializeComponent();
            CleanAll();
            richTextBoxErrors.Visible = false;
        }

        private void buttonSepalLength_Click(object sender, EventArgs e)
        {
            sepalLengthChart.Series.Clear();
            sepalLengthChart.Titles.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_SEPAL_LENGTH_CHART, "Sepal length", sepalLengthChart);
        }

        private void buttonSepalWidth_Click(object sender, EventArgs e)
        {
            sepalWidthChart.Series.Clear();
            sepalWidthChart.Titles.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_SEPAL_WIDTH_CHART, "Sepal width", sepalWidthChart);
        }

        private void buttonPetalLength_Click(object sender, EventArgs e)
        {
            petalLengthChart.Series.Clear();
            petalLengthChart.Titles.Clear();
            ChooseBarChart(Executor.Opearations.CREATE_PETAL_LENGTH_CHART, "Petal length", petalLengthChart);
        }

        private void buttonPetalWidth_Click(object sender, EventArgs e)
        {
            petalWidthChart.Series.Clear();
            petalWidthChart.Titles.Clear();
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
            try { ir.CheckData(File.ReadAllLines(fileName)); }
            catch (Exception ex) { TellAboutError(ex); return; }
            richTextBoxFileName.Text = "You choosed " + fileName;
            MakeEnabledChartsTrue();
        }

        private void MakeEnabledChartsTrue()
        {
            buttonSepalLength.Enabled = true;
            buttonSepalLength.BackColor = Color.Turquoise;
            buttonSepalWidth.Enabled = true;
            buttonSepalWidth.BackColor = Color.Turquoise;
            buttonPetalLength.Enabled = true;
            buttonPetalLength.BackColor = Color.Turquoise;
            buttonPetalWidth.Enabled = true;
            buttonPetalWidth.BackColor = Color.Turquoise;
            buttonPieChart.Enabled = true;
            buttonPieChart.BackColor = Color.Turquoise;
            richTextBoxErrors.Visible = false;
        }

        /// <summary>
        /// Cleans all charts and makes text boxes enabled.
        /// </summary>
        private void CleanAll()
        {
            sepalLengthChart.Series.Clear();
            sepalLengthChart.Titles.Clear();
            sepalWidthChart.Series.Clear();
            sepalWidthChart.Titles.Clear();
            petalLengthChart.Series.Clear();
            petalLengthChart.Titles.Clear();
            petalWidthChart.Series.Clear();
            petalWidthChart.Titles.Clear();
            pieChart.Series.Clear();
            pieChart.Titles.Clear();
            buttonSepalLength.Enabled = false;
            buttonSepalLength.BackColor = Color.Maroon;
            buttonSepalWidth.Enabled = false;
            buttonSepalWidth.BackColor = Color.Maroon;
            buttonPetalLength.Enabled = false;
            buttonPetalLength.BackColor = Color.Maroon;
            buttonPetalWidth.Enabled = false;
            buttonPetalWidth.BackColor = Color.Maroon;
            buttonPieChart.Enabled = false;
            buttonPieChart.BackColor = Color.Maroon;
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
            pieChart.Series.Clear();
            pieChart.Titles.Clear();
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
                chart.Series.Add(new Series(headers[i]));
                chart.Series[headers[i]].ChartType = SeriesChartType.Bar;
                chart.Series[headers[i]].Points.Add(Math.Round(values[i], 5));
                chart.Series[headers[i]].IsValueShownAsLabel = true;
            }
        }

        private void buttonCleanGraphics_Click(object sender, EventArgs e)
        {
            CleanAll();
        }
    }
}