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
            this.Clear = new System.Windows.Forms.Button();
            this.DoQualRandom = new System.Windows.Forms.Button();
            this.DoQualByList = new System.Windows.Forms.Button();
            this.DoRace1 = new System.Windows.Forms.Button();
            this.DoRace2 = new System.Windows.Forms.Button();
            this.DoFinal = new System.Windows.Forms.Button();
            this.RebuildPilots = new System.Windows.Forms.Button();
            this.ReadScores = new System.Windows.Forms.Button();
            this.SortScores = new System.Windows.Forms.Button();
            this.ReadTimes = new System.Windows.Forms.Button();
            this.SortTimes = new System.Windows.Forms.Button();
            this.numbersOfKarts = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(188, 443);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 54);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // DoQualRandom
            // 
            this.DoQualRandom.Location = new System.Drawing.Point(39, 22);
            this.DoQualRandom.Name = "DoQualRandom";
            this.DoQualRandom.Size = new System.Drawing.Size(170, 91);
            this.DoQualRandom.TabIndex = 3;
            this.DoQualRandom.Text = "Распределить Квалу случайно";
            this.DoQualRandom.UseVisualStyleBackColor = true;
            this.DoQualRandom.Click += new System.EventHandler(this.DoQualRandom_Click);
            // 
            // DoQualByList
            // 
            this.DoQualByList.Location = new System.Drawing.Point(39, 128);
            this.DoQualByList.Name = "DoQualByList";
            this.DoQualByList.Size = new System.Drawing.Size(170, 91);
            this.DoQualByList.TabIndex = 4;
            this.DoQualByList.Text = "Распределить Квалу По списку";
            this.DoQualByList.UseVisualStyleBackColor = true;
            this.DoQualByList.Click += new System.EventHandler(this.DoQualByList_Click);
            // 
            // DoRace1
            // 
            this.DoRace1.Location = new System.Drawing.Point(297, 79);
            this.DoRace1.Name = "DoRace1";
            this.DoRace1.Size = new System.Drawing.Size(170, 91);
            this.DoRace1.TabIndex = 5;
            this.DoRace1.Text = "Распределить Гонку 1";
            this.DoRace1.UseVisualStyleBackColor = true;
            this.DoRace1.Click += new System.EventHandler(this.DoRace1_Click);
            // 
            // DoRace2
            // 
            this.DoRace2.Location = new System.Drawing.Point(508, 79);
            this.DoRace2.Name = "DoRace2";
            this.DoRace2.Size = new System.Drawing.Size(170, 91);
            this.DoRace2.TabIndex = 6;
            this.DoRace2.Text = "Распределить Гонку 2";
            this.DoRace2.UseVisualStyleBackColor = true;
            this.DoRace2.Click += new System.EventHandler(this.DoRace2_Click);
            // 
            // DoFinal
            // 
            this.DoFinal.Location = new System.Drawing.Point(720, 79);
            this.DoFinal.Name = "DoFinal";
            this.DoFinal.Size = new System.Drawing.Size(170, 91);
            this.DoFinal.TabIndex = 7;
            this.DoFinal.Text = "Распределить Финал";
            this.DoFinal.UseVisualStyleBackColor = true;
            this.DoFinal.Click += new System.EventHandler(this.DoFinal_Click);
            // 
            // RebuildPilots
            // 
            this.RebuildPilots.Location = new System.Drawing.Point(339, 335);
            this.RebuildPilots.Name = "RebuildPilots";
            this.RebuildPilots.Size = new System.Drawing.Size(128, 83);
            this.RebuildPilots.TabIndex = 9;
            this.RebuildPilots.Text = "Пересобрать пилотов";
            this.RebuildPilots.UseVisualStyleBackColor = true;
            this.RebuildPilots.Click += new System.EventHandler(this.RebuildPilots_Click);
            // 
            // ReadScores
            // 
            this.ReadScores.Location = new System.Drawing.Point(639, 325);
            this.ReadScores.Name = "ReadScores";
            this.ReadScores.Size = new System.Drawing.Size(128, 83);
            this.ReadScores.TabIndex = 10;
            this.ReadScores.Text = "Перенести балы в общую таблицу";
            this.ReadScores.UseVisualStyleBackColor = true;
            this.ReadScores.Click += new System.EventHandler(this.ReadScores_Click);
            // 
            // SortScores
            // 
            this.SortScores.Location = new System.Drawing.Point(791, 325);
            this.SortScores.Name = "SortScores";
            this.SortScores.Size = new System.Drawing.Size(128, 83);
            this.SortScores.TabIndex = 11;
            this.SortScores.Text = "Сортировать общую таблицу по балам";
            this.SortScores.UseVisualStyleBackColor = true;
            this.SortScores.Click += new System.EventHandler(this.SortScores_Click);
            // 
            // ReadTimes
            // 
            this.ReadTimes.Location = new System.Drawing.Point(639, 414);
            this.ReadTimes.Name = "ReadTimes";
            this.ReadTimes.Size = new System.Drawing.Size(128, 83);
            this.ReadTimes.TabIndex = 12;
            this.ReadTimes.Text = "Перенести время в общую таблицу";
            this.ReadTimes.UseVisualStyleBackColor = true;
            this.ReadTimes.Click += new System.EventHandler(this.ReadTimes_Click);
            // 
            // SortTimes
            // 
            this.SortTimes.Location = new System.Drawing.Point(791, 414);
            this.SortTimes.Name = "SortTimes";
            this.SortTimes.Size = new System.Drawing.Size(128, 83);
            this.SortTimes.TabIndex = 13;
            this.SortTimes.Text = "Сортировать времена";
            this.SortTimes.UseVisualStyleBackColor = true;
            this.SortTimes.Click += new System.EventHandler(this.SortTimes_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(30, 335);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 14;
            this.numbersOfKarts.Text = "";
            this.numbersOfKarts.TextChanged += new System.EventHandler(this.numbersOfKarts_TextChanged);
            this.numbersOfKarts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOfKarts_KeyPress);
            // 
            // JuniorReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.SortTimes);
            this.Controls.Add(this.ReadTimes);
            this.Controls.Add(this.SortScores);
            this.Controls.Add(this.ReadScores);
            this.Controls.Add(this.RebuildPilots);
            this.Controls.Add(this.DoFinal);
            this.Controls.Add(this.DoRace2);
            this.Controls.Add(this.DoRace1);
            this.Controls.Add(this.DoQualByList);
            this.Controls.Add(this.DoQualRandom);
            this.Controls.Add(this.Clear);
            this.Name = "JuniorReg";
            this.Text = "JuniorReg";
            this.ResumeLayout(false);

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
    }
}