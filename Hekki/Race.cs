namespace Hekki
{
    public class Race
    {
        private static Random rng = new Random();
        private static int _countPilotsInFirstGroup;
        private static int _countPilotsInFirstGroupAmators;
        public static int CountPilotsInFirstGroup { get { return _countPilotsInFirstGroup; } }
        public static int CountPilotsInFirstGroupAmators { get { return _countPilotsInFirstGroupAmators; } }

        public static void StartHeatRace(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            List<List<Pilot>> groups = new();
            Shuffle(pilots);
            groups = DivideByGroup(pilots, numbers);
            _countPilotsInFirstGroup = groups[0].Count;
            for (int i = 0; i < groups.Count; i++)
                DoAssignmentByCombo(groups[i], numbers, numberRace);

            WriteDataInRace(groups, numberRace);
        }
        

        public static void StartSemiRace(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            List<List<Pilot>> groups = new();
            groups = DivideByGroup(pilots, numbers);
            _countPilotsInFirstGroup = groups[0].Count;
            for (int i = 0; i < groups.Count; i++)
                DoAssignmentByCombo(groups[i], numbers, numberRace);

            WriteDataInRace(groups, numberRace);
        }

        public static void StartFinalRace(List<Pilot> pilots, List<int> numbers, int numberRace, int count = 1)
        {
            List<List<Pilot>> groups = new();
            groups = SimpleDivideByGroup(pilots, numbers);
            _countPilotsInFirstGroup = groups[0].Count;
            for (int i = 0; i < groups.Count; i++)
                DoAssignmentByCombo(groups[i], numbers, numberRace);

            WriteDataInRace(groups, numberRace);
        }

        public static void StartFinalAmators(List<Pilot> pilots, List<int> numbers, int numberRace)
        {
            
            List<List<Pilot>> groups = new();
            groups = SimpleDivideByGroup(pilots, numbers);
            for (int i = 0; i < groups.Count; i++)
                DoAssignmentByCombo(groups[i], numbers, numberRace);

            WriteDataInRace(groups, numberRace);
        }

        public static void StartRandomRace(List<Pilot> pilots, List<int> numbers)
        {
            List<List<Pilot>> groups = new();
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
                ///ExcelWorker.WriteNames(groups, i, "Пилоты");
                WriteDataInRace(groups, 111);
                groups.Clear();
            }
        }

        private static void DoAssignmentByCombo(List<Pilot> pilots, List<int> numbers, List<int> combo)
        {
            List<Pilot> zaezd = new();
            for (int i = 0; i < combo.Count; i++)
            {
                pilots[combo[i]].AddNumberKart(numbers[i]);
                zaezd.Add(pilots[combo[i]]);
            }
        }

        

        public static void DoAssignmentToGroup(List<Pilot> group, List<int> numbersOfKarts, int numberRace, int counerReapeat = 0)
        {
            if (counerReapeat == 50)
            {
                DoAssignmentByCombo(group, numbersOfKarts, numberRace);
                return;
            }
            List<int> copyNumbersOfKarts;
            CopyList(numbersOfKarts, copyNumbersOfKarts = new List<int>());
            while (copyNumbersOfKarts.Count > group.Count)
                copyNumbersOfKarts.RemoveAt(0);
            for (int j = 0; j < group.Count; j++)
            {
                int k = 0;
                while (k < copyNumbersOfKarts.Count)
                {
                    if (Pilot.IsCanBeAdd(group[j], copyNumbersOfKarts[k]))
                    {
                        group[j].AddNumberKart(copyNumbersOfKarts[k]);
                        copyNumbersOfKarts.RemoveAt(k);
                        break;
                    }
                    k++;
                }
            }
            if (copyNumbersOfKarts.Count > 0)
            {
                for (int i = 0; i < group.Count; i++)
                {
                    group[i].ClearUsedKartsByNumberRace(numberRace);
                    //group[i].ClearLastUsedKart();
                }
                DoAssignmentToGroup(group, numbersOfKarts, numberRace, counerReapeat + 1);
            }
        }

        private static void DoAssignmentByCombo(List<Pilot> group, List<int> numbersOfKarts, int numberRace)
        {
            var combo = Combination.GetAvaibleCombo(numbersOfKarts, group);
            if (combo.Count == 0)
                return;
            for (int i = 0; i < group.Count; i++)
            {
                group[i].AddNumberKart(combo[i]);
            }
        }

        public static List<List<Pilot>> DivideByGroup(List<Pilot> pilots, List<int> numbersOfKarts)
        {
            List<List<Pilot>> groups = new();
            int countGroups = (int)Math.Ceiling((double)pilots.Count / numbersOfKarts.Count);

            for (int i = 0; i < countGroups; i++)
                groups.Add(new List<Pilot>());

            for (int i = 0, j = 0; i < pilots.Count; i++, j++)
            {
                if (j == countGroups)
                    j = 0;
                groups[j].Add(pilots[i]);
            }
            //CountPilotsInLastGroup = groups[groups.Count - 1].Count;
            return groups;
        }

        public static List<List<Pilot>> SimpleDivideByGroup(List<Pilot> pilots, List<int> numbersOfKarts)
        {
            var dividedGroups = DivideByGroup(pilots, numbersOfKarts);
            List<List<Pilot>> groups = new();
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

        public static List<Pilot> MakePilotsFromTotalBoard(int countPilots)
        {
            List<Pilot> pilots = new();
            var names = ExcelWorker.ReadNamesInTotalBoard();
            var kartsMerged = ExcelWorker.ReadUsedKartsInTotalBoard();
            var scoresMerged = ExcelWorker.ReadScoresInTotalBoard(countPilots);
            var timesMerged = ExcelWorker.ReadTimesInTotalBoard(countPilots);
            var liques = ExcelWorker.ReadLique(countPilots);
            for (int i = 0; i < countPilots; i++)
            {
                List<int> karts = new();
                List<int> scores = new();
                List<string> times = new();

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
                if (scoresMerged.Count != 0 && scoresMerged[i].Sum() != 0)
                {
                    for (int j = 0; j < scoresMerged[i].Count; j++)
                    {
                        scores.Add(scoresMerged[i][j]);
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

        public static void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        // TODO: Повертати новий список за допомогою ToList()
        public static void CopyList<T>(List<T> source, List<T> destination)
        {
            Shuffle(source);
            source.ForEach((item) =>
            {
                destination.Add((item));
            });
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
            List<string> pilotsNames = ExcelWorker.ReadNamesInTotalBoard();
            List<Pilot> pilots = new List<Pilot>();
            foreach (var pilotName in pilotsNames)
                pilots.Add(new Pilot(pilotName));
            List<List<Pilot>> groups = new();
            groups = DivideByGroup(pilots, numbers);
            _countPilotsInFirstGroup = groups[0].Count;
        }

        private static void WriteDataInRace(List<List<Pilot>> groups, int numberRace)
        {
            List<List<string>> names = new();
            List<List<string>> karts = new();
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
            ExcelWorker.WriteNamesInRace(names, numberRace);
            ExcelWorker.WriteKartsInRace(karts, numberRace);
        }
    }
}