using Hekki.App.DTO;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class RaceService
    {
        private Race _race;
        private Regulation _regulation;
        private HeatService _heatService;
        private readonly PilotMapper _pilotMapper = new();
        private readonly HeatMapper _heatMapper = new();
        public RaceService(Regulation regulation)
        {
            _regulation = regulation;
            _heatService = new();
            _race = MakeRace();
        }

        public IReadOnlyList<Pilot> Pilots => _race.Pilots;


        private Race MakeRace()
        {
            var _pilots = new List<Pilot>();
            {
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
            }
            return new Race(_pilots, _heatService.Make(_regulation));
        }

        public void StartNextHeat()
        {
            
        }

        public IEnumerable<HeatDTO> GetHeatsDTO()
        {
            foreach (var heat in _race.Heats)
            {
                yield return _heatMapper.Map(heat);
            }
        }

        public IEnumerable<PilotGeneralDTO> GetPilotsDTO()
        {
            foreach (var pilot in _race.Pilots)
            {
                yield return _pilotMapper.Map(pilot);
            }
        }
    }
}
