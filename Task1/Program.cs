using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Укажите путь к каталогу, в котором произвести очистку неиспользуемых файлов и папок: ");
            string dirNamePath = Convert.ToString(Console.ReadLine()); // Указывааем путь к директории

            DirectoryOperations.GetCatalogsAndFiles(dirNamePath);
        }
    }
}
