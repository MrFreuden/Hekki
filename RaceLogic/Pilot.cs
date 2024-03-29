﻿namespace RaceLogic
{
    public class Pilot
    {
        private string _name;
        private List<int> _usedKarts = new();
        private List<int> _scores = new();
        private List<string> _times = new();
        private string _ligue;
        public int Score { get { return _scores.Sum(); } }
        public int KartsCount { get { return _usedKarts.Count; } }
        public int ScoresCount { get { return _scores.Count; } }
        public int TimesCount { get { return _times.Count; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Ligue { get { return _ligue; } }
        public List<int> Scores { get { return _scores; } }
        public List<int> Times { get { return _scores; } }

        public Pilot(string name)
        {
            Name = name;
        }

        public Pilot(List<int> usedKarts, string name, List<int> scores, List<string> times)
        {
            for (int i = 0; i < usedKarts.Count; i++)
                _usedKarts.Add(usedKarts[i]);

            _name = name;

            for (int i = 0; i < scores.Count; i++)
                _scores.Add(scores[i]);

            for (int i = 0; i < times.Count; i++)
                _times.Add(times[i]);
        }

        public Pilot(List<int> usedKarts, string name, List<int> scores, List<string> times, string lique)
        {
            for (int i = 0; i < usedKarts.Count; i++)
                _usedKarts.Add(usedKarts[i]);

            _name = name;

            for (int i = 0; i < scores.Count; i++)
                _scores.Add(scores[i]);

            for (int i = 0; i < times.Count; i++)
                _times.Add(times[i]);

            _ligue = lique;
        }

        public void AddNumberKart(int numberKart)
        {
            //if (numberKart == 0)
            //    throw new Exception();
            _usedKarts.Add(numberKart);
        }

        public static bool IsCanBeAdd(Pilot pilot, int number)
        {
            if (number == 0)
                throw new Exception();
            if (pilot._usedKarts.Contains(number))
                return false;
            return true;
        }

        public string GetNumberKartByRace(int numberRace)
        {
            try
            {
                return _usedKarts[numberRace].ToString();
            }
            catch (Exception)
            {
                return _usedKarts[_usedKarts.Count - 1].ToString();
            }

        }

        public string GetAllNumbersKartsAsString()
        {
            string res = "";
            foreach (int numberKart in _usedKarts)
            {
                res += numberKart.ToString() + " ";
            }
            return res;
        }

        public void AddScore(int score)
        {
            _scores.Add(score);
        }

        public void AddScore(string score)
        {
            _scores.Add(Int32.Parse(score));
        }

        public static void AddEmptyScoresGlobal(List<Pilot> pilots)
        {
            foreach (var pilot in pilots)
            {
                pilot.AddEmptyScore();
            }
        }

        public void AddEmptyScore()
        {
            _scores.Add(0);
        }

        public void DeleteScore(int index)
        {
            _scores.RemoveAt(index);
        }

        public int GetScoreByNumberRace(int numberRace)
        {
            return _scores[numberRace];
        }


        public void ClearUsedKartsByNumberRace(int numberRace)
        {
            try
            {
                _usedKarts.RemoveAt(numberRace);
            }
            catch (Exception)
            {

                _usedKarts.RemoveAt(numberRace - 1);
            }

        }

        public void ClearLastUsedKart()
        {
            try
            {
                _usedKarts.RemoveAt(_usedKarts[_usedKarts.Count - 1]);
            }
            catch (Exception)
            {


            }
        }

        public List<int> GetNumbersKarts()
        {
            return _usedKarts;
        }

        public void AddTime(Dictionary<string, List<string>> time)
        {
            _times.Clear();
            for (int i = 0; i < time[_name].Count; i++)
            {
                _times.Add(time[_name][i]);
            }
        }

        public void AddTime(string time)
        {
            _times.Add(time);
        }

        public string GetTimeByIndex(int index)
        {
            return _times[index];
        }

        public static void ClearTimeGlobal(List<Pilot> pilots)
        {
            foreach (var pilot in pilots)
                pilot._times.Clear();
        }

        public static void ClearScoreGlobal(List<Pilot> pilots)
        {
            foreach (var pilot in pilots)
                pilot._scores.Clear();
        }
    }
}
