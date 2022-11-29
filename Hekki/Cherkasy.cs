using Hekki;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Hekki
{
    public class Cherkasy
    {
        private static List<Pilot> pilots = new List<Pilot>();
        private static int totalPilots;

        public static void DoOneRace(List<int> numbersKarts)
        {
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(pilots.Count);
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersKarts.Count);
            Race.StartFinalRace(pilots, numbersKarts, numberRace, countGroups);
            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void DoQualRace(List<int> numbersKarts)
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
            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void DoFinal(List<int> numbersKarts)
        {
            Race.ReBuildCountPilotsInFirstGroup(numbersKarts);
            int numberRace = pilots[0].GetNumbersKarts().Count;
            pilots = Race.MakePilotsFromTotalBoard(Race.CountPilotsInFirstGroup);
            Race.StartFinalRace(pilots, numbersKarts, numberRace);
            ExcelWorker.WriteUsedKarts(pilots);
        }

        public static void ReadTime()
        {
            pilots = ExcelWorker.ReadTimeInRace(pilots);
            ExcelWorker.WriteTimeInTotalBoard(pilots);
        }

        public static void ReadScor()
        {
            pilots = ExcelWorker.ReadScoresInRace(pilots);
            ExcelWorker.WriteScoreInTotalBoard(pilots);
        }

        public static void SortTimeInTB()
        {
            
            var keyCells = ExcelWorker.FindKeyCellByValue("Best Lap", null);


            var range = ExcelWorker.GetTotalBoardRange(pilots.Count);
            
            

            for (int i = 0; i < keyCells.Count; i++)
            {
                range.Sort(range.Columns[keyCells[i].Column - 2], XlSortOrder.xlAscending);
            }
        }

        public static void SortTimeInRace()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("ВРЕМЯ", null);
            for (int i = 0; i < keyCells.Count; i++)
            {
                int j = 0;
                while (keyCells[i][1, j--].Value != null) { }
                var firstCellRow = keyCells[i].Row;
                var firstCellCol = keyCells[i][1, j].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][50]];


                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlAscending);
            }
        }

        public static void SortScores()
        {
            var keyCells = ExcelWorker.FindKeyCellByValue("ВСЕГО", null);

            for (int i = 0; i < keyCells.Count; i++)
            {
                int j = 0;
                while (keyCells[i][1, j--].Value != null) { }
                var firstCellRow = keyCells[i].Row;
                var firstCellCol = keyCells[i][1, j].Column;
                var lastCellRow = keyCells[i].Row + 32;
                var lastCellCol = keyCells[i].Column;

                Range rangeToSort = ExcelWorker.excel.Range[ExcelWorker.excel.Cells[firstCellRow + 1, firstCellCol + 1], keyCells[i][50]];


                rangeToSort.Sort(rangeToSort.Columns[(j - 1) * -1], XlSortOrder.xlDescending);
            }
        }

        public static void ReBuildPilots()
        {
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            pilots = Race.MakePilotsFromTotalBoard(pilotsNames.Count);
            totalPilots = pilots.Count;
        }
    }
}
