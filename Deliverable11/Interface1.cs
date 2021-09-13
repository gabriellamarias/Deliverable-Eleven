using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverable11
{
    public enum RPS
    {
        rock,
        paper,
        scissors
    }

    public interface iPlayer
    {
        public string Name { get; set; }
        public RPS GenerateRPS();

    }

    public class RockPlayer : iPlayer
    {
        private string _name = "Golem";
        public string Name { get { return _name; } set { _name = value; } }

        public RPS GenerateRPS()
        {
            return RPS.rock;
        }
    }

    public class RandomPlayer : iPlayer
    {
        private string _name = "Medusa";
        public string Name { get { return _name; } set { _name = value; } }

        public RPS GenerateRPS()
        {
            var randomBlow = new Random();
            return (RPS)randomBlow.Next(Enum.GetNames(typeof(RPS)).Length);
        }
    }

    public class HumanPlayer : iPlayer
    {
        public string Name { get; set; }

        public HumanPlayer()
        {
            Console.Write("What is your name, valiant mortal? ");
            string userName = Console.ReadLine();
            this.Name = userName;
        }

        public RPS GenerateRPS()
        {
            bool noError = false;
            while (!noError)
            {
                Console.Write("Choose your weapon: Rock, Paper, Scissors (R/P/S): ");
                string userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "R":
                        RPS userBlow = RPS.rock;
                        noError = true;
                        return userBlow;

                    case "P":
                        userBlow = RPS.paper;
                        noError = true;
                        return userBlow;

                    case "S":
                        userBlow = RPS.scissors;
                        noError = true;
                        return userBlow;

                    default:
                        Console.WriteLine("Invalid input, please try again");
                        break;
                }
            }
            return RPS.paper;
        }


    }
}
