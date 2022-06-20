class TriviaProvider
{
    public static string GetTrivia()
    {
    string fileDirectory = @"Program Notes/Trivia.txt";
    List<string> trivia = new List<string>();
    trivia = File.ReadAllLines(fileDirectory).ToList();
    string r = GetRandomTrivia(trivia);
    return r;
    }

    private static string GetRandomTrivia(List<string> trivialist)
    {
        int n = new Random().Next(0,trivialist.Count);
        return (trivialist[n]);
    }
}   
