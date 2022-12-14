using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    /// <summary>
    /// Поиск всех папок и файлов в указанной директории и удаление тех, которые не использовались более 30 минут.
    /// </summary>
    static class DirectoryOperations
    {
        public static void DeleteCatalogsAndFiles(string dirNamePath)
        {
            if (Directory.Exists(dirNamePath))  // Проверка существования каталога.
            {
                //Console.WriteLine("Директория по пути " + dirNamePath + " найдена!");
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(dirNamePath);
                    foreach (var file in directoryInfo.GetFiles())  // Просмотр всех файлов в корневом каталоге и удаление тех, которые не использовались более 30 минут.
                    {
                        DeleteFiles(file, directoryInfo.FullName);
                    }
                    ReadAndDeleteCatalogs(directoryInfo.GetDirectories());

                    void ReadAndDeleteCatalogs(DirectoryInfo[] dirs)   // Рекурсивный метод для просмотра и вывода на консоль всех каталогов и удаления тех, которые не изменялись более 30 минут.
                    {
                        foreach (var dir in dirs)
                        {
                            ReadFiles(dir.GetFiles());
                            ReadAndDeleteCatalogs(dir.GetDirectories());
                            Console.WriteLine("Обнаружен каталог -- " + dir.Name);
                            TimeSpan timeFromLastUsingDir = -dir.LastAccessTime.Subtract(DateTime.Now);     // Переменная для вывода разницы времени последнего использования и текущего времени.
                            if (timeFromLastUsingDir > TimeSpan.FromMinutes(30))
                            {
                                Console.WriteLine("Каталог {0} удален, т.к. не использовался {1} времени", dir.Name, timeFromLastUsingDir);
                                dir.Delete(true);
                            }
                        }
                    }

                    void ReadFiles(FileInfo[] files)    // Метод для просмотр всех файлов в каталоге.
                    {
                        foreach (var file in files)
                        {
                            DeleteFiles(file, file.DirectoryName + "\\");
                        }
                    }

                    void DeleteFiles(FileInfo file, string dirPath)  // Метод для выведения всех файлов в каталоге на консоль и удаления тех, которые не использовались более 30 минут.
                    {
                        Console.WriteLine("Обнаружен файл - " + file.Name + " последнее время использования - " + File.GetLastAccessTime(dirPath + file.Name));
                        TimeSpan timeFromLastUsingFile = DateTime.Now - File.GetLastAccessTime(dirPath + file.Name);
                        if (timeFromLastUsingFile > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("Файл {0} удален, т.к. не использовался {1} времени", file.Name, timeFromLastUsingFile);
                            file.Delete();
                        }
                    }
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
