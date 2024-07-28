using Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public static class ExcelRead
    {
        public static string GetValue(int row, int col)
        {
            return ExcelWorker.excel.Cells[row, col].Value.ToString();
        }

        public static Range FindKeyCellByValue(
            string value,
            bool needEmpty,
            Range searchedRange)
        {
            searchedRange ??= ExcelWorker.excel.get_Range("A1", "XFD1048576");

            var finded = searchedRange.Find(value) ?? throw new Exception("Поиск по слову {" + value + "} не выполнен. Попробуйте переименовать ячейки в таблице.");
            var firstAdress = finded.Address;
            while (ExcelWorker.excel.Cells[finded.Row + 1, finded.Column].Value != null && needEmpty)
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
            searchedRange ??= ExcelWorker.excel.get_Range("A1", "XFD1048576");
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

        public static List<string> ReadTestNamesFromTxt()
        {
            List<string> names = File.ReadAllLines(@"../../../TestNames.txt").ToList();
            return names;
        }

        public static List<string> ReadNamesInTotalBoard()
        {
            var keyCells = FindKeyCellByValue("Ім'я", null);
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
            var keyCells = FindKeyCellByValue(keyWord, ExcelHelper.GetHeadersTB());
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
                    var val = Convert.ToString(ExcelWorker.excel.Cells[startIndexName, keyScore[j].Column].Value);
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
                int columnIndexName = ExcelHelper.GetIndexNearColLeft("Пілоти", keyCells[j].Row, keyCells[j][startIndexKey - 1].Column);
                cols[j] = columnIndexName;

                if (Convert.ToString(ExcelWorker.excel.Cells[startIndexKey, columnIndexName].Value) == null)
                    continue;
                pilotsData.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexKey < countBreaker; startIndexKey++)
                {
                    if (Convert.ToString(ExcelWorker.excel.Cells[startIndexKey, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(ExcelWorker.excel.Cells[startIndexKey, keyCells[j].Column].Value);

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
                int columnIndexName = ExcelHelper.GetIndexNearColLeft("Пілоти", keyScore[j].Row, keyScore[j][startIndexScore - 1].Column);
                cols[j] = columnIndexName;
                pilotsScores.Add(new List<string>());
                for (int i = 0; i < countInGroup; startIndexScore++)
                {
                    if (Convert.ToString(ExcelWorker.excel.Cells[startIndexScore, columnIndexName].Value) == null)
                        continue;
                    var val = Convert.ToString(ExcelWorker.excel.Cells[startIndexScore, keyScore[j].Column].Value);

                    pilotsScores[j].Add(val);
                    i++;
                }
            }
            return pilotsScores;
        }
    }
}
