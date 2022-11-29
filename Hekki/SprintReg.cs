using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hekki
{
    public partial class SprintReg : Form
    {
        private static List<int> numbersKarts;
        public SprintReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoOneRace_Click(object sender, EventArgs e)
        {
            Sprint.DoOneRace(numbersKarts);
        }

        private void DoThreeRaces_Click(object sender, EventArgs e)
        {
            Sprint.DoThreeRaces(numbersKarts);
        }

        private void DoSemiFinal_Click(object sender, EventArgs e)
        {
            Sprint.DoNextRace(numbersKarts, 3);
        }

        private void DoFinalPro_Click(object sender, EventArgs e)
        {
            Sprint.DoNextRace(numbersKarts, 4);
        }

        private void DoFinalAmator_Click(object sender, EventArgs e)
        {
            Sprint.DoFinalAmators(numbersKarts, 4);
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
            Sprint.ReBuildPilots(numbersKarts);
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            ExcelWorker.DeleteLastUsedKartsInTotalBoard();
            Sprint.ReBuildPilots(numbersKarts);
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            Sprint.ReadScor();
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            Sprint.Sort();
        }

        private void SortByLique_Click(object sender, EventArgs e)
        {
            Sprint.SortTwoLiques(numbersKarts);
        }
    }
}
