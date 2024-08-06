namespace Hekki
{
    partial class SprintNewReg
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
            DoQual1 = new Button();
            DoHeat1 = new Button();
            DoQual2 = new Button();
            DoHeat2 = new Button();
            DoFinal = new Button();
            RebuildPilots = new Button();
            ReadScores = new Button();
            SortScores = new Button();
            ReadTimes = new Button();
            SortTimes = new Button();
            DeleteKartsFromLastRace = new Button();
            DoSemiFinal = new Button();
            SortTimeDead = new Button();
            SuspendLayout();
            // 
            // Clear
            // 
            Clear.Location = new Point(224, 546);
            Clear.Margin = new Padding(4);
            Clear.Name = "Clear";
            Clear.Size = new Size(160, 68);
            Clear.TabIndex = 1;
            Clear.Text = "Очистить";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // numbersOfKarts
            // 
            numbersOfKarts.Location = new Point(32, 411);
            numbersOfKarts.Margin = new Padding(4);
            numbersOfKarts.Name = "numbersOfKarts";
            numbersOfKarts.Size = new Size(155, 202);
            numbersOfKarts.TabIndex = 15;
            numbersOfKarts.Text = "";
            numbersOfKarts.TextChanged += numbersOfKarts_TextChanged;
            numbersOfKarts.KeyPress += numbersOfKarts_KeyPress;
            // 
            // DoQual1
            // 
            DoQual1.Location = new Point(32, 115);
            DoQual1.Margin = new Padding(4);
            DoQual1.Name = "DoQual1";
            DoQual1.Size = new Size(212, 114);
            DoQual1.TabIndex = 16;
            DoQual1.Text = "Распределить Квалу 1";
            DoQual1.UseVisualStyleBackColor = true;
            DoQual1.Click += DoQual1_Click;
            // 
            // DoHeat1
            // 
            DoHeat1.Location = new Point(338, 115);
            DoHeat1.Margin = new Padding(4);
            DoHeat1.Name = "DoHeat1";
            DoHeat1.Size = new Size(212, 114);
            DoHeat1.TabIndex = 17;
            DoHeat1.Text = "Распределить 1 хит";
            DoHeat1.UseVisualStyleBackColor = true;
            DoHeat1.Click += DoHeat1_Click;
            // 
            // DoQual2
            // 
            DoQual2.Location = new Point(634, 115);
            DoQual2.Margin = new Padding(4);
            DoQual2.Name = "DoQual2";
            DoQual2.Size = new Size(212, 114);
            DoQual2.TabIndex = 18;
            DoQual2.Text = "Распределить Квала 2";
            DoQual2.UseVisualStyleBackColor = true;
            DoQual2.Click += DoQual2_Click;
            // 
            // DoHeat2
            // 
            DoHeat2.Location = new Point(932, 115);
            DoHeat2.Margin = new Padding(4);
            DoHeat2.Name = "DoHeat2";
            DoHeat2.Size = new Size(212, 114);
            DoHeat2.TabIndex = 19;
            DoHeat2.Text = "Распределить 2 хит";
            DoHeat2.UseVisualStyleBackColor = true;
            DoHeat2.Click += DoHeat2_Click;
            // 
            // DoFinal
            // 
            DoFinal.Location = new Point(932, 251);
            DoFinal.Margin = new Padding(4);
            DoFinal.Name = "DoFinal";
            DoFinal.Size = new Size(212, 114);
            DoFinal.TabIndex = 20;
            DoFinal.Text = "Распределить Финал";
            DoFinal.UseVisualStyleBackColor = true;
            DoFinal.Click += DoFinal_Click;
            // 
            // RebuildPilots
            // 
            RebuildPilots.Location = new Point(420, 411);
            RebuildPilots.Margin = new Padding(4);
            RebuildPilots.Name = "RebuildPilots";
            RebuildPilots.Size = new Size(160, 104);
            RebuildPilots.TabIndex = 22;
            RebuildPilots.Text = "Пересобрать пилотов";
            RebuildPilots.UseVisualStyleBackColor = true;
            RebuildPilots.Click += RebuildPilots_Click;
            // 
            // ReadScores
            // 
            ReadScores.Location = new Point(831, 411);
            ReadScores.Margin = new Padding(4);
            ReadScores.Name = "ReadScores";
            ReadScores.Size = new Size(160, 104);
            ReadScores.TabIndex = 23;
            ReadScores.Text = "Перенести балы в общую таблицу";
            ReadScores.UseVisualStyleBackColor = true;
            ReadScores.Click += ReadScores_Click;
            // 
            // SortScores
            // 
            SortScores.Location = new Point(1018, 411);
            SortScores.Margin = new Padding(4);
            SortScores.Name = "SortScores";
            SortScores.Size = new Size(160, 104);
            SortScores.TabIndex = 24;
            SortScores.Text = "Сортировать общую таблицу по балам";
            SortScores.UseVisualStyleBackColor = true;
            SortScores.Click += SortScores_Click;
            // 
            // ReadTimes
            // 
            ReadTimes.Location = new Point(831, 529);
            ReadTimes.Margin = new Padding(4);
            ReadTimes.Name = "ReadTimes";
            ReadTimes.Size = new Size(160, 104);
            ReadTimes.TabIndex = 25;
            ReadTimes.Text = "Перенести время в общую таблицу";
            ReadTimes.UseVisualStyleBackColor = true;
            ReadTimes.Click += ReadTimes_Click;
            // 
            // SortTimes
            // 
            SortTimes.Location = new Point(1018, 529);
            SortTimes.Margin = new Padding(4);
            SortTimes.Name = "SortTimes";
            SortTimes.Size = new Size(160, 104);
            SortTimes.TabIndex = 26;
            SortTimes.Text = "Сортировать времена";
            SortTimes.UseVisualStyleBackColor = true;
            SortTimes.Click += SortTimes_Click;
            // 
            // DeleteKartsFromLastRace
            // 
            DeleteKartsFromLastRace.Location = new Point(420, 529);
            DeleteKartsFromLastRace.Margin = new Padding(4);
            DeleteKartsFromLastRace.Name = "DeleteKartsFromLastRace";
            DeleteKartsFromLastRace.Size = new Size(160, 104);
            DeleteKartsFromLastRace.TabIndex = 27;
            DeleteKartsFromLastRace.Text = "Удалить карты с последнего хита";
            DeleteKartsFromLastRace.UseVisualStyleBackColor = true;
            DeleteKartsFromLastRace.Click += DeleteKartsFromLastRace_Click;
            // 
            // DoSemiFinal
            // 
            DoSemiFinal.Location = new Point(634, 251);
            DoSemiFinal.Margin = new Padding(4);
            DoSemiFinal.Name = "DoSemiFinal";
            DoSemiFinal.Size = new Size(212, 114);
            DoSemiFinal.TabIndex = 28;
            DoSemiFinal.Text = "Распределить Полуфинал";
            DoSemiFinal.UseVisualStyleBackColor = true;
            DoSemiFinal.Click += DoSemiFinal_Click;
            // 
            // SortTimeDead
            // 
            SortTimeDead.Location = new Point(653, 529);
            SortTimeDead.Margin = new Padding(4);
            SortTimeDead.Name = "SortTimeDead";
            SortTimeDead.Size = new Size(160, 104);
            SortTimeDead.TabIndex = 29;
            SortTimeDead.Text = "Сортировать времена Дед";
            SortTimeDead.UseVisualStyleBackColor = true;
            SortTimeDead.Click += SortTimeDead_Click;
            // 
            // TestNewReg
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 655);
            Controls.Add(SortTimeDead);
            Controls.Add(DoSemiFinal);
            Controls.Add(DeleteKartsFromLastRace);
            Controls.Add(SortTimes);
            Controls.Add(ReadTimes);
            Controls.Add(SortScores);
            Controls.Add(ReadScores);
            Controls.Add(RebuildPilots);
            Controls.Add(DoFinal);
            Controls.Add(DoHeat2);
            Controls.Add(DoQual2);
            Controls.Add(DoHeat1);
            Controls.Add(DoQual1);
            Controls.Add(numbersOfKarts);
            Controls.Add(Clear);
            Margin = new Padding(4);
            Name = "TestNewReg";
            Text = "TestNew";
            ResumeLayout(false);
        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoQual1;
        private Button DoHeat1;
        private Button DoQual2;
        private Button DoHeat2;
        private Button DoFinal;
        private Button RebuildPilots;
        private Button ReadScores;
        private Button SortScores;
        private Button ReadTimes;
        private Button SortTimes;
        private Button DeleteKartsFromLastRace;
        private Button DoSemiFinal;
        private Button SortTimeDead;
    }
}