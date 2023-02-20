namespace Hekki
{
    partial class CherkasyReg
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
            this.numbersOfKarts = new System.Windows.Forms.RichTextBox();
            this.DoQual1 = new System.Windows.Forms.Button();
            this.DoHeat1 = new System.Windows.Forms.Button();
            this.DoQual2 = new System.Windows.Forms.Button();
            this.DoHeat2 = new System.Windows.Forms.Button();
            this.DoFinal = new System.Windows.Forms.Button();
            this.RebuilKarts = new System.Windows.Forms.Button();
            this.RebuildPilots = new System.Windows.Forms.Button();
            this.ReadScores = new System.Windows.Forms.Button();
            this.SortScores = new System.Windows.Forms.Button();
            this.ReadTimes = new System.Windows.Forms.Button();
            this.SortTimes = new System.Windows.Forms.Button();
            this.DeleteKartsFromLastRace = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(179, 437);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 54);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(26, 329);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 15;
            this.numbersOfKarts.Text = "11\n12\n13\n14\n15\n16\n17\n18\n19\n20";
            this.numbersOfKarts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOfKarts_KeyPress);
            // 
            // DoQual1
            // 
            this.DoQual1.Location = new System.Drawing.Point(26, 92);
            this.DoQual1.Name = "DoQual1";
            this.DoQual1.Size = new System.Drawing.Size(170, 91);
            this.DoQual1.TabIndex = 16;
            this.DoQual1.Text = "Распределить Квалу 1";
            this.DoQual1.UseVisualStyleBackColor = true;
            this.DoQual1.Click += new System.EventHandler(this.DoQual1_Click);
            // 
            // DoHeat1
            // 
            this.DoHeat1.Location = new System.Drawing.Point(270, 92);
            this.DoHeat1.Name = "DoHeat1";
            this.DoHeat1.Size = new System.Drawing.Size(170, 91);
            this.DoHeat1.TabIndex = 17;
            this.DoHeat1.Text = "Распределить 1 хит";
            this.DoHeat1.UseVisualStyleBackColor = true;
            this.DoHeat1.Click += new System.EventHandler(this.DoHeat1_Click);
            // 
            // DoQual2
            // 
            this.DoQual2.Location = new System.Drawing.Point(507, 92);
            this.DoQual2.Name = "DoQual2";
            this.DoQual2.Size = new System.Drawing.Size(170, 91);
            this.DoQual2.TabIndex = 18;
            this.DoQual2.Text = "Распределить Квала 2";
            this.DoQual2.UseVisualStyleBackColor = true;
            this.DoQual2.Click += new System.EventHandler(this.DoQual2_Click);
            // 
            // DoHeat2
            // 
            this.DoHeat2.Location = new System.Drawing.Point(746, 92);
            this.DoHeat2.Name = "DoHeat2";
            this.DoHeat2.Size = new System.Drawing.Size(170, 91);
            this.DoHeat2.TabIndex = 19;
            this.DoHeat2.Text = "Распределить 2 хит";
            this.DoHeat2.UseVisualStyleBackColor = true;
            this.DoHeat2.Click += new System.EventHandler(this.DoHeat2_Click);
            // 
            // DoFinal
            // 
            this.DoFinal.Location = new System.Drawing.Point(746, 201);
            this.DoFinal.Name = "DoFinal";
            this.DoFinal.Size = new System.Drawing.Size(170, 91);
            this.DoFinal.TabIndex = 20;
            this.DoFinal.Text = "Распределить Финал";
            this.DoFinal.UseVisualStyleBackColor = true;
            this.DoFinal.Click += new System.EventHandler(this.DoFinal_Click);
            // 
            // RebuilKarts
            // 
            this.RebuilKarts.Location = new System.Drawing.Point(179, 329);
            this.RebuilKarts.Name = "RebuilKarts";
            this.RebuilKarts.Size = new System.Drawing.Size(128, 83);
            this.RebuilKarts.TabIndex = 21;
            this.RebuilKarts.Text = "Пересобрать карты";
            this.RebuilKarts.UseVisualStyleBackColor = true;
            this.RebuilKarts.Click += new System.EventHandler(this.RebuilKarts_Click);
            // 
            // RebuildPilots
            // 
            this.RebuildPilots.Location = new System.Drawing.Point(336, 329);
            this.RebuildPilots.Name = "RebuildPilots";
            this.RebuildPilots.Size = new System.Drawing.Size(128, 83);
            this.RebuildPilots.TabIndex = 22;
            this.RebuildPilots.Text = "Пересобрать пилотов";
            this.RebuildPilots.UseVisualStyleBackColor = true;
            this.RebuildPilots.Click += new System.EventHandler(this.RebuildPilots_Click);
            // 
            // ReadScores
            // 
            this.ReadScores.Location = new System.Drawing.Point(665, 329);
            this.ReadScores.Name = "ReadScores";
            this.ReadScores.Size = new System.Drawing.Size(128, 83);
            this.ReadScores.TabIndex = 23;
            this.ReadScores.Text = "Перенести балы в общую таблицу";
            this.ReadScores.UseVisualStyleBackColor = true;
            this.ReadScores.Click += new System.EventHandler(this.ReadScores_Click);
            // 
            // SortScores
            // 
            this.SortScores.Location = new System.Drawing.Point(814, 329);
            this.SortScores.Name = "SortScores";
            this.SortScores.Size = new System.Drawing.Size(128, 83);
            this.SortScores.TabIndex = 24;
            this.SortScores.Text = "Сортировать общую таблицу по балам";
            this.SortScores.UseVisualStyleBackColor = true;
            this.SortScores.Click += new System.EventHandler(this.SortScores_Click);
            // 
            // ReadTimes
            // 
            this.ReadTimes.Location = new System.Drawing.Point(665, 423);
            this.ReadTimes.Name = "ReadTimes";
            this.ReadTimes.Size = new System.Drawing.Size(128, 83);
            this.ReadTimes.TabIndex = 25;
            this.ReadTimes.Text = "Перенести время в общую таблицу";
            this.ReadTimes.UseVisualStyleBackColor = true;
            this.ReadTimes.Click += new System.EventHandler(this.ReadTimes_Click);
            // 
            // SortTimes
            // 
            this.SortTimes.Location = new System.Drawing.Point(814, 423);
            this.SortTimes.Name = "SortTimes";
            this.SortTimes.Size = new System.Drawing.Size(128, 83);
            this.SortTimes.TabIndex = 26;
            this.SortTimes.Text = "Сортировать времена";
            this.SortTimes.UseVisualStyleBackColor = true;
            this.SortTimes.Click += new System.EventHandler(this.SortTimes_Click);
            // 
            // DeleteKartsFromLastRace
            // 
            this.DeleteKartsFromLastRace.Location = new System.Drawing.Point(336, 423);
            this.DeleteKartsFromLastRace.Name = "DeleteKartsFromLastRace";
            this.DeleteKartsFromLastRace.Size = new System.Drawing.Size(128, 83);
            this.DeleteKartsFromLastRace.TabIndex = 27;
            this.DeleteKartsFromLastRace.Text = "Удалить карты с последнего хита";
            this.DeleteKartsFromLastRace.UseVisualStyleBackColor = true;
            this.DeleteKartsFromLastRace.Click += new System.EventHandler(this.DeleteKartsFromLastRace_Click);
            // 
            // CherkasyReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.DeleteKartsFromLastRace);
            this.Controls.Add(this.SortTimes);
            this.Controls.Add(this.ReadTimes);
            this.Controls.Add(this.SortScores);
            this.Controls.Add(this.ReadScores);
            this.Controls.Add(this.RebuildPilots);
            this.Controls.Add(this.RebuilKarts);
            this.Controls.Add(this.DoFinal);
            this.Controls.Add(this.DoHeat2);
            this.Controls.Add(this.DoQual2);
            this.Controls.Add(this.DoHeat1);
            this.Controls.Add(this.DoQual1);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.Clear);
            this.Name = "CherkasyReg";
            this.Text = "CherkasyReg";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoQual1;
        private Button DoHeat1;
        private Button DoQual2;
        private Button DoHeat2;
        private Button DoFinal;
        private Button RebuilKarts;
        private Button RebuildPilots;
        private Button ReadScores;
        private Button SortScores;
        private Button ReadTimes;
        private Button SortTimes;
        private Button DeleteKartsFromLastRace;
    }
}