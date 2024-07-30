using ExcelController;

namespace RaceLogic.Regulations
{
    public class TestNew : Regulation
    {
        public void DoOneRace(List<int> numbersKarts)
        {
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersKarts.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
        }

        public void DoQualRace(List<int> numbersKarts)
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
            Race.StartHeatRace(pilots, numbersKarts, numberRace);
        }

        public void DoNextRace(List<int> numbersKarts)
        {
            if (pilots.Count < numbersKarts.Count)
            {
                var k1 = ExcelWorker.FindKeyCellByValue("Карт", null);
                var k2 = ExcelWorker.FindKeyCellByValue("Пілоти", null);
                k1[4][2] = 0.ToString();
                k2[4][2] = 0.ToString();
                return;
            }
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            if (pilots.Count < numbersKarts.Count * 2 && pilotsCount % 2 > 0)
            {
                pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            }
            else
            {
                pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup * 2);
            }
            Race.StartSemiRace(pilots, numbersKarts, 4);
        }

        public void DoFinal(List<int> numbersKarts)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);

        }
    }
}
