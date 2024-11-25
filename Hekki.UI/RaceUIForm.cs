using Hekki.App;
using Hekki.Domain.Models;

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
            DrawHeats();
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
                dataGridView.Columns.Add("PilotName", "Name");

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
                    var rowValues = new List<object> { string.Join(" ", row.UsedKarts.Select(x => x.ToString())), row.Name };
                    rowValues.AddRange(row.Results.Select(x => x.Value));
                    dataGridView.Rows.Add(rowValues.ToArray());
                }
            }
            //PilotUsedKarts = string.Join(" ", pilot.UsedKarts.Select(x => x.ToString())),
        }

        private void DrawHeats()
        {
            var heatsModels = _tableService.BuildHeatTables();

            foreach (var heat in heatsModels)
            {
                var dgv = CreateDataGridView();
                DrawColumns(dgv, heat);
                DrawRows(dgv, heat);
                AdjustDataGridViewHeight(dgv);
            }

            void DrawColumns(DataGridView dataGridView, HeatViewModel heatView)
            {
                dataGridView.Columns.Add("KartNumber", "Kart");
                dataGridView.Columns.Add("PilotName", "Name");

                foreach (var heatColumn in heatView.Columns)
                {
                    dataGridView.Columns.Add(heatColumn.Name, heatColumn.Name);
                }

            }

            void DrawRows(DataGridView dataGridView, HeatViewModel heatView)
            {
                for (int i = 0; i < heatView.GroupsCount; i++)
                {
                    dataGridView.Rows.Add(heatView.MaxGroupCapacity);
                    var rowIndex = dataGridView.Rows.Add();
                    var separatorRow = dataGridView.Rows[rowIndex];
                    separatorRow.DefaultCellStyle.BackColor = Color.Black;
                    separatorRow.DefaultCellStyle.ForeColor = Color.Black;
                    separatorRow.ReadOnly = true;
                }
                
            }
        }

        private DataGridView CreateDataGridView()
        {
            var dgv = new DataGridView
            {
                Width = 300,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Margin = new Padding(10),
            };

            flowLayoutPanel1.Controls.Add(dgv);
            return dgv;
        }

        private void AdjustDataGridViewHeight(DataGridView dgv)
        {
            int rowHeight = dgv.RowTemplate.Height;
            int headerHeight = dgv.ColumnHeadersHeight;
            int totalRowsHeight = dgv.Rows.Count * rowHeight;
            int totalHeight = headerHeight + totalRowsHeight;

            dgv.Height = totalHeight + 2;
        }
    }
}
