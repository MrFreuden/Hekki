using Hekki.App;
using Hekki.Domain.Models;

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
            return new TestRegulation(4, new List<Func<Pilots, Pilots>>
            {
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
            });
        }

        private void ImitationStartButton_Click(object sender, EventArgs e)
        {
            _regulation = GetRegulation();
            var raceForm = new RaceUIForm();
            raceForm.Show();
            
        }
    }
}
