using ExcelController;
namespace RaceLogic.Regulations
{
    public class School : Regulation
    {
        public void DoRace(List<int> numbersKarts)
        {
            int numberRace;
            try
            {
                numberRace = pilots[0].GetNumbersKarts().Count;
            }
            catch (Exception)
            {
                numberRace = 0;
            }

            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
        }
    }
}
