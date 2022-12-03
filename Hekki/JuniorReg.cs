using RaceLogic;
using ExcelController;

namespace Hekki
{
    public partial class JuniorReg : Form
    {
        private static List<int> numbersKarts;
        public JuniorReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoQualRandom_Click(object sender, EventArgs e)
        {
            Junior.DoQualRandom(numbersKarts);
        }

        private void DoQualByList_Click(object sender, EventArgs e)
        {
            Junior.DoQualByList(numbersKarts);
        }

        private void DoRace1_Click(object sender, EventArgs e)
        {
            Junior.DoRace(numbersKarts);
        }

        private void DoRace2_Click(object sender, EventArgs e)
        {
            Junior.DoRace(numbersKarts);
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            Junior.DoFinal(numbersKarts);
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
            Junior.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            Junior.ReadScor();
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            Junior.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            Junior.ReadTime();
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            Junior.SortTimeInRace();
            Junior.SortTimeInTB();
        }
    }
}
