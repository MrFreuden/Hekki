using ExcelController;
using Microsoft.Office.Interop.Excel;
using RaceLogic.Regulations;
using System.Text.RegularExpressions;

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
            _sprint.SortTwoLiques(numbersKarts);
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

        private void DoQualRandom_Click(object sender, EventArgs e)
        {
            _sprint.DoQualRandom(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void DoQualByList_Click(object sender, EventArgs e)
        {
            _sprint.DoQualByList(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            var times = _sprint.GetTimes();
            _sprint.WriteTimes(times);
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            _sprint.SortTimeInTB();
            _sprint.SortTimeInRace();
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            _sprint.DoOneRace(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            _sprint.DoOneRace(numbersKarts);
            _sprint.WriteUsedKarts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _sprint.DoOneRace(numbersKarts);
            _sprint.WriteUsedKarts();
        }
    }
}
