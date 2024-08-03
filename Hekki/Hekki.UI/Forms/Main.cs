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
            //this.Hide();
            //SprintReg win2 = new(karts);
            //win2.Closed += (s, args) => this.Close();
            //win2.Show();
        }

        private void Cherkasy_Click(object sender, EventArgs e)
        {
            
        }

        private void School_Click(object sender, EventArgs e)
        {
            
        }

        private void Junior_Click(object sender, EventArgs e)
        {
            
        }

        private void EveryOnEvery_Click(object sender, EventArgs e)
        {
            
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
            
        }

        private void TestNew_Click(object sender, EventArgs e)
        {
            
        }
    }
}