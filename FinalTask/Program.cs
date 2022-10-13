using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileNamePath = @"c:\Users\LEGION 5\Desktop\Students.dat";   //Указывааем путь к файлу
            string dirNamePath = @"c:\Users\LEGION 5\Desktop\Students";    //Указывааем путь к директории
            Student.ReadStudents(fileNamePath, out Student[] arrayOfStudents);
            WorkWithFilesAndDir.ChoiceDirectory(dirNamePath);
            WorkWithFilesAndDir.CreateTXTFile(arrayOfStudents);
        }
    }
}
