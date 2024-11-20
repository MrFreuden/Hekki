using Hekki.Domain.Models;

namespace Hekki.App
{
    public class RaceService
    {
        private Race _race;
        public void MakeRace(List<string> names)
        {
            var pilots = new List<Pilot>();
            foreach (string name in names) 
                pilots.Add(new Pilot(name));

            //_race = new Race(pilots, new List<Heat>(), new TestRegulation());
        }

        public void StartNextHeat()
        {
            
        }
    }

    
}
