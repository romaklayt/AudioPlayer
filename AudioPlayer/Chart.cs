using System;
using System.Collections.Generic;

namespace AudioPlayer
{
    internal class Chart
    {
        private string _posChart;

        internal Chart(string posChart)
        {
            PosChart = posChart;
        }

        public string PosChart
        {
            get => _posChart;

            set => _posChart = value == "" ? "НЕТ ДАННЫХ" : value;
        }
    }

    public class ComparerChart : IComparer<string>
    {
        public int Compare(string s1, string s2)
        {
            var tempIsNumeric = IsNumeric(s1);
            var tempIsNumeric2 = IsNumeric(s2);
            if (tempIsNumeric && tempIsNumeric2)
            {
                if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
                if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
                if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
            }

            if (tempIsNumeric && tempIsNumeric2)
                return -1;

            if (!tempIsNumeric && tempIsNumeric2)
                return 1;

            return string.Compare(s1, s2, true);
        }

        public static bool IsNumeric(object value)
        {
            int i;
            var answ = int.TryParse(value.ToString(), out i);
            if (answ) return true;

            return false;
        }
    }
}