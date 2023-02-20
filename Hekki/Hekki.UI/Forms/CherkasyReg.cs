using RaceLogic.Regulations;
using ExcelController;
namespace Hekki
{
    public partial class CherkasyReg : Form
    {
        private static Cherkasy _cherkasy = new();
        private static List<int> _numbersKarts;

        public CherkasyReg(List<int> karts)
        {
            InitializeComponent();
            
            _numbersKarts = karts;
            numbersOfKarts.Lines = _numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DoQual1_Click(object sender, EventArgs e)
        {
            
            _cherkasy.DoQualRace(_numbersKarts);
            _cherkasy.WriteUsedKarts();
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            _cherkasy.DoOneRace(_numbersKarts);
            _cherkasy.WriteUsedKarts();
        }

        private void DoQual2_Click(object sender, EventArgs e)
        {
            _cherkasy.DoQualRace(_numbersKarts);
            _cherkasy.WriteUsedKarts();
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            _cherkasy.DoOneRace(_numbersKarts);
            _cherkasy.WriteUsedKarts();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            _cherkasy.DoFinal(_numbersKarts);
            _cherkasy.WriteUsedKarts();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ExcelWorker.CleanData();
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            _numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                _numbersKarts.Add(Int32.Parse(i));
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            _cherkasy.ReBuildPilots();
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();
            _cherkasy.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            var scores = _cherkasy.GetScores();
            _cherkasy.WriteScores(scores);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            _cherkasy.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            var times = _cherkasy.GetTimes();
            _cherkasy.WriteTimes(times);
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            _cherkasy.SortTimeInTB();
            _cherkasy.SortTimeInRace();
        }
    }
}
