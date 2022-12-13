using System.Globalization;
using System.Linq;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace ExcelController
{
    public class ExcelWorker
    {
        public const int MAXkarts = 8;
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
            if (searchedRange == null)
                searchedRange = excel.get_Range("A1", "XFD1048576");

            var finded = searchedRange.Find(value);
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
            if (searchedRange == null)
                searchedRange = excel.get_Range("A1", "XFD1048576");
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

        public static void CleanData(Range rangeToClean = null, int countBellow = 45, bool debugMode = true)
        {
            List<IList<Range>> keyCells = new()
            {
                FindKeyCellByValue("Номера", rangeToClean),
                FindKeyCellByValue("Best Lap", rangeToClean),
                FindKeyCellByValue("ХИТ", rangeToClean),
                FindKeyCellByValue("Карт", rangeToClean),
                FindKeyCellByValue("Пилоты", rangeToClean),
                FindKeyCellByValue("Штраф", rangeToClean),
                FindKeyCellByValue("Время", rangeToClean)
            };

            if (debugMode)
            {
                keyCells.Add(FindKeyCellByValue("Имя", rangeToClean));
                keyCells.Add(FindKeyCellByValue("Лига", rangeToClean));
                keyCells.Add(FindKeyCellByValue("Очки", rangeToClean));
            }

            for (int j = 0; j < keyCells.Count; j++)
            {
                for (int i = 0; i < keyCells[j].Count; i++)
                {
                    string q = keyCells[j][i][2].Address.Replace("$", String.Empty);
                    string s = keyCells[j][i][countBellow].Address.Replace("$", String.Empty);
                    var aras = excel.get_Range(q, s);
                    //aras.Interior.Color = Microsoft.Office.Interop.Excel.XlRgbColor.rgbWhite;
                    aras.ClearContents();
                }
            }


        }

        public static Range GetTotalBoardRange(int countPilots)
        {
            var keyCells = FindKeyCellByValue("№", null);
            var keyCells2 = FindKeyCellByValue("Всего", null);
            string ad1 = keyCells[0][2, 3].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            ad2 = ad2[0] + (ad2[1] + countPilots.ToString());
            return excel.get_Range(ad1, ad2);
        }

        public static void CleanColumnAfterKey(Range keyCell)
        {
            for (int i = 2; i < 100; i++)
            {
                keyCell[i] = "";
            }
        }

        public static void DeleteLastUsedKartsInTotalBoard()
        {
            var numberKarts = ReadUsedKartsInTotalBoard();
            var firstPilotsKarts = numberKarts[0].Count;

            if (firstPilotsKarts > numberKarts[numberKarts.Count - 1].Count)
            {
                foreach (var kart in numberKarts)
                {
                    if (kart.Count == firstPilotsKarts)
                    {
                        kart.RemoveAt(kart.Count - 1);
                    }
                }
            }
            else
            {
                foreach (var kart in numberKarts)
                {
                    kart.RemoveAt(kart.Count - 1);
                }
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
            var keyCells = FindKeyCellByValue("Имя", null);
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
                for (int j = 0, k = 0; j < numbers.Length; j++, k++)
                {
                    karts[q].Add(numbers[k] - '0');
                }
                i++;
                q++;
            }

            return karts;
        }

        public static List<List<int>> ReadScoresInTotalBoard(int countPilots)
        {
            var keyCells = FindKeyCellByValue("Хит", GetHeadersTB());

            List<List<int>> score = new();

            int i = 0;
            int k = 1;

            for (int j = 0; j < countPilots; j++)
            {
                score.Add(new List<int>());
                for (int q = 0; q < keyCells.Count; q++)
                {
                    int number;
                    if (keyCells[q].Cells[1 + k].Value == null)
                        continue;
                    else
                        number = (int)keyCells[q].Cells[1 + k].Value;
                    score[i].Add(number);
                }
                i++;
                k++;
            }
            return score;
        }

        public static List<List<string>> ReadTimesInTotalBoard(int countPilots)
        {
            var keyCells = FindKeyCellByValue("Best Lap", excel.Range["A1", "K100"]);
            if (keyCells.Count == 0)
            {
                return new List<List<string>>();
            }
            List<List<string>> time = new();

            int i = 0;
            int k = 1;

            for (int j = 0; j < countPilots; j++)
            {
                time.Add(new List<string>());
                for (int q = 0; q < keyCells.Count; q++)
                {
                    string number;
                    if (keyCells[q].Cells[1 + k].Value == null)
                        continue;
                    else
                        number = keyCells[q].Cells[1 + k].Value.ToString();
                    time[i].Add(number);
                }
                i++;
                k++;
            }
            return time;
        }

        public static List<string> ReadLique(int countPilots)
        {
            List<string> pilotsLiques = new();
            var keyCells = FindKeyCellByValue("Лига", null);
            if (keyCells.Count == 0)
                return pilotsLiques;

            for (int i = 2; i < countPilots + 2; i++)
            {
                pilotsLiques.Add(keyCells[0].Cells[i].Value.ToString());
            }

            return pilotsLiques;
        }

        public static List<List<string>> ReadNamesInRace(int pilotsCount, int[] indexesNeededCols)
        {
            var pilotsNames = new List<List<string>>();
            var keyScore = FindKeyCellByValue("Пилоты", null);
            for (int j = 0, k = 0; j < keyScore.Count; j++)
            {
                if ( ! (indexesNeededCols.Contains(keyScore[j].Column)))
                    continue;

                var startIndexScore = keyScore[j].Row + 1;

                pilotsNames.Add(new List<string>());
                for (int i = 0; i < pilotsCount; startIndexScore++)
                {
                    var val = Convert.ToString(excel.Cells[startIndexScore, keyScore[j].Column].Value);
                    if (val == null)
                        continue;

                    pilotsNames[k].Add(val);
                    i++;
                }
                k++;
            }
            return pilotsNames;
        }

        public static List<List<string>> ReadScoresInRace(int pilotsCount, out int[] cols)
        {
            var pilotsScores = new List<List<string>>();
            var keyScore = FindKeyCellByValue("Итого", null);
            cols = new int[keyScore.Count];
            for (int j = 0; j < keyScore.Count; j++)
            {
                var startIndexScore = keyScore[j].Row + 1;
                int columnIndexName = 0;

                while (excel.Cells[keyScore[j].Row, keyScore[j][startIndexScore - 1, columnIndexName].Column].Value != "Пилоты")
                    columnIndexName--;

                columnIndexName = keyScore[j].Column - ((columnIndexName * -1) + 1);
                cols[j] = columnIndexName;
                pilotsScores.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexScore < 50; startIndexScore++)
                {
                    if (Convert.ToString(excel.Cells[startIndexScore, columnIndexName].Value) == null)
                    {
                        continue;
                    }
                    var val = Convert.ToString(excel.Cells[startIndexScore, keyScore[j].Column].Value);
                    
                    pilotsScores[j].Add(val);
                    i++;
                }
            }
            return pilotsScores;
        }

        public static List<List<string>> ReadScoresInRaceEveryOnEvery(int pilotsCount, int countInGroup, out int[] cols)
        {
            var pilotsScores = new List<List<string>>();  
            var keyScore = FindKeyCellByValue("Итого", null);
            cols = new int[keyScore.Count];
            for (int j = 0; j < pilotsCount; j++)
            {
                var startIndexScore = keyScore[j].Row + 1;
                int columnIndexName = 0;

                while (excel.Cells[keyScore[j].Row, keyScore[j][startIndexScore - 1, columnIndexName].Column].Value != "Пилоты")
                    columnIndexName--;

                columnIndexName = keyScore[j].Column - ((columnIndexName * -1) + 1);
                cols[j] = columnIndexName;
                pilotsScores.Add(new List<string>());
                for (int i = 0; i < countInGroup; startIndexScore++)
                {
                    if (Convert.ToString(excel.Cells[startIndexScore, columnIndexName].Value) == null)
                    {
                        continue;
                    }
                    var val = Convert.ToString(excel.Cells[startIndexScore, keyScore[j].Column].Value);

                    pilotsScores[j].Add(val);
                    i++;
                }
            }
            return pilotsScores;
        }

        public static List<List<string>> ReadTimesInRace(int pilotsCount, out int[] cols)
        {
            var pilotsTimes = new List<List<string>>();
            var keyTime = FindKeyCellByValue("Время", null);
            cols = new int[keyTime.Count];
            for (int j = 0; j < keyTime.Count; j++)
            {
                var startIndexTime = keyTime[j].Row + 1;
                int columnIndexName = 0;

                while (excel.Cells[keyTime[j].Row, keyTime[j][startIndexTime - 1, columnIndexName].Column].Value != "Пилоты")
                    columnIndexName--;

                columnIndexName = keyTime[j].Column - ((columnIndexName * -1) + 1);
                cols[j] = columnIndexName;
                if (Convert.ToString(excel.Cells[startIndexTime, columnIndexName].Value) == null)
                {
                    continue;
                }
                pilotsTimes.Add(new List<string>());
                for (int i = 0; i < pilotsCount && startIndexTime < 50; startIndexTime++)
                {
                    if (Convert.ToString(excel.Cells[startIndexTime, columnIndexName].Value) == null)
                    {
                        continue;
                    }
                    var val = Convert.ToString(excel.Cells[startIndexTime, keyTime[j].Column].Value);

                    pilotsTimes[j].Add(val);
                    i++;
                }
            }
            return pilotsTimes;
        }

        public static void WriteLique(List<string> pilotsLiques)
        {
            var keyCells = FindKeyCellByValue("Лига", null);
            var startIndex = keyCells[0].Row + 1;
            for (int i = 0; i < pilotsLiques.Count; i++)
            {
                excel.Cells[startIndex, keyCells[0].Column] = pilotsLiques[i];
                startIndex++;
            }
        }

        public static void WriteNamesInRace(List<List<string>> pilotsNamesByGroup, int numberRace)
        {
            var keyCells = FindKeyCellByValue("Пилоты", true, null);
            var startIndex = GetStartIndexOfEmptyTable(keyCells[1].Row, keyCells[1].Column);

            foreach (var group in pilotsNamesByGroup)
            {
                List<string> fullGroup = new(group);
                if (fullGroup.Count < MAXkarts)
                    fullGroup = AddEmptysInList(group, "");

                foreach (var pilot in fullGroup)
                {
                    //System.Threading.Thread.Sleep(500);
                    excel.Cells[startIndex, keyCells[1].Column] = pilot;
                    startIndex++;

                }
            }
        }

        public static void WriteKartsInRace(List<List<string>> pilotsKartsByGroup, int numberRace)
        {
            var keyCells = FindKeyCellByValue("Карт", true, null);
            var startIndex = GetStartIndexOfEmptyTable(keyCells[1].Row, keyCells[1].Column);

            foreach (var groupNumbers in pilotsKartsByGroup)
            {
                List<string> fullGroupNumbers = new(groupNumbers);
                if (fullGroupNumbers.Count < MAXkarts)
                    fullGroupNumbers = AddEmptysInList(groupNumbers, "");

                foreach (var number in fullGroupNumbers)
                {
                    //System.Threading.Thread.Sleep(500);
                    excel.Cells[startIndex, keyCells[1].Column] = number;
                    startIndex++;
                }
            }
        }


        public static void WriteUsedKarts(List<string> pilotsKarts)
        {
            var keyCells = FindKeyCellByValue("Номера", null);
            var startIndex = keyCells[0].Row + 1;
            for (int i = 0; i < pilotsKarts.Count; i++)
            {
                excel.Cells[startIndex, keyCells[0].Column] = pilotsKarts[i];
                startIndex++;
            }
        }

        public static void WriteUsedKartsAmators(List<string> pilotsKarts, int countMargin)
        {
            var keyCells = FindKeyCellByValue("Номера", null);
            var startIndex = keyCells[0].Row + 1 + countMargin;

            for (int i = 0; i < pilotsKarts.Count; i++)
            {
                excel.Cells[startIndex, keyCells[0].Column] = pilotsKarts[i];
                startIndex++;
            }
        }

        public static void WriteScoreInTotalBoard(List<List<string>> pilotsScores)
        {
            var keyCells = FindKeyCellByValue("Хит", GetHeadersTB());
            for (int i = 0; i < keyCells.Count; i++)
            {
                var startIndex = keyCells[0].Row + 1;
                for (int j = 0; j < pilotsScores.Count; j++)
                {
                    excel.Cells[startIndex, keyCells[i].Column].Value = pilotsScores[j][i].ToString();
                    startIndex++;
                }
            }
        }

        public static void WriteTimeInTotalBoard(List<List<string>> pilotsTimes)
        {
            var myCulture = new CultureInfo("ru-RU");
            myCulture.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = myCulture;

            var keyCells = FindKeyCellByValue("Best Lap", excel.Range["A1", "K100"]);


            for (int i = 0; i < keyCells.Count; i++)
            {
                var startIndex = keyCells[0].Row + 1;
                for (int j = 0; j < pilotsTimes.Count; j++)
                {
                    try
                    {
                        excel.Cells[startIndex, keyCells[i].Column] = pilotsTimes[j][i].ToString();
                    }
                    catch (ArgumentOutOfRangeException)
                    {

                    }

                    startIndex++;
                }
            }
        }

        public static void WriteNamesInTotalBoard(List<string> names)
        {
            var keyCells = FindKeyCellByValue("Имя", null);
            CleanColumnAfterKey(keyCells[0]);
            for (int i = 2, j = 0; j < names.Count; i++, j++)
            {
                keyCells[0][i] = names[j];
            }
        }

        public static void WriteUsedKartsInTotalBoard(List<List<int>> numberKarts)
        {
            var keyCells = FindKeyCellByValue("Номера", excel.Range["A1", "K100"]);
            int k = 2;
            for (int i = 0; i < numberKarts.Count; i++)
            {
                string numbers = "";
                for (int j = 0; j < numberKarts[i].Count; j++)
                {
                    numbers += numberKarts[i][j].ToString();
                }
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
            {
                index++;
            }
            return index;
        }

        private static List<string> AddEmptysInList(List<string> group, string value)
        {
            while (group.Count < MAXkarts)
            {
                group.Add(value);
            }
            return group;
        }

        private static Range GetHeadersTB()
        {
            var keyCells = FindKeyCellByValue("№", null);
            var keyCells2 = FindKeyCellByValue("Всего", null);
            string ad1 = keyCells[0].Address.Replace("$", String.Empty);
            string ad2 = keyCells2[0].Address.Replace("$", String.Empty);
            return excel.get_Range(ad1, ad2);
        }
    }
}