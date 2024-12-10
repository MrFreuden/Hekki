using Hekki.App;
using Hekki.App.DTO;
using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;
using System.ComponentModel;

namespace Hekki.UI
{
    public partial class RaceUIForm : Form
    {
        private RaceService _raceService;
        private readonly DataGridViewFactory _gridFactory = new DataGridViewFactory();
        private readonly ColumnMapper _columnMapper;
        private List<PilotDTO> _pilotDTOs;
        private List<HeatDTO> _heatDTOs;

        public RaceUIForm(Regulation regulation)
        {
            _raceService = new RaceService(regulation);
            _columnMapper = new ColumnMapper();
            _pilotDTOs = _raceService.GetPilotsDTO();
            _heatDTOs = _raceService.GetHeatsDTO();
            InitializeComponent();
            DrawGeneralTable();
            DrawHeats();
        }

        private void DrawGeneralTable()
        {
            var grid = _gridFactory.CreateGeneralTableGrid();
            BindPilotsToGeneralGrid(grid, _pilotDTOs, _heatDTOs);
            this.Controls.Add(grid);
            flowLayoutPanel2.Controls.Add(grid);
        }

        private void BindPilotsToGeneralGrid(DataGridView grid, List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var bindingList = new BindingList<PilotDTO>(pilotDTOs);
            grid.DataSource = bindingList;
            grid.AutoGenerateColumns = false;

            var columnMappers = _columnMapper.GenerateColumnMappers(heatDTOs);
            AddColumns(grid, columnMappers);

            grid.CellFormatting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var pilotDTO = grid.Rows[e.RowIndex].DataBoundItem as PilotDTO;
                    var mapper = grid.Columns[e.ColumnIndex].Tag as ColumnMapper;

                    if (pilotDTO != null && mapper != null)
                    {
                        e.Value = mapper.Formatter(pilotDTO);
                        e.FormattingApplied = true;
                    }
                }
            };

            grid.CellParsing += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var pilotDTO = grid.Rows[e.RowIndex].DataBoundItem as PilotDTO;
                    var mapper = grid.Columns[e.ColumnIndex].Tag as ColumnMapper;

                    if (pilotDTO != null && mapper != null)
                    {
                        try
                        {
                            mapper.Parser(pilotDTO, e.Value.ToString());
                            e.ParsingApplied = true;
                        }
                        catch (ArgumentException)
                        {
                            MessageBox.Show("Invalid value format.");
                        }
                    }
                }
            };

            grid.CellValueChanged += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    var pilotDTO = grid.Rows[e.RowIndex].DataBoundItem as PilotDTO;
                    if (pilotDTO != null)
                    {
                        var model = _raceService.Pilots.FirstOrDefault(p => p.Id == pilotDTO.Id);
                        if (model != null)
                        {
                            var mapper = new DTOToModelMapper();
                            mapper.SyncPilotDTOToModel(pilotDTO, model);
                        }
                    }
                }
            };

            grid.UserAddedRow += (sender, e) =>
            {
                var pilot = bindingList.Last();
                foreach (var heat in heatDTOs)
                {
                    pilot.Results.Add((IResult)Activator.CreateInstance(heat.Column.DataType, heat.HeatIndex, default));
                }
                _raceService.AddNewPilot(pilot);
            };
        }

        private void AddColumns(DataGridView grid, List<ColumnMapper> columnMappers)
        {
            foreach (var mapper in columnMappers.OrderBy(c => c.Z_index))
            {
                grid.Columns.Add(new DataGridViewTextBoxColumn
                {
                    HeaderText = mapper.HeaderText,
                    Tag = mapper
                });
            }
        }

        private void DrawHeats()
        {
            foreach (var heat in _heatDTOs)
            {
                var heatTable = _gridFactory.CreateHeatTableGrid();
                this.Controls.Add(heatTable);
                flowLayoutPanel1.Controls.Add(heatTable);
                
                AdjustDataGridViewHeight(heatTable);
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

        private void button1_Click(object sender, EventArgs e)
        {
            _raceService.StartNextHeat();
        }
    }
}
