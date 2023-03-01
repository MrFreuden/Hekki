using System;
using System.Diagnostics;

namespace RaceLogic
{
    public class Combination
    {
        private static Random rnd = new();
        private static List<List<int>> allCombinations;
        private static List<List<int>> tempForDelete;

        public static List<int> GetAvaibleCombo(List<List<int>> usedKarts, List<int> numberKarts)
        {
            CalculateAllCombinations(numberKarts);
            var combinations = allCombinations.ToList();

            for (int i = 0; i < usedKarts.Count; i++)
            {
                if (usedKarts[i].Count < 1)
                    continue;
                combinations = combinations.OrderBy(x => x[i]).ToList();
                DeleteCombinations(combinations, usedKarts[i], i);
            }

            return combinations[rnd.Next(combinations.Count)];
        }

        public static List<List<int>> GetComboEveryOnEvery(int pilotsCount, int kartsCount)
        {
            List<int> pilotsIndexs = Enumerable.Range(0, pilotsCount).ToList();
            var items = Shuffle(pilotsIndexs).Select((d, i) => 
                                pilotsIndexs.Concat(pilotsIndexs).Skip(i).Take(kartsCount));
            var combos = new List<List<int>>();
            foreach (var item in items)
            {
                combos.Add(item.ToList());
            }
            Shuffle(combos);
            return combos;
        }

        public static void RedefineRandomWithSeed()
        {
            rnd = new Random(1234124535);
        }

        private static bool IsNumbersKartChanged(List<int> numberKarts)
        {
            bool flag;
            for (int i = 0; i < numberKarts.Count; i++)
            {
                flag = allCombinations[0].Contains(numberKarts[i]);
                if (!flag)
                {
                    return true;
                }
            }
            return false;
        }

        private static void CalculateAllCombinations(List<int> numberKarts)
        {
            if (allCombinations == null || IsNumbersKartChanged(numberKarts))
            {
                allCombinations = GenerateCombinations(numberKarts, numberKarts.Count);
            }
        }

        private static void DeleteCombinations(
            List<List<int>> combinations, 
            List<int> numbers, 
            int position)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var firstIndex = BinSearchStartIndex(combinations, numbers[i], 
                                                        position, 0, combinations.Count - 1);
                if (firstIndex == -1)
                {
                    continue;
                }
                var lastIndex = BinSearchLastIndex(combinations, numbers[i], 
                                                        position, 0, combinations.Count - 1);
                var length = lastIndex - firstIndex + 1;
                
                combinations.RemoveRange(firstIndex, length);
            }
        }

        private static List<List<int>> GenerateCombinations(List<int> numbers, int length)
        {
            var result = new List<List<int>>();

            GenerateCombinationsRecursive(numbers, length, new List<int>(), result);

            return result;
        }

        private static void GenerateCombinationsRecursive(
            List<int> numbers, 
            int length, 
            List<int> currentCombination, 
            List<List<int>> result)
        {
            if (currentCombination.Count == length)
            {
                result.Add(currentCombination);
            }
            else
            {
                foreach (int number in numbers)
                {
                    if (!currentCombination.Contains(number))
                    {
                        var newCombination = new List<int>(currentCombination)
                        {
                            number
                        };
                        GenerateCombinationsRecursive(numbers, length, newCombination, result);
                    }
                }
            }
        }

        private static int BinSearchStartIndex(
            List<List<int>> array, 
            int value, 
            int position, 
            int left, 
            int right)
        {
            if (left == right - 1)
            {
                if (array[right][position] == value)
                {
                    return array[left][position] == value ? left : right;
                }
                return -1;
            }

            var m = (left + right) / 2;
            if (array[m][position] < value)
                return BinSearchStartIndex(array, value, position, m, right);
            return BinSearchStartIndex(array, value, position, left, m);
        }

        private static int BinSearchLastIndex(
            List<List<int>> array,
            int value,
            int position,
            int left, 
            int right)
        {
            if (left == right - 1)
            {
                if (array[left][position] == value)
                {
                    return array[right][position] == value ? right : left;
                }
                return -1;
            }

            var m = (left + right) / 2;
            if (array[m][position] > value)
                return BinSearchLastIndex(array, value, position, left, m);
            return BinSearchLastIndex(array, value, position, m, right);
        }

        private static IList<T> Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }
    }
}
