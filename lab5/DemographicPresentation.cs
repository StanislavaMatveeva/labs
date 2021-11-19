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
        const int defaultStartYear = 1970;
        const int defaultLastYear = 2021;
        const int defaultStartAmount = 130000000;
        int startYear;
        int lastYear;
        double startAmount;
        int[,] categories;
        IInitialAgesFiler initialAge = new InitialAge();
        IDeathRulesFiler deathRules = new DeathRules();
        IEngine engine = new Engine(new List<Person>());

        public DemographicPresentation()
        {
            InitializeComponent(); 
            categories = new int[,] { { 0, 18 }, { 19, 45 }, { 46, 65 }, { 66, 100 } };
            secondThread = new Thread(YearTicks);
            startAmount = defaultStartAmount;
            startYear = defaultStartYear;
            lastYear = defaultLastYear;
            buttonStandartMode.Enabled = false;
            buttonDynamicMode.Enabled = false;
            buttonCleanCharts.Enabled = false;
            buttonPause.Visible = false;
            buttonStop.Visible = false;
            richTextBoxAllPopulationAmountText.Visible = false;
            richTextBoxAllPopulationAmountValue.Visible = false;
            richTextBoxMenAmountText.Visible = false;
            richTextBoxAmountOfMenValue.Visible = false;
            richTextBoxAmountOfWomenText.Visible = false;
            richTextBoxAmountOfWomenValue.Visible = false;
            richTextBoxBirthsText.Visible = false;
            richTextBoxBirthsValue.Visible = false;
            richTextBoxDeathsText.Visible = false;
            richTextBoxDeathsValue.Visible = false;
            richTextBoxCurrentYearText.Visible = false;
            richTextBoxCurrentYearValue.Visible = false;
        }

        /// <summary>
        /// Gets name of file with death rules for people of different ages and genders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseDeathRulesFile_Click(object sender, EventArgs e)
        {
            if (secondThread.IsAlive)
            { TellAboutError("Wait until dynamic modeling will be finished or press button \"Stop\" to finish it"); return; }
            MakeUnabled();
            openFileDialog1.Filter = "csv files(*.csv)|*.csv|All files(*.*)|*.*";
            openFileDialog1.ShowDialog();
            deathRules.FileName = openFileDialog1.FileName;
            try { deathRules.CheckFile(); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            richTextBoxChooseFiles.Text = " You choosed " + deathRules.FileName.ToString();
            if (initialAge.FileName != null)
                MakeEnabled();
        }

        /// <summary>
        /// Gets name of file with start ages and amount of people of different genders.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseInitialAgeFile_Click(object sender, EventArgs e)
        {
            if (secondThread.IsAlive)
            { TellAboutError("Wait until dynamic modeling will be finished or press button \"Stop\" to finish it"); return; }
            MakeUnabled();
            openFileDialog1.Filter = "csv files(*.csv)|*.csv|All files(*.*)|*.*";
            openFileDialog1.ShowDialog();
            initialAge.FileName = openFileDialog1.FileName;
            try { initialAge.CheckFile(); }
            catch (Exception ex) { TellAboutError(ex.Message); return; }
            richTextBoxChooseFiles.Text = " You choosed " + initialAge.FileName.ToString();
            if (deathRules.FileName != null)
                MakeEnabled();
        }

        /// <summary>
        /// Shows error's message in MessageBox.
        /// </summary>
        /// <param name="message">Text of message, that should be shown in MessageBox.</param>
        private void TellAboutError(string message)
        {
            MessageBox.Show(message, "DemographicPresentation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TellInformation(string message)
        {
            MessageBox.Show(message, "DemographicPresentation", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Checks if form should be closed or not.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DemographicPresentation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to finish modeling?", "DemographicPresentation", MessageBoxButtons.YesNo) == DialogResult.No)
                e.Cancel = true;
        }

        /// <summary>
        /// Gets start year of modeling.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when value of start year of modeling is invalid.</exception>
        /// <exception cref="Exception">Is thrown, when value of start year of modeling is less, then 1970
        /// or more then 2020.</exception>
        /// <returns>Value of last year of modeling.</returns>
        private int GetStartYear()
        {
            if (!int.TryParse(richTextBoxStartYear.Text, out startYear))
            { throw new Exception("Wrong value of start year"); }
            else if (startYear < defaultStartYear || startYear > defaultLastYear - 1)
            {
                throw new Exception("Wrong value of start year. It can't be less, then 1970" +
                        " and more, then 2020");
            }
            else
                return startYear;
        }

        /// <summary>
        /// Gets last yaer of modeling.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when value of last year of modeling is invalid.</exception>
        /// <exception cref="Exception">Is thrown, when value of last year of modeling is less, 
        /// then 1971 or more, then 2030.</exception>
        /// <returns>Value of last year of modeling.</returns>
        private int GetLastYear()
        {
            if (!int.TryParse(richTextBoxLastYear.Text, out lastYear))
            { throw new Exception("Wrong value of last year"); }
            else if (lastYear < defaultStartYear + 1 || lastYear > defaultLastYear + 10)
            {
                throw new Exception("Wrong value of last year. It can't be less, then 1971" +
                        " and more, then 2030");
            }
            else
                return lastYear;
        }

        /// <summary>
        /// Gets start amount of population.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when value of start amount is invalid.</exception>
        /// <exception cref="Exception">Is thrown, when value of start amount is less, then 130000000
        /// or more, then 140000000.</exception>
        /// <returns>Amount of population.</returns>
        private double GetStartAmount()
        {
            if (!double.TryParse(richTextBoxStartAmount.Text, out startAmount))
            { throw new Exception("Wrong value of start amount"); }
            else if (startAmount < defaultStartAmount || startAmount > defaultStartAmount + 100000000)
            {
                throw new Exception("Wrong value of start amount: it can't be less, then 130000000" +
                        " or more, then 140000000");
            }
            else
                return startAmount / 1000;
        }

        /// <summary>
        /// Gets start data from text boxes.
        /// </summary>
        /// <exception cref="Exception">Is thrown, when last year is less, then start year
        /// or equal to it</exception>
        private bool GetStartData()
        {
            var check = true;
            try { startAmount = GetStartAmount(); }
            catch (Exception ex) 
            { TellInformation(ex.Message); richTextBoxStartAmount.Text = defaultStartAmount.ToString(); check = false; }
            try { startYear = GetStartYear(); }
            catch(Exception ex) { TellInformation(ex.Message); richTextBoxStartYear.Text = defaultStartYear.ToString(); check = false; }
            try { lastYear = GetLastYear(); }
            catch (Exception ex) { TellInformation(ex.Message); richTextBoxLastYear.Text = defaultLastYear.ToString(); check = false; }
            if (lastYear <= startYear)
            {
                TellInformation("Last year can't be less, then start year or equal to it");
                richTextBoxLastYear.Text = defaultLastYear.ToString();
                check = false;
            }
            return check;
        }

        /// <summary>
        /// Cleans all charts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCleanCharts_Click(object sender, EventArgs e)
        {
            if (secondThread.IsAlive)
            { TellAboutError("Wait until dynamic modeling will be finished or press button \"Stop\" to finish it"); return; }
            CleanAll();
        }

        /// <summary>
        /// Initialises series of all population chart.
        /// </summary>
        private void InitAllPopulationChart()
        {
            chartAllPopulation.Series.Clear();
            chartAllPopulation.Titles.Clear();
            chartAllPopulation.Legends.Clear();
            chartAllPopulation.Titles.Add("All population");
            chartAllPopulation.Legends.Add("population dynamics");
            chartAllPopulation.Series.Add(new Series("all population"));
            chartAllPopulation.Series["all population"].Legend = "population dynamics";
            chartAllPopulation.Series["all population"].IsVisibleInLegend = true;
            chartAllPopulation.Series["all population"].ToolTip = "#VALX: #VALY"; 
            chartAllPopulation.Series["all population"].ChartType = SeriesChartType.Spline;
            chartAllPopulation.Series["all population"].Color = Color.MidnightBlue;
            chartAllPopulation.Series["all population"].BorderWidth = 3;
        }

        /// <summary>
        /// Initialises series of men's population chart.
        /// </summary>
        private void InitMenPopulationChart()
        {
            chartAllPopulation.Series.Add(new Series("men's population"));
            chartAllPopulation.Series["men's population"].ToolTip = "#VALX: #VALY";
            chartAllPopulation.Series["men's population"].ChartType = SeriesChartType.Spline;
            chartAllPopulation.Series["men's population"].Color = Color.RoyalBlue;
            chartAllPopulation.Series["men's population"].BorderWidth = 3;
        }

        /// <summary>
        /// Initialises series of women's population chart.
        /// </summary>
        private void InitWomenPopulationChart()
        {
            chartAllPopulation.Series.Add(new Series("women's population"));
            chartAllPopulation.Series["women's population"].ToolTip = "#VALX: #VALY";
            chartAllPopulation.Series["women's population"].ChartType = SeriesChartType.Spline;
            chartAllPopulation.Series["women's population"].Color = Color.Coral;
            chartAllPopulation.Series["women's population"].BorderWidth = 3;
        }

        /// <summary>
        /// Initialises chart for men's population amount by categories of ages.
        /// </summary>
        private void InitMenPopulationByCategoriesChart()
        {
            chartMenCategories.Series.Clear();
            chartMenCategories.Titles.Clear();
            chartMenCategories.Legends.Clear();
            chartMenCategories.Titles.Add("Men's population by categories");
            chartMenCategories.Legends.Add("men's categories");
            var palette = new Color[] { Color.RoyalBlue, Color.DeepSkyBlue, Color.LightSkyBlue, Color.SteelBlue };
            for (int i = 0; i < 4; i++)
            {
                chartMenCategories.Series.Add(new Series($"{categories[i, 0]} - {categories[i, 1]}"));
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].ToolTip = "#VALY";
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Legend = "men's categories";
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].IsVisibleInLegend = true;
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].ChartType = SeriesChartType.Bar;
                chartMenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Color = palette[i];
            }
        }

        /// <summary>
        /// Initialises chart for women's popultion amount by categories of ages.
        /// </summary>
        private void InitWomenPopulationByCategoriesChart()
        {
            chartWomenCategories.Series.Clear();
            chartWomenCategories.Titles.Clear();
            chartWomenCategories.Legends.Clear();
            chartWomenCategories.Titles.Add("Women's population by categories");
            chartWomenCategories.Legends.Add("women's categories");
            var palette = new Color[] { Color.Tomato, Color.OrangeRed, Color.Coral, Color.LightSalmon };
            for (int i = 0; i < 4; i++)
            {
                chartWomenCategories.Series.Add(new Series($"{categories[i, 0]} - {categories[i, 1]}"));
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].ToolTip = "#VALY";
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Legend = "women's categories";
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].IsVisibleInLegend = true;
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].ChartType = SeriesChartType.Bar;
                chartWomenCategories.Series[$"{categories[i, 0]} - {categories[i, 1]}"].Color = palette[i];
            }
        }

        /// <summary>
        /// Clears all charts and text boxes.
        /// </summary>
        private void CleanAll()
        {
            chartAllPopulation.Series.Clear();
            chartAllPopulation.Titles.Clear();
            chartAllPopulation.Legends.Clear();
            chartMenCategories.Series.Clear();
            chartMenCategories.Titles.Clear();
            chartMenCategories.Legends.Clear();
            chartWomenCategories.Series.Clear();
            chartWomenCategories.Titles.Clear();
            chartWomenCategories.Legends.Clear();
        }

        /// <summary>
        /// Makes enabled buttonStandartMode, buttonDynamicMode and buttonCleanCharts.
        /// </summary>
        private void MakeEnabled()
        {
            buttonStandartMode.Enabled = true;
            buttonDynamicMode.Enabled = true;
            buttonCleanCharts.Enabled = true;
        }

        /// <summary>
        /// Makes unabled buttonStandartMode, buttonDynamicMode and buttonCleanCharts.
        /// </summary>
        private void MakeUnabled()
        {
            buttonStandartMode.Enabled = false;
            buttonDynamicMode.Enabled = false;
            buttonCleanCharts.Enabled = false;
        }

        /// <summary>
        /// Makes buttons and text boxes for dynamic modeling invisible.
        /// </summary>
        private void MakeInvisibleElements()
        {
            buttonPause.Visible = false;
            buttonStop.Visible = false;
            richTextBoxAllPopulationAmountText.Visible = false;
            richTextBoxAllPopulationAmountValue.Visible = false;
            richTextBoxMenAmountText.Visible = false;
            richTextBoxAmountOfMenValue.Visible = false;
            richTextBoxAmountOfWomenText.Visible = false;
            richTextBoxAmountOfWomenValue.Visible = false;
            richTextBoxBirthsText.Visible = false;
            richTextBoxBirthsValue.Visible = false;
            richTextBoxDeathsText.Visible = false;
            richTextBoxDeathsValue.Visible = false;
            richTextBoxCurrentYearText.Visible = false;
            richTextBoxCurrentYearValue.Visible = false;
        }

        /// <summary>
        /// Makes buttons and text boxes for dynamic modeling invisible.
        /// </summary>
        private void MakeVisibleElements()
        {
            buttonPause.Visible = true;
            buttonStop.Visible = true;
            richTextBoxAllPopulationAmountText.Visible = true;
            richTextBoxAllPopulationAmountValue.Visible = true;
            richTextBoxMenAmountText.Visible = true;
            richTextBoxAmountOfMenValue.Visible = true;
            richTextBoxAmountOfWomenText.Visible = true;
            richTextBoxAmountOfWomenValue.Visible = true;
            richTextBoxBirthsText.Visible = true;
            richTextBoxBirthsValue.Visible = true;
            richTextBoxDeathsText.Visible = true;
            richTextBoxDeathsValue.Visible = true;
            richTextBoxCurrentYearText.Visible = true;
            richTextBoxCurrentYearValue.Visible = true;
            richTextBoxAllPopulationAmountValue.Clear();
            richTextBoxAmountOfMenValue.Clear();
            richTextBoxAmountOfWomenValue.Clear();
            richTextBoxBirthsValue.Clear();
            richTextBoxDeathsValue.Clear();
            richTextBoxCurrentYearValue.Clear();
        }
    }
}
