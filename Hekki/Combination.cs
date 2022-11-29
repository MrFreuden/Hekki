using Hekki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Hekki
{
    public class Combination
    {
        private static Random rnd = new();

        private static IEnumerable<List<int>> AllCombinations(List<int> arg, List<int> awithout)
        {
            if (arg.Count == 1)
            {
                var result = new List<List<int>>();
                result.Add(new List<int>());
                result[0].Add(arg[0]);
                return result;
            }
            else
            {
                var result = new List<List<int>>();

                foreach (var first in arg)
                {
                    var others0 = new List<int>(arg.Except(new int[1] { first }));
                    awithout.Add(first);
                    var others = new List<int>(others0.Except(awithout));

                    var combinations = AllCombinations(others, awithout);
                    awithout.Remove(first);

                    foreach (var tail in combinations)
                    {
                        tail.Insert(0, first);
                        result.Add(tail);
                    }
                }
                return result;
            }
        }

        public static List<int> GetAvaibleCombo(List<int> numbersKarts, List<Pilot> pilots)
        {
            var totallist = new List<int>(numbersKarts);
            var allcombis = AllCombinations(totallist, new List<int>());
            var allcombi = allcombis.ToList();
            List<int> spare = new();
            List<int> nums = new();

            for (int i = 0; i < pilots.Count; i++)
            {
                if (allcombi.Count > 0)
                {
                    spare = allcombi[rnd.Next(allcombi.Count)];
                }
                for (int j = 0; j < pilots[i].GetNumbersKarts().Count; j++)
                {
                    nums.Clear();

                    int count = 0;
                    foreach (var combi in allcombi)
                    {
                        if (combi[i] == pilots[i].GetNumbersKarts()[j])
                        {
                            nums.Add(count);
                        }
                        count++;
                    }
                    foreach (int indice in nums.OrderByDescending(v => v))
                    {
                        allcombi.RemoveAt(indice);
                    }

                }
            }

            if (allcombi.Count == 0)
            {
                return spare;
            }
            else
                return allcombi[rnd.Next(allcombi.Count)];
        }

        public static List<List<int>> GetComboEveryOnEvery(int pilotsCount, int kartsCount)
        {
            List<int> pilotsIndexs = Enumerable.Range(0, pilotsCount).ToList();
            var items = Shuffle(pilotsIndexs).Select((d, i) => pilotsIndexs.Concat(pilotsIndexs).Skip(i).Take(kartsCount));
            List<List<int>> combos = new List<List<int>>();
            foreach (var item in items)
            {
                combos.Add(item.ToList());
            }
            Shuffle(combos);
            return combos;
        }

        private static IList<T> Shuffle<T>(IList<T> list)
        {
            
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void RedefineRandomWithSeed()
        {
            rnd = new Random(1234124535);
        }
    }
}
