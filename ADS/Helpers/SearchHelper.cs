using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Helpers
{
    public static class SearchHelper
    {
        public static List<int> BinarySearch(int[] array, int value)
        {
            List<int> ret = new List<int>();
            int pos = 0;
            int left = 0;
            int count = array.Count();
            int right = count - 1;
            //Vypočítám výchozí pozici
            pos = (int)Math.Floor((right - left) / 2M);
            //Hledám, dokud nenajdu správnou hodnotu
            while (array[pos] != value)
            {
                //Pokud jsem našel menší hodnotu, posouvám levý okraj hledání
                if (array[pos] < value)
                {
                    left = pos + 1;
                    //Pozice okrajů se rovnají - již není co prohledávat, končím
                    if (left == right)
                    {
                        pos = -1;
                        break;
                    }
                    //Posunu pozici vpravo od současné
                    pos = pos + int.Parse(Math.Ceiling((right - left) / 2M).ToString());
                }
                //Pokud jsem našel větší hodnotu, posouvám pravý okraj hledání
                else if (array[pos] > value)
                {
                    right = pos - 1;
                    //Pozice okrajů se rovnají - již není co prohledávat, končím
                    if (left == right)
                    {
                        pos = -1;
                        break;
                    }
                    //Posunu pozici vlevo od současné
                    pos = pos - int.Parse(Math.Ceiling((right - left) / 2M).ToString());
                }
            }
            //Prvek jsem našel
            if (pos != -1)
            {
                //Uložím pozici nalezení
                int orgPos = pos;
                //Projdu pole vlevo od nalezené pozice, včetně aktuální a přidám stejné hodnoty do pole
                while (pos > -1 && array[pos] == value)
                {
                    ret.Add(pos--);
                }
                //Načtu výchozí nalezenou pozici a posunu se o jednu vpravo(výchozí nalezená pozice je již přidaná v předchozím cyklu)
                pos = orgPos+1;
                //Projdu pole vpravo od nalezené pozice a přídám stejné hodnoty do pole
                while (pos < count && array[pos] == value)
                {
                    ret.Add(pos++);
                }
            }
            return ret;
        }
    }
}
