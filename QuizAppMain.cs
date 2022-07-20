using System;
class QuizAppMain
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Please type in your name: ");
        string? answeredName = Console.ReadLine();
        string? answer1;
        string highScores = "HighScore.txt";
        do
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("     ▄▀▄ █ █ █ ▀█▀ ▄▀▄ █▀▄ █▀▄ ");
            Console.WriteLine("     ▀▄█ ▀▄█ █ █▄▄ █▀█ █▀  █▀  ");
            Console.WriteLine("\nWelcome to QuizApp! Please choose an action.\n");
            Console.WriteLine("[1] Play\n[2] Settings \n[X] Quit Game");
            answer1 = Console.ReadLine();
            Console.Clear();

            if (string.Equals(answer1, "1")) //To compare strings
            {
                string? answer2 = null; // ? are called "nullable" allows the string answer2 to be null
                Dictionary<string, string> categories = CategoryProvider.GetCategories(); //Keyword Dictionary was found on listed recommendation of C#. For mapping.
                do
                {
                    if (answer2 != null)
                    {
                        Console.WriteLine("\nInvalid input, please try again.\n");
                    }
                    Console.WriteLine("\nSelect a category:\n");
                    foreach (KeyValuePair<string, string> category in categories)
                    {
                        Console.WriteLine("[" + category.Key + "]: " + category.Value);
                    }
                    answer2 = Console.ReadLine();
                    Console.Clear();

                    string? answer3 = null;
                    Dictionary<string, string> difficulties = DifficultyProvider.GetDifficulties();
                    do
                    {
                        if (answer3 != null)
                        {
                            Console.WriteLine("\nInvalid input, please try again.\n");
                        }
                        Console.WriteLine("\nSelect a difficulty:\n");
                        foreach (KeyValuePair<string, string> difficulty in difficulties)
                        {
                            Console.WriteLine("[" + difficulty.Key + "]: " + difficulty.Value);
                        }
                        answer3 = Console.ReadLine();
                        if (difficulties.ContainsKey(answer3!) && categories.ContainsKey(answer2!))
                        {
                            string selectedCategory = categories[answer2!]; // Variable declaring "selectedCategory to be the holder for answer2 from categories (ex.Science)
                            string selectedDifficulty = difficulties[answer3!]; // Variable declaring "selectedDifficulty to be the holder for answer3 from categories (ex.Hard)
                            Console.Clear();
                            Console.WriteLine("\nYou have chosen,\n" + selectedDifficulty + " : " + selectedCategory);
                            Console.WriteLine("\nIncorrect spelling of answer is considered wrong.\n");

                            List<Question> questions = QuestionProvider.GetQuestion(selectedCategory, selectedDifficulty);

                            int counter = 1;
                            int score = 0;
                            foreach (Question q in questions)
                            {
                                Console.WriteLine(counter + ".] " + q.Questions);
                                Console.WriteLine(q.getChoices());

                                string? useranswer = Console.ReadLine();
                                if (string.Equals(useranswer!.ToLower(), q.Correctans.ToLower())) //To compare strings
                                {
                                    Console.WriteLine("\nCorrect!");
                                    score++;
                                }
                                else
                                {
                                    Console.WriteLine("\nIncorrect");
                                    Console.WriteLine("\nThe correct answer is: " + q.Correctans);
                                }
                                counter++;
                                Console.WriteLine("\nScore: " + score);

                                string trivia = TriviaProvider.GetTrivia();
                                if (counter == 2 || counter == 5 || counter == 10 || counter == 15)
                                {
                                    Console.WriteLine("\n" + trivia);
                                }
                                Console.WriteLine("\nPress Enter to proceed");
                                Console.ReadLine();
                                // Thread.Sleep(2000); Decided not to put this since there won't be enough time to read the generated trivia.
                                Console.Clear();
                            }
                            Console.WriteLine("\n\nYour total score is: " + score + "\nThanks for playing!");
                            Console.WriteLine("\nPress Enter to play again.\n");
                            string scoreTextFile = File.ReadAllText(@highScores).ToString();
                            int currentHighScore = int.Parse(scoreTextFile);
                            if (currentHighScore < score)
                            {
                                File.WriteAllTextAsync(highScores, answeredName + " : " + score.ToString());
                                Console.WriteLine("\nCongratulations " + answeredName + "! You set the new high score: " + score);
                            }
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    while (!difficulties.ContainsKey(answer3!));
                }
                while (!categories.ContainsKey(answer2!));
            }
            else if (string.Equals(answer1, "2"))
            {
                Console.Clear();
                Console.WriteLine("[1] Set number of questions. \n[2] Show High Score \n[3] Reset High Score");
                string? answer4 = Console.ReadLine();
                if (String.Equals(answer4,"1"))
                {
                    Console.Clear();
                    Console.WriteLine("\n\nPlease set the number of questions you'd like to answer on your next game(1-15).\n");
                    int newTestSize = int.Parse(Console.ReadLine()!);
                    if (newTestSize <= 15)
                    {
                        QuestionProvider.SetTestSize(newTestSize);
                    }
                    else
                    {
                        Console.WriteLine("\nQuizApp is currently expanding the number of questions available, please set a number according to the stated limit.");
                    }
                }
                else if (String.Equals(answer4,"2"))
                {
                    Console.Clear();
                    string scoreTextFile = File.ReadAllText(@highScores).ToString();
                    Console.WriteLine("The current High Score is: " + scoreTextFile);
                    Thread.Sleep(2000);
                }
                else if (String.Equals(answer4,"3"))
                {
                    Console.Clear();
                    Console.WriteLine("Are you sure you want to reset highscore? (y/n)");
                    string? answer5 = Console.ReadLine();
                    if(String.Equals(answer5,"y"))
                    {
                        File.WriteAllTextAsync(highScores, "0");
                        Console.WriteLine("\nHigh Score has been reset.");
                        Thread.Sleep(2000);
                    }
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }
        while (string.Equals(answer1, "1") || string.Equals(answer1, "2")); //To compare strings
    }
}
