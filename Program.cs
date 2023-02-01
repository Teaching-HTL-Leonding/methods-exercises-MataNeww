string selection, text;
int input = 0, minimum = 0, maximum = 0;

do
{
    Console.Clear();
    Console.WriteLine("What do you want to execute?");
    Console.WriteLine("============================");
    Console.WriteLine();
    Console.WriteLine("0. Calculate Circle Area");
    Console.WriteLine("1. Random in Range");
    Console.WriteLine("2. To FizzBuzz");
    Console.WriteLine("3. Fibonacci by Index");
    Console.WriteLine("4. Ask for Number in Range");
    Console.WriteLine("5. Is palindrome?");
    Console.WriteLine("6. Is palindrome? (advanced)");
    Console.WriteLine("7. Chart Bar");
    Console.WriteLine("q to Quit");
    selection = Console.ReadLine()!;

    if (selection != "q")
    {
        Console.Clear();
        switch (selection)
        {
            case "0": RunCalculateCircleArea(); break;
            case "1": RunRandomInRange(); break;
            case "2": RunToFizzBuzz(); break;
            case "3": RunFibonacciByIndex(); break;
            case "4": RunAskForNumberInRange(); break;
            case "5": RunCheckIfPalindrome(); break;
            case "6": RunCheckIfPalindromeAdvanced(); break;
            case "7": RunChartBar();break;
            default: break;
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
while (selection != "q");

#region Calculate Circle Area
void RunCalculateCircleArea()
{
    Console.Write("Enter radius:");
    var radius = double.Parse(Console.ReadLine()!);
    var area = CalculateCircleArea(radius);
    Console.WriteLine($"Area of circle with radius {radius} is {area}");
}

double CalculateCircleArea(double radius)
{
    return radius * radius * Math.PI;
}
#endregion

#region RandomInRange
void RunRandomInRange()
{
    //Variables 
    int counter_for_minimum = 0, counter = 0, counter_for_maximum = 0;

    Console.Write("Enter the minimum: ");
    minimum = int.Parse(Console.ReadLine()!);

    Console.Write("Enter the maximum:  ");
    maximum = int.Parse(Console.ReadLine()!);

    for (int i = 0; i <= 1_000_000; i++)
    {
        var result = RandomInRange(minimum, maximum);

        if (result == minimum)
        {
            counter_for_minimum++;
        }
        else if (result == maximum)
        {
            counter_for_maximum++;
        }
        else
        {
            counter++;
        }
    }
    Console.WriteLine($"Counter for {minimum} is {counter_for_minimum} ");
    Console.WriteLine($"Counter for {maximum} is {counter_for_maximum} ");
    Console.WriteLine($"Counter for random number is {counter}");
}

int RandomInRange(int min, int max)
{
    max++;
    int random = Random.Shared.Next(min, max);
    return random;
}

#endregion

#region ToFizzBuzz
void RunToFizzBuzz()
{
    Console.Write("Please enter your number: ");
    input = int.Parse(Console.ReadLine()!);

    var result = ToFizzBuzz(input);
    Console.WriteLine($"The result is {result}");
}
string ToFizzBuzz(int number)
{
    string Fizz = "Fizz";
    string Buzz = "Buzz";
    string FizzBuzz = "FizzBuzz";
    string result = "";

    if (number % 3 == 0 && !(number % 5 == 0))
    {
        result = Fizz;
    }
    else if (number % 5 == 0 && !(number % 3 == 0))
    {
        result = Buzz;
    }
    else if (number % 3 == 0 && number % 5 == 0)
    {
        result = FizzBuzz;
    }
    return $"{result}";
}
#endregion

#region Fibonacci by Index

void RunFibonacciByIndex()
{
    Console.Write("Enter a number: ");
    input = int.Parse(Console.ReadLine()!);

    var result = FibonacciByIndex(input);
    Console.WriteLine($"The result of {input} is {result}");

}

int FibonacciByIndex(int input)
{
    int a = 0;
    int b = 1;
    int c = 0;

    /* if (input == 0)
     {
         return a; 
     }*/

    for (int i = 2; i <= input; i++)
    {
        c = a + b;
        a = b;
        b = c;
    }
    return b;
}
#endregion

#region AskForNumberInRange
void RunAskForNumberInRange()
{
    Console.Write("Please enter your minimum: ");
    minimum = int.Parse(Console.ReadLine()!);

    Console.Write("Please enter your maximum: ");
    maximum = int.Parse(Console.ReadLine()!);

    var result = AskForNumberInRange(minimum, maximum);

    Console.WriteLine("Thank you! Your input is valid!");
}

int AskForNumberInRange(int mini, int maxi)
{
    Console.Write($"Please enter a value between {mini} and {maxi}: ");
    do
    {
        input = int.Parse(Console.ReadLine()!);
        if (input <= mini)
        {
            Console.WriteLine($"Wrong number! Your input is too low! The minimum is {mini}, Try Again");
        }
        else if (input >= maxi)
        {
            Console.WriteLine($"Wrong number! Your input is too high! The maximum is {maxi}, Try again.");
        }
    } while (input <= mini || input >= maxi);

    return input;
}
#endregion

#region IsPalindrome
void RunCheckIfPalindrome()
{
    Console.Write("Please enter your text: ");
    text = Console.ReadLine()!;

    var result = CheckIfPalindrome(text);
    Console.WriteLine($"The result is: {result}");
}

bool CheckIfPalindrome(string input)
{
    for (int i = 0; i < input.Length / 2; i++)
    {
        if (input[i] != input[input.Length - i - 1])
        {
            return false;
        }
    }
    return true;

}
#endregion

#region IsPalindrome(Advanced)
void RunCheckIfPalindromeAdvanced()
{
    Console.Write("Please enter your text: ");
    text = Console.ReadLine()!;

    var result = CheckIfPalindromeAdvanced(text);
    Console.WriteLine($"The result is: {result}");
}

bool CheckIfPalindromeAdvanced(string input)
{
    input = input
    .Replace(" ", "")
    .Replace(",", "")
    .Replace("-", "")
    .ToLower();

    for (int i = 0; i < input.Length / 2; i++)
    {
        if (input[i] != input[input.Length - i - 1])
        {
            return false;
        }
    }
    return true;
}
#endregion

#region ChartBar
void RunChartBar()
{
    Console.Write("Please enter your number: ");
    double input = double.Parse(Console.ReadLine()!);

    var result = ChartBar(input);

    Console.WriteLine($"The result of {input} is {result}");
}

string ChartBar(double input)
{
    string bar;
    if (input > 0 && input < 0.1)
    {
        bar = "..........";
    }
    else if (input >= 0.1 && input < 0.2)
    {
        bar = "o.........";
    }
    else if (input >= 0.2 && input < 0.3)
    {
        bar = "oo........";
    }
    else if (input >= 0.3 && input < 0.4)
    {
        bar = "ooo.......";
    }
    else if (input >= 0.4 && input < 0.5)
    {
        bar = "oooo......";
    }
    else if (input >= 0.5 && input < 0.6)
    {
        bar = "ooooo.....";
    }
    else if (input >= 0.6 && input < 0.7)
    {
        bar = "oooooo....";
    }
    else if (input >= 0.7 && input < 0.8)
    {
        bar = "oooooo....";
    }
    else if (input >= 0.8 && input < 0.9)
    {
        bar = "oooooooo..";
    }
    else if (input >= 0.9 && input < 1)
    {
        bar = "ooooooooo.";
    }
    else
    {
        bar = "oooooooooo";
    }
    return bar;
}
#endregion
