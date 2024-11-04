using Newtonsoft.Json;

public static class TaskRepository
{
    private static readonly string filePath = "tasks.json";

    public static List<Task> LoadTasks()
    {
        if (File.Exists(filePath))
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Task>>(json) ?? new List<Task>();
        }
        return new List<Task>();
    }

    public static void SaveTasks(List<Task> tasks)
    {
        var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    // prosto commit

    // Melnyk Viacheslav
    public static Task AddTask()
    {
        Console.Clear();
        Console.WriteLine("Enter Task Title:");
        string title = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Enter Task Description:");
        string description = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Enter Flag (e.g., Important, Unimportant):");
        string flag = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Enter Label Color:");
        string labelColor = Console.ReadLine();

        Console.Clear();
        Console.WriteLine("Enter Task Color:");
        string taskColor = Console.ReadLine();

        DateTime creationDate = DateTime.Now;

        Console.Clear();
        Console.WriteLine("Summary of the new task:");
        Console.WriteLine($"Title: {title}\nDescription: {description}\nFlag: {flag}\nLabel Color: {labelColor}\nTask Color: {taskColor}");
        Console.WriteLine("Confirm add task? (y/n)");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            var newTask = new Task
            {
                Id = TaskRepository.LoadTasks().Count + 1,
                Title = title,
                CreationDate = creationDate,
                Description = description,
                Flag = flag,
                LabelColor = labelColor,
                TaskColor = taskColor
            };
            return newTask;
        }
        return null;
    }

}
