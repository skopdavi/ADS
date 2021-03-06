﻿using ADS.DataModel;
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
            Console.WriteLine(stack.Pop().ToString());
            Console.WriteLine(stack.ToString());
            if (!stack.Push(1))
                Console.WriteLine("Zásobník je plný.");
            Console.WriteLine(stack.ToString());
        }

        private static void TestQueue(int count, List<int> lst)
        {
            Queue queue = new Queue(count);
            foreach (var value in lst)
            {
                queue.Push(value);
            }
            Console.WriteLine(queue.ToString());
            Console.WriteLine(queue.Pop().ToString());
            Console.WriteLine(queue.Pop().ToString());
            Console.WriteLine(queue.ToString());
            if (!queue.Push(1))
                Console.WriteLine("Fronta je plná.");
            Console.WriteLine(queue.ToString());
        }


        static void Main(string[] args)
        {

            //Lze upravit výchozí hodnoty pro generování
            int min = -500;
            int max = 200;
            int count = 1000;
            string path;
            string fileName;
            string saveQ;
            bool? saveToFile = null;
            List<int> lst = null;

            Console.WriteLine("Chcete generovat náhodná čísla do souboru? Ano/Ne");

            while (!saveToFile.HasValue)
            {
                saveQ = Console.ReadLine().Trim();
                if (saveQ.ToLower() == "ano")
                {
                    //Přepsat soubor
                    saveToFile = true;
                    break;
                }
                else if (saveQ.ToLower() == "ne")
                {
                    //Nepřepsat soubor
                    saveToFile = false;
                    break;
                }
                Console.WriteLine(@"Neplatný vstup. Zadejte Ano/Ne.");
            }

            if (saveToFile.Value)
            {
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

                Console.Write("Zadejte absolutní cestu pro uložení vygenerovaných čísel do souboru(bez názvu souboru): ");
                path = Console.ReadLine();

                while (!Directory.Exists(path))
                {
                    Console.Write("Vstup není platný. Zadejte absolutní cestu pro uložení vygenerovaných čísel do souboru(bez názvu souboru): ");
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
                    lst = dataList.Select(a => int.Parse(a)).ToList();
                }
            }
            else
            {
                lst = RandomGeneratorHelper.GetRandomNumbers(min, max, count);
            }

            //Otestuje vložit všechny hodnoty do stacku + jednu navíc
            /*Console.WriteLine("Stack");
            TestStack(count, lst);

            //Otestuje vložit všechny hodnoty do queue + jednu navíc
            Console.WriteLine("Queue");
            TestQueue(count, lst);*/
            Console.WriteLine();
            /*Console.WriteLine("Vygenerované pole");
            Console.WriteLine(String.Join(", ", lst.ToArray()));*/
            /*Console.WriteLine("Select sort");
            Console.WriteLine(String.Join(", ", SortingHelper.SelectSort(lst.ToArray())));
            Console.WriteLine("Insert sort");
            Console.WriteLine(String.Join(", ", SortingHelper.InsertSort(lst.ToArray())));
            Console.WriteLine("Bubble sort");
            Console.WriteLine(String.Join(", ", SortingHelper.BubbleSort(lst.ToArray())));*/

            //arr = FileReader.ReadToList(path).ToArray();
            var arr = lst.ToArray();
            SortingHelper.QuickSort(arr);
            FileWriter.WriteListToFile(arr.ToList(), @"c:\skola\ADS\Quick.txt");

            int val = 0;
            Console.Write("Zadejte hledanou hodnotu čísla: ");
            while (!int.TryParse(Console.ReadLine(), out val))
                Console.Write("Vstup není platný. Zadejte hledanou hodnotu čísla: ");
            var retLst = SearchHelper.BinarySearch(arr, val);
            if (retLst.Count == 0)
            {
                Console.WriteLine("Hledaná hodnota {0} nebyla nalezena", val);
            }
            else
            {
                Console.WriteLine("Hledaná hodnota {0} se nachází na pozicích: ", val);
                foreach(var pos in retLst)
                    Console.WriteLine(pos);
            }

            Console.ReadKey();
        }
    }
}
