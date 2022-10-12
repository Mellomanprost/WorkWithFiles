using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            byte originalSize;
            byte sizeAfterDeleting;
            Console.WriteLine("Укажите путь к каталогу, в котором произвести очистку неиспользуемых файлов и папок: ");
            string dirNamePath = Convert.ToString(Console.ReadLine()); // Указывааем путь к директории
            DirectoryCleanerDisplay.ShowCatalogsAndFilesInfo(dirNamePath, out originalSize);
            Console.WriteLine("Исходный размер папки: " + originalSize + " байт.");

            DirectoryCleanerDisplay.DeleteCatalogsAndFiles(dirNamePath);
            DirectoryCleanerDisplay.ShowCatalogsAndFilesInfo(dirNamePath, out sizeAfterDeleting);

            Console.WriteLine("Освобождено: " + (originalSize - sizeAfterDeleting) + " байт.");
            Console.WriteLine("Текущий размер папки: " + sizeAfterDeleting);

        }
    }
}
