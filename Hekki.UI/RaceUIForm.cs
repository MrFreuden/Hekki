using Hekki.App;
using Hekki.Domain.Models;
using System.Data.Common;
using System.Windows.Forms;

namespace Hekki.UI
{
    public partial class RaceUIForm : Form
    {
        private Regulation _regulation;
        private List<Pilot> _pilots;
        private TableService _tableService;

        public RaceUIForm(Regulation regulation)
        {
            InitializeComponent();
            _regulation = regulation;
            _pilots = new List<Pilot>
            {
                new Pilot("Test1"),
                new Pilot("Test2"),
                new Pilot("Test3"),
            };
            _tableService = new TableService(_regulation, _pilots);
            DrawGeneralTable();
        }

        private void DrawGeneralTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            RegulationViewModel regulationViewModel = _tableService.BuildGeneralTable();
            DrawColumns(dataGridView1);
            DrawRows(dataGridView1);
            
            void DrawColumns(DataGridView dataGridView)
            {
                dataGridView.Columns.Add("PilotName", "Pilot Name");

                foreach (var heatViewModel in regulationViewModel.Heats)
                {
                    foreach (var heatColumn in heatViewModel.Columns)
                    {
                        dataGridView.Columns.Add(heatColumn.Name, heatColumn.Name);
                    }
                }
            }

            void DrawRows(DataGridView dataGridView)
            {
                foreach (var row in regulationViewModel.PilotViewModels)
                {
                    var rowValues = new List<object> { row.UsedKarts, row.Name };
                    rowValues.AddRange(row.RowViewModel.Results);
                    dataGridView.Rows.Add(rowValues);
                }
            }
            //PilotUsedKarts = string.Join(" ", pilot.UsedKarts.Select(x => x.ToString())),
        }

        private void DrawHeats()
        {

        }
    }
}
