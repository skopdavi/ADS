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
                for (int j = 1; j < array.Count() - i; j++)
                {
                    //Pokud je hodnota na nižší pozici větší, prohoď je
                    if (array[j] < array[j - 1])
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

        #region QuickSort
        private static void Divide(int[] array, int left, int right)
        {
            //Uchování výchozích pozic, tedy levé a pravé strany pro použití v této rekurzi(vnoření)
            int start = left;
            int end = right;
            //Počet prvků v části řazeného pole
            int count = end - start + 1;
            //Vyřešení jednoducých stavů
            if (count == 2)
            {
                if (array[start] > array[end])
                    swapValue(start, end, array);
                return;
            }
            //dohledání pivota a načtení hodnoty pivota
            int pivot = (end + start + 1) / 2;
            int pivotValue = array[pivot];
            //Dokud je start menší než end
            while (end - start > 0)
            {
                //hledání hodnoty pro swap - hledám menší hodnotu než je pivot
                while (array[start] < pivotValue)
                {
                    start++;
                }
                //hledání hodnoty pro swap - hledám větší hodnotu než je pivot
                while (array[end] > pivotValue )
                {
                    end--;
                }
                //Pokud nejsou pozice stejné(neměním sebe), tak prověď prohození
                if (start < end)
                {
                    swapValue(start++, end--, array);
                }
            }
            //Pokud mohu řadit, tedy počet je větší než 1, tak řaď pole
            if (left < end)
            {
                Divide(array, left, end);
            }
            //Pokud mohu řadit, tedy počet je větší než 1, tak řaď pole
            if (start < right)
            {
                Divide(array, start, right);
            }
            
        }

        public static void QuickSort(int[] array)
        {
            int left = 0;
            int right = array.Count() - 1;

            Divide(array, left, right);
        }
        #endregion

    }
}
