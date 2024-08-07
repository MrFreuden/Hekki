namespace Hekki
{
    partial class EveryOnEveryReg
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
            DoRaces = new Button();
            ReadScores = new Button();
            SortScores = new Button();
            ReplaceKart = new Button();
            RebuildPilots = new Button();
            ReadTimes = new Button();
            SortTimeDead = new Button();
            SuspendLayout();
            // 
            // Clear
            // 
            Clear.Location = new Point(180, 432);
            Clear.Name = "Clear";
            Clear.Size = new Size(128, 54);
            Clear.TabIndex = 1;
            Clear.Text = "Очистить";
            Clear.UseVisualStyleBackColor = true;
            Clear.Click += Clear_Click;
            // 
            // numbersOfKarts
            // 
            numbersOfKarts.Location = new Point(31, 324);
            numbersOfKarts.Name = "numbersOfKarts";
            numbersOfKarts.Size = new Size(125, 162);
            numbersOfKarts.TabIndex = 15;
            numbersOfKarts.Text = "";
            numbersOfKarts.TextChanged += numbersOfKarts_TextChanged;
            numbersOfKarts.KeyPress += numbersOfKarts_KeyPress;
            // 
            // DoRaces
            // 
            DoRaces.Location = new Point(31, 97);
            DoRaces.Name = "DoRaces";
            DoRaces.Size = new Size(170, 91);
            DoRaces.TabIndex = 17;
            DoRaces.Text = "Распределить заезды";
            DoRaces.UseVisualStyleBackColor = true;
            DoRaces.Click += DoRaces_Click;
            // 
            // ReadScores
            // 
            ReadScores.Location = new Point(664, 324);
            ReadScores.Name = "ReadScores";
            ReadScores.Size = new Size(128, 83);
            ReadScores.TabIndex = 24;
            ReadScores.Text = "Перенести балы в общую таблицу";
            ReadScores.UseVisualStyleBackColor = true;
            ReadScores.Click += ReadScores_Click;
            // 
            // SortScores
            // 
            SortScores.Location = new Point(811, 324);
            SortScores.Name = "SortScores";
            SortScores.Size = new Size(128, 83);
            SortScores.TabIndex = 25;
            SortScores.Text = "Сортировать общую таблицу по балам";
            SortScores.UseVisualStyleBackColor = true;
            SortScores.Click += SortScores_Click;
            // 
            // ReplaceKart
            // 
            ReplaceKart.Location = new Point(786, 42);
            ReplaceKart.Name = "ReplaceKart";
            ReplaceKart.Size = new Size(128, 83);
            ReplaceKart.TabIndex = 26;
            ReplaceKart.Text = "Заменить карт";
            ReplaceKart.UseVisualStyleBackColor = true;
            // 
            // RebuildPilots
            // 
            RebuildPilots.Location = new Point(329, 324);
            RebuildPilots.Name = "RebuildPilots";
            RebuildPilots.Size = new Size(128, 83);
            RebuildPilots.TabIndex = 28;
            RebuildPilots.Text = "Пересобрать пилотов";
            RebuildPilots.UseVisualStyleBackColor = true;
            RebuildPilots.Click += RebuildPilots_Click;
            // 
            // ReadTimes
            // 
            ReadTimes.Location = new Point(664, 429);
            ReadTimes.Name = "ReadTimes";
            ReadTimes.Size = new Size(128, 83);
            ReadTimes.TabIndex = 29;
            ReadTimes.Text = "Перенести время в общую таблицу";
            ReadTimes.UseVisualStyleBackColor = true;
            ReadTimes.Click += ReadTimes_Click;
            // 
            // SortTimeDead
            // 
            SortTimeDead.Location = new Point(514, 429);
            SortTimeDead.Name = "SortTimeDead";
            SortTimeDead.Size = new Size(128, 83);
            SortTimeDead.TabIndex = 30;
            SortTimeDead.Text = "Сортировать времена Дед";
            SortTimeDead.UseVisualStyleBackColor = true;
            SortTimeDead.Click += SortTimeDead_Click;
            // 
            // EveryOnEveryReg
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(969, 524);
            Controls.Add(SortTimeDead);
            Controls.Add(ReadTimes);
            Controls.Add(RebuildPilots);
            Controls.Add(ReplaceKart);
            Controls.Add(SortScores);
            Controls.Add(ReadScores);
            Controls.Add(DoRaces);
            Controls.Add(numbersOfKarts);
            Controls.Add(Clear);
            Name = "EveryOnEveryReg";
            Text = "EveryOnEveryReg";
            Load += EveryOnEveryReg_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoRaces;
        private Button ReadScores;
        private Button SortScores;
        private Button ReplaceKart;
        private Button RebuildPilots;
        private Button ReadTimes;
        private Button SortTimeDead;
    }
}