
using System.Text;

namespace RandomPasswordGenerator;

public class PasswordGenerator
{
    public bool HasSpecialCharacters = true;
    public int Length = 8;
    public bool WithNumbers = true;
    public int MinSpecialChars = 1;
    public int MinNumbers = 1;
    
    private readonly Random _random = new();
    private readonly StringBuilder _sb = new();

    public void GetNewPassword()
    {
        string? password = CheckPassword();
        if (password is not null)
        {
            Console.Write("Generated password: ");
            foreach (char c in password)
            {
                if (c.EqualsAny("!@#$%^&*"))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (c.EqualsAny("1234567890"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                Console.Write(c);
                Console.ResetColor();
            }
        }
        Console.WriteLine();
    }
    private string? CheckPassword()
    {
        string? password = GeneratePassword();
        const string numbers = "1234567890";
        const string specialchars = "!@#$%^&*";
        if (password is null)
        {
            return null;
        }
        
        if (!HasSpecialCharacters) MinSpecialChars = 0;
        if (!WithNumbers) MinNumbers = 0;

        if (!password.CheckCount(numbers, MinNumbers))
        {
            password = CheckPassword();
        }
        if (!password.CheckCount(specialchars, MinSpecialChars))
        {
            password = CheckPassword();
        }

        return password;
    }

    private string? GeneratePassword()
    {
        _sb.Clear();
        if (Length < 5)
        {
            PrintError("Password must be at least 5 characters");
            return null;
        }

        Delegate[] functions = { GetUpperCase, GetLowerCase, GetSpecialChars, GetNumber };

        if (MinNumbers == Length || MinSpecialChars == Length)
        {
            Length += 3;
        }
        for (var _ = 0; _ < Length; _++)
        {
            int randomint = _random.Next(functions.Length);
            _sb.Append(functions[randomint].DynamicInvoke());
        }

        return _sb.ToString();
    }
    
    private char GetUpperCase()
    {
        const string uppercase = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
        return uppercase[_random.Next(uppercase.Length)];
    }

    private char GetLowerCase()
    {
        const string uppercase = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
        string lowercase = uppercase.ToLower();
        return lowercase[_random.Next(lowercase.Length)];
    }

    private char GetSpecialChars()
    {
        const string specialchars = "!@#$%^&*";
        return specialchars[_random.Next(specialchars.Length)];
    }

    private int GetNumber()
    {
        int number = _random.Next(0, 9);
        return number;
    }

    private static void PrintError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ResetColor();
    }
}