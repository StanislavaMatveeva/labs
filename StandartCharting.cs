using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demographic;
using FileOperations;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;

namespace DemographicPresentation
{
    public partial class DemographicPresentation : Form
    {

        /// <summary>
        /// Starts creating of charts in standart mode.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStandartMode_Click(object sender, EventArgs e)
        {
            CreateCharts();
        }

        /// <summary>
        /// Creates spline charts for all population's, men's and women's amount dynamics.
        /// </summary>
        /// <param name="populationArray">Array with amount of all population, men and women 
        /// for each year of modeling.</param>
        private void CreateAllPopulationChart(double[][] populationArray)
        {
            InitAllPopulationChart();
            InitMenPopulationChart();
            InitWomenPopulationChart();
            int i = 0;
            while (i < populationArray.Length)
            {
                chartAllPopulation.Series["all population"].Points
                    .AddXY(startYear + i, populationArray[i][0]);
                chartAllPopulation.Series["men's population"].Points
                    .AddXY(startYear + i, populationArray[i][1]);
                chartAllPopulation.Series["women's population"].Points
                    .AddXY(startYear + i, populationArray[i][2]);
                i++;
            }
        }

        /// <summary>
        /// Creates bar chart for men's amount, divided by ages categories.
        /// </summary>
        /// <param name="populationArray">Array that contains amount of men for each category.</param>
        private void CreateMenPopulationChartByCategories(double[][] populationArray)
        {
            InitMenPopulationByCategoriesChart();
            int i = 0;
            while (i < populationArray.Length)
            {
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Points.Add(populationArray[i][0]);
                i++;
            }
        }

        /// <summary>
        /// Creates bar chart for women's amount, divided by ages categories.
        /// </summary>
        /// <param name="populationArray">Array that contains amount of women for each category.</param>
        private void CreateWomenPopulationChartByCategories(double[][] populationArray)
        {
            InitWomenPopulationByCategoriesChart();
            int i = 0;
            while (i < populationArray.Length)
            {
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Points.Add(populationArray[i][1]);
                i++;
            }
        }

        /// <summary>
        /// Creates all charts.
        /// </summary>
        private void CreateCharts()
        {
            if (secondThread.IsAlive)
            { TellAboutError("Wait until dynamic modeling will be finished or press button \"Stop\" to finish it"); return; }
            CleanAll();
            if (!GetStartData())
                return;
            MakeInvisibleElements();
            IEngine newEngine = new Engine(new List<Person>()) 
            { FirstYear = startYear, CurrentYear = startYear, LastYear = lastYear, PopulationAmount = startAmount };
            double[][] population;
            try { population = engine.GetCollection(ref newEngine, initialAge, deathRules); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            CreateAllPopulationChart(population);
            try { population = engine.GetPopulationAmountByCategories(newEngine.Collection, categories); }
            catch(Exception ex) { TellAboutError(ex.Message); return; }
            CreateMenPopulationChartByCategories(population);
            CreateWomenPopulationChartByCategories(population);
        }
    }
}
