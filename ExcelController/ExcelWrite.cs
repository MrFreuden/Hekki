using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public static class ExcelWrite
    {
        public static void CleanData(Range rangeToClean = null, int countBellow = 50)
        {
            List<IList<Range>> keyCells = new()
            {
                ExcelRead.FindKeyCellByValue("Номера", rangeToClean),
                ExcelRead.FindKeyCellByValue("Best Lap", rangeToClean),
                ExcelRead.FindKeyCellByValue("ХІТ", rangeToClean),
                ExcelRead.FindKeyCellByValue("Карт", rangeToClean),
                ExcelRead.FindKeyCellByValue("Пілоти", rangeToClean),
                ExcelRead.FindKeyCellByValue("Штраф", rangeToClean),
                ExcelRead.FindKeyCellByValue("Час", rangeToClean),
                ExcelRead.FindKeyCellByValue("Ім'я", rangeToClean),
                ExcelRead.FindKeyCellByValue("Ліга", rangeToClean),
                ExcelRead.FindKeyCellByValue("Очки", rangeToClean)
        };

            for (int j = 0; j < keyCells.Count; j++)
            {
                for (int i = 0; i < keyCells[j].Count; i++)
                {
                    string q = keyCells[j][i][2].Address.Replace("$", String.Empty);
                    string s = keyCells[j][i][countBellow].Address.Replace("$", String.Empty);
                    var aras = ExcelWorker.excel.get_Range(q, s);
                    aras.ClearContents();
                }
            }
        }

        public static void DeleteLastUsedKartsInTotalBoard()
        {
            var numberKarts = ExcelRead.ReadUsedKartsInTotalBoard();
            var firstPilotsKarts = numberKarts[0].Count;

            if (firstPilotsKarts > numberKarts[numberKarts.Count - 1].Count)
            {
                foreach (var kart in numberKarts)
                    if (kart.Count == firstPilotsKarts)
                        kart.RemoveAt(kart.Count - 1);
            }
            else
            {
                foreach (var kart in numberKarts)
                    kart.RemoveAt(kart.Count - 1);
            }
            WriteUsedKartsInTotalBoard(numberKarts);
        }
        public static void WriteInfoDataInRace(string keyWord, List<List<string>> pilotsDataByGroup)
        {
            var keyCells = ExcelRead.FindKeyCellByValue(keyWord, true, null);
            var startIndex = ExcelHelper.GetStartIndexOfEmptyTable(keyCells[1].Row, keyCells[1].Column);

            foreach (var groupData in pilotsDataByGroup)
            {
                List<string> fullGroupData = new(groupData);
                if (fullGroupData.Count < ExcelWorker.MAXkarts)
                    fullGroupData = ExcelHelper.AddEmptysInList(groupData, "");

                foreach (var data in fullGroupData)
                {
                    //System.Threading.Thread.Sleep(500);
                    ExcelWorker.excel.Cells[startIndex, keyCells[1].Column] = data;
                    startIndex++;
                }
            }
        }

        public static void WriteDataInCol(string keyWord, List<string> data, int countMargin = 0)
        {
            var keyCells = ExcelRead.FindKeyCellByValue(keyWord, null);
            var startIndex = keyCells[0].Row + 1 + countMargin;
            for (int i = 0; i < data.Count; i++)
            {
                ExcelWorker.excel.Cells[startIndex, keyCells[0].Column] = data[i];
                startIndex++;
            }
        }

        public static void WriteResultsInTB(string keyWord, List<List<string>> pilotsResultsData)
        {
            var keyCells = ExcelRead.FindKeyCellByValue(keyWord, ExcelHelper.GetHeadersTB());
            for (int i = 0; i < keyCells.Count; i++)
            {
                var startIndex = keyCells[0].Row + 1;
                for (int j = 0; j < pilotsResultsData.Count; j++)
                {
                    try
                    {
                        ExcelWorker.excel.Cells[startIndex, keyCells[i].Column].Value = pilotsResultsData[j][i].ToString();
                    }
                    catch (Exception)
                    {

                    }
                    startIndex++;
                }
            }
        }

        public static void WriteUsedKartsInTotalBoard(List<List<int>> numberKarts)
        {
            var keyCells = ExcelRead.FindKeyCellByValue("Номера", ExcelHelper.GetHeadersTB());
            int k = 2;
            for (int i = 0; i < numberKarts.Count; i++)
            {
                string numbers = "";
                for (int j = 0; j < numberKarts[i].Count; j++)
                    numbers += numberKarts[i][j].ToString() + " ";
                keyCells[0][k].Value = numbers;
                k++;
            }
        }

        public static void WriteTestData(string path, string keyWord, Range range = null)
        {
            List<string> data = File.ReadAllLines(path).ToList();
            var keyCell = ExcelRead.FindKeyCellByValue(keyWord, range);
            int h = 0;
            for (int i = 0; i < keyCell.Count; i++)
            {
                for (int j = 0; data[h] != "~"; j++, h++)
                {
                    if (data[h] == "")
                        continue;
                    keyCell[i][j + 2].Value = data[h];
                }
                h++;
            }
        }
    }
}
