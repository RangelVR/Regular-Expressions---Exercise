using System.Text;
using System.Text.RegularExpressions;

string input = Console.ReadLine();

string name = "(?<name>[A-Z][a-z]+)";
string product = @"(?<product>\w+)";
string count = @"(?<count>\d+)";
string price = @"(?<price>\d+(\.\d+)?)";
string junk = "[^|$.%]";

string pattern = $@"%{name}%{junk}*?<{product}>{junk}*?\|{count}\|{junk}*?{price}\$";
//@"%(?<name>[A-Z][a-z]+)%[^|$.%]*?<(?<product>\w+)>[^|$.%]*?\|(?<count>\d+)\|[^|$.%]*?(?<price>\d+(\.\d+)?)\$"
decimal totalSum = 0;

StringBuilder sb = new StringBuilder();

while (input != "end of shift")
{
    Match match = Regex.Match(input, pattern);
    if (match.Success)
    {
        string customerName = match.Groups["name"].Value;
        string productName = match.Groups["product"].Value;
        int countProduct = int.Parse(match.Groups["count"].Value);
        decimal currPrice = decimal.Parse(match.Groups["price"].Value);
        decimal curSum = countProduct * currPrice;

        totalSum += curSum;

        sb.AppendLine($"{customerName}: {productName} - {curSum:f2}");
    }

    input = Console.ReadLine();
}

Console.Write(sb);
Console.WriteLine($"Total income: {totalSum:f2}");