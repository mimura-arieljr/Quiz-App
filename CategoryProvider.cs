static class CategoryProvider
{   
    public static Dictionary<string,string> GetCategories() //Keyword Dictionary was found on listed recommendation of C#. For mapping.
    {
        Dictionary<string,string> Categories = new Dictionary<string,string>();
        Categories["1"] = "Science";
        Categories["2"] = "GeneralInfo";
        Categories["3"] = "Math";
        Categories["4"] = "Entertainment"; 

        return Categories;
    }
}