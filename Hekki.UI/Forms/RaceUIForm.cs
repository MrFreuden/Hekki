using Hekki.App;
using Hekki.App.DTO;
using Hekki.Domain.Models;
using Hekki.UI.FormElementsFactorys;

namespace Hekki.UI
{
    public partial class RaceUIForm : Form
    {
        private RaceService _raceService;
        private PilotsDTO _pilotsDTO;
        private List<HeatDTO> _heatDTOs;
        private UIPanelFactory _block;
        public RaceUIForm(Regulation regulation)
        {
            _raceService = new RaceService(regulation);

            _pilotsDTO = new PilotsDTO(_raceService.GetPilotsDTO());
            _pilotsDTO.PilotAdded += (sender, pilot) => _raceService.AddNewPilot(pilot);

            _heatDTOs = _raceService.GetHeatsDTO();

            _block = new UIFlowLayoutPanelFactory(new DataGridViewFactory(), new FlowLayoutPanelFactory(), new ColumnMapper());

            InitializeComponent();
            DrawGeneralTable();
            DrawHeats();
        }

        private void DrawGeneralTable()
        {
            var panel = _block.GetGeneral(_pilotsDTO, _heatDTOs);
            this.Controls.Add(panel);
        }

        private void DrawHeats()
        {
            var panel = _block.GetSub(_pilotsDTO, _heatDTOs);
            this.Controls.Add(panel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            //var s = flowLayoutPanel2.Controls;
            //_raceService.StartNextHeat();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
