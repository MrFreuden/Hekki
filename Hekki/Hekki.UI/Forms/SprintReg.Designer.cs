namespace Hekki
{
    partial class SprintReg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Clear = new Button();
            numbersOfKarts = new RichTextBox();
            DoFinalPro = new Button();
            RebuildPilots = new Button();
            DeleteKartsFromLastRace = new Button();
            ReadScores = new Button();
            SortScores = new Button();
            DoFinalAmator = new Button();
            SortByLique = new Button();
            DoQualRandom = new Button();
            DoQualByList = new Button();
            DoHeat1 = new Button();
            DoHeat2 = new Button();
            button1 = new Button();
            ReadTimes = new Button();
            SortTimes = new Button();
            SuspendLayout();
            // 
            // Clear
            // 
            Clear.Location = new Point(228, 542);
            Clear.Margin = new Padding(4);
            Clear.Name = "Clear";
            Clear.Size = new Size(160, 68);
            Clear.TabIndex = 0;
            Clear.Text = "Очистить";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // numbersOfKarts
            // 
            numbersOfKarts.Location = new Point(38, 408);
            numbersOfKarts.Margin = new Padding(4);
            numbersOfKarts.Name = "numbersOfKarts";
            numbersOfKarts.Size = new Size(155, 202);
            numbersOfKarts.TabIndex = 15;
            numbersOfKarts.Text = "";
            numbersOfKarts.TextChanged += numbersOfKarts_TextChanged;
            numbersOfKarts.KeyPress += numbersOfKarts_KeyPress;
            // 
            // DoFinalPro
            // 
            DoFinalPro.Location = new Point(968, 42);
            DoFinalPro.Margin = new Padding(4);
            DoFinalPro.Name = "DoFinalPro";
            DoFinalPro.Size = new Size(212, 114);
            DoFinalPro.TabIndex = 20;
            DoFinalPro.Text = "Распределить финал про";
            DoFinalPro.UseVisualStyleBackColor = true;
            DoFinalPro.Click += DoFinalPro_Click;
            // 
            // RebuildPilots
            // 
            RebuildPilots.Location = new Point(419, 408);
            RebuildPilots.Margin = new Padding(4);
            RebuildPilots.Name = "RebuildPilots";
            RebuildPilots.Size = new Size(160, 104);
            RebuildPilots.TabIndex = 23;
            RebuildPilots.Text = "Пересобрать пилотов";
            RebuildPilots.UseVisualStyleBackColor = true;
            RebuildPilots.Click += RebuildPilots_Click;
            // 
            // DeleteKartsFromLastRace
            // 
            DeleteKartsFromLastRace.Location = new Point(419, 525);
            DeleteKartsFromLastRace.Margin = new Padding(4);
            DeleteKartsFromLastRace.Name = "DeleteKartsFromLastRace";
            DeleteKartsFromLastRace.Size = new Size(160, 104);
            DeleteKartsFromLastRace.TabIndex = 28;
            DeleteKartsFromLastRace.Text = "Удалить карты с последнего хита";
            DeleteKartsFromLastRace.UseVisualStyleBackColor = true;
            DeleteKartsFromLastRace.Click += DeleteKartsFromLastRace_Click;
            // 
            // ReadScores
            // 
            ReadScores.Location = new Point(841, 408);
            ReadScores.Margin = new Padding(4);
            ReadScores.Name = "ReadScores";
            ReadScores.Size = new Size(160, 104);
            ReadScores.TabIndex = 29;
            ReadScores.Text = "Перенести балы в общую таблицу";
            ReadScores.UseVisualStyleBackColor = true;
            ReadScores.Click += ReadScores_Click;
            // 
            // SortScores
            // 
            SortScores.Location = new Point(1020, 408);
            SortScores.Margin = new Padding(4);
            SortScores.Name = "SortScores";
            SortScores.Size = new Size(160, 104);
            SortScores.TabIndex = 30;
            SortScores.Text = "Сортировать общую таблицу по балам";
            SortScores.UseVisualStyleBackColor = true;
            SortScores.Click += SortScores_Click;
            // 
            // DoFinalAmator
            // 
            DoFinalAmator.Location = new Point(968, 194);
            DoFinalAmator.Margin = new Padding(4);
            DoFinalAmator.Name = "DoFinalAmator";
            DoFinalAmator.Size = new Size(212, 114);
            DoFinalAmator.TabIndex = 31;
            DoFinalAmator.Text = "Распределить финал аматоров";
            DoFinalAmator.UseVisualStyleBackColor = true;
            DoFinalAmator.Click += DoFinalAmator_Click;
            // 
            // SortByLique
            // 
            SortByLique.Location = new Point(664, 524);
            SortByLique.Margin = new Padding(4);
            SortByLique.Name = "SortByLique";
            SortByLique.Size = new Size(160, 104);
            SortByLique.TabIndex = 32;
            SortByLique.Text = "Сортировать по лигам";
            SortByLique.UseVisualStyleBackColor = true;
            SortByLique.Click += SortByLique_Click;
            // 
            // DoQualRandom
            // 
            DoQualRandom.Location = new Point(38, 28);
            DoQualRandom.Margin = new Padding(4);
            DoQualRandom.Name = "DoQualRandom";
            DoQualRandom.Size = new Size(212, 114);
            DoQualRandom.TabIndex = 33;
            DoQualRandom.Text = "Распределить Квалу случайно";
            DoQualRandom.UseVisualStyleBackColor = true;
            DoQualRandom.Click += DoQualRandom_Click;
            // 
            // DoQualByList
            // 
            DoQualByList.Location = new Point(38, 181);
            DoQualByList.Margin = new Padding(4);
            DoQualByList.Name = "DoQualByList";
            DoQualByList.Size = new Size(212, 114);
            DoQualByList.TabIndex = 34;
            DoQualByList.Text = "Распределить Квалу По списку";
            DoQualByList.UseVisualStyleBackColor = true;
            DoQualByList.Click += DoQualByList_Click;
            // 
            // DoHeat1
            // 
            DoHeat1.Location = new Point(283, 101);
            DoHeat1.Margin = new Padding(4);
            DoHeat1.Name = "DoHeat1";
            DoHeat1.Size = new Size(212, 114);
            DoHeat1.TabIndex = 35;
            DoHeat1.Text = "Распределить 1 хит";
            DoHeat1.UseVisualStyleBackColor = true;
            DoHeat1.Click += DoHeat1_Click;
            // 
            // DoHeat2
            // 
            DoHeat2.Location = new Point(503, 101);
            DoHeat2.Margin = new Padding(4);
            DoHeat2.Name = "DoHeat2";
            DoHeat2.Size = new Size(212, 114);
            DoHeat2.TabIndex = 36;
            DoHeat2.Text = "Распределить 2 хит";
            DoHeat2.UseVisualStyleBackColor = true;
            DoHeat2.Click += DoHeat2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(723, 101);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(212, 114);
            button1.TabIndex = 37;
            button1.Text = "Распределить 3 хит";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ReadTimes
            // 
            ReadTimes.Location = new Point(841, 525);
            ReadTimes.Margin = new Padding(4);
            ReadTimes.Name = "ReadTimes";
            ReadTimes.Size = new Size(160, 104);
            ReadTimes.TabIndex = 38;
            ReadTimes.Text = "Перенести время в общую таблицу";
            ReadTimes.UseVisualStyleBackColor = true;
            ReadTimes.Click += ReadTimes_Click;
            // 
            // SortTimes
            // 
            SortTimes.Location = new Point(1020, 525);
            SortTimes.Margin = new Padding(4);
            SortTimes.Name = "SortTimes";
            SortTimes.Size = new Size(160, 104);
            SortTimes.TabIndex = 39;
            SortTimes.Text = "Сортировать времена";
            SortTimes.UseVisualStyleBackColor = true;
            SortTimes.Click += SortTimes_Click;
            // 
            // SprintReg
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 655);
            Controls.Add(SortTimes);
            Controls.Add(ReadTimes);
            Controls.Add(button1);
            Controls.Add(DoHeat2);
            Controls.Add(DoHeat1);
            Controls.Add(DoQualByList);
            Controls.Add(DoQualRandom);
            Controls.Add(SortByLique);
            Controls.Add(DoFinalAmator);
            Controls.Add(SortScores);
            Controls.Add(ReadScores);
            Controls.Add(DeleteKartsFromLastRace);
            Controls.Add(RebuildPilots);
            Controls.Add(DoFinalPro);
            Controls.Add(numbersOfKarts);
            Controls.Add(Clear);
            Margin = new Padding(4);
            Name = "SprintReg";
            Text = "SprintReg";
            ResumeLayout(false);
        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoFinalPro;
        private Button RebuildPilots;
        private Button DeleteKartsFromLastRace;
        private Button ReadScores;
        private Button SortScores;
        private Button DoFinalAmator;
        private Button SortByLique;
        private Button DoQualRandom;
        private Button DoQualByList;
        private Button DoHeat1;
        private Button DoHeat2;
        private Button button1;
        private Button ReadTimes;
        private Button SortTimes;
    }
}