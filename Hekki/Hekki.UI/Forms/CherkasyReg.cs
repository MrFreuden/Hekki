using RaceLogic.Regulations;
using ExcelController;
namespace Hekki
{
    public partial class CherkasyReg : Form
    {
        private static Cherkasy cherkasy = new();
        private static List<int> numbersKarts;

        public CherkasyReg(List<int> karts)
        {
            InitializeComponent();
            
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DoQual1_Click(object sender, EventArgs e)
        {
            
            cherkasy.DoQualRace(numbersKarts);
            cherkasy.WriteUsedKarts();
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            cherkasy.DoOneRace(numbersKarts);
            cherkasy.WriteUsedKarts();
        }

        private void DoQual2_Click(object sender, EventArgs e)
        {
            cherkasy.DoQualRace(numbersKarts);
            cherkasy.WriteUsedKarts();
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            cherkasy.DoOneRace(numbersKarts);
            cherkasy.WriteUsedKarts();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            cherkasy.DoFinal(numbersKarts);
            cherkasy.WriteUsedKarts();
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
            cherkasy.ReBuildPilots();
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();
            cherkasy.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            var scores = cherkasy.GetScores();
            cherkasy.WriteScores(scores);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            cherkasy.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            var times = cherkasy.GetTimes();
            cherkasy.WriteTimes(times);
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            cherkasy.SortTimeInTB();
            cherkasy.SortTimeInRace();
        }

        private void numbersOfKarts_TextChanged(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string line in numbersOfKarts.Lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                numbersKarts.Add(Int32.Parse(line));
            }
        }
    }
}
