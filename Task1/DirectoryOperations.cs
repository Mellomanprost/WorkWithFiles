using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    static class DirectoryOperations
    {
        public static void GetCatalogsAndFiles(string dirNamePath)
        {
            if (Directory.Exists(dirNamePath))
            {
                Console.WriteLine("Директория по пути " + dirNamePath + " найдена!");
                try
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(dirNamePath);
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        //Console.WriteLine("время последнего использования: " + (DateTime.UtcNow - File.GetLastAccessTimeUtc(directoryInfo.FullName + file.Name)));
                        //if ((DateTime.UtcNow - File.GetLastAccessTimeUtc(directoryInfo.FullName + file.Name)) > TimeSpan.FromMinutes(30))
                        //{
                        //    Console.WriteLine("Файл " + file.Name + " удален!");
                        //    file.Delete();
                        //}
                        //else
                        //    Console.WriteLine(" -- " + file.Name);
                        Console.WriteLine("Имя файла = {0}, полный путь = {1}", file, directoryInfo.FullName + file);
                        DeleteFiles(file, directoryInfo.FullName);
                    }

                    ReadCatalogs(directoryInfo.GetDirectories());

                    void ReadCatalogs(DirectoryInfo[] dirs)
                    {
                        foreach (var dir in dirs)
                        {
                            ReadFiles(dir.GetFiles());
                            ReadCatalogs(dir.GetDirectories());
                            Console.WriteLine(" > " + dir.Name);
                        }
                    }

                    void ReadFiles(FileInfo[] files)
                    {
                        foreach (var file in files)
                        {
                            Console.WriteLine("Полный путь к файлу в папке {0} = {1}", file, file.DirectoryName);
                            //Console.WriteLine(" - " + file.Name);
                            DeleteFiles(file, file.DirectoryName + "\\");
                        }
                    }

                    void DeleteFiles(FileInfo file, string dirPath)
                    {
                        Console.WriteLine("Текущее время: " + DateTime.Now);
                        Console.WriteLine("Полный путь к файлу: {0}", dirPath + file.Name);
                        Console.WriteLine("Время последнего использования файла: " + File.GetLastAccessTime(dirPath + file.Name));
                        Console.WriteLine("Разница времени: " + (DateTime.Now - File.GetLastAccessTime(dirPath + file.Name)));
                        if ((DateTime.Now - File.GetLastAccessTime(dirPath + file.Name)) > TimeSpan.FromMinutes(30))
                        {
                            Console.WriteLine("Файл " + file.Name + " удален!");
                            //file.Delete();
                        }
                        else
                            Console.WriteLine(" -- " + file.Name);

                    }
                    //foreach (var dir in directories)
                    //{
                    //    if((DateTime.UtcNow - Directory.GetLastAccessTimeUtc(dirNamePath)) > TimeSpan.FromMinutes(30))
                    //    {

                    //    }
                    //}
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
                Console.WriteLine("Директории по адресу " + dirNamePath + " не существует либо указан некорректный путь!");
        }

    }
}
