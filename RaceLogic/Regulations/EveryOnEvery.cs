using ExcelController;

namespace RaceLogic.Regulations
{
    public class EveryOnEvery : Regulation
    {
        public void DoRaces(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartRandomRace(pilots, numbersKarts);

        }

        public void ReadScor(List<int> numbersKarts)
        {
            var names = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = names.Count;
            var scores = ExcelWorker.ReadScoresInRaceEveryOnEvery(names, numbersKarts.Count);


            ExcelWorker.WriteScoreInTotalBoard(scores);
        }
    }
}
