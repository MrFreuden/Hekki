namespace Hekki.App
{
    public static class SortService
    {
        private static Random _rnd = new();
        public static List<T> RandomSort<T>(List<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = _rnd.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }

        public static List<T> NoSort<T>(List<T> list)
        {
            return list;
        }

        public static List<T> CardSort<T>(List<T> list)
        {
            var evenIndexElements = list.Where((t, index) => index % 2 == 0);
            var oddIndexElements = list.Where((t, index) => index % 2 != 0);
            return evenIndexElements.Concat(oddIndexElements).ToList();
        }
    }
}
