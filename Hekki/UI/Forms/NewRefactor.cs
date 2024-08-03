using ExcelController.Services;
using RaceLogic.Algorithms;
using RaceLogic.Interfaces;
using RaceLogic.Models;
using RaceLogic.Services;
namespace Hekki
{
    public partial class NewRefactor : Form
    {
        private IRace _race;
        private IRaceDataService _raceService;
        private static List<int> numbersKarts;
        public const int MaxKarts = 10;
        public NewRefactor(List<int> karts)
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();

            var excelWorker = new ExcelWorker();
            _raceService = new RaceDataService(excelWorker);
            var regulation = new NewRefactorRegulation(new SimpleMethodDevide(numbersKarts.Count, 10), new SortMethod(), new Combination());
            _race = new Race(regulation, _raceService, new List<Pilot>(), numbersKarts);
        }

        private void DoQual1_Click(object sender, EventArgs e)
        {
            _race.SetSortMethod(new SortShuffle());
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void DoHeat1_Click(object sender, EventArgs e)
        {
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void DoQual2_Click(object sender, EventArgs e)
        {
            _race.SetSortMethod(new SortShuffle());
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void DoHeat2_Click(object sender, EventArgs e)
        {
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void DoSemiFinal_Click(object sender, EventArgs e)
        {
            _race.SetDevideMethod(new CardMethodDevide());
            _race.MakeHeat();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _race.ClearAll();
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            _race.TransferScoresToBoard();
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            _race.SortBoardByScore();
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            _race.TransferTimesToBoard();
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            _race.SortBoardByTime();
        }

        private void SortTimeDead_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void RebuildPilots_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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


        //TODO: это что???
        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }
    }
}
