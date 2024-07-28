using ExcelController;
namespace RaceLogic
{
    public class Race
    {
        public static int CountPilotsInFirstGroup { get { return _countPilotsInFirstGroup; } }
        public static int CountPilotsInFirstGroupAmators { get { return _countPilotsInFirstGroupAmators; } }
        
        private static Random rng = new();
        private static int _countPilotsInFirstGroup;
        private static int _countPilotsInFirstGroupAmators;

        public static void StartHeatRace(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            Shuffle(pilots);
            var groups = DivideByGroup(pilots, numbers);
            DoAssignment(groups, numbers, numberRace);
        }

        public static void StartSemiRace(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            var groups = DivideByGroup(pilots, numbers);
            DoAssignment(groups, numbers, numberRace);
        }

        public static void StartFinalRace(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            var groups = SimpleDivideByGroup(pilots, numbers);
            DoAssignment(groups, numbers, numberRace);
        }

        public static void StartFinalAmators(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            var groups = SimpleDivideByGroup(pilots, numbers);
            DoAssignment(groups, numbers, numberRace);
        }

        public static void StartRandomRace(List<Pilot> pilots, List<int> numbers)
        {
            var groups = new List<List<Pilot>>();
            var combos = Combination.GetComboEveryOnEvery(pilots.Count, numbers.Count);
            Shuffle(pilots);
            for (int i = 0; i < pilots.Count; i++)
            {
                DoAssignmentByCombo(pilots, numbers, combos[i]);
                groups.Add(new List<Pilot>());
                for (int j = 0; j < numbers.Count; j++)
                {
                    groups[0].Add(pilots[combos[i][j]]);
                }
                WriteDataInRace(groups, 111);
                groups.Clear();
            }
        }

        public static List<List<Pilot>> DivideByGroup(List<Pilot> pilots, List<int> numbersOfKarts)
        {
            var groups = new List<List<Pilot>>();
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersOfKarts.Count);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<Pilot>());

            for (int i = 0, j = 0; i < pilots.Count; i++, j++)
            {
                if (j == countGroups)
                    j = 0;
                groups[j].Add(pilots[i]);
            }
            return groups;
        }

        public static List<List<Pilot>> SimpleDivideByGroup(List<Pilot> pilots, List<int> numbersOfKarts)
        {
            var dividedGroups = DivideByGroup(pilots, numbersOfKarts);
            var groups = new List<List<Pilot>>();
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersOfKarts.Count);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<Pilot>());

            int counter = 0;
            for (int i = 0, j = 0; i < countGroups; i++)
            {
                while (counter < dividedGroups[i].Count)
                {
                    groups[i].Add(pilots[j]);
                    j++;
                    counter++;
                }
                counter = 0;
            }
            return groups;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }

        public static int DefineCountPilotsInFinal(List<Pilot> pilots, string lique)
        {
            int count = pilots.FindAll(x => x.Ligue == lique).Count;
            int result = count < CountPilotsInFirstGroup ? count : CountPilotsInFirstGroup;
            return result;
        }

        public static void RedefineRandomWithSeed()
        {
            rng = new Random(1234124535);
        }

        public static void ReBuildCountPilotsInFirstGroup(List<int> numbers)
        {
            var pilotsNames = ExcelRead.ReadNamesInTotalBoard();
            var pilots = new List<Pilot>();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            var groups = DivideByGroup(pilots, numbers);
            _countPilotsInFirstGroup = groups[0].Count;
        }

        public static List<Pilot> MakePilotsFromTotalBoard(int countPilots)
        {
            var pilots = new List<Pilot>();
            var names = ExcelRead.ReadNamesInTotalBoard();
            var kartsMerged = ExcelRead.ReadUsedKartsInTotalBoard();
            var scoresMerged = ExcelRead.ReadResultsInTB("Хіт", countPilots);
            var timesMerged = ExcelRead.ReadResultsInTB("Best Lap", countPilots);
            var liques = ExcelRead.ReadLique(countPilots);
            for (int i = 0; i < countPilots; i++)
            {
                var karts = new List<int>();
                var scores = new List<int>();
                var times = new List<string>();

                if (kartsMerged.Count != 0)
                {
                    for (int j = 0; j < kartsMerged[i].Count; j++)
                    {
                        karts.Add(kartsMerged[i][j]);
                    }
                }
                if (timesMerged.Count != 0)
                {
                    for (int j = 0; j < timesMerged[i].Count; j++)
                    {
                        times.Add(timesMerged[i][j]);
                    }
                }
                if (scoresMerged.Count != 0)
                {
                    for (int j = 0; j < scoresMerged[i].Count; j++)
                    {
                        scores.Add(Int32.Parse(scoresMerged[i][j]));
                    }
                }
                if (liques.Count != 0)
                {
                    pilots.Add(new Pilot(karts, names[i], scores, times, liques[i]));
                }
                else
                {
                    pilots.Add(new Pilot(karts, names[i], scores, times));
                }
            }
            return pilots;
        }

        private static void DoAssignment(List<List<Pilot>> groups, List<int> numbers, int numberRace)
        {
            _countPilotsInFirstGroup = groups[0].Count;
            for (int i = 0; i < groups.Count; i++)
                DoAssignmentByCombo(groups[i], numbers);

            WriteDataInRace(groups, numberRace);
        }

        private static void DoAssignmentByCombo(List<Pilot> pilots, List<int> numbers, List<int> combo)
        {
            var zaezd = new List<Pilot>();
            for (int i = 0; i < combo.Count; i++)
            {
                pilots[combo[i]].AddNumberKart(numbers[i]);
                zaezd.Add(pilots[combo[i]]);
            }
        }

        private static void DoAssignmentByCombo(List<Pilot> group, List<int> numbersOfKarts)
        {
            var combo = Combination.GetAvaibleCombo(GetUsedKartsFromGroup(group), numbersOfKarts);
            if (combo.Count == 0)
                return;
            for (int i = 0; i < group.Count; i++)
            {
                group[i].AddNumberKart(combo[i]);
            }
        }

        private static List<List<int>> GetUsedKartsFromGroup(List<Pilot> group)
        {
            var usedKarts = new List<List<int>>();
            for (int i = 0; i < group.Count; i++)
            {
                usedKarts.Add(group[i].GetNumbersKarts());
            }
            return usedKarts;
        }

        private static void WriteDataInRace(List<List<Pilot>> groups, int numberRace)
        {
            var names = new List<List<string>>();
            var karts = new List<List<string>>();
            for (int i = 0; i < groups.Count; i++)
            {
                names.Add(new List<string>());
                karts.Add(new List<string>());
                foreach (var pilot in groups[i])
                {
                    names[i].Add(pilot.Name);
                    karts[i].Add(pilot.GetNumberKartByRace(numberRace));
                }
            }
            ExcelWrite.WriteInfoDataInRace("Пілоти", names);
            ExcelWrite.WriteInfoDataInRace("Карт", karts);
        }
    }
}
