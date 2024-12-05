namespace Hekki.Domain.Models
{
    public class Race
    {
        private readonly List<Pilot> _pilots;
        private readonly List<Heat> _heats;

        public Race(List<Pilot> pilots, List<Heat> heats)
        {
            _pilots = pilots;
            _heats = heats;
        }

        public List<Pilot> Pilots => _pilots;

        public List<Heat> Heats => _heats;
    }
}
