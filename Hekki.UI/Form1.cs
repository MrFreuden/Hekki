using Hekki.App;
using Hekki.Domain.Models;

namespace Hekki.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Regulation GetRegulation()
        {
            var pilots = new Pilots
            {
                "Test1",
                "Test2"
            };

            return new TestRegulation(4, new List<Func<Pilots, Pilots>>
            {
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
                list => SortService.RandomSort(list),
            });
        }

        
    }
}
