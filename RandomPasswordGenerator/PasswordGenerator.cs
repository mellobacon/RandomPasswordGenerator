
using System.Text;

namespace RandomPasswordGenerator;

public class PasswordGenerator
{
    public bool HasSpecialCharacters = false;
    public int Length = 6;
    public bool WithNumbers = true;
    public int MinSpecialChars = 1;
    public int MinNumbers = 1;
    
    private readonly Random random = new();
    private readonly StringBuilder sb = new();

    public void GetNewPassword()
    {
        string? password = GenerateNewPassword();
        if (password is not null)
        {
            Console.Write($"Generated password: ");
            foreach (var c in password)
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
    private string? GenerateNewPassword()
    {
        string? password = GeneratePassword();
        string numbers = "1234567890";
        string specialchars = "!@#$%^&*";
        if (password is null)
        {
            return null;
        }
        
        if (!HasSpecialCharacters) MinSpecialChars = 0;
        if (!WithNumbers) MinNumbers = 0;

        if (!password.CheckCount(numbers, MinNumbers))
        {
            password = GenerateNewPassword();
        }
        if (!password.CheckCount(specialchars, MinSpecialChars))
        {
            password = GenerateNewPassword();
        }

        return password;
    }

    private string? GeneratePassword()
    {
        sb.Clear();
        if (Length <= 4)
        {
            PrintError("Password must be atleast 5 characters");
            return null;
        }

        Delegate[] functions = { GetUpperCase, GetLowerCase, GetSpecialChars, GetNumber };

        if (MinNumbers == Length || MinSpecialChars == Length)
        {
            Length += 3;
        }
        for (int i = 0; i < Length; i++)
        {
            int randomint = random.Next(functions.Length);
            sb.Append(functions[randomint].DynamicInvoke());
        }

        return sb.ToString();
    }
    
    private char GetUpperCase()
    {
        const string uppercase = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
        return uppercase[random.Next(uppercase.Length)];
    }

    private char GetLowerCase()
    {
        const string uppercase = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
        string lowercase = uppercase.ToLower();
        return lowercase[random.Next(lowercase.Length)];
    }

    private char GetSpecialChars()
    {
        string specialchars = "!@#$%^&*";
        return specialchars[random.Next(specialchars.Length)];
    }

    private int GetNumber()
    {
        int number = random.Next(0, 9);
        return number;
    }

    private static void PrintError(string error)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(error);
        Console.ResetColor();
    }
}