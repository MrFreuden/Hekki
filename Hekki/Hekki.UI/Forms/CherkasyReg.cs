using RaceLogic;
using ExcelController;
namespace Hekki
{
    public partial class CherkasyReg : Form
    {
        private static List<int> numbersKarts;
        public CherkasyReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoQual1_Click(object sender, EventArgs e)
        {
            RaceLogic.Cherkasy.DoQualRace(numbersKarts);
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            Cherkasy.DoOneRace(numbersKarts);
        }

        private void DoQual2_Click(object sender, EventArgs e)
        {
            Cherkasy.DoQualRace(numbersKarts);
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            Cherkasy.DoOneRace(numbersKarts);
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            Cherkasy.DoFinal(numbersKarts);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ExcelController. ExcelWorker.CleanData();
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            Cherkasy.ReBuildPilots();
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();
            Cherkasy.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            Cherkasy.ReadScor();
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            Cherkasy.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            Cherkasy.ReadTime();
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            Cherkasy.SortTimeInTB();
            Cherkasy.SortTimeInRace();
        }
    }
}
