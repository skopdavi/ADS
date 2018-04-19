using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ADS.Helpers
{
    class RandomGeneratorHelper
    {
        private static readonly Random _random = new Random();
        /// <summary>
        /// Generates numbers to file.
        /// </summary>
        /// <param name="min">Min value of generated number</param>
        /// <param name="max">Max value of generated number</param>
        /// <param name="count">Count of generated numbers</param>
        /// <param name="filePath">Name of file with path to store numbers</param>
        /// <returns>True if file is saved, otherwise return false</returns>
        public static bool GetRandomNumbers(int min, int max, int count, string filePath)
        {
            List<int> ret = new List<int>();
            bool? createFile = null;

            try
            {
                if (File.Exists(filePath))
                {
                    //Uživatel zadal soubor, který již existuje
                    Console.WriteLine(@"Opravdu checete uvedený soubor přepsat? Ano/Ne");
                    string reply = "";
                    while (!createFile.HasValue)
                    {
                        reply = Console.ReadLine().Trim();
                        if (reply.ToLower() == "ano")
                        {
                            //Přepsat soubor
                            createFile = true;
                            break;
                        }
                        else if (reply.ToLower() == "ne")
                        {
                            //Nepřepsat soubor
                            createFile = false;
                            break;
                        }
                        Console.WriteLine(@"Neplatný vstup. Zadejte Ano/Ne.");
                    }
                }
                //Soubor neexistoval nebo uživatel chce soubor přepsat
                if (!createFile.HasValue || createFile.Value)
                {
                    //Generování pole dle zadaných parametrů
                    for (int i = 0; i < count; i++)
                        ret.Add(_random.Next(min, max));
                    using (StreamWriter file = new StreamWriter(filePath))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(String.Join(" ", ret.ToArray()));
                        file.Write(sb.ToString());
                        return true;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Při vytváření souboru došlo k chybě.");
                return false;
            }
        }
        /// <summary>
        /// Generates numbers to List.
        /// </summary>
        /// <param name="min">Min value of generated number</param>
        /// <param name="max">Max value of generated number</param>
        /// <param name="count">Count of generated numbers</param>
        /// <returns>List of generated numbers.</returns>
        public static List<int> GetRandomNumbers(int min, int max, int count)
        {
            List<int> ret = new List<int>();

            //Generování seznamu dle zadaných parametrů
            for (int i = 0; i < count; i++)
                ret.Add(_random.Next(min, max));
            return ret;
        }
    }
}
