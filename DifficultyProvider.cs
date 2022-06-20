static class DifficultyProvider
{   
    public static Dictionary<string,string> GetDifficulties() //Keyword Dictionary was found on listed recommendation of C#. For mapping.
    {
        Dictionary<string,string> Difficulties = new Dictionary<string,string>();
        
        Difficulties["1"] = "Easy";
        Difficulties["2"] = "Hard";

        return Difficulties;
    }
}