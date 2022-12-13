using ExcelController;
using RaceLogic.Regulations;

namespace Hekki
{
    public partial class SprintReg : Form
    {
        private static Sprint _sprint = new();
        private static List<int> numbersKarts;
        public SprintReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoOneRace_Click(object sender, EventArgs e)
        {
            _sprint.DoOneRace(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void DoThreeRaces_Click(object sender, EventArgs e)
        {
            _sprint.DoThreeRaces(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void DoSemiFinal_Click(object sender, EventArgs e)
        {
            _sprint.DoNextRace(numbersKarts, 3);
            _sprint.WriteUsedKarts();
        }

        private void DoFinalPro_Click(object sender, EventArgs e)
        {
            _sprint.DoNextRace(numbersKarts, 4);
            _sprint.WriteUsedKarts();
        }

        private void DoFinalAmator_Click(object sender, EventArgs e)
        {
            _sprint.DoFinalAmators(numbersKarts, 4);
            _sprint.WriteUsedKartsAmators();
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
            _sprint.ReBuildPilots(numbersKarts);
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();
            _sprint.ReBuildPilots(numbersKarts);
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            var scores = _sprint.GetScores();
            _sprint.WriteScores(scores);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            _sprint.SortScores();
        }

        private void SortByLique_Click(object sender, EventArgs e)
        {
            _sprint.SortTwoLiques(numbersKarts);
        }
    }
}
