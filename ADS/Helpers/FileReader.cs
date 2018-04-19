using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Helpers
{
    public static class FileReader
    {
        public static List<int> ReadToList(string path)
        {
            List<int> ret = new List<int>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                    ret.Add(int.Parse(sr.ReadLine()));
            }
            return ret;
        }
    }
}
