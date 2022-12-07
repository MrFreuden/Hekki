using ExcelController;
using RaceLogic.Regulations;

namespace Hekki
{
    public partial class SchoolReg : Form
    {
        private static School _school = new();
        private static List<int> numbersKarts;
        public SchoolReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoQual_Click(object sender, EventArgs e)
        {
            _school.DoRace(numbersKarts);
            _school.WriteUsedKarts();
        }

        private void DoRace1_Click(object sender, EventArgs e)
        {
            _school.DoRace(numbersKarts);
            _school.WriteUsedKarts();
        }

        private void DoRace2_Click(object sender, EventArgs e)
        {
            _school.DoRace(numbersKarts);
            _school.WriteUsedKarts();
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
            _school.ReBuildPilots();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            _school.ReadTime();
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            _school.SortTimeInTB();
            _school.SortTimeInRace();
        }
    }
}
