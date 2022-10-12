using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3
{
    class DirectoryCleanerDisplay
    {
        public static void DeleteCatalogsAndFiles(string dirNamePath)
        {
            if (Directory.Exists(dirNamePath))  // Проверка существования каталога.
            {
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
                            TimeSpan timeFromLastUsingDir = -dir.LastAccessTime.Subtract(DateTime.Now);     // Переменная для вывода разницы времени последнего использования и текущего времени.
                            if (timeFromLastUsingDir > TimeSpan.FromMinutes(30))
                            {
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
                        TimeSpan timeFromLastUsingFile = DateTime.Now - File.GetLastAccessTime(dirPath + file.Name);
                        if (timeFromLastUsingFile > TimeSpan.FromMinutes(30))
                        {
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


        public static byte ShowCatalogsAndFilesInfo(string dirNamePath, out byte displayInfo)
        {
            if (Directory.Exists(dirNamePath))  // Проверка существования каталога.
            {
                //Console.WriteLine("Директория по пути " + dirNamePath + " найдена!");
                byte allFileSize = 0;

                try
                {
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
                }
                catch (Exception e)     // Обработка исключений.
                {
                    Console.WriteLine(e.Message);
                }
                displayInfo = allFileSize;
                return displayInfo;
            }
            else
            {
                Console.WriteLine("Директории по адресу " + dirNamePath + " не существует либо указан некорректный путь!");
                displayInfo = 0;
                return displayInfo;
            }
        }


    }
}
