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

        public List<List<string>> GetScores(List<int> numbersKarts)
        {
            var namesInOrder = ExcelWorker.ReadNamesInTotalBoard();
            pilotsCount = namesInOrder.Count;
            var scores = ExcelWorker.ReadScoresInRaceEveryOnEvery(pilotsCount, numbersKarts.Count, out int[] cols);
            var namesInRace = ExcelWorker.ReadNamesInRace(numbersKarts.Count, cols, 111);

            return GetSortedDataInOrdenNames(scores, namesInRace, namesInOrder, false);
        }
    }
}
