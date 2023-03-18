using System.Text.RegularExpressions;

int numberOfMessages = int.Parse(Console.ReadLine());
List<string> attackedPlanets = new List<string>();
List<string> destroyedPlanets = new List<string>();

string patternKey = "(?<key>[STAR]|[star])";
string pattern = @"@(?<planet>[A-Z][a-z]+)[^@\-\!\:\>]*?\:(?<population>\d+)[^@\-\!\:\>]*?\!(?<attack>[A|D])\![^@\-\!\:\>]*?->(?<soldiers>\d+)";

for (int message = 1; message <= numberOfMessages; message++)
{
    string encryptedMessage = Console.ReadLine();

    MatchCollection keyRegexColection = Regex.Matches(encryptedMessage, patternKey);
    int key = string.Join("", keyRegexColection).Length;

    string decriptedMessage = string.Empty;

    foreach (var ch in encryptedMessage)
    {
        decriptedMessage += (char)(ch - key);
    }

    Match match = Regex.Match(decriptedMessage, pattern);
    if (match.Success)
    {
        string planet = match.Groups["planet"].Value;
        string attackType = match.Groups["attack"].Value;

        if (attackType == "A")
        {
            attackedPlanets.Add(planet);
        }
        else
        {
            destroyedPlanets.Add(planet);
        }
    }
}

Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
foreach (var planet in attackedPlanets.OrderBy(x => x))
{
    Console.WriteLine($"-> {planet}");
}

Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
foreach (var planet in destroyedPlanets.OrderBy(x => x))
{
    Console.WriteLine($"-> {planet}");
}