using ExcelController;
using RaceLogic.Regulations;
namespace Hekki
{
    public partial class JuniorReg : Form
    {
        private static Junior _junior = new();
        private static List<int> numbersKarts;

        public JuniorReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DoQualRandom_Click(object sender, EventArgs e)
        {
            _junior.DoQualRandom(numbersKarts);
            _junior.WriteUsedKarts();
        }

        private void DoQualByList_Click(object sender, EventArgs e)
        {
            _junior.DoQualByList(numbersKarts);
            _junior.WriteUsedKarts();
        }

        private void DoRace1_Click(object sender, EventArgs e)
        {
            _junior.DoRace(numbersKarts);
            _junior.WriteUsedKarts();
        }

        private void DoRace2_Click(object sender, EventArgs e)
        {
            _junior.DoRace(numbersKarts);
            _junior.WriteUsedKarts();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            _junior.DoFinal(numbersKarts);
            _junior.WriteUsedKarts();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ExcelWorker.CleanData();
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            _junior.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            var scores = _junior.GetScores();
            _junior.WriteScores(scores);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            _junior.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            var times = _junior.GetTimes();
            _junior.WriteTimes(times);
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            _junior.SortTimeInRace();
            _junior.SortTimeInTB();
        }
    }
}
