using Hekki.App.DTO;
using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PilotMapper : IMapper<Pilot, PilotDTO>
    {
        public PilotDTO Map(Pilot source)
        {
            return new PilotDTO(source.Name, source.UsedKarts, source.Results.ToList(), source.Id);
        }

        public Pilot MapBack(PilotDTO destination)
        {
            return new Pilot(destination.Name);
        }
    }

    public class HeatMapper : IMapper<Heat, HeatDTO>
    {
        public HeatDTO Map(Heat source)
        {
            var column = new HeatColumnViewModel(source.ResultType.Name, source.ResultType.GetType());
            
            return new HeatDTO(source.Index, column, source.MaxGroupCapacity, source.GroupsCount);
        }

        public Heat MapBack(HeatDTO destination)
        {
            var t = destination.Column.DataType;
            var s = Activator.CreateInstance(t);
            return new Heat(destination.HeatIndex, (IResult)s, destination.MaxGroupCapacity, destination.GroupsCount);
        }
    }
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TSource MapBack(TDestination destination);
    }

    public class DTOToModelMapper
    {
        public void SyncPilotDTOToModel(PilotDTO dto, Pilot model)
        {
            model.Name = dto.Name;
            model.UsedKarts = new Karts(dto.UsedKarts);
            model.Results = dto.Results.ToList();

            dto.Id = model.Id; //TODO: разобраться с этим
        }

        public void SyncModelToPilotDTO(Pilot model, PilotDTO dto)
        {
            dto.Id = model.Id;
            dto.Name = model.Name;
            dto.UsedKarts = new Karts(model.UsedKarts);

            dto.Results = model.Results.ToList();
        }
    }
}
