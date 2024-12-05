using Hekki.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hekki.App.DTO
{
    public class DTOFactory
    {
        private readonly PilotMapper _pilotMapper = new();
        private readonly HeatMapper _heatMapper = new();

        public List<HeatDTO> CreateHeatDTOs(List<Heat> heats)
        {
            var result = new List<HeatDTO>();
            foreach (var heat in heats)
            {
                result.Add(_heatMapper.Map(heat));
            }
            return result;
        }

        public List<PilotGeneralDTO> CreatePilotDTOs(List<Pilot> pilots)
        {
            var result = new List<PilotGeneralDTO>();
            foreach (var pilot in pilots)
            {
                result.Add(_pilotMapper.Map(pilot));
            }
            return result;
        }
    }
}
