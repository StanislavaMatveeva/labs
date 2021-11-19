
namespace DemographicPresentation
{
    partial class DemographicPresentation
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chartAllPopulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonChooseInitialAgeFile = new System.Windows.Forms.Button();
            this.buttonChooseDeathRulesFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBoxChooseFiles = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEnterStartYear = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEntarLastYear = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEnterAmount = new System.Windows.Forms.RichTextBox();
            this.richTextBoxStartYear = new System.Windows.Forms.RichTextBox();
            this.richTextBoxLastYear = new System.Windows.Forms.RichTextBox();
            this.richTextBoxStartAmount = new System.Windows.Forms.RichTextBox();
            this.buttonStandartMode = new System.Windows.Forms.Button();
            this.chartMenCategories = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartWomenCategories = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.richTextBoxCurrentYearText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxCurrentYearValue = new System.Windows.Forms.RichTextBox();
            this.richTextBoxBirthsText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDeathsText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxMenAmountText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAmountOfWomenText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAllPopulationAmountText = new System.Windows.Forms.RichTextBox();
            this.richTextBoxBirthsValue = new System.Windows.Forms.RichTextBox();
            this.richTextBoxDeathsValue = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAmountOfMenValue = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAmountOfWomenValue = new System.Windows.Forms.RichTextBox();
            this.richTextBoxAllPopulationAmountValue = new System.Windows.Forms.RichTextBox();
            this.buttonDynamicMode = new System.Windows.Forms.Button();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonCleanCharts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartAllPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMenCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWomenCategories)).BeginInit();
            this.SuspendLayout();
            // 
            // chartAllPopulation
            // 
            chartArea4.Name = "ChartArea1";
            this.chartAllPopulation.ChartAreas.Add(chartArea4);
            this.chartAllPopulation.Location = new System.Drawing.Point(832, 62);
            this.chartAllPopulation.Name = "chartAllPopulation";
            this.chartAllPopulation.Size = new System.Drawing.Size(1018, 504);
            this.chartAllPopulation.TabIndex = 2;
            this.chartAllPopulation.Text = "chart3";
            // 
            // buttonChooseInitialAgeFile
            // 
            this.buttonChooseInitialAgeFile.BackColor = System.Drawing.Color.Coral;
            this.buttonChooseInitialAgeFile.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonChooseInitialAgeFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChooseInitialAgeFile.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonChooseInitialAgeFile.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonChooseInitialAgeFile.Location = new System.Drawing.Point(345, 62);
            this.buttonChooseInitialAgeFile.Name = "buttonChooseInitialAgeFile";
            this.buttonChooseInitialAgeFile.Size = new System.Drawing.Size(277, 68);
            this.buttonChooseInitialAgeFile.TabIndex = 5;
            this.buttonChooseInitialAgeFile.Text = "Choose file with Initial ages";
            this.buttonChooseInitialAgeFile.UseVisualStyleBackColor = false;
            this.buttonChooseInitialAgeFile.Click += new System.EventHandler(this.buttonChooseInitialAgeFile_Click);
            // 
            // buttonChooseDeathRulesFile
            // 
            this.buttonChooseDeathRulesFile.BackColor = System.Drawing.Color.Coral;
            this.buttonChooseDeathRulesFile.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonChooseDeathRulesFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChooseDeathRulesFile.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChooseDeathRulesFile.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonChooseDeathRulesFile.Location = new System.Drawing.Point(62, 62);
            this.buttonChooseDeathRulesFile.Name = "buttonChooseDeathRulesFile";
            this.buttonChooseDeathRulesFile.Size = new System.Drawing.Size(277, 68);
            this.buttonChooseDeathRulesFile.TabIndex = 6;
            this.buttonChooseDeathRulesFile.Text = "Choose file with death probabilities";
            this.buttonChooseDeathRulesFile.UseVisualStyleBackColor = false;
            this.buttonChooseDeathRulesFile.Click += new System.EventHandler(this.buttonChooseDeathRulesFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // richTextBoxChooseFiles
            // 
            this.richTextBoxChooseFiles.Font = new System.Drawing.Font("MS Reference Sans Serif", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxChooseFiles.ForeColor = System.Drawing.Color.Maroon;
            this.richTextBoxChooseFiles.Location = new System.Drawing.Point(62, 152);
            this.richTextBoxChooseFiles.Name = "richTextBoxChooseFiles";
            this.richTextBoxChooseFiles.Size = new System.Drawing.Size(560, 96);
            this.richTextBoxChooseFiles.TabIndex = 7;
            this.richTextBoxChooseFiles.Text = "Choose both files before start modeling";
            // 
            // richTextBoxEnterStartYear
            // 
            this.richTextBoxEnterStartYear.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxEnterStartYear.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEnterStartYear.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxEnterStartYear.Location = new System.Drawing.Point(62, 266);
            this.richTextBoxEnterStartYear.Name = "richTextBoxEnterStartYear";
            this.richTextBoxEnterStartYear.Size = new System.Drawing.Size(168, 56);
            this.richTextBoxEnterStartYear.TabIndex = 9;
            this.richTextBoxEnterStartYear.Text = "Enter start year";
            // 
            // richTextBoxEntarLastYear
            // 
            this.richTextBoxEntarLastYear.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxEntarLastYear.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEntarLastYear.Location = new System.Drawing.Point(236, 266);
            this.richTextBoxEntarLastYear.Name = "richTextBoxEntarLastYear";
            this.richTextBoxEntarLastYear.Size = new System.Drawing.Size(168, 56);
            this.richTextBoxEntarLastYear.TabIndex = 10;
            this.richTextBoxEntarLastYear.Text = "Enter last year";
            // 
            // richTextBoxEnterAmount
            // 
            this.richTextBoxEnterAmount.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxEnterAmount.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxEnterAmount.Location = new System.Drawing.Point(410, 266);
            this.richTextBoxEnterAmount.Name = "richTextBoxEnterAmount";
            this.richTextBoxEnterAmount.Size = new System.Drawing.Size(256, 56);
            this.richTextBoxEnterAmount.TabIndex = 11;
            this.richTextBoxEnterAmount.Text = "Enter start amount of people";
            // 
            // richTextBoxStartYear
            // 
            this.richTextBoxStartYear.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxStartYear.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxStartYear.Location = new System.Drawing.Point(62, 328);
            this.richTextBoxStartYear.Name = "richTextBoxStartYear";
            this.richTextBoxStartYear.Size = new System.Drawing.Size(168, 51);
            this.richTextBoxStartYear.TabIndex = 12;
            this.richTextBoxStartYear.Text = "1970";
            // 
            // richTextBoxLastYear
            // 
            this.richTextBoxLastYear.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxLastYear.Location = new System.Drawing.Point(236, 328);
            this.richTextBoxLastYear.Name = "richTextBoxLastYear";
            this.richTextBoxLastYear.Size = new System.Drawing.Size(168, 51);
            this.richTextBoxLastYear.TabIndex = 13;
            this.richTextBoxLastYear.Text = "2021";
            // 
            // richTextBoxStartAmount
            // 
            this.richTextBoxStartAmount.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxStartAmount.Location = new System.Drawing.Point(410, 328);
            this.richTextBoxStartAmount.Name = "richTextBoxStartAmount";
            this.richTextBoxStartAmount.Size = new System.Drawing.Size(256, 51);
            this.richTextBoxStartAmount.TabIndex = 14;
            this.richTextBoxStartAmount.Text = "130079210";
            // 
            // buttonStandartMode
            // 
            this.buttonStandartMode.BackColor = System.Drawing.Color.Coral;
            this.buttonStandartMode.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonStandartMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStandartMode.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonStandartMode.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonStandartMode.Location = new System.Drawing.Point(62, 404);
            this.buttonStandartMode.Name = "buttonStandartMode";
            this.buttonStandartMode.Size = new System.Drawing.Size(210, 79);
            this.buttonStandartMode.TabIndex = 15;
            this.buttonStandartMode.Text = "Standart mode";
            this.buttonStandartMode.UseVisualStyleBackColor = false;
            this.buttonStandartMode.Click += new System.EventHandler(this.buttonStandartMode_Click);
            // 
            // chartMenCategories
            // 
            chartArea5.Name = "ChartArea1";
            this.chartMenCategories.ChartAreas.Add(chartArea5);
            this.chartMenCategories.Location = new System.Drawing.Point(832, 572);
            this.chartMenCategories.Name = "chartMenCategories";
            this.chartMenCategories.Size = new System.Drawing.Size(506, 431);
            this.chartMenCategories.TabIndex = 17;
            this.chartMenCategories.Text = "chart1";
            // 
            // chartWomenCategories
            // 
            chartArea6.Name = "ChartArea1";
            this.chartWomenCategories.ChartAreas.Add(chartArea6);
            this.chartWomenCategories.Location = new System.Drawing.Point(1344, 572);
            this.chartWomenCategories.Name = "chartWomenCategories";
            this.chartWomenCategories.Size = new System.Drawing.Size(506, 431);
            this.chartWomenCategories.TabIndex = 18;
            this.chartWomenCategories.Text = "chart2";
            // 
            // richTextBoxCurrentYearText
            // 
            this.richTextBoxCurrentYearText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxCurrentYearText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxCurrentYearText.Location = new System.Drawing.Point(62, 504);
            this.richTextBoxCurrentYearText.Name = "richTextBoxCurrentYearText";
            this.richTextBoxCurrentYearText.Size = new System.Drawing.Size(310, 51);
            this.richTextBoxCurrentYearText.TabIndex = 20;
            this.richTextBoxCurrentYearText.Text = "Current year";
            // 
            // richTextBoxCurrentYearValue
            // 
            this.richTextBoxCurrentYearValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxCurrentYearValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxCurrentYearValue.Location = new System.Drawing.Point(378, 504);
            this.richTextBoxCurrentYearValue.Name = "richTextBoxCurrentYearValue";
            this.richTextBoxCurrentYearValue.Size = new System.Drawing.Size(162, 51);
            this.richTextBoxCurrentYearValue.TabIndex = 21;
            this.richTextBoxCurrentYearValue.Text = "";
            // 
            // richTextBoxBirthsText
            // 
            this.richTextBoxBirthsText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxBirthsText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxBirthsText.Location = new System.Drawing.Point(62, 573);
            this.richTextBoxBirthsText.Name = "richTextBoxBirthsText";
            this.richTextBoxBirthsText.Size = new System.Drawing.Size(310, 51);
            this.richTextBoxBirthsText.TabIndex = 22;
            this.richTextBoxBirthsText.Text = "Births";
            // 
            // richTextBoxDeathsText
            // 
            this.richTextBoxDeathsText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxDeathsText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxDeathsText.Location = new System.Drawing.Point(62, 644);
            this.richTextBoxDeathsText.Name = "richTextBoxDeathsText";
            this.richTextBoxDeathsText.Size = new System.Drawing.Size(310, 51);
            this.richTextBoxDeathsText.TabIndex = 23;
            this.richTextBoxDeathsText.Text = "Deaths";
            // 
            // richTextBoxMenAmountText
            // 
            this.richTextBoxMenAmountText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxMenAmountText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxMenAmountText.Location = new System.Drawing.Point(62, 712);
            this.richTextBoxMenAmountText.Name = "richTextBoxMenAmountText";
            this.richTextBoxMenAmountText.Size = new System.Drawing.Size(310, 51);
            this.richTextBoxMenAmountText.TabIndex = 24;
            this.richTextBoxMenAmountText.Text = "Amount of men";
            // 
            // richTextBoxAmountOfWomenText
            // 
            this.richTextBoxAmountOfWomenText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxAmountOfWomenText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxAmountOfWomenText.Location = new System.Drawing.Point(62, 779);
            this.richTextBoxAmountOfWomenText.Name = "richTextBoxAmountOfWomenText";
            this.richTextBoxAmountOfWomenText.Size = new System.Drawing.Size(310, 51);
            this.richTextBoxAmountOfWomenText.TabIndex = 25;
            this.richTextBoxAmountOfWomenText.Text = "Amount of women";
            // 
            // richTextBoxAllPopulationAmountText
            // 
            this.richTextBoxAllPopulationAmountText.BackColor = System.Drawing.Color.DarkSalmon;
            this.richTextBoxAllPopulationAmountText.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F);
            this.richTextBoxAllPopulationAmountText.Location = new System.Drawing.Point(62, 847);
            this.richTextBoxAllPopulationAmountText.Name = "richTextBoxAllPopulationAmountText";
            this.richTextBoxAllPopulationAmountText.Size = new System.Drawing.Size(310, 88);
            this.richTextBoxAllPopulationAmountText.TabIndex = 26;
            this.richTextBoxAllPopulationAmountText.Text = "Amount of all population";
            // 
            // richTextBoxBirthsValue
            // 
            this.richTextBoxBirthsValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxBirthsValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxBirthsValue.Location = new System.Drawing.Point(378, 573);
            this.richTextBoxBirthsValue.Name = "richTextBoxBirthsValue";
            this.richTextBoxBirthsValue.Size = new System.Drawing.Size(245, 51);
            this.richTextBoxBirthsValue.TabIndex = 27;
            this.richTextBoxBirthsValue.Text = "";
            // 
            // richTextBoxDeathsValue
            // 
            this.richTextBoxDeathsValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxDeathsValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxDeathsValue.Location = new System.Drawing.Point(378, 644);
            this.richTextBoxDeathsValue.Name = "richTextBoxDeathsValue";
            this.richTextBoxDeathsValue.Size = new System.Drawing.Size(245, 51);
            this.richTextBoxDeathsValue.TabIndex = 28;
            this.richTextBoxDeathsValue.Text = "";
            // 
            // richTextBoxAmountOfMenValue
            // 
            this.richTextBoxAmountOfMenValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxAmountOfMenValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxAmountOfMenValue.Location = new System.Drawing.Point(378, 712);
            this.richTextBoxAmountOfMenValue.Name = "richTextBoxAmountOfMenValue";
            this.richTextBoxAmountOfMenValue.Size = new System.Drawing.Size(245, 51);
            this.richTextBoxAmountOfMenValue.TabIndex = 29;
            this.richTextBoxAmountOfMenValue.Text = "";
            // 
            // richTextBoxAmountOfWomenValue
            // 
            this.richTextBoxAmountOfWomenValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxAmountOfWomenValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxAmountOfWomenValue.Location = new System.Drawing.Point(378, 779);
            this.richTextBoxAmountOfWomenValue.Name = "richTextBoxAmountOfWomenValue";
            this.richTextBoxAmountOfWomenValue.Size = new System.Drawing.Size(245, 51);
            this.richTextBoxAmountOfWomenValue.TabIndex = 30;
            this.richTextBoxAmountOfWomenValue.Text = "";
            // 
            // richTextBoxAllPopulationAmountValue
            // 
            this.richTextBoxAllPopulationAmountValue.Font = new System.Drawing.Font("MS Reference Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxAllPopulationAmountValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.richTextBoxAllPopulationAmountValue.Location = new System.Drawing.Point(378, 847);
            this.richTextBoxAllPopulationAmountValue.Name = "richTextBoxAllPopulationAmountValue";
            this.richTextBoxAllPopulationAmountValue.Size = new System.Drawing.Size(245, 51);
            this.richTextBoxAllPopulationAmountValue.TabIndex = 31;
            this.richTextBoxAllPopulationAmountValue.Text = "";
            // 
            // buttonDynamicMode
            // 
            this.buttonDynamicMode.BackColor = System.Drawing.Color.Coral;
            this.buttonDynamicMode.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonDynamicMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonDynamicMode.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonDynamicMode.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonDynamicMode.Location = new System.Drawing.Point(329, 404);
            this.buttonDynamicMode.Name = "buttonDynamicMode";
            this.buttonDynamicMode.Size = new System.Drawing.Size(211, 79);
            this.buttonDynamicMode.TabIndex = 32;
            this.buttonDynamicMode.Text = "Dynamic mode";
            this.buttonDynamicMode.UseVisualStyleBackColor = false;
            this.buttonDynamicMode.Click += new System.EventHandler(this.buttonDynamicMode_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.BackColor = System.Drawing.Color.Khaki;
            this.buttonPause.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonPause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPause.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonPause.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonPause.Location = new System.Drawing.Point(658, 504);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(142, 79);
            this.buttonPause.TabIndex = 33;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = false;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.IndianRed;
            this.buttonStop.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonStop.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonStop.Location = new System.Drawing.Point(658, 589);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(142, 79);
            this.buttonStop.TabIndex = 35;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click_1);
            // 
            // buttonCleanCharts
            // 
            this.buttonCleanCharts.BackColor = System.Drawing.Color.Coral;
            this.buttonCleanCharts.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.buttonCleanCharts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCleanCharts.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F);
            this.buttonCleanCharts.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.buttonCleanCharts.Location = new System.Drawing.Point(589, 404);
            this.buttonCleanCharts.Name = "buttonCleanCharts";
            this.buttonCleanCharts.Size = new System.Drawing.Size(211, 79);
            this.buttonCleanCharts.TabIndex = 36;
            this.buttonCleanCharts.Text = "Clean charts";
            this.buttonCleanCharts.UseVisualStyleBackColor = false;
            this.buttonCleanCharts.Click += new System.EventHandler(this.buttonCleanCharts_Click);
            // 
            // DemographicPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.buttonCleanCharts);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonPause);
            this.Controls.Add(this.buttonDynamicMode);
            this.Controls.Add(this.richTextBoxAllPopulationAmountValue);
            this.Controls.Add(this.richTextBoxAmountOfWomenValue);
            this.Controls.Add(this.richTextBoxAmountOfMenValue);
            this.Controls.Add(this.richTextBoxDeathsValue);
            this.Controls.Add(this.richTextBoxBirthsValue);
            this.Controls.Add(this.richTextBoxAllPopulationAmountText);
            this.Controls.Add(this.richTextBoxAmountOfWomenText);
            this.Controls.Add(this.richTextBoxMenAmountText);
            this.Controls.Add(this.richTextBoxDeathsText);
            this.Controls.Add(this.richTextBoxBirthsText);
            this.Controls.Add(this.richTextBoxCurrentYearValue);
            this.Controls.Add(this.richTextBoxCurrentYearText);
            this.Controls.Add(this.chartWomenCategories);
            this.Controls.Add(this.chartMenCategories);
            this.Controls.Add(this.buttonStandartMode);
            this.Controls.Add(this.richTextBoxStartAmount);
            this.Controls.Add(this.richTextBoxLastYear);
            this.Controls.Add(this.richTextBoxStartYear);
            this.Controls.Add(this.richTextBoxEnterAmount);
            this.Controls.Add(this.richTextBoxEntarLastYear);
            this.Controls.Add(this.richTextBoxEnterStartYear);
            this.Controls.Add(this.richTextBoxChooseFiles);
            this.Controls.Add(this.buttonChooseDeathRulesFile);
            this.Controls.Add(this.buttonChooseInitialAgeFile);
            this.Controls.Add(this.chartAllPopulation);
            this.Name = "DemographicPresentation";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DemographicPresentation_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.chartAllPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMenCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartWomenCategories)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAllPopulation;
        private System.Windows.Forms.Button buttonChooseInitialAgeFile;
        private System.Windows.Forms.Button buttonChooseDeathRulesFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox richTextBoxChooseFiles;
        private System.Windows.Forms.RichTextBox richTextBoxEnterStartYear;
        private System.Windows.Forms.RichTextBox richTextBoxEntarLastYear;
        private System.Windows.Forms.RichTextBox richTextBoxEnterAmount;
        private System.Windows.Forms.RichTextBox richTextBoxStartYear;
        private System.Windows.Forms.RichTextBox richTextBoxLastYear;
        private System.Windows.Forms.RichTextBox richTextBoxStartAmount;
        private System.Windows.Forms.Button buttonStandartMode;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMenCategories;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWomenCategories;
        private System.Windows.Forms.RichTextBox richTextBoxCurrentYearText;
        private System.Windows.Forms.RichTextBox richTextBoxCurrentYearValue;
        private System.Windows.Forms.RichTextBox richTextBoxBirthsText;
        private System.Windows.Forms.RichTextBox richTextBoxDeathsText;
        private System.Windows.Forms.RichTextBox richTextBoxMenAmountText;
        private System.Windows.Forms.RichTextBox richTextBoxAmountOfWomenText;
        private System.Windows.Forms.RichTextBox richTextBoxAllPopulationAmountText;
        private System.Windows.Forms.RichTextBox richTextBoxBirthsValue;
        private System.Windows.Forms.RichTextBox richTextBoxDeathsValue;
        private System.Windows.Forms.RichTextBox richTextBoxAmountOfMenValue;
        private System.Windows.Forms.RichTextBox richTextBoxAmountOfWomenValue;
        private System.Windows.Forms.RichTextBox richTextBoxAllPopulationAmountValue;
        private System.Windows.Forms.Button buttonDynamicMode;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonCleanCharts;
    }
}

