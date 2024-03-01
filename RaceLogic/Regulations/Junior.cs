using ExcelController;
using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace RaceLogic.Regulations
{
    public class Junior : Regulation
    {
        public void DoQualRandom(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartHeatRace(pilots, numbersKarts, 0);

        }

        public void DoQualDead(List<int> numbersKarts, int numberOfRace)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartHeatRace(pilots, numbersKarts, numberOfRace);

        }

        public void DoQualByList(List<int> numbersKarts)
        {
            pilots.Clear();
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            totalPilots = pilots.Count;

            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            Race.StartFinalRace(pilots, numbersKarts, 0);

        }

        public void DoRace(List<int> numbersKarts)
        {
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersKarts.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);

        }

        public void DoFinal(List<int> numbersKarts)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);

        }

        public void DoFinalDead(List<int> numbersKarts)
        {
            int numberRace = pilots[0].GetNumbersKarts().Count;
            if (pilots.Count <= 8)
            {
                pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            }
            else
            {
                pilots = Race.MakePilotsFromTotalBoard(8);
            }
            
            Race.StartFinalRace(pilots, numbersKarts, numberRace);

        }

        public void SortTimeDead()
        {
            string firstCell = "C";
            var keyCell = ExcelWorker.FindKeyCellByValue("Усього", null);
            var address = keyCell[0].Address;
            string lastCell = address[1].ToString();
            lastCell += (3 + pilots.Count).ToString();
            int w = 4;

            Range rangeToSort = ExcelWorker.excel.Range[firstCell + w.ToString(), lastCell];
            var c2 = rangeToSort.Columns[keyCell[0].Column];
            rangeToSort.Sort(c2, XlSortOrder.xlAscending);
        }
    }
}
