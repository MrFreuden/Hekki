using Hekki.App;
using Hekki.App.DTO;
using Hekki.Domain.Interfaces;
using Hekki.UI.FormElementsFactorys;
using System.ComponentModel;
using System.Windows.Forms;

namespace Hekki.UI
{
    public class UIFlowLayoutPanelFactory : UIPanelFactory
    {
        private readonly DataGridViewFactory _gridFactory;
        private readonly ColumnMapper _columnMapper;
        private readonly FlowLayoutPanelFactory _flowLayoutPanelFactory;

        public UIFlowLayoutPanelFactory(DataGridViewFactory gridFactory, FlowLayoutPanelFactory panelFactory, ColumnMapper columnMapper)
        {
            _gridFactory = gridFactory;
            _columnMapper = columnMapper;
            _flowLayoutPanelFactory = panelFactory;
        }

        public FlowLayoutPanel GetGeneral(PilotsDTO pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var grid = _gridFactory.CreateGeneralTableGrid();
            BindPilotsToGeneralGrid(grid, pilotDTOs, heatDTOs);
            var panel = _flowLayoutPanelFactory.GetForGeneral();
            panel.Controls.Add(grid);
            return panel;
        }

        private void BindPilotsToGeneralGrid(DataGridView grid, PilotsDTO pilotDTOs, List<HeatDTO> heatDTOs)
        {
            var bindingList = new BindingList<PilotDTO>(pilotDTOs);
            bindingList.AddingNew += (sender, e) =>
            {
                if (grid.Rows.Count == bindingList.Count)
                {
                    bindingList.RemoveAt(bindingList.Count - 2); //TODO 2????!
                }
            };
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
                 //TODO
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

        public FlowLayoutPanel GetSub(PilotsDTO pilotDTOs, List<HeatDTO> heatDTOs)
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

        private void BindPilotsToHeatsTables(DataGridView grid, PilotsDTO pilotDTOs, HeatDTO heatDTO)
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
        public FlowLayoutPanel GetGeneral(PilotsDTO pilotDTOs, List<HeatDTO> heatDTOs);
        public FlowLayoutPanel GetSub(PilotsDTO pilotDTOs, List<HeatDTO> heatDTOs);
        public FlowLayoutPanel GetControlPanel();
    }
}
