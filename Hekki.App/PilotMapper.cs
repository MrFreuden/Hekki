using Hekki.App.DTO;
using Hekki.Domain.Interfaces;
using Hekki.Domain.Models;

namespace Hekki.App
{
    public class PilotMapper : IMapper<Pilot, PilotGeneralDTO>
    {
        public PilotGeneralDTO Map(Pilot source)
        {
            return new PilotGeneralDTO(source.Name, source.UsedKarts.ToList(), source.Results.ToList());
        }

        public Pilot MapBack(PilotGeneralDTO destination)
        {
            return new Pilot(destination.Name);
        }
    }

    public class HeatMapper : IMapper<Heat, HeatDTO>
    {
        public HeatDTO Map(Heat source)
        {
            var columns = new List<HeatColumnViewModel>()
            {
                new HeatColumnViewModel(source.ResultType.Label, source.ResultType.GetType())
            };
            
            return new HeatDTO(source.Index, columns, source.MaxGroupCapacity, source.GroupsCount);
        }

        public Heat MapBack(HeatDTO destination)
        {
            var t = destination.Columns.FirstOrDefault().DataType;
            var s = Activator.CreateInstance(t);
            return new Heat(destination.HeatIndex, (IResult)s, destination.MaxGroupCapacity, destination.GroupsCount);
        }
    }
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
        TSource MapBack(TDestination destination);
    }
}
