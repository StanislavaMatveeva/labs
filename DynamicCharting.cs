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
        Thread secondThread;

        delegate void GetData();

        delegate void SendMessage(string text);

        delegate void ChageObject(int year, int index, double[][] populationArray);

        /// <summary>
        /// Starts dynamics creating of charts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDynamicMode_Click(object sender, EventArgs e)
        {
            DynamicCreatingOfCharts();
        }

        /// <summary>
        /// Finishes modeling.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStop_Click_1(object sender, EventArgs e)
        {
            if (richTextBoxAllPopulationAmountValue.Text != "")
                secondThread.Abort();
        }

        /// <summary>
        /// Stops modeling for 3 seconds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPause_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Draws charts for one year of modeling.
        /// </summary>
        /// <param name="year">Current year of modeling.</param>
        /// <param name="index">Index of array with all population's, men's and women's amount.</param>
        /// <param name="populationArray">Array with all population's, men's and women's amount.</param>
        private void ShowNewYearData(int year, int index, double[][] populationArray)
        {
            richTextBoxCurrentYearValue.Text = year.ToString();
            richTextBoxBirthsValue.Text = (populationArray[index][Engine.birthsAmountIndex] * 10000).ToString();
            richTextBoxDeathsValue.Text = (populationArray[index][Engine.deathsAmountIndex] * 10000).ToString();
            richTextBoxAmountOfMenValue.Text = (populationArray[index][Engine.menAmountIndex] * 1000).ToString();
            richTextBoxAmountOfWomenValue.Text = (populationArray[index][Engine.womenAmountIndex] * 1000).ToString();
            richTextBoxAllPopulationAmountValue.Text = (populationArray[index][Engine.allPopulationAmountIndex] * 1000).ToString();
            chartAllPopulation.Series["all population"].Points
                .AddXY(year, populationArray[index][Engine.allPopulationAmountIndex]);
            chartAllPopulation.Series["men's population"].Points
                .AddXY(year, populationArray[index][Engine.menAmountIndex]);
            chartAllPopulation.Series["women's population"].Points
                .AddXY(year, populationArray[index][Engine.womenAmountIndex]);
        }

        /// <summary>
        /// Cales creating of charts will current of modeling year isn't equal to the last year of modeling.
        /// </summary>
        private void YearTicks()
        {
            IEngine newEngine = new Engine(new List<Person>())
            { FirstYear = startYear, CurrentYear = startYear, LastYear = lastYear, PopulationAmount = startAmount };
            double[][] population;
            try { population = engine.GetCollection(ref newEngine, initialAge, deathRules); }
            catch (Exception ex) { BeginInvoke(new SendMessage(TellAboutError), ex.Message); return; }
            var year = startYear;
            int i = 0;
            while (year != lastYear)
            {
                year++;
                i++;
                if (InvokeRequired)
                {
                    BeginInvoke(new ChageObject(ShowNewYearData), year, i, population);
                    Thread.Sleep(700);
                }
                else
                    return;
            }
        }

        /// <summary>
        /// Initialise charts and necessary text boxes before dynamic creating of charts.
        /// </summary>
        private void DynamicCreatingOfCharts()
        {
            if (secondThread.IsAlive)
            { TellAboutError("Wait until dynamic modeling will be finished or press button \"Stop\" to finish it"); return; }
            if (!GetStartData())
                return;
            CleanAll();
            InitAllPopulationChart();
            InitMenPopulationChart();
            InitWomenPopulationChart();
            MakeVisibleElements();
            MessageBox.Show("Press \"Pause\" to interrupt modeling for 3 seconds. " +
                "Press \"Stop\" to finish modeling", "DemographicPresentation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            secondThread = new Thread(YearTicks);
            secondThread.Start();
        }
    }
}
