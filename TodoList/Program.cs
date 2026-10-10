List<string> todos = new List<string>();

while (true)
{
    Console.WriteLine("\n1. Add todo");
    Console.WriteLine("2. Show todos");
    Console.WriteLine("3. Quit");
    Console.Write("Choose: ");
    string choice = Console.ReadLine();

    if (choice == "1")
    {
        Console.Write("Enter todo: ");
        string todo = Console.ReadLine();
        todos.Add(todo);
    }
    else if (choice == "2")
    {
        Console.WriteLine("\nYour todos:");
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + todos[i]);
        }
    }
    else if (choice == "3")
    {
        break;
    }
    else
    {
        Console.WriteLine("Not a valid choice.");
    }
}