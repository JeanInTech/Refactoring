using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RefactoringLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>
            {
                "Caspian", "Sanjeev","Daniel","Ted",
                "Tevin", "Tobey","Elisa","Jermaine"
            };
            List<string> surnames = new List<string>
            {
                "Melendez","Padilla","Barrow","Scott",
                "Lowery","Reeve","Mosley","Mays"
            };
            List<string> hometowns = new List<string>
            {
                "Detroit, MI","Dearborn, MI","Bloomfield Hills, MI","Sterling Heights, MI",
                "Warren, MI","Roseville, MI","Eastpointe, MI","Detroit, MI"
            };
            List<string> faveFoods = new List<string>
            {
                "pizza","ramen","elote","pesto",
                "cookies","bulgogi","burgers","sushi"
            };
            List<string> faveColors = new List<string>
            {
                "red","orange","yellow","green",
                "blue","indigo","purple","pink"
            };

            //List<Students> classmates = new List<Students>
            //{
            //    new Students("Caspain", "Melendez", "Detroit","pizza", "red"),
            //    new Students("Sanjeev", "Padilla", "Dearborn", "ramen", "orange"),
            //    new Students("Daniel", "Barrow", "Bloomfield Hills", "elote", "yellow"),
            //    new Students("Ted", "Scott", "Sterling Heights", "pesto", "green"),
            //    new Students("Tevin", "Lowery", "Warren", "cookies", "blue"),
            //    new Students("Tobey", "Reeve", "Roseville", "bulgogi", "indigo"),
            //    new Students("Elisa", "Mosley", "Eastpointe", "burgers", "purple"),
            //    new Students("Jermaine", "Mays", "Detroit", "sushi", "pink")
            //};

            bool userContinue = true;

            while (userContinue)
            {
                Console.WriteLine("Welcome to our C# class! Here are our students:\n");

                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {names[i]}");
                }
                string input = GetUserInput($"\nWhich student would you like to learn more about? Please enter 1 - {names.Count}");

                bool proceed = true;

                while (proceed)
                {
                    try
                    {
                        if (Int32.TryParse(input, out int studentNumber))
                        {
                            int index = studentNumber - 1;

                            Console.Write($"Student {studentNumber} is {names[index]} {surnames[index]}. ");
                            string moreInfo = GetUserInput($"What would you like to know about {names[index]}? (enter hometown, favorite food or favorite color)");

                            Console.Write(GetMoreInfo(index, moreInfo, names[index], hometowns, faveFoods, faveColors));
                            proceed = UserContinue("Do you want to learn more about this student? (y/n)");
                        }
                        else
                        {
                            input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Count})");
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Count})");
                    }
                    catch (FormatException)
                    {
                        input = GetUserInput($"That student does not exist. Please try again. (enter a number 1-{names.Count})");
                    }
                }

                while (true)
                {
                    input = GetUserInput("Do you want to add or remove a student? (enter add, remove, or no)");
                    if (input == "add")
                    {
                        string firstName = GetUserInput("Okay, let's add a new student. To begin, what's the student's first name?");
                        if (string.IsNullOrEmpty(firstName))
                        {
                            firstName = ValidateInput(firstName);                           
                        }
                        names.Add(firstName);

                        string lastName = GetUserInput("What's the student's last name?");
                        if (string.IsNullOrEmpty(lastName))
                        {
                            lastName = ValidateInput(lastName);
                        }
                        surnames.Add(lastName);

                        string town = GetUserInput("What's the student's hometown?");
                        if (string.IsNullOrEmpty(town))
                        {
                            town = ValidateInput(town);
                        }
                        hometowns.Add(town);

                        string food = GetUserInput("What's the student's favorite food?");
                        if (string.IsNullOrEmpty(food))
                        {
                            food = ValidateInput(food);
                        }
                        faveFoods.Add(food);

                        string color = GetUserInput("What's the student's favorite color?");
                        if (string.IsNullOrEmpty(color))
                        {
                            color = ValidateInput(color);
                        }
                        faveColors.Add(color);

                        Console.WriteLine("Great! This student has been added");
                        break;
                    }
                    else if (input == "remove")
                    {
                        break;
                    }
                    else if (input == "no")
                    {
                        break;
                    }
                    else if (input != "add" || input != "remove" || input != "no")
                    {
                        input = GetUserInput("Invalid input. Do you want to add or remove a student? (enter add, remove, or no)");
                        if (input == "add" || input == "remove" || input == "no") continue;
                    }
                }
                userContinue = UserContinue("Do you want to learn about another student? (y/n)");
            }
            Console.WriteLine("Thanks!");
        }
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim();
            return input;
        }
        public static string GetMoreInfo(int index, string input, string name, List<string> info1, List<string> info2, List<string> info3)
        {
            try
            {
                if (input == "hometown")
                {
                    return $"{name} is from {info1[index]}. ";
                }
                else if (input == "favorite food")
                {
                    return $"{name}'s favorite food is {info2[index]}. ";
                }
                else if (input == "favorite color")
                {
                    return $"{name}'s favorite color is {info3[index]}. ";
                }
                else
                    return "That data does not exist. ";
            }
            catch (FormatException)
            {
                return $"That data does not exist. ";
            }
        }
        public static bool UserContinue(string message)
        {
            Console.WriteLine(message);
            string proceed = Console.ReadLine().Trim().ToLower();

            while (proceed != "n" && proceed != "y")
            {
                Console.WriteLine("Invalid input. Please enter 'y' or 'n'.");
                proceed = Console.ReadLine().Trim().ToLower();
            }

            if (proceed == "y")
            {
                return true;
            }
            else
                return false;
        }
        public static string ValidateInput(string input)
        {
            while (true)
            {
                string updatedInput = GetUserInput("No information detected. Please input the requested information");

                if (string.IsNullOrEmpty(updatedInput))
                {
                    continue;
                }
                else
                {
                    return updatedInput;
                }
            }
        }
    }
}
