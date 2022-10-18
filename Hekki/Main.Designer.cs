namespace Hekki
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Cherkasy = new System.Windows.Forms.Button();
            this.School = new System.Windows.Forms.Button();
            this.Sprint = new System.Windows.Forms.Button();
            this.Junior = new System.Windows.Forms.Button();
            this.EveryOnEvery = new System.Windows.Forms.Button();
            this.numbersOfKarts = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Cherkasy
            // 
            this.Cherkasy.Location = new System.Drawing.Point(61, 61);
            this.Cherkasy.Name = "Cherkasy";
            this.Cherkasy.Size = new System.Drawing.Size(204, 86);
            this.Cherkasy.TabIndex = 0;
            this.Cherkasy.Text = "Cherkasy";
            this.Cherkasy.UseVisualStyleBackColor = true;
            this.Cherkasy.Click += new System.EventHandler(this.Cherkasy_Click);
            // 
            // School
            // 
            this.School.Location = new System.Drawing.Point(346, 61);
            this.School.Name = "School";
            this.School.Size = new System.Drawing.Size(204, 86);
            this.School.TabIndex = 1;
            this.School.Text = "School";
            this.School.UseVisualStyleBackColor = true;
            this.School.Click += new System.EventHandler(this.School_Click);
            // 
            // Sprint
            // 
            this.Sprint.Location = new System.Drawing.Point(61, 236);
            this.Sprint.Name = "Sprint";
            this.Sprint.Size = new System.Drawing.Size(204, 86);
            this.Sprint.TabIndex = 2;
            this.Sprint.Text = "Sprint";
            this.Sprint.UseVisualStyleBackColor = true;
            this.Sprint.Click += new System.EventHandler(this.Sprint_Click);
            // 
            // Junior
            // 
            this.Junior.Location = new System.Drawing.Point(628, 370);
            this.Junior.Name = "Junior";
            this.Junior.Size = new System.Drawing.Size(204, 86);
            this.Junior.TabIndex = 3;
            this.Junior.Text = "Junior";
            this.Junior.UseVisualStyleBackColor = true;
            this.Junior.Click += new System.EventHandler(this.Junior_Click);
            // 
            // EveryOnEvery
            // 
            this.EveryOnEvery.Location = new System.Drawing.Point(637, 236);
            this.EveryOnEvery.Name = "EveryOnEvery";
            this.EveryOnEvery.Size = new System.Drawing.Size(204, 86);
            this.EveryOnEvery.TabIndex = 4;
            this.EveryOnEvery.Text = "Every On Every";
            this.EveryOnEvery.UseVisualStyleBackColor = true;
            this.EveryOnEvery.Click += new System.EventHandler(this.EveryOnEvery_Click);
            // 
            // numbersOfKarts
            // 
            this.numbersOfKarts.Location = new System.Drawing.Point(61, 350);
            this.numbersOfKarts.Name = "numbersOfKarts";
            this.numbersOfKarts.Size = new System.Drawing.Size(125, 162);
            this.numbersOfKarts.TabIndex = 15;
            this.numbersOfKarts.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 524);
            this.Controls.Add(this.numbersOfKarts);
            this.Controls.Add(this.EveryOnEvery);
            this.Controls.Add(this.Junior);
            this.Controls.Add(this.Sprint);
            this.Controls.Add(this.School);
            this.Controls.Add(this.Cherkasy);
            this.Name = "Main";
            this.Text = "Hekki";
            this.ResumeLayout(false);

        }

        #endregion

        private Button Cherkasy;
        private Button School;
        private Button Sprint;
        private Button Junior;
        private Button EveryOnEvery;
        private RichTextBox numbersOfKarts;
    }
}