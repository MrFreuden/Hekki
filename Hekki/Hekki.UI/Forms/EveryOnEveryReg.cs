using RaceLogic.Regulations;
using ExcelController;

namespace Hekki
{
    public partial class EveryOnEveryReg : Form
    {
        private static EveryOnEvery _every = new();
        private static List<int> numbersKarts;
        public EveryOnEveryReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoRaces_Click(object sender, EventArgs e)
        {
            _every.DoRaces(numbersKarts);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ExcelWorker.CleanData(null, 11);
            ExcelWorker.CleanData(ExcelWorker.GetTotalBoardRange(45));
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            _every.ReadScor(numbersKarts);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            _every.SortScores();
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            _every.ReBuildPilots();
        }

        private void EveryOnEveryReg_Load(object sender, EventArgs e)
        {

        }
    }
}
