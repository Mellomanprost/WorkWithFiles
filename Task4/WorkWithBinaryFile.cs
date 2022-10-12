using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Collections;

namespace Task4
{
    [Serializable]
    class WorkWithBinaryFile
    {

        public static void ChoseDirectory(string pathDir)
        {
            try
            {
                if (!Directory.Exists(pathDir))
                {
                    Directory.CreateDirectory(pathDir);
                    Console.WriteLine("Папка Students создана на рабочем столе!");
                }
                else
                    Console.WriteLine("Папка Students выбрана!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static void ReadFile(string pathFile)
        {
            if (File.Exists(pathFile))
            {
                //Student person = new Student();
                Console.WriteLine("Объект создан");

                BinaryFormatter formatter = new BinaryFormatter();
                // получаем поток, куда будем записывать сериализованный объект
                //using (var fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                //{
                //    formatter.Serialize(fs, person);
                //    Console.WriteLine("Объект сериализован");
                //}
                // десериализация
                using (var fs = new FileStream(pathFile, FileMode.OpenOrCreate))
                {
                    Student newStudent = (Student)formatter.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");
                    Console.WriteLine($"Имя: {newStudent.Name} --- Возраст: {newStudent.DateOfBirth}");
                }
                Console.ReadLine();
            }
        }

    }
}
