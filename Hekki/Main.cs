namespace Hekki
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            numbersOfKarts.Text = "1\n2\n3\n4\n5\n6\n7\n8";
        }

        private void Sprint_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<int> karts = new List<int>();
            foreach (string i in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(i));
            SprintReg win2 = new SprintReg(karts);
            win2.Closed += (s, args) => this.Close();
            win2.Show();
        }

        private void Cherkasy_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<int> karts = new List<int>();
            foreach (string i in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(i));
            CherkasyReg win3 = new CherkasyReg(karts);
            win3.Closed += (s, args) => this.Close();
            win3.Show();
        }

        private void School_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<int> karts = new List<int>();
            foreach (string i in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(i));
            SchoolReg win4 = new SchoolReg(karts);
            win4.Closed += (s, args) => this.Close();
            win4.Show();
        }

        private void Junior_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<int> karts = new List<int>();
            foreach (string i in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(i));
            JuniorReg win5 = new JuniorReg(karts);
            win5.Closed += (s, args) => this.Close();
            win5.Show();
        }

        private void EveryOnEvery_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<int> karts = new List<int>();
            foreach (string i in numbersOfKarts.Lines)
                karts.Add(Int32.Parse(i));
            EveryOnEveryReg win6 = new EveryOnEveryReg(karts);
            win6.Closed += (s, args) => this.Close();
            win6.Show();
        }
    }
}