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
using System.Windows.Forms.DataVisualization.Charting;

namespace IrisGraphics
{
    public partial class Form1 : Form
    {
        IrisClass iris = new IrisClass();
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSepalLength_Click(object sender, EventArgs e)
        {
            sepalLengthChart.Series.Clear();
            ChooseChart(1, "Sepal Length", sepalLengthChart);
        }

        private void buttonSepalWidth_Click(object sender, EventArgs e)
        {
            sepalWidthChart.Series.Clear();
            ChooseChart(2, "Sepal Width", sepalWidthChart);
        }

        private void buttonPetalLength_Click(object sender, EventArgs e)
        {
            petalLengthChart.Series.Clear();
            ChooseChart(3, "Petal Length", petalLengthChart);
        }

        private void buttonPetalWidth_Click(object sender, EventArgs e)
        {
            petalWidthChart.Series.Clear();
            ChooseChart(4, "Petal Widgth", petalWidthChart);
        }

        private void buttonDistance_Click(object sender, EventArgs e)
        {
            CreatePieChart();
        }

        private void GetValues(ref string[] headers, ref double[] values, int metricNumber)
        {
            if (metricNumber <= 0)
                throw new Exception("Wrong value of metricNumber");
            else
            {
                double result1;
                double result2;
                double result3;
                if (metricNumber == 5)
                {
                    var vector1 = iris.CreateIris(1);
                    var vector2 = iris.CreateIris(2);
                    var vector3 = iris.CreateIris(3);
                    vector1 = iris.CreateAverageVector(vector1);
                    vector2 = iris.CreateAverageVector(vector2);
                    vector3 = iris.CreateAverageVector(vector3);
                    result1 = vector1.CalcDistance(vector2);
                    result2 = vector1.CalcDistance(vector3);
                    result3 = vector2.CalcDistance(vector3);
                    headers = new string[] { "Setosa and VersiColor vectors","Setosa and Virginica vectors",
                    "Versicolor and Virginica vectors" };
                    values = new double[] { result1, result2, result3 };
                }
                else
                {
                    result1 = iris.CreateData(1, metricNumber);
                    result2 = iris.CreateData(2, metricNumber);
                    result3 = iris.CreateData(3, metricNumber);
                    headers = new string[] { "Setosa", "VersiColor", "Virginica" };
                    values = new double[] { result1, result2, result3 };
                }
            }
        }

        private void CreatePieChart()
        {
            string[] headers = { };
            double[] values = { };
            GetValues(ref headers, ref values, 5);
            pieChart.Palette = ChartColorPalette.SeaGreen;
            pieChart.Series[0].ChartType = SeriesChartType.Pie;
            pieChart.Titles.Add("Distances");
            for (int i = 0; i < values.Length; i++)
            {
                pieChart.Series[0].Points.Add(values[i]);
                pieChart.Series[0].LegendText = headers[i];
            }
        }

        private void ChooseBarChart(int chartNumber, string chartHeader, Chart chart)
        {
            string[] headers = { };
            double[] values = { };
            GetValues(ref headers, ref values, chartNumber);
            chart.Palette = ChartColorPalette.SeaGreen;
            chart.Titles.Add(chartHeader);
            for (int i = 0; i < values.Length; i++)
            {
                Series series = new Series();
                series = chart.Series.Add(headers[i]);
                series.ChartType = SeriesChartType.Bar;
                series.Points.Add(values[i]);
            }
        }
    }
}
