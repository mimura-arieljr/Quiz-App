using System;

static class QuestionProvider
{

    private static int testSize = 15;
    public static void SetTestSize(int newTestSize)
    {
        testSize = newTestSize;
    }

    public static List<Question> GetQuestion(string category, string difficulty)
    {
        List<Question> questions = new List<Question>();

        string fileName = "Q"+category+difficulty+".txt";
        string filePath = @"Questions/"+fileName;
        List<string> lines = new List<string>();
        
        lines = File.ReadAllLines(filePath).ToList();
        
        foreach(string line in lines)
        {
            string [] words = line.Split ("@");

            string type = words [3];
            if (string.Equals(type,"Identification"))
            {
                Identification iq = new Identification(); //Instantiating a new object "iq" to set properties of object iq.
                iq.Difficulty = words[2];
                iq.Category = words[1];
                iq.ID = words[0];
                iq.Correctans = words[5];
                iq.Questions = words[4];

                questions.Add(iq);
            }
            else if (string.Equals(type, "MultChoice"))
            {
                MultChoice mq = new MultChoice(words[5]);
                mq.Difficulty = words[2];
                mq.Category = words[1];
                mq.ID = words[0];
                mq.Correctans = words[6];
                mq.Questions = words[4];

                questions.Add(mq);
            }
            else 
            {
                TrueFalse tfq = new TrueFalse();
                tfq.Difficulty = words[2];
                tfq.Category = words[1];
                tfq.ID = words[0];
                tfq.Correctans = words[5];
                tfq.Questions = words[4];

                questions.Add(tfq);
            }

        }
        Dictionary<string,Question> qcontainer = new Dictionary<string, Question>();
        while (qcontainer.Count<testSize)
        {
            Question q = GetRandomQuestion(questions);
            if (!qcontainer.ContainsKey(q.ID))
            {
                qcontainer[q.ID] = q;
            }
        }
        List<Question> quniqueholder = new List<Question>(); //Holder of unique Questions
        quniqueholder = qcontainer.Values.ToList();
        return quniqueholder;
    }
    private static Question GetRandomQuestion(List<Question> questions)
    {
        int n = new Random().Next(0,questions.Count);
        return (questions[n]);
    }
}