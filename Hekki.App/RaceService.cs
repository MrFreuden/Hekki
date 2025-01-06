using Hekki.App.DTO;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class RaceService
    {
        private Race _race;
        private Regulation _regulation;
        private HeatService _heatService;
        private readonly DTOFactory _dTOFactory = new();
        private readonly DTOToModelSynchronizer _dTOToModelSynchronizer;
        private PilotsDTO _DTOs;

        public RaceService(Regulation regulation)
        {
            _regulation = regulation;
            _heatService = new();
            _race = MakeRace();
            _DTOs = new(_dTOFactory.CreatePilotDTOs(_race.Pilots), Sync);
            _dTOToModelSynchronizer = new(_DTOs, _race.Pilots);
        }

        public List<Pilot> Pilots => _race.Pilots;


        private Race MakeRace()
        {
            var _pilots = new List<Pilot>();
            //{
            //    _pilots = new List<Pilot>
            //{
            //    new Pilot("Test1"),
            //    new Pilot("Test2"),
            //    new Pilot("Test3"),
            //};
            //    _pilots[0].AddResult(new PointsResult(0, 5));
            //    _pilots[0].AddResult(new PointsResult(1, 4));
            //    _pilots[0].AddResult(new PointsResult(2, 3));

            //    _pilots[1].AddResult(new PointsResult(0, 3));
            //    _pilots[1].AddResult(new PointsResult(1, 5));
            //    _pilots[1].AddResult(new PointsResult(2, 4));

            //    _pilots[2].AddResult(new PointsResult(0, 4));
            //    _pilots[2].AddResult(new PointsResult(1, 3));
            //    _pilots[2].AddResult(new PointsResult(2, 5));

            //    _pilots[0].AddUsedKart(1);
            //    _pilots[0].AddUsedKart(2);
            //    _pilots[0].AddUsedKart(3);

            //    _pilots[1].AddUsedKart(4);
            //    _pilots[1].AddUsedKart(1);
            //    _pilots[1].AddUsedKart(2);

            //    _pilots[2].AddUsedKart(2);
            //    _pilots[2].AddUsedKart(3);
            //    _pilots[2].AddUsedKart(1);
            //}
            return new Race(_pilots, _heatService.Make(_regulation));
        }

        public void StartNextHeat()
        {
            _dTOToModelSynchronizer.SyncPilotDTOToModel(new PilotDTO());
        }

        public List<HeatDTO> GetHeatsDTO() => _dTOFactory.CreateHeatDTOs(_race.Heats);

        public PilotsDTO GetPilotsDTO() => _DTOs;

        public void Sync(PilotDTO pilotDTO)
        {
            _dTOToModelSynchronizer.SyncPilotDTOToModel(pilotDTO);
        }
    }
}
