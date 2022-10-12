using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task2
{
    /// <summary>
    /// Класс для подсчета размера папки на диске (вместе со всеми вложенными папками и файлами). 
    /// На вход метод принимает URL директории, в ответ - размер в байтах.
    /// </summary>
    class DirectorySize
    {
        public static void ShowCatalogsAndFilesInfo(string dirNamePath)
        {
            if (Directory.Exists(dirNamePath))  // Проверка существования каталога.
            {
                //Console.WriteLine("Директория по пути " + dirNamePath + " найдена!");
                try
                {
                    byte allFileSize = 0;
                    DirectoryInfo directoryInfo = new DirectoryInfo(dirNamePath);
                    foreach (var file in directoryInfo.GetFiles())  // Просмотр всех файлов в корневом каталоге.
                    {
                        ShowFilesInfo(file, directoryInfo.FullName);
                    }

                    ReadAndShowCatalogsInfo(directoryInfo.GetDirectories());


                    void ReadAndShowCatalogsInfo(DirectoryInfo[] dirs)   // Рекурсивный метод для просмотра всех каталогов.
                    {
                        foreach (var dir in dirs)
                        {
                            ReadFiles(dir.GetFiles());
                            ReadAndShowCatalogsInfo(dir.GetDirectories());
                        }
                    }

                    void ReadFiles(FileInfo[] files)    // Метод для просмотр всех файлов в каталоге.
                    {
                        foreach (var file in files)
                        {
                            ShowFilesInfo(file, file.DirectoryName + "\\");
                        }
                    }

                    void ShowFilesInfo(FileInfo file, string dirPath)  // Метод для выведения всех файлов в каталоге на консоль и отображения их размера.
                    {
                        //Console.WriteLine("Обнаружен файл - " + file.Name + " размером - " + file.Length + " байт.");
                        allFileSize += Convert.ToByte(file.Length);
                    }

                    Console.WriteLine("Общий размер папки: " + allFileSize + " байт.");
                }
                catch (Exception e)     // Обработка исключений.
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
                Console.WriteLine("Директории по адресу " + dirNamePath + " не существует либо указан некорректный путь!");
        }

    }
}
