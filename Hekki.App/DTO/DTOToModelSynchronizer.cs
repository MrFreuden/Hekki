using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App.DTO
{
    public class DTOToModelSynchronizer
    {
        private PilotsDTO _pilotDTOs;
        private List<Pilot> _pilotModels;

        public DTOToModelSynchronizer(PilotsDTO pilotDTOs, List<Pilot> pilotModels)
        {
            _pilotDTOs = pilotDTOs;
            _pilotModels = pilotModels;
        }

        public void SyncPilotDTOToModel(PilotDTO dto)
        {
            var model = _pilotModels.FirstOrDefault(p => p.Id == dto.Id);
            if (model == null)
            {
                model = new Pilot("");
                _pilotModels.Add(model);
            }
            model.Name = dto.Name;
            model.UsedKarts = new List<Kart>(dto.UsedKarts);
            model.Results = dto.Results.ToList();

            dto.Id = model.Id; //TODO: разобраться с этим
        }

        public void SyncModelToPilotDTO(PilotDTO model)
        {
            var dto = _pilotDTOs.FirstOrDefault(p => p.Id == model.Id);
            if (dto == null)
            {
                dto = new PilotDTO();
                _pilotDTOs.Add(dto);
            }
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.UsedKarts = new FullyObservableCollection<Kart>(model.UsedKarts);
            dto.Results = new FullyObservableCollection<IResult>(model.Results.ToList());
        }
    }
}
