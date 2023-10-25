using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static List<Task> tasks = new List<Task>();
    static string dataFilePath = "tasks.txt";

    static void Main(string[] args)
    {
        LoadTasks();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Úkolový seznam:");
            DisplayTasks();
            Console.WriteLine("Vyberte možnost:");
            Console.WriteLine("1. Přidat úkol");
            Console.WriteLine("2. Smazat úkol");
            Console.WriteLine("3. Označit úkol jako dokončený/nedokončený");
            Console.WriteLine("4. Uložit a ukončit");
            Console.Write("Vaše volba: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    DeleteTask();
                    break;
                case "3":
                    ToggleTaskCompletion();
                    break;
                case "4":
                    SaveTasks();
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Neplatná volba.");
                    break;
            }
        }
    }

    static void DisplayTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            var task = tasks[i];
            Console.WriteLine($"{i + 1}. {task.Title} - {task.Description} ({(task.IsCompleted ? "Dokončený" : "Nedokončený")})");
        }
    }

    static void AddTask()
    {
        Console.Write("Název úkolu: ");
        string title = Console.ReadLine();
        Console.Write("Popis úkolu: ");
        string description = Console.ReadLine();

        tasks.Add(new Task { Title = title, Description = description, IsCompleted = false });
        Console.WriteLine("Úkol byl přidán.");
    }

    static void DeleteTask()
    {
        Console.Write("Zadejte číslo úkolu ke smazání: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Úkol byl smazán.");
        }
        else
        {
            Console.WriteLine("Neplatná volba.");
        }
    }

    static void ToggleTaskCompletion()
    {
        Console.Write("Zadejte číslo úkolu ke změně stavu: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasks[taskNumber - 1].IsCompleted = !tasks[taskNumber - 1].IsCompleted;
            Console.WriteLine("Stav úkolu byl změněn.");
        }
        else
        {
            Console.WriteLine("Neplatná volba.");
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(dataFilePath))
        {
            var lines = File.ReadAllLines(dataFilePath);
            foreach (var line in lines)
            {
                var taskData = line.Split(';');
                if (taskData.Length == 3)
                {
                    tasks.Add(new Task
                    {
                        Title = taskData[0],
                        Description = taskData[1],
                        IsCompleted = bool.Parse(taskData[2])
                    });
                }
            }
        }
    }

    static void SaveTasks()
    {
        List<string> lines = tasks.Select(t => $"{t.Title};{t.Description};{t.IsCompleted}").ToList();
        File.WriteAllLines(dataFilePath, lines);
        Console.WriteLine("Seznam úkolů byl uložen.");
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}