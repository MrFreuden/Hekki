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
            this.Clear = new System.Windows.Forms.Button();
            this.numbersOfKarts = new System.Windows.Forms.RichTextBox();
            this.DoRaces = new System.Windows.Forms.Button();
            this.ReadScores = new System.Windows.Forms.Button();
            this.SortScores = new System.Windows.Forms.Button();
            this.ReplaceKart = new System.Windows.Forms.Button();
            this.RebuilKarts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(180, 432);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 54);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(31, 324);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 15;
            this.numbersOfKarts.Text = "";
            // 
            // DoRaces
            // 
            this.DoRaces.Location = new System.Drawing.Point(31, 97);
            this.DoRaces.Name = "DoRaces";
            this.DoRaces.Size = new System.Drawing.Size(170, 91);
            this.DoRaces.TabIndex = 17;
            this.DoRaces.Text = "Распределить заезды";
            this.DoRaces.UseVisualStyleBackColor = true;
            this.DoRaces.Click += new System.EventHandler(this.DoRaces_Click);
            // 
            // ReadScores
            // 
            this.ReadScores.Location = new System.Drawing.Point(664, 324);
            this.ReadScores.Name = "ReadScores";
            this.ReadScores.Size = new System.Drawing.Size(128, 83);
            this.ReadScores.TabIndex = 24;
            this.ReadScores.Text = "Перенести балы в общую таблицу";
            this.ReadScores.UseVisualStyleBackColor = true;
            this.ReadScores.Click += new System.EventHandler(this.ReadScores_Click);
            // 
            // SortScores
            // 
            this.SortScores.Location = new System.Drawing.Point(811, 324);
            this.SortScores.Name = "SortScores";
            this.SortScores.Size = new System.Drawing.Size(128, 83);
            this.SortScores.TabIndex = 25;
            this.SortScores.Text = "Сортировать общую таблицу по балам";
            this.SortScores.UseVisualStyleBackColor = true;
            this.SortScores.Click += new System.EventHandler(this.SortScores_Click);
            // 
            // ReplaceKart
            // 
            this.ReplaceKart.Location = new System.Drawing.Point(786, 42);
            this.ReplaceKart.Name = "ReplaceKart";
            this.ReplaceKart.Size = new System.Drawing.Size(128, 83);
            this.ReplaceKart.TabIndex = 26;
            this.ReplaceKart.Text = "Заменить карт";
            this.ReplaceKart.UseVisualStyleBackColor = true;
            // 
            // RebuilKarts
            // 
            this.RebuilKarts.Location = new System.Drawing.Point(180, 324);
            this.RebuilKarts.Name = "RebuilKarts";
            this.RebuilKarts.Size = new System.Drawing.Size(128, 83);
            this.RebuilKarts.TabIndex = 27;
            this.RebuilKarts.Text = "Пересобрать карты";
            this.RebuilKarts.UseVisualStyleBackColor = true;
            this.RebuilKarts.Click += new System.EventHandler(this.RebuilKarts_Click);
            // 
            // EveryOnEveryReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.RebuilKarts);
            this.Controls.Add(this.ReplaceKart);
            this.Controls.Add(this.SortScores);
            this.Controls.Add(this.ReadScores);
            this.Controls.Add(this.DoRaces);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.Clear);
            this.Name = "EveryOnEveryReg";
            this.Text = "EveryOnEveryReg";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoRaces;
        private Button ReadScores;
        private Button SortScores;
        private Button ReplaceKart;
        private Button RebuilKarts;
    }
}