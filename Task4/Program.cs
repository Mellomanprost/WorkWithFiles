using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"c:\Users\LEGION 5\Desktop\Students\";
            string filePath = @"c:\Users\LEGION 5\Desktop\Students.dat";
            WorkWithBinaryFile.ChoseDirectory(directoryPath);
            WorkWithBinaryFile.ReadFile(filePath);
        }
    }
}
