using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Helpers
{
    public static class SearchHelper
    {
        public static int BinarySearch(int[] array, int value)
        {
            int pos = 0;
            int left = 0;
            int right = array.Count() - 1;
            pos = (int)Math.Floor((right - left) / 2M);
            while (array[pos] != value)
            {
                if (array[pos] < value)
                {
                    left = pos + 1;
                    if (left == right)
                    {
                        pos = -1;
                        break;
                    }
                    pos = pos + int.Parse(Math.Ceiling((right - left) / 2M).ToString());
                }
                else if (array[pos] > value)
                {
                    right = pos - 1;
                    if (left == right)
                    {
                        pos = -1;
                        break;
                    }
                    pos = pos - int.Parse(Math.Ceiling((right - left) / 2M).ToString());
                }
            }
            return pos;
        }
    }
}
