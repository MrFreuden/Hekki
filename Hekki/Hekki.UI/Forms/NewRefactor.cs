using RaceLogic.Regulations;
using ExcelController;
using RaceLogic;
using RaceLogic.Interfaces;
namespace Hekki
{
    public partial class NewRefactor : Form
    {
        private IRace _race;
        private IRaceDataService _raceService;
        private static TestNew testNew = new();
        private static List<int> numbersKarts;

        public NewRefactor(List<int> karts)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();

            _raceService = new RaceDataService(new ExcelHelper(), new ExcelReader(), new ExcelWriter(), new ExcelWorker());
            var regulation = new NewRefactorRegulation(new GroupDevider());
            _race = new Race1(regulation, _raceService, new List<Pilot>(), numbersKarts);
        }

        private void DoQual1_Click(object sender, EventArgs e)
        {

            testNew.DoQualRace(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            testNew.DoOneRace(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void DoQual2_Click(object sender, EventArgs e)
        {
            testNew.DoQualRace(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            testNew.DoOneRace(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            testNew.DoFinal(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            testNew.ReBuildPilots();
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            testNew.ReBuildPilots();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            var scores = testNew.GetScores();
            testNew.WriteScores(scores);
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            testNew.SortScores();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            var times = testNew.GetTimes();
            testNew.WriteTimes(times);
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            testNew.SortTimeInTB();
            testNew.SortTimeInRace();
        }

        private void DoSemiFinal_Click(object sender, EventArgs e)
        {
            testNew.DoNextRace(numbersKarts);
            testNew.WriteUsedKarts();
        }

        private void SortTimeDead_Click(object sender, EventArgs e)
        {
            testNew.SortTimeDead();
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

        private void numbersOfKarts_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
