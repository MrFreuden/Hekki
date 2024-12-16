using Hekki.App;
using Hekki.App.DTO;
using Hekki.Domain.Interfaces;
using System.ComponentModel;

namespace Hekki.UI
{
    public class UIFlowLayoutPanelFactory : UIPanelFactory
    {
        private readonly DataGridViewFactory _gridFactory;
        private readonly ColumnMapper _columnMapper;
        private readonly FlowLayoutPanelFactory _flowLayoutPanelFactory;
        private readonly RaceService _raceService;

        public UIFlowLayoutPanelFactory(DataGridViewFactory gridFactory, FlowLayoutPanelFactory panelFactory,
            ColumnMapper columnMapper, RaceService raceService)
        {
            _gridFactory = gridFactory;
            _columnMapper = columnMapper;
            _flowLayoutPanelFactory = panelFactory;
            _raceService = raceService;
        }

        public FlowLayoutPanel GetGeneral(List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var grid = _gridFactory.CreateGeneralTableGrid();
            BindPilotsToGeneralGrid(grid, pilotDTOs, heatDTOs);
            var panel = _flowLayoutPanelFactory.GetForGeneral();
            panel.Controls.Add(grid);
            return panel;
        }

        private void BindPilotsToGeneralGrid(DataGridView grid, List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var bindingList = new BindingList<PilotDTO>(pilotDTOs);
            grid.DataSource = bindingList;

            var columnMappers = _columnMapper.GenerateColumnMappers(heatDTOs);
            AddColumns(grid, columnMappers);
            SubscribeGrid(grid);

            grid.UserAddedRow += (sender, e) =>
            {
                var pilot = bindingList.Last();
                foreach (var heat in heatDTOs)
                {
                    pilot.Results.Add((IResult)Activator.CreateInstance(heat.Column.DataType, heat.HeatIndex, default));
                }
                _raceService.AddNewPilot(pilot);
            };

            foreach (var pilot in pilotDTOs)
            {
                pilot.PropertyChanged += (sender, e) => grid.Refresh();
            }
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

        public FlowLayoutPanel GetSub(List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var panel = _flowLayoutPanelFactory.GetForHeats();
            foreach (var heat in heatDTOs)
            {
                var heatTable = _gridFactory.CreateHeatTableGrid(heat.HeatIndex);
                if (pilotDTOs.Count == 0)
                {
                    heatTable.RowCount = heat.GroupsCount * heat.MaxGroupCapacity;
                }
                else
                {
                    BindPilotsToHeatsTables(heatTable, pilotDTOs, heat);
                }
                panel.Controls.Add(heatTable);
            }
            return panel;
        }

        private void BindPilotsToHeatsTables(DataGridView grid, List<PilotDTO> pilotDTOs, HeatDTO heatDTO)
        {
            var bindingList = new BindingList<PilotDTO>(pilotDTOs);
            grid.DataSource = bindingList;

            var columnMappers = _columnMapper.HeatColumnMappers(heatDTO);
            AddColumns(grid, columnMappers);
            SubscribeGrid(grid);

            foreach (var pilot in pilotDTOs)
            {
                pilot.PropertyChanged += (sender, e) => grid.Refresh();
            }
        }

        private void SubscribeGrid(DataGridView grid)
        {
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

            grid.DataBindingComplete += (sender, e) =>
            {
                grid.ClearSelection();
            };
        }

        public FlowLayoutPanel GetControlPanel()
        {
            throw new NotImplementedException();
        }
    }

    public interface UIPanelFactory
    {
        public FlowLayoutPanel GetGeneral(List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs);
        public FlowLayoutPanel GetSub(List<PilotDTO> pilotDTOs, List<HeatDTO> heatDTOs);
        public FlowLayoutPanel GetControlPanel();
    }
}
