using Hekki.App;
using Hekki.App.DTO;
using Hekki.Domain.Models;

namespace Hekki.UI
{
    public partial class RaceUIForm : Form
    {
        private RaceService _raceService;
        private readonly DataGridViewFactory _gridFactory = new DataGridViewFactory();
        public RaceUIForm(Regulation regulation)
        {
            _raceService = new RaceService(regulation);
            InitializeComponent();
            DrawGeneralTable();
            DrawHeats();
        }

        private void DrawGeneralTable()
        {
            var grid = _gridFactory.CreateGeneralTableGrid();
            this.Controls.Add(grid);
            flowLayoutPanel2.Controls.Add(grid);
            FillGeneralTable(grid);
        }

        private void FillGeneralTable(DataGridView grid)
        {
            var heats = _raceService.GetHeatsDTO();
            var pilots = _raceService.GetPilotsDTO();

            DrawColumns(grid);
            DrawRows(grid);

            void DrawColumns(DataGridView dataGridView)
            {
                dataGridView.Columns.Add("UsedKarts", "Used Karts");
                dataGridView.Columns.Add("PilotName", "Name");

                foreach (var heatViewModel in heats)
                {
                    foreach (var heatColumn in heatViewModel.Columns)
                    {
                        dataGridView.Columns.Add(heatColumn.Name, heatColumn.Name);
                    }
                }
            }

            void DrawRows(DataGridView dataGridView)
            {
                foreach (var pilot in pilots)
                {
                    var rowValues = new List<object> { string.Join(" ", pilot.UsedKarts.Select(x => x.ToString())), pilot.Name };
                    rowValues.AddRange(pilot.Results.Select(x => x.Value));
                    dataGridView.Rows.Add(rowValues.ToArray());
                }
            }
        }

        private void DrawHeats()
        {
            var heats = _raceService.GetHeatsDTO();
            var pilots = _raceService.GetPilotsDTO();
            foreach (var heat in heats)
            {
                var heatTable = _gridFactory.CreateHeatTableGrid();
                this.Controls.Add(heatTable);
                flowLayoutPanel1.Controls.Add(heatTable);
                FillHeatTable(heatTable, heat);
                AdjustDataGridViewHeight(heatTable);
            }
        }

        private void FillHeatTable(DataGridView item, HeatDTO heatDTO)
        {

            DrawColumns(item, heatDTO);
            DrawRows(item, heatDTO);

            void DrawColumns(DataGridView dataGridView, HeatDTO heatView)
            {
                dataGridView.Columns.Add("KartNumber", "Kart");
                dataGridView.Columns.Add("PilotName", "Name");

                foreach (var heatColumn in heatView.Columns)
                {
                    dataGridView.Columns.Add(heatColumn.Name, heatColumn.Name);
                }

            }

            void DrawRows(DataGridView dataGridView, HeatDTO heatView)
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

        private void AdjustDataGridViewHeight(DataGridView dgv)
        {
            int rowHeight = dgv.RowTemplate.Height;
            int headerHeight = dgv.ColumnHeadersHeight;
            int totalRowsHeight = dgv.Rows.Count * rowHeight;
            int totalHeight = headerHeight + totalRowsHeight;

            dgv.Height = totalHeight + 2;
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
