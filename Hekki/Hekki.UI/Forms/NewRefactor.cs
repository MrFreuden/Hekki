﻿using ExcelController;
using RaceLogic;
using RaceLogic.Interfaces;
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
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
        }

        private void DoFinal_Click(object sender, EventArgs e)
        {
            _race.SetDevideMethod(new SimpleMethodDevide(numbersKarts.Count, MaxKarts));
            _race.MakeHeat();
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
            
        }

        private void DeleteKartsFromLastRace_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            
        }

        private void ReadTimes_Click(object sender, EventArgs e)
        {
            
        }

        private void SortTimes_Click(object sender, EventArgs e)
        {
            
        }

        private void SortTimeDead_Click(object sender, EventArgs e)
        {

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
