using ExcelController;

namespace RaceLogic.Regulations
{
    public class EveryOnEvery : Regulation
    {
        public void DoRaces(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelRead.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartRandomRace(pilots, numbersKarts);

        }

        public List<List<string>> GetScores(List<int> numbersKarts)
        {
            var namesInOrder = ExcelRead.ReadNamesInTotalBoard();
            pilotsCount = namesInOrder.Count;
            var scores = ExcelRead.ReadScoresInRaceEveryOnEvery(pilotsCount, numbersKarts.Count, out int[] cols);
            var namesInRace = ExcelRead.ReadNamesInRace(numbersKarts.Count, cols, 111);

            return GetSortedDataInOrdenNames(scores, namesInRace, namesInOrder, false);
        }
    }
}
