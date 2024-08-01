﻿using RaceLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceLogic
{
    public class CardMethodDevide : IDevideMethod
    {
        public IList<IList<T>> Devide<T>(IList<T> list, int count)
        {
            var groups = new List<IList<T>>();

            for (int i = 0; i < count; i++)
                groups.Add(new List<T>());

            for (int i = 0, j = 0; i < list.Count; i++, j++)
            {
                if (j == count)
                    j = 0;
                groups[j].Add(list[i]);
            }
            return groups;
        }
    }
}