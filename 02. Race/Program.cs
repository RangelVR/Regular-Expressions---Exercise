
using System.Text.RegularExpressions;

string[] inputNames = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

string info = Console.ReadLine();

var participants = new Dictionary<string, int>();

foreach (var name in inputNames)
{
    participants.Add(name, 0);
}

while (info != "end of race")
{
    MatchCollection name = Regex.Matches(info, "[A-Za-z]+");
    MatchCollection distanceRegxColection = Regex.Matches(info, @"\d");

    string curName = string.Join("", name);
    int distance = distanceRegxColection.Select(x => int.Parse(x.Value)).Sum();

    if (participants.ContainsKey(curName))
    {
        participants[curName] += distance;
    }

    info = Console.ReadLine();
}

var winners = participants.OrderByDescending(x => x.Value).Take(3).ToList();

int counter = 1;
foreach (var participant in winners)
{
    string suffix = counter == 1 ? "st" : counter == 2 ? "nd" : "rd"; 
    Console.WriteLine($"{counter++}{suffix} place: {participant.Key}");
}
