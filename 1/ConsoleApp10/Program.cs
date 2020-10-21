using System;
using System.Text.Json;
using System.IO;
using System.Xml.Linq;
using System.IO.Compression;

namespace ConsoleApp1
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void ZIPMethod()
        {
            string input;
            bool flag = true;
            Console.WriteLine("Работа с ZIP файлом");
            string startPath = Directory.GetCurrentDirectory() + "\\start";
            string zipPath = Directory.GetCurrentDirectory() + "\\result.zip";
            while (flag)
            {
                Console.WriteLine("\n1 - Создать ZIP файл\n2 - Создать TXT файл в ZIP файле\n3 - Размер ZIP файла в байтах\n4 - Удалить созданные файлы\n5 - Завершить работу с ZIP файлом");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (!File.Exists(zipPath))
                        {
                            if (Directory.Exists(startPath))
                            {
                                Console.WriteLine("Исходный файл уже существует");
                                ZipFile.CreateFromDirectory(startPath, zipPath);
                                Console.WriteLine("ZIP файл создан");
                            }
                            else
                            {
                                Directory.CreateDirectory(startPath);
                                Console.WriteLine("Исходный файл создан");
                                ZipFile.CreateFromDirectory(startPath, zipPath);
                            }
                        }
                        else
                        {
                            Console.WriteLine("ZIP файл уже существует");
                        }
                        break;
                    case "2":
                        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
                        {
                            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                            {
                                ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt");
                                using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                                {
                                    Console.WriteLine("Строка для записи в zip файл");
                                    writer.WriteLine(Console.ReadLine());
                                }
                            }
                        }
                        break;
                    case "3":
                        FileInfo f = new FileInfo(Directory.GetCurrentDirectory() + "\\result.zip");
                        long filesize = f.Length;
                        Console.WriteLine($"Размер ZIP файла: {filesize} байт");
                        break;
                    case "4":
                        if (Directory.Exists(startPath))
                        {
                            Directory.Delete(startPath);
                            File.Delete(startPath);
                            Console.WriteLine("Стартовый каталог удалён");
                        }
                        else
                        {
                            Console.WriteLine("Стартовый каталог не существует");
                        }
                        if (File.Exists(zipPath))
                        {
                            File.Delete(zipPath);
                            Console.WriteLine("ZIP файл удалён");
                        }
                        else
                        {
                            Console.WriteLine("ZIP файл не существует");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Конец работы с ZIP файлом");
                        flag = false;
                        break;
                }
            }
        }
    


        static void XMLMethod()
        {
            Console.Clear();
            bool flag = true;
            string input;
            Console.WriteLine("Работа с XML файлом");
            string fileName = Directory.GetCurrentDirectory() + "\\base.xml";
            int trackId = 1;
            XDocument doc = new XDocument(
              new XElement("library",
                new XElement("track",
                  new XAttribute("id", trackId++),
                  new XAttribute("genre", "Rap"),
                  new XAttribute("time", "2:12"),
                  new XElement("name", "Butterfly Doors "),
                  new XElement("artist", "Lil Pump "),
                  new XElement("album", "Harverd Dropout")),
                new XElement("track",
                  new XAttribute("id", trackId++),
                  new XAttribute("genre", "Rap"),
                  new XAttribute("time", "2:15"),
                  new XElement("name", "D Rose "),
                  new XElement("artist", "Lil Pump "),
                  new XElement("album", "Lil Pump")),
                new XElement("track",
                  new XAttribute("id", trackId++),
                  new XAttribute("genre", "Rap"),
                  new XAttribute("time", "2:04"),
                  new XElement("name", "Gucci Gang "),
                  new XElement("artist", "Lil Pump "),
                  new XElement("album", "Lil Pump")),
                new XElement("track",
                  new XAttribute("id", trackId++),
                  new XAttribute("genre", "Rap"),
                  new XAttribute("time", "3:01"),
                  new XElement("name", "Esskeetit "),
                  new XElement("artist", "Lil Pump "),
                  new XElement("album", "Harverd Dropout"))));

            doc.Save(fileName);
            Console.WriteLine("XML файл создан");
            while (flag)
            {
                Console.WriteLine("1 - Вывести содержимое XML файла\n2 - Закончить работу с XML файлом");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        foreach (var item in doc.Root.Elements())
                        {
                            Console.WriteLine($"{item.Name}: {item.Value}");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Конец работы с XML файлом");
                        flag = false;
                        break;
                }
            }
        }
        static void DriveMethod()
        {
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (var item in Drives)
            {
                Console.WriteLine($"Название: {item.Name}");
                Console.WriteLine($"Тип: {item.DriveType}");
                if (item.IsReady)
                {
                    Console.WriteLine($"Объем диска: {item.TotalSize}");
                    Console.WriteLine($"Свободное пространство: {item.TotalSize}");
                    Console.WriteLine($"Метка: {item.VolumeLabel}");
                }
            }
        }
        static void TXTMethod()
        {
            Console.WriteLine("Работа с TXT файлом");
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine("\n1 - Создать TXT файл\n2 - Запись TXT строки в файл\n3 - Чтение из TXT файла\n4 - Удаление TXT файла\n5 - Закончить работу с TXT файлом");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        string path = Directory.GetCurrentDirectory() + "\\qwe.txt";
                        if (!File.Exists(path))
                        {
                            using (FileStream fs = File.Create(path))
                            {
                                Console.WriteLine("Файл создан");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Файл уже существует");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите текст: \n");
                        using (FileStream fs = File.OpenWrite(Directory.GetCurrentDirectory() + "\\qwe.txt"))
                        {
                            string text = Console.ReadLine();
                            byte[] array = System.Text.Encoding.Default.GetBytes(text);
                            fs.Write(array, 0, array.Length);
                            Console.WriteLine("Строка записана в файл");
                        }
                        break;
                    case "3":
                        using (FileStream fs = File.OpenRead(Directory.GetCurrentDirectory() + "\\qwe.txt"))
                        {
                            byte[] array = new byte[fs.Length];
                            fs.Read(array, 0, array.Length);
                            string textFromFile = System.Text.Encoding.Default.GetString(array);
                            Console.WriteLine($"Текст из файла: {textFromFile}");
                        }
                        break;
                    case "4":
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\qwe.txt"))
                        {
                            File.Delete(Directory.GetCurrentDirectory() + "\\qwe.txt");
                            Console.WriteLine("Файл удалён");
                        }
                        else
                        {
                            Console.WriteLine("Файл не существует");
                        }
                        break;
                    case "5":
                        Flag = false;
                        Console.WriteLine("Конец работы с TXT файлом");
                        break;
                }
            }
        }
        static void JSONMethod()
        {
            Console.WriteLine("Работа с JSON файлом");
            Person person = new Person { Name = "Tom", Age = 35 };
            string jsonString = JsonSerializer.Serialize<Person>(person);
            bool Flag = true;
            while (Flag)
            {
                Console.WriteLine("\n1 - Создать JSON файл\n2 - Запись JSON строки в файл\n3 - Чтение из JSON файла\n4 - Удаление JSON файла\n5 - Закончить работу с JSON файлом");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        string path = Directory.GetCurrentDirectory() + "\\qwe.json";
                        if (!File.Exists(path))
                        {
                            using (FileStream fs = File.Create(path))
                            {
                                Console.WriteLine("Файл создан");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Файл уже существует");
                        }
                        break;
                    case "2":
                        using (FileStream fs = File.OpenWrite(Directory.GetCurrentDirectory() + "\\qwe.json"))
                        {
                            string text = jsonString;
                            byte[] array = System.Text.Encoding.Default.GetBytes(text);
                            fs.Write(array, 0, array.Length);
                            Console.WriteLine("Строка json записана в файл");
                        }
                        break;
                    case "3":
                        using (FileStream fs = File.OpenRead(Directory.GetCurrentDirectory() + "\\qwe.json"))
                        {
                            byte[] array = new byte[fs.Length];
                            fs.Read(array, 0, array.Length);
                            Person restoredPerson = JsonSerializer.Deserialize<Person>(System.Text.Encoding.Default.GetString(array));
                            string textFromFile = System.Text.Encoding.Default.GetString(array);
                            Console.WriteLine($"Объект из файла как json - строка {textFromFile}");
                            Console.WriteLine($"Объект из файла: {restoredPerson.ToString()}");
                            Console.WriteLine($"Свойства объекта из файла:\nВозраст: {restoredPerson.Age}\nИмя: {restoredPerson.Name}");
                        }
                        break;
                    case "4":
                        if (File.Exists(Directory.GetCurrentDirectory() + "\\qwe.json"))
                        {
                            File.Delete(Directory.GetCurrentDirectory() + "\\qwe.json");
                            Console.WriteLine("Файл удалён");
                        }
                        else
                        {
                            Console.WriteLine("Файл не существует");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Конец работы с JSON файлом");
                        Flag = false;
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            string input;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\n1 - drives\n2 - TXT файл\n3 - JSON файл\n4 - работа с XML файлом\n5 - работа с ZIP файлом\n6 - конец работы");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        DriveMethod();
                        break;
                    case "2":
                        Console.Clear();
                        TXTMethod();
                        break;
                    case "3":
                        Console.Clear();
                        JSONMethod();
                        break;
                    case "4":
                        XMLMethod();
                        break;
                    case "5":
                        ZIPMethod();
                        break;
                    case "6":
                        flag = false;
                        break;
                }
            }
        }
    }
}