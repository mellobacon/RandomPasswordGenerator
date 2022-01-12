// See https://aka.ms/new-console-template for more information

using RandomPasswordGenerator;

PasswordGenerator generator = new();
Console.WriteLine($"Password defaults: Length - {generator.Length}, Special characters - {generator.HasSpecialCharacters}, " +
                  $"Numbers - {generator.WithNumbers}, Min numbers - {generator.MinNumbers}, Min special characters - {generator.MinSpecialChars}");

Console.Write("Password length: ");
string? input = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(input))
{
    if (int.TryParse(input, out int length))
    {
        generator.Length = length;
    }
    else
    {
        Console.WriteLine("Input not valid. Set to default.");
    }
}

Console.Write("Will password have special characters (!@#$%^&*)?: ");
input = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(input))
{
    if (bool.TryParse(input, out bool b))
    {
        generator.HasSpecialCharacters = b;
    }
    else
    {
        Console.WriteLine("Input not valid. Set to default.");
    }
}

Console.Write("Will password have numbers (1234567890)?: ");
input = Console.ReadLine();
if (!string.IsNullOrWhiteSpace(input))
{
    if (bool.TryParse(input, out bool b))
    {
        generator.WithNumbers = b;
    }
    else
    {
        Console.WriteLine("Input not valid. Set to default.");
    }
}

if (generator.WithNumbers)
{
    Console.Write("Min numbers: ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        if (int.TryParse(input, out int count))
        {
            generator.MinNumbers = count;
        }
        else
        {
            Console.WriteLine("Input not valid. Set to default.");
        }
    }
}

if (generator.HasSpecialCharacters)
{
    Console.Write("Min special characters: ");
    input = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(input))
    {
        if (int.TryParse(input, out int count))
        {
            generator.MinSpecialChars = count;
        }
        else
        {
            Console.WriteLine("Input not valid. Set to default.");
        }
    }
}
Console.WriteLine("Press 'enter' or 'space' to generate password");

while (true)
{
    if (Console.ReadKey().Key is ConsoleKey.Enter or ConsoleKey.Spacebar)
    {
        generator.GetNewPassword();
    }
    else if (Console.ReadKey().Key is ConsoleKey.Escape or ConsoleKey.Backspace)
    {
        break;
    }
}