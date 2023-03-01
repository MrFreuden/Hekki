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
            this.Clear = new System.Windows.Forms.Button();
            this.numbersOfKarts = new System.Windows.Forms.RichTextBox();
            this.DoOneRace = new System.Windows.Forms.Button();
            this.DoThreeRaces = new System.Windows.Forms.Button();
            this.DoSemiFinal = new System.Windows.Forms.Button();
            this.DoFinalPro = new System.Windows.Forms.Button();
            this.RebuildPilots = new System.Windows.Forms.Button();
            this.DeleteKartsFromLastRace = new System.Windows.Forms.Button();
            this.ReadScores = new System.Windows.Forms.Button();
            this.SortScores = new System.Windows.Forms.Button();
            this.DoFinalAmator = new System.Windows.Forms.Button();
            this.SortByLique = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(182, 434);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(128, 54);
            this.Clear.TabIndex = 0;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(30, 326);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 15;
            this.numbersOfKarts.Text = "";
            this.numbersOfKarts.TextChanged += new System.EventHandler(this.numbersOfKarts_TextChanged);
            this.numbersOfKarts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numbersOfKarts_KeyPress);
            // 
            // DoOneRace
            // 
            this.DoOneRace.Location = new System.Drawing.Point(30, 12);
            this.DoOneRace.Name = "DoOneRace";
            this.DoOneRace.Size = new System.Drawing.Size(170, 91);
            this.DoOneRace.TabIndex = 17;
            this.DoOneRace.Text = "Распределить 1 хит";
            this.DoOneRace.UseVisualStyleBackColor = true;
            this.DoOneRace.Click += new System.EventHandler(this.DoOneRace_Click);
            // 
            // DoThreeRaces
            // 
            this.DoThreeRaces.Location = new System.Drawing.Point(30, 120);
            this.DoThreeRaces.Name = "DoThreeRaces";
            this.DoThreeRaces.Size = new System.Drawing.Size(170, 91);
            this.DoThreeRaces.TabIndex = 18;
            this.DoThreeRaces.Text = "Распределить 3 хита";
            this.DoThreeRaces.UseVisualStyleBackColor = true;
            this.DoThreeRaces.Click += new System.EventHandler(this.DoThreeRaces_Click);
            // 
            // DoSemiFinal
            // 
            this.DoSemiFinal.Location = new System.Drawing.Point(251, 120);
            this.DoSemiFinal.Name = "DoSemiFinal";
            this.DoSemiFinal.Size = new System.Drawing.Size(170, 91);
            this.DoSemiFinal.TabIndex = 19;
            this.DoSemiFinal.Text = "Распределить полуфинал";
            this.DoSemiFinal.UseVisualStyleBackColor = true;
            this.DoSemiFinal.Click += new System.EventHandler(this.DoSemiFinal_Click);
            // 
            // DoFinalPro
            // 
            this.DoFinalPro.Location = new System.Drawing.Point(471, 120);
            this.DoFinalPro.Name = "DoFinalPro";
            this.DoFinalPro.Size = new System.Drawing.Size(170, 91);
            this.DoFinalPro.TabIndex = 20;
            this.DoFinalPro.Text = "Распределить финал про";
            this.DoFinalPro.UseVisualStyleBackColor = true;
            this.DoFinalPro.Click += new System.EventHandler(this.DoFinalPro_Click);
            // 
            // RebuildPilots
            // 
            this.RebuildPilots.Location = new System.Drawing.Point(335, 326);
            this.RebuildPilots.Name = "RebuildPilots";
            this.RebuildPilots.Size = new System.Drawing.Size(128, 83);
            this.RebuildPilots.TabIndex = 23;
            this.RebuildPilots.Text = "Пересобрать пилотов";
            this.RebuildPilots.UseVisualStyleBackColor = true;
            this.RebuildPilots.Click += new System.EventHandler(this.RebuildPilots_Click);
            // 
            // DeleteKartsFromLastRace
            // 
            this.DeleteKartsFromLastRace.Location = new System.Drawing.Point(335, 420);
            this.DeleteKartsFromLastRace.Name = "DeleteKartsFromLastRace";
            this.DeleteKartsFromLastRace.Size = new System.Drawing.Size(128, 83);
            this.DeleteKartsFromLastRace.TabIndex = 28;
            this.DeleteKartsFromLastRace.Text = "Удалить карты с последнего хита";
            this.DeleteKartsFromLastRace.UseVisualStyleBackColor = true;
            this.DeleteKartsFromLastRace.Click += new System.EventHandler(this.DeleteKartsFromLastRace_Click);
            // 
            // ReadScores
            // 
            this.ReadScores.Location = new System.Drawing.Point(673, 326);
            this.ReadScores.Name = "ReadScores";
            this.ReadScores.Size = new System.Drawing.Size(128, 83);
            this.ReadScores.TabIndex = 29;
            this.ReadScores.Text = "Перенести балы в общую таблицу";
            this.ReadScores.UseVisualStyleBackColor = true;
            this.ReadScores.Click += new System.EventHandler(this.ReadScores_Click);
            // 
            // SortScores
            // 
            this.SortScores.Location = new System.Drawing.Point(816, 326);
            this.SortScores.Name = "SortScores";
            this.SortScores.Size = new System.Drawing.Size(128, 83);
            this.SortScores.TabIndex = 30;
            this.SortScores.Text = "Сортировать общую таблицу по балам";
            this.SortScores.UseVisualStyleBackColor = true;
            this.SortScores.Click += new System.EventHandler(this.SortScores_Click);
            // 
            // DoFinalAmator
            // 
            this.DoFinalAmator.Location = new System.Drawing.Point(690, 120);
            this.DoFinalAmator.Name = "DoFinalAmator";
            this.DoFinalAmator.Size = new System.Drawing.Size(170, 91);
            this.DoFinalAmator.TabIndex = 31;
            this.DoFinalAmator.Text = "Распределить финал аматоров";
            this.DoFinalAmator.UseVisualStyleBackColor = true;
            this.DoFinalAmator.Click += new System.EventHandler(this.DoFinalAmator_Click);
            // 
            // SortByLique
            // 
            this.SortByLique.Location = new System.Drawing.Point(816, 420);
            this.SortByLique.Name = "SortByLique";
            this.SortByLique.Size = new System.Drawing.Size(128, 83);
            this.SortByLique.TabIndex = 32;
            this.SortByLique.Text = "Сортировать по лигам";
            this.SortByLique.UseVisualStyleBackColor = true;
            this.SortByLique.Click += new System.EventHandler(this.SortByLique_Click);
            // 
            // SprintReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.SortByLique);
            this.Controls.Add(this.DoFinalAmator);
            this.Controls.Add(this.SortScores);
            this.Controls.Add(this.ReadScores);
            this.Controls.Add(this.DeleteKartsFromLastRace);
            this.Controls.Add(this.RebuildPilots);
            this.Controls.Add(this.DoFinalPro);
            this.Controls.Add(this.DoSemiFinal);
            this.Controls.Add(this.DoThreeRaces);
            this.Controls.Add(this.DoOneRace);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.Clear);
            this.Name = "SprintReg";
            this.Text = "SprintReg";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Clear;
        private RichTextBox numbersOfKarts;
        private Button DoOneRace;
        private Button DoThreeRaces;
        private Button DoSemiFinal;
        private Button DoFinalPro;
        private Button RebuildPilots;
        private Button DeleteKartsFromLastRace;
        private Button ReadScores;
        private Button SortScores;
        private Button DoFinalAmator;
        private Button SortByLique;
    }
}