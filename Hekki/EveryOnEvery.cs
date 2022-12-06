using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hekki;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace Hekki
{
    public class Every : Regulation
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
