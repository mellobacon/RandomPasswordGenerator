// See https://aka.ms/new-console-template for more information

using RandomPasswordGenerator;

PasswordGenerator generator = new()
{
    HasSpecialCharacters = true, 
    WithNumbers = true, 
    MinSpecialChars = 1,
    MinNumbers = 1,
    Length = 8
};

Console.WriteLine("Password length: ");
string? input = Console.ReadLine();

Console.WriteLine("Will password have special characters (!@#$%^&*)?: ");
input = Console.ReadLine();

Console.WriteLine("Will password have numbers (1234567890)?: ");
input = Console.ReadLine();

if (generator.WithNumbers)
{
    Console.WriteLine("Min numbers: ");
    input = Console.ReadLine();
}

if (generator.HasSpecialCharacters)
{
    Console.WriteLine("Min special characters: ");
    input = Console.ReadLine();
}
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