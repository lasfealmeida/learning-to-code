Random random = new Random();
int secretNumber = random.Next(1, 101);
int guess = 0;
int tries = 0;

Console.WriteLine("Guess a number between 1 and 100!");

while (guess != secretNumber)
{
    Console.Write("Your guess: ");
    guess = int.Parse(Console.ReadLine());
    tries++;

    if (guess < secretNumber)
    {
        Console.WriteLine("Too low!");
    }
    else if (guess > secretNumber)
    {
        Console.WriteLine("Too high!");
    }
    else
    {
        Console.WriteLine("You got it! It took you " + tries + " tries.");
    }
}

Console.ReadLine();