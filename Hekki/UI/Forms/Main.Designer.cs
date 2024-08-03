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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            Cherkasy = new Button();
            School = new Button();
            Sprint = new Button();
            Junior = new Button();
            EveryOnEvery = new Button();
            numbersOfKarts = new RichTextBox();
            versionNumber = new Label();
            SprintOld = new Button();
            TestNew = new Button();
            SuspendLayout();
            // 
            // Cherkasy
            // 
            Cherkasy.Location = new Point(76, 76);
            Cherkasy.Margin = new Padding(4);
            Cherkasy.Name = "Cherkasy";
            Cherkasy.Size = new Size(255, 108);
            Cherkasy.TabIndex = 0;
            Cherkasy.Text = "Cherkasy";
            Cherkasy.UseVisualStyleBackColor = true;
            Cherkasy.Click += Cherkasy_Click;
            // 
            // School
            // 
            School.Location = new Point(430, 76);
            School.Margin = new Padding(4);
            School.Name = "School";
            School.Size = new Size(255, 108);
            School.TabIndex = 1;
            School.Text = "School";
            School.UseVisualStyleBackColor = true;
            School.Click += School_Click;
            // 
            // Sprint
            // 
            Sprint.Location = new Point(76, 295);
            Sprint.Margin = new Padding(4);
            Sprint.Name = "Sprint";
            Sprint.Size = new Size(255, 108);
            Sprint.TabIndex = 2;
            Sprint.Text = "Sprint";
            Sprint.UseVisualStyleBackColor = true;
            Sprint.Click += Sprint_Click;
            // 
            // Junior
            // 
            Junior.Location = new Point(430, 295);
            Junior.Margin = new Padding(4);
            Junior.Name = "Junior";
            Junior.Size = new Size(255, 108);
            Junior.TabIndex = 3;
            Junior.Text = "Junior";
            Junior.UseVisualStyleBackColor = true;
            Junior.Click += Junior_Click;
            // 
            // EveryOnEvery
            // 
            EveryOnEvery.Location = new Point(796, 295);
            EveryOnEvery.Margin = new Padding(4);
            EveryOnEvery.Name = "EveryOnEvery";
            EveryOnEvery.Size = new Size(255, 108);
            EveryOnEvery.TabIndex = 4;
            EveryOnEvery.Text = "Every On Every";
            EveryOnEvery.UseVisualStyleBackColor = true;
            EveryOnEvery.Click += EveryOnEvery_Click;
            // 
            // numbersOfKarts
            // 
            numbersOfKarts.Location = new Point(76, 438);
            numbersOfKarts.Margin = new Padding(4);
            numbersOfKarts.Name = "numbersOfKarts";
            numbersOfKarts.Size = new Size(155, 202);
            numbersOfKarts.TabIndex = 15;
            numbersOfKarts.Text = "11\n12\n13\n14\n15\n16\n17\n18\n19\n20";
            numbersOfKarts.TextChanged += numbersOfKarts_TextChanged;
            numbersOfKarts.KeyPress += numbersOfKarts_KeyPress;
            // 
            // versionNumber
            // 
            versionNumber.AutoSize = true;
            versionNumber.Location = new Point(1056, 25);
            versionNumber.Name = "versionNumber";
            versionNumber.Size = new Size(69, 25);
            versionNumber.TabIndex = 16;
            versionNumber.Text = "Версия";
            // 
            // SprintOld
            // 
            SprintOld.Location = new Point(796, 76);
            SprintOld.Margin = new Padding(4);
            SprintOld.Name = "SprintOld";
            SprintOld.Size = new Size(255, 108);
            SprintOld.TabIndex = 17;
            SprintOld.Text = "SprintOld";
            SprintOld.UseVisualStyleBackColor = true;
            SprintOld.Click += SprintOld_Click;
            // 
            // TestNew
            // 
            TestNew.Location = new Point(430, 473);
            TestNew.Margin = new Padding(4);
            TestNew.Name = "TestNew";
            TestNew.Size = new Size(255, 108);
            TestNew.TabIndex = 18;
            TestNew.Text = "TestNew";
            TestNew.UseVisualStyleBackColor = true;
            TestNew.Click += TestNew_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1211, 655);
            Controls.Add(TestNew);
            Controls.Add(SprintOld);
            Controls.Add(versionNumber);
            Controls.Add(numbersOfKarts);
            Controls.Add(EveryOnEvery);
            Controls.Add(Junior);
            Controls.Add(Sprint);
            Controls.Add(School);
            Controls.Add(Cherkasy);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Main";
            Text = "Hekki";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Cherkasy;
        private Button School;
        private Button Sprint;
        private Button Junior;
        private Button EveryOnEvery;
        private RichTextBox numbersOfKarts;
        private Label versionNumber;
        private Button SprintOld;
        private Button TestNew;
    }
}