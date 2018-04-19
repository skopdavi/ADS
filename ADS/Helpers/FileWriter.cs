using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADS.Helpers
{
    public static class FileWriter
    {
        public static bool WriteListToFile(List<int> arr, string path)
        {
            using (StreamWriter fs = new StreamWriter(path))
            {
                StringBuilder sb = new StringBuilder();

                foreach (var num in arr)
                    fs.WriteLine(num.ToString());
            }
            return true;
        }
    }
}
