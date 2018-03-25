using ADS.DataModel;
using ADS.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS
{
    class Program
    {

        private static void TestStack(int count, List<int> lst)
        {
            Stack stack = new Stack(count);
            foreach (var value in lst)
            {
                stack.Push(value);
            }
            Console.WriteLine(stack.ToString());
            if (!stack.Push(1))
                Console.WriteLine("Zásobník je plný.");
            Console.WriteLine(stack.ToString());
        }


        static void Main(string[] args)
        {
            int min;
            int max;
            int count;
            string path;
            string fileName;

            Console.WriteLine("Zadejte vstupní parametry pro přípravu pole celočíselných čísel.");
            Console.Write("Zadejte minimální hodnotu čísla: ");
            while (!int.TryParse(Console.ReadLine(), out min))
                Console.Write("Vstup není platný. Zadejte minimální hodnotu čísla: ");

            Console.Write("Zadejte maximální hodnotu čísla: ");
            while (!int.TryParse(Console.ReadLine(), out max))
                Console.Write("Vstup není platný. Zadejte maximální hodnotu čísla: ");

            Console.Write("Zadejte počet generovaných čísel: ");
            while (!int.TryParse(Console.ReadLine(), out count))
                Console.Write("Vstup není platný. Zadejte počet generovaných čísel: ");

            Console.Write("Zadejte absolutní cestu pro uložení vygenerovaných čísel do souboru: ");
            path = Console.ReadLine();

            while (!Directory.Exists(path))
            {
                Console.Write("Vstup není platný. Zadejte absolutní cestu pro uložení vygenerovaných čísel do souboru včetně názvu souboru: ");
                path = Console.ReadLine();
            }

            Console.Write("Zadejte název souboru: ");
            fileName = Console.ReadLine();
            while (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
            {
                Console.Write("Vstup není platný. Zadejte název souboru: ");
                fileName = Console.ReadLine();
            }

            if (path.Last() != '\\')
                path += '\\';

            if (RandomGeneratorHelper.GetRandomNumbers(min, max, count, path + fileName))
            {
                string data = File.ReadAllLines(path + fileName)[0];
                List<string> dataList = data.Split(' ').ToList();
                List<int> lst = dataList.Select(a => int.Parse(a)).ToList();
                //Otestuje vložit všechny hodnoty do stacku + jednu navíc
                TestStack(count, lst);
            }
            else
            {

            }
            Console.ReadKey();
        }
    }
}
