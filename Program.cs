using System.Text;
using System.Diagnostics;

// ==============================
// 1. String interpolation
// ==============================
string name = "Igor";
int age = 25;
Console.WriteLine($"Hi {name}, you are {age}. Next year you'll be {age + 1}.");

// ==============================
// 2. Classes and objects
// ==============================
var dog = new Animal("Rex", "Dog", 3);
var cat = new Animal("Whiskers", "Cat", 5);
dog.Speak();
cat.Speak();

// ==============================
// 3. Records - way less code!
// ==============================
var p1 = new Point(3, 4);
var p2 = new Point(3, 4);
Console.WriteLine(p1);                 // prints nicely
Console.WriteLine(p1 == p2);           // True! records compare values
Console.WriteLine(p1 with { X = 10 }); // copy with change

// ==============================
// 4. Enums
// ==============================
var today = DayOfWeek2.Wednesday;
Console.WriteLine($"Today is {today} ({(int)today})");

// ==============================
// 5. Collections
// ==============================
var numbers = new List<int> { 5, 3, 8, 1, 9, 2 };
var scores = new Dictionary<string, int>
{
    ["Alex"] = 90,
    ["Sam"] = 75,
    ["Jo"] = 88
};

// ==============================
// 6. LINQ - this is magic
// ==============================
var evens = numbers.Where(n => n % 2 == 0).ToList();
var sorted = numbers.OrderBy(n => n).ToList();
var total = numbers.Sum();
var biggest = numbers.Max();

Console.WriteLine($"Evens: {string.Join(", ", evens)}");
Console.WriteLine($"Sorted: {string.Join(", ", sorted)}");
Console.WriteLine($"Sum: {total}, Max: {biggest}");

var topScorers = scores.Where(kv => kv.Value >= 80)
                       .OrderByDescending(kv => kv.Value)
                       .Select(kv => kv.Key);

Console.WriteLine("Top scorers: " + string.Join(", ", topScorers));

// ==============================
// 7. Switch expression + pattern matching
// ==============================
foreach (var n in new[] { 1, 7, 13, 42 })
{
    Console.WriteLine($"{n} -> {Describe(n)}");
}

// ==============================
// 8. Nullable / null-coalescing
// ==============================
string? maybeName = null;
string display = maybeName ?? "no name";
Console.WriteLine(display);

maybeName ??= "default";
Console.WriteLine(maybeName);

// ?. and ??
var box = new Box();
Console.WriteLine(box.Item?.Length ?? 0);

// ==============================
// 9. Exceptions
// ==============================
try
{
    Console.Write("Enter a number: ");
    int parsed = int.Parse(Console.ReadLine() ?? "");
    Console.WriteLine($"You entered {parsed}");
}
catch (FormatException)
{
    Console.WriteLine("That wasn't a number!");
}
catch (Exception ex)
{
    Console.WriteLine($"Something else broke: {ex.Message}");
}
finally
{
    Console.WriteLine("(done trying)");
}

// ==============================
// 10. Interfaces + polymorphism
// ==============================
var shapes = new List<IShape>
{
    new Circle(2),
    new Square(3),
    new Circle(1)
};

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: area = {shape.Area():F2}");
}

record Point(int X, int Y);

enum Day
{
    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
}

class Box
{
    public string? Item { get; set; }
}

interface IShape
{
    string Name { get; }
    double Area();
}

class Circle : IShape
{
    public double Radius { get; }

    public Circle(double radius) => Radius = radius;

    public string Name => "Circle";
    public double Area() => Math.PI * Radius * Radius;
}

class Square : IShape
{
    public double Side { get; }

    public Square(double side) => Side = side;

    public string Name => "Square";
    public double Area() => Side * Side;
}