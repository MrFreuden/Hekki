namespace Hekki.Domain.Models
{
    public class Race
    {
        private List<Pilot> _pilots;
        private List<Heat> _heats;
        private Regulation _regulation;

        public Race(List<Pilot> pilots, Regulation regulation)
        {
            _pilots = pilots;
            _regulation = regulation;
            CreateHeats();
        }

        private void CreateHeats()
        {
            _heats = new List<Heat>();
            for (int i = 0; i < _regulation.HeatCount; i++)
            {
                _heats.Add(new Heat(_regulation.SortMethods[i], _regulation.HeatResults[i]));
            }
        }

        public UIGeneralTableDTO GetGeneralTable()
        {
            throw new NotImplementedException();
        }
    }

    public class UIGeneralTableDTO
    {
        
    }
}
