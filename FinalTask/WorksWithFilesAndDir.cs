using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FinalTask
{
    /// <summary>
    /// Класс, который принимает считанный массив студентов, создает директорию Students, создает txt файлы и записывает информацию о студентах по группам.
    /// </summary>
    class WorkWithFilesAndDir
    {
        public static void ChoiceDirectory(string dirPath)     // Создает папку, если ее не было.
        {
            try
            {
                if (!Directory.Exists(dirPath))
                {
                    Directory.CreateDirectory(dirPath);
                    Console.WriteLine("Папка Students создана!");
                }
                else
                    Console.WriteLine("Папка Students выбрана!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void CreateTXTFile(Student[] students)        // Сортировка студентов из разных групп по файлам соответствующих групп.
        {
            string group1Path = @"c:\Users\LEGION 5\Desktop\Students\Group-150.txt";
            string group2Path = @"c:\Users\LEGION 5\Desktop\Students\Group-151.txt";
            string group3Path = @"c:\Users\LEGION 5\Desktop\Students\Group-152.txt";
            string group4Path = @"c:\Users\LEGION 5\Desktop\Students\Group-153.txt";

            try
            {
                foreach (var stud in students)
                {
                    if (stud.Group == "G-150")
                    {
                        WriteInFile(group1Path, stud);
                    }
                    else if (stud.Group == "G-151")
                    {
                        WriteInFile(group2Path, stud);
                    }
                    else if (stud.Group == "G-152")
                    {
                        WriteInFile(group3Path, stud);
                    }
                    else if (stud.Group == "G-153")
                    {
                        WriteInFile(group4Path, stud);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void WriteInFile(string groupPath, Student student)       // Чтение потока студентов и запись нужной информации в файл если он существует или создание и запись, если его не найдено.
        {
            using (FileStream fs = new FileStream(groupPath, FileMode.Append))
            {
                using (StreamWriter swOut = new StreamWriter(fs))
                {
                    swOut.WriteLine("{0}, {1}", student.Name, student.DateOfBirth);
                }
            }
        }
    }
}
