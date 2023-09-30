using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

namespace Exam
{
    namespace Exam
    {
        namespace Exam
        {
            public class CV
            {
                public string? Ixtisas { get; set; }
                public string? OxuduguMekteb { get; set; }
                public string? UniQebulBali { get; set; }
                public List<string>? Bacariqlar { get; set; }
                public List<string>? Companies { get; set; }
                public DateTime IsheBashlamaTarixi { get; set; }
                public DateTime BitirmeTarixi { get; set; }
                public Dictionary<string, string>? XariciDiller { get; set; }
                public bool FerqlenmeDiplomuVar { get; set; }
                public string? GitLink { get; set; }
                public string? LinkedIn { get; set; }
            }

            public class Worker
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Surname { get; set; }
                public string Sheher { get; set; }
                public string Phone { get; set; }
                public int Age { get; set; }
                public CV Cv { get; set; }

                public Worker(int id, string name, string surname, string sheher, string phone, int age, CV cv)
                {
                    Id = id;
                    Name = name;
                    Surname = surname;
                    Sheher = sheher;
                    Phone = phone;
                    Age = age;
                    Cv = cv;
                }

                public void IshdenCix()
                {
                    Console.WriteLine($"{Name} {Surname} ishden chixdi.");
                }
            }

            public class Employer
            {
                public int Id { get; set; }
                public string Name { get; set; }
                public string Surname { get; set; }
                public string Sheher { get; set; }
                public string Phone { get; set; }
                public int Age { get; set; }
                public List<string> Vacancies { get; set; }

                public Employer(int id, string name, string surname, string sheher, string phone, int age)
                {
                    Id = id;
                    Name = name;
                    Surname = surname;
                    Sheher = sheher;
                    Phone = phone;
                    Age = age;
                    Vacancies = new List<string>();
                }

                public void IshciIshəQebulEt(Worker worker)
                {
                    Console.WriteLine($"{worker.Name} {worker.Surname} ishe qebul edildi.");
                    Vacancies.Add($"{worker.Name} {worker.Surname}");
                }
            }

            public class NotificationSystem
            {
                public void SendNotification(string message, string recipient)
                {
                    Console.WriteLine($"Notification sent to {recipient}: {message}");
                }
            }

            class Program
            {
                static CV CreateCV()
                {
                    CV cv = new CV();

                    Console.Write("Ixtisas: ");
                    cv.Ixtisas = Console.ReadLine();

                    Console.Write("Oxudugu Mekteb: ");
                    cv.OxuduguMekteb = Console.ReadLine();

                    Console.Write("Uni Qebul Bali: ");
                    cv.UniQebulBali = Console.ReadLine();

                    Console.WriteLine("Bacariqlar (Her bir bacariqni daxil etmek ucun 'q' daxil edin):");
                    cv.Bacariqlar = new List<string>();
                    while (true)
                    {
                        Console.Write("Bacariq: ");
                        string bacariq = Console.ReadLine();
                        if (string.IsNullOrEmpty(bacariq) || bacariq.ToLower() == "q")
                            break;
                        cv.Bacariqlar.Add(bacariq);
                    }

                    Console.WriteLine("Companies (Her bir sirketi daxil etmek ucun 'q' daxil edin):");
                    cv.Companies = new List<string>();
                    while (true)
                    {
                        Console.Write("Company: ");
                        string company = Console.ReadLine();
                        if (string.IsNullOrEmpty(company) || company.ToLower() == "q")
                            break;
                        cv.Companies.Add(company);
                    }

                    Console.Write("Ishe bashlama tarixi (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime isheBashlamaTarixi))
                    {
                        cv.IsheBashlamaTarixi = isheBashlamaTarixi;
                    }
                    else
                    {
                        Console.WriteLine("Tarixi duzgun daxil edin.");
                    }

                    Console.Write("Bitirme tarixi (YYYY-MM-DD): ");
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime bitirmeTarixi))
                    {
                        cv.BitirmeTarixi = bitirmeTarixi;
                    }
                    else
                    {
                        Console.WriteLine("Tarixi duzgun daxil edin.");
                    }

                    Console.WriteLine("Xarici Diller (Her bir dil ve seviyesini daxil etmek ucun 'q' daxil edin):");
                    cv.XariciDiller = new Dictionary<string, string>();
                    while (true)
                    {
                        Console.Write("Dil: ");
                        string dil = Console.ReadLine();
                        if (string.IsNullOrEmpty(dil) || dil.ToLower() == "q")
                            break;

                        Console.Write("Seviyye: ");
                        string seviyye = Console.ReadLine();
                        cv.XariciDiller[dil] = seviyye;
                    }

                    Console.Write("Ferqlenme Diplomu Var? (true/false): ");
                    if (bool.TryParse(Console.ReadLine(), out bool ferqlenmeDiplomuVar))
                    {
                        cv.FerqlenmeDiplomuVar = ferqlenmeDiplomuVar;
                    }
                    else
                    {
                        Console.WriteLine("Duzgun true/false daxil edin.");
                    }

                    Console.Write("GitHub Link: ");
                    cv.GitLink = Console.ReadLine();

                    Console.Write("LinkedIn Link: ");
                    cv.LinkedIn = Console.ReadLine();

                    return cv;
                }

                static void Main()
                {

                    string menuChoice;
                    do
                    {
                        Console.WriteLine("Menyu:");
                        Console.WriteLine("1. Ishchini ishe qebul et");
                        Console.WriteLine("2. Ishchini ishden chixart");
                        Console.WriteLine("3. CV-lere bax");
                        Console.WriteLine("4. Loglari gor");
                        Console.WriteLine("5. Cixish");
                        Console.Write("Seciminizi daxil edin: ");
                        menuChoice = Console.ReadLine();

                        switch (menuChoice)
                        {
                            case "1":
                                Console.WriteLine("Ishchini ishe qebul et");
                                Console.Write("Ishchinin adini daxil edin: ");
                                string newWorkerName = Console.ReadLine();
                                Console.Write("Ishchinin soyadini daxil edin: ");
                                string newWorkerSurname = Console.ReadLine();
                                Worker newWorker = new Worker(3, newWorkerName, newWorkerSurname, "Sheher", "Telefon", 30, new CV());
                                employer.IshciIshəQebulEt(newWorker);
                                break;
                            case "2":
                                Console.WriteLine("Ishchini ishden chixart");
                                Console.Write("Ishchinin adini daxil edin: ");
                                string workerNameToFire = Console.ReadLine();
                                Console.Write("Ishchinin soyadini daxil edin: ");
                                string workerSurnameToFire = Console.ReadLine();

                                break;
                            case "3":
                                Console.WriteLine("CV-lere bax");
                                Console.WriteLine($"CV1: {JsonConvert.SerializeObject(worker1.Cv, Formatting.Indented)}");
                                Console.WriteLine($"CV2: {JsonConvert.SerializeObject(worker2.Cv, Formatting.Indented)}");
                                break;
                            case "4":
                                Console.WriteLine("Loglari gor");
                                string logFileName = "log.json";
                                if (File.Exists(logFileName))
                                {
                                    string logContent = File.ReadAllText(logFileName);
                                    Console.WriteLine(logContent);
                                }
                                else
                                {
                                    Console.WriteLine("Log fayli tapilmadi.");
                                }
                                break;
                            case "5":
                                Console.WriteLine("Cixish");
                                break;
                            default:
                                Console.WriteLine("Yanlish secim. Yeniden secin.");
                                break;
                        }
                    } while (menuChoice != "5");

                    worker1.IshdenCix();
                    worker2.IshdenCix();

                    WriteToJsonFile(worker1, "worker1.json");
                    WriteToJsonFile(worker2, "worker2.json");

                    LogProcess("Worker1 ishden cixdi.");
                    LogProcess("Worker2 ishden cixdi.");
                }

                static void WriteToJsonFile(object obj, string fileName)
                {
                    string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
                    File.WriteAllText(fileName, json);
                    Console.WriteLine($"{fileName} fayla yazildi..");
                }

                static void LogProcess(string process)
                {
                    string logFileName = "log.json";
                    string logEntry = $"{DateTime.Now}: {process}";
                    File.AppendAllText(logFileName, logEntry + Environment.NewLine);
                    Console.WriteLine($"Log: {logEntry}");
                }
            }
        }
    }
}










