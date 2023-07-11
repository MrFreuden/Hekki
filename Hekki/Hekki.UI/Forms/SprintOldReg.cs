using ExcelController;
using RaceLogic.Regulations;

namespace Hekki
{
    public partial class SprintOldReg : Form
    {
        private static Sprint _sprint = new();
        private static List<int> numbersKarts;

        public SprintOldReg(List<int> karts)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void DoFinalPro_Click(object sender, EventArgs e)
        {
            _sprint.DoFinalPro(numbersKarts, 4);
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
            _sprint.SortTwoLiquesOld(numbersKarts);
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

        private void DoOneRace_Click(object sender, EventArgs e)
        {
            _sprint.DoOneOldRace(numbersKarts);
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
    }
}
