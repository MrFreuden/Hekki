using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hekki
{
    public partial class EveryOnEveryReg : Form
    {
        private static List<int> numbersKarts;
        public EveryOnEveryReg(List<int> karts)
        {
            InitializeComponent();
            numbersKarts = karts;
            numbersOfKarts.Lines = numbersKarts.ConvertAll<string>(delegate (int i) { return i.ToString(); }).ToArray();
        }

        private void DoRaces_Click(object sender, EventArgs e)
        {
            Every.DoRaces(numbersKarts);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ExcelWorker.CleanData(11);
        }

        private void RebuilKarts_Click(object sender, EventArgs e)
        {
            numbersKarts.Clear();
            foreach (string i in numbersOfKarts.Lines)
                numbersKarts.Add(Int32.Parse(i));
        }

        private void ReadScores_Click(object sender, EventArgs e)
        {
            Every.ReadScor();
        }

        private void SortScores_Click(object sender, EventArgs e)
        {
            Every.SortScores();
        }
    }
}
