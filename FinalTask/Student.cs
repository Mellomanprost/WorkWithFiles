using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    /// <summary>
    /// Класс для чтения данных из файла Students.dat и записи значений в объекты класса Student.
    /// </summary>

    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public static Student[] ReadStudents(string filePath, out Student[] arrayOfStudents)    // Чтение и десериализация данных из бинарного файла.
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (var fsIn = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Student[] students = (Student[])formatter.Deserialize(fsIn);
                arrayOfStudents = students;
                //int i = 0;
                //foreach (var student in students)
                //{
                //    i++;
                //    Console.WriteLine($"Студент {i}\n Name: {student.Name} Group: {student.Group} Birthday: {student.DateOfBirth}");
                //}
            }
            return arrayOfStudents;
        }
    }
}
