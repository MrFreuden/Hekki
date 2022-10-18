namespace Hekki
{
    partial class SchoolReg
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
            this.RebuilKarts = new System.Windows.Forms.Button();
            this.RebuildPilots = new System.Windows.Forms.Button();
            this.ReadTimes = new System.Windows.Forms.Button();
            this.SortTimes = new System.Windows.Forms.Button();
            this.DoQual = new System.Windows.Forms.Button();
            this.DoRace1 = new System.Windows.Forms.Button();
            this.DoRace2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(185, 430);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 54);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(36, 322);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 15;
            this.numbersOfKarts.Text = "";
            // 
            // RebuilKarts
            // 
            this.RebuilKarts.Location = new System.Drawing.Point(185, 322);
            this.RebuilKarts.Name = "RebuilKarts";
            this.RebuilKarts.Size = new System.Drawing.Size(128, 83);
            this.RebuilKarts.TabIndex = 23;
            this.RebuilKarts.Text = "Пересобрать карты";
            this.RebuilKarts.UseVisualStyleBackColor = true;
            this.RebuilKarts.Click += new System.EventHandler(this.RebuilKarts_Click);
            // 
            // RebuildPilots
            // 
            this.RebuildPilots.Location = new System.Drawing.Point(337, 322);
            this.RebuildPilots.Name = "RebuildPilots";
            this.RebuildPilots.Size = new System.Drawing.Size(128, 83);
            this.RebuildPilots.TabIndex = 24;
            this.RebuildPilots.Text = "Пересобрать пилотов";
            this.RebuildPilots.UseVisualStyleBackColor = true;
            this.RebuildPilots.Click += new System.EventHandler(this.RebuildPilots_Click);
            // 
            // ReadTimes
            // 
            this.ReadTimes.Location = new System.Drawing.Point(669, 401);
            this.ReadTimes.Name = "ReadTimes";
            this.ReadTimes.Size = new System.Drawing.Size(128, 83);
            this.ReadTimes.TabIndex = 26;
            this.ReadTimes.Text = "Перенести время в общую таблицу";
            this.ReadTimes.UseVisualStyleBackColor = true;
            this.ReadTimes.Click += new System.EventHandler(this.ReadTimes_Click);
            // 
            // SortTimes
            // 
            this.SortTimes.Location = new System.Drawing.Point(819, 401);
            this.SortTimes.Name = "SortTimes";
            this.SortTimes.Size = new System.Drawing.Size(128, 83);
            this.SortTimes.TabIndex = 27;
            this.SortTimes.Text = "Сортировать времена";
            this.SortTimes.UseVisualStyleBackColor = true;
            this.SortTimes.Click += new System.EventHandler(this.SortTimes_Click);
            // 
            // DoQual
            // 
            this.DoQual.Location = new System.Drawing.Point(36, 90);
            this.DoQual.Name = "DoQual";
            this.DoQual.Size = new System.Drawing.Size(170, 91);
            this.DoQual.TabIndex = 28;
            this.DoQual.Text = "Распределить Квалу";
            this.DoQual.UseVisualStyleBackColor = true;
            this.DoQual.Click += new System.EventHandler(this.DoQual_Click);
            // 
            // DoRace1
            // 
            this.DoRace1.Location = new System.Drawing.Point(249, 90);
            this.DoRace1.Name = "DoRace1";
            this.DoRace1.Size = new System.Drawing.Size(170, 91);
            this.DoRace1.TabIndex = 29;
            this.DoRace1.Text = "Распределить Гонку 1";
            this.DoRace1.UseVisualStyleBackColor = true;
            this.DoRace1.Click += new System.EventHandler(this.DoRace1_Click);
            // 
            // DoRace2
            // 
            this.DoRace2.Location = new System.Drawing.Point(458, 90);
            this.DoRace2.Name = "DoRace2";
            this.DoRace2.Size = new System.Drawing.Size(170, 91);
            this.DoRace2.TabIndex = 30;
            this.DoRace2.Text = "Распределить Гонку 2";
            this.DoRace2.UseVisualStyleBackColor = true;
            this.DoRace2.Click += new System.EventHandler(this.DoRace2_Click);
            // 
            // SchoolReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.DoRace2);
            this.Controls.Add(this.DoRace1);
            this.Controls.Add(this.DoQual);
            this.Controls.Add(this.SortTimes);
            this.Controls.Add(this.ReadTimes);
            this.Controls.Add(this.RebuildPilots);
            this.Controls.Add(this.RebuilKarts);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.Clear);
            this.Name = "SchoolReg";
            this.Text = "SchoolReg";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button RebuilKarts;
        private Button RebuildPilots;
        private Button ReadTimes;
        private Button SortTimes;
        private Button DoQual;
        private Button DoRace1;
        private Button DoRace2;
    }
}