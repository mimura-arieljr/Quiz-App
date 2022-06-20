class Question 
{
    private string _difficulty = "";
    private string _category = "";
    private string _id = "";
    private string _correctans = "";
    private string _questions = "";

    private string _choices = "";

    public string Difficulty
    {
        get {return _difficulty;}
        set {_difficulty = value;}
    }

    public string Category
    {
        get {return _category;}
        set {_category = value;}
    }

    public string ID
    {
        get {return _id;}
        set {_id = value;}
    }

    public string Correctans
    {
        get {return _correctans;}
        set {_correctans = value;}
    }

    public string Questions
    {
        get {return _questions;}
        set {_questions = value;}
    }

    public void setChoices(string value)
    {
        _choices = value;
    }

    public virtual string getChoices()
    {
        return _choices;
    }
}