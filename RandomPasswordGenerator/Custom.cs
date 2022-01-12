namespace RandomPasswordGenerator;

public static class Custom
{
    public static bool CheckCount(this string? str, string? chars, int count)
    {
        int charcount = (from c in str from s in chars where c == s select c).Count();

        if (count == 0) return charcount == count;
        return charcount >= count;
    }

    public static bool EqualsAny(this char c, string chars)
    {
        var check = false;
        foreach (char _ in chars.Where(ch => c == ch))
        {
            check = true;
        }

        return check;
    }
}