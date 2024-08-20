using RaceLogic.Interfaces;

namespace RaceLogic.Algorithms
{
    public class Combination : ICombination
    {
        private static Random _rnd = new();
        private static List<List<int>> _allCombinations;

        public List<int> GetCombo(List<List<int>> usedKarts, List<int> numberKarts)
        {
            CalculateAllCombinations(numberKarts);
            var combinations = _allCombinations.ToList();

            for (int i = 0; i < usedKarts.Count; i++)
            {
                if (usedKarts[i].Count < 1)
                    continue;
                combinations = combinations.OrderBy(x => x[i]).ToList();
                DeleteCombinations(combinations, usedKarts[i], i);
            }

            return combinations[_rnd.Next(combinations.Count)];
        }

        private void CalculateAllCombinations(List<int> numberKarts)
        {
            if (_allCombinations == null || IsNumbersKartChanged(numberKarts))
            {
                _allCombinations = GenerateCombinations(numberKarts, numberKarts.Count);
            }
        }

        private bool IsNumbersKartChanged(List<int> numberKarts)
        {
            return !numberKarts.SequenceEqual(_allCombinations[0]);
        }

        private List<List<int>> GenerateCombinations(List<int> numbers, int length)
        {
            var result = new List<List<int>>();

            GenerateCombinationsRecursive(numbers, length, new List<int>(), result);

            return result;
        }

        private void GenerateCombinationsRecursive(
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

        private void DeleteCombinations(
            List<List<int>> combinations,
            List<int> numbers,
            int position)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                var firstIndex = BinSearchStartIndex(combinations, numbers[i], position, 0, combinations.Count - 1);
                if (firstIndex == -1)
                {
                    continue;
                }
                var lastIndex = BinSearchLastIndex(combinations, numbers[i], position, 0, combinations.Count - 1);
                var length = lastIndex - firstIndex + 1;

                combinations.RemoveRange(firstIndex, length);
            }
        }

        private int BinSearchStartIndex(
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

        private int BinSearchLastIndex(
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

        public void RedefineRandomWithSeed()
        {
            _rnd = new Random(1234124535);
        }
    }
}
