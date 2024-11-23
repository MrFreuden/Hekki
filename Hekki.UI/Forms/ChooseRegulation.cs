using Hekki.App;
using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;
using System.Collections.Generic;

namespace Hekki.UI
{
    public partial class ChooseRegulation : Form
    {
        private Regulation _regulation;
        public ChooseRegulation()
        {
            InitializeComponent();
        }

        private Regulation GetRegulation()
        {
            var results = new List<IResult>()
            {
                new PointsResult(),
                new PointsResult(),
                new PointsResult()
            };
            return new TestRegulation(3, results, new List<Func<List<Pilot>, List<Pilot>>>
            {
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
            });
        }

        private void ImitationStartButton_Click(object sender, EventArgs e)
        {
            _regulation = GetRegulation();
            var raceForm = new RaceUIForm(_regulation);
            raceForm.Show();
            
        }
    }
}
