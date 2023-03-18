using System.Text;
using System.Text.RegularExpressions;

string input = Console.ReadLine();
StringBuilder sb = new StringBuilder();

Regex regex = new Regex(@">>(?<name>[A-Za-z]+)<<(?<price>\d+(\.\d*)?)!(?<quantity>\d+)");

decimal totalSum = 0;

while (input != "Purchase")
{
    Match match = regex.Match(input);

    if (match.Success)
    {
        string name = match.Groups["name"].Value;
        decimal price = decimal.Parse(match.Groups["price"].Value);
        int quantity = int.Parse(match.Groups["quantity"].Value);

        sb.AppendLine(name);
        totalSum += price * quantity;
    }

    input = Console.ReadLine();
}

Console.WriteLine("Bought furniture:");
Console.Write(sb);
Console.WriteLine($"Total money spend: {totalSum:f2}");