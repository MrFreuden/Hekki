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
            _pilots[0].AddResult(new PointsResult(5));
            _pilots[0].AddResult(new PointsResult(4));
            _pilots[0].AddResult(new PointsResult(3));

            _pilots[1].AddResult(new PointsResult(3));
            _pilots[1].AddResult(new PointsResult(5));
            _pilots[1].AddResult(new PointsResult(4));

            _pilots[2].AddResult(new PointsResult(4));
            _pilots[2].AddResult(new PointsResult(3));
            _pilots[2].AddResult(new PointsResult(5));

            _pilots[0].AddUsedKart(1);
            _pilots[0].AddUsedKart(2);
            _pilots[0].AddUsedKart(3);

            _pilots[1].AddUsedKart(4);
            _pilots[1].AddUsedKart(1);
            _pilots[1].AddUsedKart(2);

            _pilots[2].AddUsedKart(2);
            _pilots[2].AddUsedKart(3);
            _pilots[2].AddUsedKart(1);


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
                dataGridView.Columns.Add("UsedKarts", "Used Karts");
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
                    var rowValues = new List<object> { string.Join(" ", row.UsedKarts.Select(x => x.ToString())), row.Name};
                    rowValues.AddRange(row.RowViewModel.Results.Select(x => x.Value));
                    dataGridView.Rows.Add(rowValues.ToArray());
                }
            }
            //PilotUsedKarts = string.Join(" ", pilot.UsedKarts.Select(x => x.ToString())),
        }

        private void DrawHeats()
        {

        }
    }
}
