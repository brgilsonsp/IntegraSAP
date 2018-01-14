using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Infra
{
    public static class RecordFile
    {

        public static void SaveFile(string file, string text)
        {
            using (StreamWriter str = File.AppendText(file))
            {
                str.WriteLine(text);
            }
        }

        public static void CreateDirectorIfNotExisty(string filePath)
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
        }
    }
}
