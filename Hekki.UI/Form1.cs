using Hekki.App;
using Hekki.Domain.Models;

namespace Hekki.UI
{
    public partial class Form1 : Form
    {
        private Regulation _regulation;
        public Form1()
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
        }
    }
}
