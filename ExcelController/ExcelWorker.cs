using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker
    {
        public const int MAXkarts = 10;
        public static Application excel = GetExcel();
        private static int count = 0;

        public static Application GetExcel()
        {
            Application myExcel;

            try
            {
                myExcel = (Application)Marshal2.GetActiveObject("Excel.Application");
            }
            catch (Exception)
            {
                throw new Exception("Excel не открыт");
            }
            return myExcel;
        }

        public static Range FindKeyCellByValue(
            string value,
            bool needEmpty,
            Range searchedRange)
        {
            searchedRange ??= excel.get_Range("A1", "XFD1048576");

            var finded = searchedRange.Find(value) ?? throw new Exception("Поиск по слову {" + value + "} не выполнен. Попробуйте переименовать ячейки в таблице.");
            var firstAdress = finded.Address;
            while (excel.Cells[finded.Row + 1, finded.Column].Value != null && needEmpty)
            {
                finded = searchedRange.FindNext(finded);
                if (firstAdress == finded.Address)
                    throw new Exception("While doing a cirle");
                firstAdress = finded.Address;
            }
            return finded;
        }

        public static IList<Range> FindKeyCellByValue(
            string value,
            Range searchedRange)
        {
            searchedRange ??= excel.get_Range("A1", "XFD1048576");
            var finded = searchedRange.Find(value);

            if (finded == null)
                return new List<Range>();

            var firstAdress = finded.Address;
            List<Range> ranges = new();
            while (true)
            {
                ranges.Add(finded);
                finded = searchedRange.FindNext(finded);
                if (firstAdress == finded.Address)
                    return ranges;
            }
        }

        public static void CleanData(Range rangeToClean = null, int countBellow = 50)
        {
            List<IList<Range>> keyCells = new()
            {
                FindKeyCellByValue("Номера", rangeToClean),
                FindKeyCellByValue("Best Lap", rangeToClean),
                FindKeyCellByValue("ХІТ", rangeToClean),
                FindKeyCellByValue("Карт", rangeToClean),
                FindKeyCellByValue("Пілоти", rangeToClean),
                FindKeyCellByValue("Штраф", rangeToClean),
                FindKeyCellByValue("Час", rangeToClean),
                //FindKeyCellByValue("Им'я", rangeToClean),
                //FindKeyCellByValue("Ліга", rangeToClean),
                FindKeyCellByValue("Очки", rangeToClean)
        };

            for (int j = 0; j < keyCells.Count; j++)
            {
                for (int i = 0; i < keyCells[j].Count; i++)
                {
                    string q = keyCells[j][i][2].Address.Replace("$", String.Empty);
                    string s = keyCells[j][i][countBellow].Address.Replace("$", String.Empty);
                    var aras = excel.get_Range(q, s);
                    aras.ClearContents();
                }
            }
        }

        public static Range GetTBRange(int countPilots)
        {
            var keyCells = FindKeyCellByValue("№", null);
            var keyCells2 = FindKeyCellByValue("Сума", null);
            string ad1 = keyCells[0][2, 3].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            ad2 = ad2[0] + (ad2[1] + countPilots.ToString());
            return excel.get_Range(ad1, ad2);
        }

        public static void DeleteLastUsedKartsInTotalBoard()
        {
            var numberKarts = ReadUsedKartsInTotalBoard();
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

        public static List<string> ReadTestNamesFromTxt()
        {
            List<string> names = File.ReadAllLines(@"../../../TestNames.txt").ToList();
            return names;
        }

        public static List<string> ReadNamesInTotalBoard()
        {
            var keyCells = FindKeyCellByValue("Им'я", null);
            List<string> names = new();

            int i = 2;
            while (keyCells[0].Cells[i].Value != null)
            {
                names.Add(keyCells[0].Cells[i].Value.ToString());
                i++;
            }
            return names;
        }

        public static List<List<int>> ReadUsedKartsInTotalBoard()
        {
            var keyCells = FindKeyCellByValue("Номера", null);
            if (keyCells.Count == 0)
                return new List<List<int>>();
            List<List<int>> karts = new();

            int i = 2;
            int q = 0;

            while (keyCells[0].Cells[i].Value != null)
            {
                karts.Add(new List<int>());

                string numbers = keyCells[0].Cells[i, 1].Value.ToString();
                var splitedNumbers = numbers.Split(' ').ToList();
                if (string.IsNullOrEmpty(splitedNumbers[splitedNumbers.Count - 1]))
                {
                    splitedNumbers.RemoveAt(splitedNumbers.Count - 1);
                }
                for (int j = 0, k = 0; j < splitedNumbers.Count; j++, k++)
                {
                    karts[q].Add(Int32.Parse(splitedNumbers[k]));
                }
                i++;
                q++;
            }

            return karts;
        }

        public static List<List<string>> ReadResultsInTB(string keyWord, int countPilots)
        {
            var keyCells = FindKeyCellByValue(keyWord, GetHeadersTB());
            if (keyCells.Count == 0)
            {
                return new List<List<string>>();
            }
            List<List<string>> data = new();

            int i = 0;
            int k = 1;

            for (int j = 0; j < countPilots; j++)
            {
                data.Add(new List<string>());
                for (int q = 0; q < keyCells.Count; q++)
                {
                    string number;
                    if (keyCells[q].Cells[1 + k].Value == null)
                        continue;
                    else
                        number = keyCells[q].Cells[1 + k].Value.ToString();
                    data[i].Add(number);
                }
                i++;
                k++;
            }
            return data;
        }

        public static List<string> ReadLique(int countPilots)
        {
            List<string> pilotsLiques = new();
            var keyCells = FindKeyCellByValue("Ліга", null);
            if (keyCells.Count == 0)
                return pilotsLiques;

            for (int i = 2; i < countPilots + 2; i++)
                pilotsLiques.Add(keyCells[0].Cells[i].Value.ToString());

            return pilotsLiques;
        }

        public static List<List<string>> ReadNamesInRace(int pilotsCount,
            int[] indexesNeededCols,
            int countBreaker = 50)
        {
            var pilotsNames = new List<List<string>>();
            var keyScore = FindKeyCellByValue("Пілоти", null);
            for (int j = 0, k = 0; j < keyScore.Count; j++)
            {
                if (!(indexesNeededCols.Contains(keyScore[j].Column)))
                    continue;

                var startIndexName = keyScore[j].Row + 1;

                pilotsNames.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexName < countBreaker; startIndexName++)
                {
                    var val = Convert.ToString(excel.Cells[startIndexName, keyScore[j].Column].Value);
                    if (val == null)
                        continue;

                    pilotsNames[k].Add(val);
                    i++;
                }
                k++;
            }
            return pilotsNames;
        }

        public static List<List<string>> ReadResultsInRace(string keyWord,
            int pilotsCount,
            out int[] cols,
            int countBreaker = 50)
        {
            var pilotsData = new List<List<string>>();
            var keyCells = FindKeyCellByValue(keyWord, null);
            cols = new int[keyCells.Count];
            for (int j = 0; j < keyCells.Count; j++)
            {
                var startIndexKey = keyCells[j].Row + 1;
                int columnIndexName = GetIndexNearColLeft("Пілоти", keyCells[j].Row, keyCells[j][startIndexKey - 1].Column);
                cols[j] = columnIndexName;

                if (Convert.ToString(excel.Cells[startIndexKey, columnIndexName].Value) == null)
                    continue;
                pilotsData.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexKey < countBreaker; startIndexKey++)
                {
                    if (Convert.ToString(excel.Cells[startIndexKey, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(excel.Cells[startIndexKey, keyCells[j].Column].Value);

                    pilotsData[j].Add(val);
                    i++;
                }
            }
            return pilotsData;
        }

        public static List<List<string>> ReadScoresInRaceEveryOnEvery(int pilotsCount, int countInGroup, out int[] cols)
        {
            var pilotsScores = new List<List<string>>();
            var keyScore = FindKeyCellByValue("Разом", null);
            cols = new int[keyScore.Count];
            for (int j = 0; j < pilotsCount; j++)
            {
                var startIndexScore = keyScore[j].Row + 1;
                int columnIndexName = GetIndexNearColLeft("Пілоти", keyScore[j].Row, keyScore[j][startIndexScore - 1].Column);
                cols[j] = columnIndexName;
                pilotsScores.Add(new List<string>());
                for (int i = 0; i < countInGroup; startIndexScore++)
                {
                    if (Convert.ToString(excel.Cells[startIndexScore, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(excel.Cells[startIndexScore, keyScore[j].Column].Value);

                    pilotsScores[j].Add(val);
                    i++;
                }
            }
            return pilotsScores;
        }

        public static void WriteInfoDataInRace(string keyWord, List<List<string>> pilotsDataByGroup)
        {
            var keyCells = FindKeyCellByValue(keyWord, true, null);
            var startIndex = GetStartIndexOfEmptyTable(keyCells[1].Row, keyCells[1].Column);

            foreach (var groupData in pilotsDataByGroup)
            {
                List<string> fullGroupData = new(groupData);
                if (fullGroupData.Count < MAXkarts)
                    fullGroupData = AddEmptysInList(groupData, "");

                foreach (var data in fullGroupData)
                {
                    //System.Threading.Thread.Sleep(500);
                    excel.Cells[startIndex, keyCells[1].Column] = data;
                    startIndex++;
                }
            }
        }

        public static void WriteDataInCol(string keyWord, List<string> data, int countMargin = 0)
        {
            var keyCells = FindKeyCellByValue(keyWord, null);
            var startIndex = keyCells[0].Row + 1 + countMargin;
            for (int i = 0; i < data.Count; i++)
            {
                excel.Cells[startIndex, keyCells[0].Column] = data[i];
                startIndex++;
            }
        }

        public static void WriteResultsInTB(string keyWord, List<List<string>> pilotsResultsData)
        {
            var keyCells = FindKeyCellByValue(keyWord, GetHeadersTB());
            for (int i = 0; i < keyCells.Count; i++)
            {
                var startIndex = keyCells[0].Row + 1;
                for (int j = 0; j < pilotsResultsData.Count; j++)
                {
                    try
                    {
                        excel.Cells[startIndex, keyCells[i].Column].Value = pilotsResultsData[j][i].ToString();
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
            var keyCells = FindKeyCellByValue("Номера", GetHeadersTB());
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
            var keyCell = FindKeyCellByValue(keyWord, range);
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

        private static int GetStartIndexOfEmptyTable(int row, int column)
        {
            int index = row;
            while (excel.Cells[index, column].Value != null)
                index++;
            return index;
        }

        private static List<string> AddEmptysInList(List<string> group, string value)
        {
            while (group.Count < MAXkarts)
                group.Add(value);
            return group;
        }

        private static Range GetHeadersTB()
        {
            var keyCells = FindKeyCellByValue("№", null);
            var keyCells2 = FindKeyCellByValue("Сума", null);
            string ad1 = keyCells[0].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            return excel.get_Range(ad1, ad2);
        }

        private static int GetIndexNearColLeft(string keyWord, int startRow, int startCol)
        {
            int index = 0;
            while (excel.Cells[startRow, startCol - index].Value != keyWord)
                index++;

            return startCol - index;
        }
    }
}//579