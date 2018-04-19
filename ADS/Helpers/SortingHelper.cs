using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Helpers
{
    public static class SortingHelper
    {

        public static void swapValue(int i, int j, int[] array)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static int[] SelectSort(int[] array)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                //sledování pozice našlé minimální hodnoty
                int minPos = i;
                for (int j = i + 1; j < array.Count(); j++)
                {
                    //kontrola minima a případné uložení pozice minima
                    if (array[j] < array[minPos])
                        minPos = j;
                }
                //Prohození minima s aktuální pozicí
                swapValue(i, minPos, array);
            }
            return array;
        }

        public static int[] InsertSort(int[] array)
        {
            int pos;
            for (int i = 1; i < array.Count(); i++)
            {
                //Uložení aktuální pozice, která určuje hodnotu, která se zařazuje
                pos = i;
                for (int j = i - 1; 0 <= j; j--)
                {
                    //Kontrola zda má proběhnout posun v rámci seřazeného pole. Rovnost z důvodu stability.
                    if (array[pos] <= array[j])
                    {
                        swapValue(j, pos, array);
                        pos = j;
                    }
                    else
                    {
                        //Hodnota se již neposunula, již je na správném místě
                        break;
                    }
                }
            }
            return array;
        }

        public static int[] BubbleSort(int[] array)
        {
            bool swap;
            for (int i = 0; i < array.Count(); i++)
            {
                swap = false;
                //Projde neseřazenou část pole
                for (int j = 1; j < array.Count()-i; j++)
                {
                    //Pokud je hodnota na nižší pozici větší, prohoď je
                    if (array[j] < array[j-1])
                    {
                        //Informace o tom, že došlo k prohození
                        swap = true;
                        swapValue(j, j - 1, array);
                    }
                }
                //Nedojde-li k prohození, pole je seřazené
                if (!swap)
                    break;
            }
            return array;
        }


    }
}
