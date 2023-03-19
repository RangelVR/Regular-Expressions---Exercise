using System.Text;
using System.Text.RegularExpressions;

string[] demonsList = Console.ReadLine()
    .Split(new[] {' ', ',', ' '}, StringSplitOptions.RemoveEmptyEntries)
    .OrderBy(x => x)
    .ToArray();
string patternLetters = @"[^\+\-\.\/\*,0-9]";
string digitsPattern = @"(?:-)?[0-9]+(?:\.[0-9]+)?";

StringBuilder sb = new StringBuilder();

foreach (var demonName in demonsList)
{
    MatchCollection letters = Regex.Matches(demonName, patternLetters);
    MatchCollection digits = Regex.Matches(demonName, digitsPattern);

    double damage = digits.Select(x => double.Parse(x.Value)).Sum();

    string name = string.Join("", letters);
    int health = 0;
    foreach (var ch in name)
    {
        health += ch;
    }

    foreach (var ch in demonName)
    {
        if (ch == '*')
        {
            damage *= 2;
        }
        else if (ch == '/')
        {
            damage /= 2;
        }
    }

    sb.AppendLine($"{demonName} - {health} health, {damage:f2} damage");
}

Console.WriteLine(sb);

