using FileManager.Service;
using FileManager.Service.Pathfinders;
using FileManager.Service.Scaner;
using System;
using System.IO;
using System.Linq;

namespace FileManager
{
    class Program
    {

        static void Main(string[] args)
        {
            PathfinderFile pathfinderFile = new PathfinderFile();
            PathfinderDirectrory pathfinderDirectrory = new PathfinderDirectrory(pathfinderFile);
            ScanerSize scanerSize = new ScanerSize(pathfinderFile);
            ScanerTypeCount scanerType = new ScanerTypeCount(pathfinderFile);
            ScanerManager scanerManager = new ScanerManager(pathfinderDirectrory, pathfinderFile, scanerSize, scanerType);

            while (true)
            {
                Console.WriteLine("1.Путь до директории. 2.Путь до файла. 3.выход");
                string comanda = Console.ReadLine();
                if (comanda == "1")
                {
                    Console.WriteLine("Введите путь");
                    string path = Console.ReadLine();

                    scanerManager.WriteAllData(new DirectoryInfo(path));
                }
                if (comanda == "2")
                {
                    Console.WriteLine("Введите путь");
                    string path = Console.ReadLine();

                    Console.WriteLine("Введите тип файла");
                    string type = Console.ReadLine();

                    scanerManager.WriteDataFiles(new DirectoryInfo(path), type);
                }
                if (comanda == "0")
                    break;
            }

        }
    }
}