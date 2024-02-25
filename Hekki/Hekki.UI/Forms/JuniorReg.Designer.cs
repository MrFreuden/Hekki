namespace Hekki
{
    partial class JuniorReg
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
            DoQualRandom = new Button();
            DoQualByList = new Button();
            DoRace1 = new Button();
            DoRace2 = new Button();
            DoFinal = new Button();
            RebuildPilots = new Button();
            ReadScores = new Button();
            SortScores = new Button();
            ReadTimes = new Button();
            SortTimes = new Button();
            numbersOfKarts = new RichTextBox();
            DoFinalDed = new Button();
            DoQualDead = new Button();
            SortTimeDead = new Button();
            SuspendLayout();
            // 
            // Clear
            // 
            Clear.Location = new Point(235, 554);
            Clear.Margin = new Padding(4);
            Clear.Name = "Clear";
            Clear.Size = new Size(160, 68);
            Clear.TabIndex = 1;
            Clear.Text = "Очистить";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // DoQualRandom
            // 
            DoQualRandom.Location = new Point(49, 28);
            DoQualRandom.Margin = new Padding(4);
            DoQualRandom.Name = "DoQualRandom";
            DoQualRandom.Size = new Size(212, 114);
            DoQualRandom.TabIndex = 3;
            DoQualRandom.Text = "Распределить Квалу случайно";
            DoQualRandom.UseVisualStyleBackColor = true;
            DoQualRandom.Click += DoQualRandom_Click;
            // 
            // DoQualByList
            // 
            DoQualByList.Location = new Point(49, 160);
            DoQualByList.Margin = new Padding(4);
            DoQualByList.Name = "DoQualByList";
            DoQualByList.Size = new Size(212, 114);
            DoQualByList.TabIndex = 4;
            DoQualByList.Text = "Распределить Квалу По списку";
            DoQualByList.UseVisualStyleBackColor = true;
            DoQualByList.Click += DoQualByList_Click;
            // 
            // DoRace1
            // 
            DoRace1.Location = new Point(371, 99);
            DoRace1.Margin = new Padding(4);
            DoRace1.Name = "DoRace1";
            DoRace1.Size = new Size(212, 114);
            DoRace1.TabIndex = 5;
            DoRace1.Text = "Распределить Гонку 1";
            DoRace1.UseVisualStyleBackColor = true;
            DoRace1.Click += DoRace1_Click;
            // 
            // DoRace2
            // 
            DoRace2.Location = new Point(635, 99);
            DoRace2.Margin = new Padding(4);
            DoRace2.Name = "DoRace2";
            DoRace2.Size = new Size(212, 114);
            DoRace2.TabIndex = 6;
            DoRace2.Text = "Распределить Гонку 2";
            DoRace2.UseVisualStyleBackColor = true;
            DoRace2.Click += DoRace2_Click;
            // 
            // DoFinal
            // 
            DoFinal.Location = new Point(900, 99);
            DoFinal.Margin = new Padding(4);
            DoFinal.Name = "DoFinal";
            DoFinal.Size = new Size(212, 114);
            DoFinal.TabIndex = 7;
            DoFinal.Text = "Распределить Финал";
            DoFinal.UseVisualStyleBackColor = true;
            DoFinal.Click += DoFinal_Click;
            // 
            // RebuildPilots
            // 
            RebuildPilots.Location = new Point(424, 419);
            RebuildPilots.Margin = new Padding(4);
            RebuildPilots.Name = "RebuildPilots";
            RebuildPilots.Size = new Size(160, 104);
            RebuildPilots.TabIndex = 9;
            RebuildPilots.Text = "Пересобрать пилотов";
            RebuildPilots.UseVisualStyleBackColor = true;
            RebuildPilots.Click += RebuildPilots_Click;
            // 
            // ReadScores
            // 
            ReadScores.Location = new Point(799, 406);
            ReadScores.Margin = new Padding(4);
            ReadScores.Name = "ReadScores";
            ReadScores.Size = new Size(160, 104);
            ReadScores.TabIndex = 10;
            ReadScores.Text = "Перенести балы в общую таблицу";
            ReadScores.UseVisualStyleBackColor = true;
            ReadScores.Click += ReadScores_Click;
            // 
            // SortScores
            // 
            SortScores.Location = new Point(989, 406);
            SortScores.Margin = new Padding(4);
            SortScores.Name = "SortScores";
            SortScores.Size = new Size(160, 104);
            SortScores.TabIndex = 11;
            SortScores.Text = "Сортировать общую таблицу по балам";
            SortScores.UseVisualStyleBackColor = true;
            SortScores.Click += SortScores_Click;
            // 
            // ReadTimes
            // 
            ReadTimes.Location = new Point(799, 518);
            ReadTimes.Margin = new Padding(4);
            ReadTimes.Name = "ReadTimes";
            ReadTimes.Size = new Size(160, 104);
            ReadTimes.TabIndex = 12;
            ReadTimes.Text = "Перенести время в общую таблицу";
            ReadTimes.UseVisualStyleBackColor = true;
            ReadTimes.Click += ReadTimes_Click;
            // 
            // SortTimes
            // 
            SortTimes.Location = new Point(989, 518);
            SortTimes.Margin = new Padding(4);
            SortTimes.Name = "SortTimes";
            SortTimes.Size = new Size(160, 104);
            SortTimes.TabIndex = 13;
            SortTimes.Text = "Сортировать времена";
            SortTimes.UseVisualStyleBackColor = true;
            SortTimes.Click += SortTimes_Click;
            // 
            // numbersOfKarts
            // 
            numbersOfKarts.Location = new Point(38, 419);
            numbersOfKarts.Margin = new Padding(4);
            numbersOfKarts.Name = "numbersOfKarts";
            numbersOfKarts.Size = new Size(155, 202);
            numbersOfKarts.TabIndex = 14;
            numbersOfKarts.Text = "";
            numbersOfKarts.TextChanged += numbersOfKarts_TextChanged;
            numbersOfKarts.KeyPress += numbersOfKarts_KeyPress;
            // 
            // DoFinalDed
            // 
            DoFinalDed.Location = new Point(837, 243);
            DoFinalDed.Margin = new Padding(4);
            DoFinalDed.Name = "DoFinalDed";
            DoFinalDed.Size = new Size(212, 114);
            DoFinalDed.TabIndex = 15;
            DoFinalDed.Text = "Распределить Финал Дед";
            DoFinalDed.UseVisualStyleBackColor = true;
            DoFinalDed.Click += DoFinalDed_Click;
            // 
            // DoQualDead
            // 
            DoQualDead.Location = new Point(372, 248);
            DoQualDead.Margin = new Padding(4);
            DoQualDead.Name = "DoQualDead";
            DoQualDead.Size = new Size(212, 114);
            DoQualDead.TabIndex = 16;
            DoQualDead.Text = "Распределить Квалу Дед";
            DoQualDead.UseVisualStyleBackColor = true;
            DoQualDead.Click += DoQualDead_Click;
            // 
            // SortTimeDead
            // 
            SortTimeDead.Location = new Point(635, 248);
            SortTimeDead.Margin = new Padding(4);
            SortTimeDead.Name = "SortTimeDead";
            SortTimeDead.Size = new Size(160, 104);
            SortTimeDead.TabIndex = 17;
            SortTimeDead.Text = "Сортировать времена Дед";
            SortTimeDead.UseVisualStyleBackColor = true;
            SortTimeDead.Click += SortTimeDead_Click;
            // 
            // JuniorReg
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 655);
            Controls.Add(SortTimeDead);
            Controls.Add(DoQualDead);
            Controls.Add(DoFinalDed);
            Controls.Add(numbersOfKarts);
            Controls.Add(SortTimes);
            Controls.Add(ReadTimes);
            Controls.Add(SortScores);
            Controls.Add(ReadScores);
            Controls.Add(RebuildPilots);
            Controls.Add(DoFinal);
            Controls.Add(DoRace2);
            Controls.Add(DoRace1);
            Controls.Add(DoQualByList);
            Controls.Add(DoQualRandom);
            Controls.Add(Clear);
            Margin = new Padding(4);
            Name = "JuniorReg";
            Text = "JuniorReg";
            ResumeLayout(false);
        }

        #endregion

        private Button Clear;
        private Button DoQualRandom;
        private Button DoQualByList;
        private Button DoRace1;
        private Button DoRace2;
        private Button DoFinal;
        private Button RebuildPilots;
        private Button ReadScores;
        private Button SortScores;
        private Button ReadTimes;
        private Button SortTimes;
        private RichTextBox numbersOfKarts;
        private Button DoFinalDed;
        private Button DoQualDead;
        private Button SortTimeDead;
    }
}