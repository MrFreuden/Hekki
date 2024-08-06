using System.Diagnostics;

namespace Hekki
{
    public partial class Main : Form
    {
        private static List<int> karts = new();

        public Main()
        {
            InitializeComponent();
            System.Reflection.Assembly executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fieVersionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
            var version = fieVersionInfo.FileVersion;
            versionNumber.Text = String.Format("Версия {0}", version.Remove(version.Length - 2));
            foreach (string line in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(line));
        }

        private void Sprint_Click(object sender, EventArgs e)
        {
            this.Hide();
            SprintReg win2 = new(karts);
            win2.Closed += (s, args) => this.Close();
            win2.Show();
        }

        private void Cherkasy_Click(object sender, EventArgs e)
        {
            this.Hide();
            CherkasyReg win3 = new(karts);
            win3.Closed += (s, args) => this.Close();
            win3.Show();
        }

        private void School_Click(object sender, EventArgs e)
        {
            this.Hide();
            SchoolReg win4 = new(karts);
            win4.Closed += (s, args) => this.Close();
            win4.Show();
        }

        private void Junior_Click(object sender, EventArgs e)
        {
            this.Hide();
            JuniorReg win5 = new(karts);
            win5.Closed += (s, args) => this.Close();
            win5.Show();
        }

        private void EveryOnEvery_Click(object sender, EventArgs e)
        {
            this.Hide();
            EveryOnEveryReg win6 = new(karts);
            win6.Closed += (s, args) => this.Close();
            win6.Show();
        }

        private void numbersOfKarts_TextChanged(object sender, EventArgs e)
        {
            karts.Clear();
            foreach (string line in numbersOfKarts.Lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                karts.Add(Int32.Parse(line));
            }
        }

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void SprintOld_Click(object sender, EventArgs e)
        {
            this.Hide();
            SprintOldReg win7 = new(karts);
            win7.Closed += (s, args) => this.Close();
            win7.Show();
        }

        private void TestNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            TestNewReg win8 = new(karts);
            win8.Closed += (s, args) => this.Close();
            win8.Show();
        }

        private void SprintNew_Click(object sender, EventArgs e)
        {
            this.Hide();
            SprintNewReg win9 = new(karts);
            win9.Closed += (s, args) => this.Close();
            win9.Show();
        }
    }
}