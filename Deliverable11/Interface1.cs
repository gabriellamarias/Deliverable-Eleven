using System;
using System.Collections.Generic;
using System.Text;

namespace Deliverable11
{
    interface Interface1
    {
        public enum RPS
        {
            rock,
            paper,
            scissors
        }

        public interface Player
        {
            public string Name { get; set; }
            public RPS GenerateRPS();

        }

        public class RockPlayer : Player
        {
            private string _name = "Golem";
            public string Name { get { return _name; } set { _name = value; } }

            public RPS GenerateRPS()
            {
                return RPS.rock;
            }
        }

        public class RandomPlayer : Player
        {
            private string _name = "Medusa";
            public string Name { get { return _name; } set { _name = value; } }

            public RPS GenerateRPS()
            {
                var randomBlow = new Random();
                return (RPS)randomBlow.Next(Enum.GetNames(typeof(RPS)).Length);
            }
        }

        public class HumanPlayer : Player
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
                return RPS.rock;
            }



            public RPS GenerateRPS(string userInput)
            {

                RPS userBlow = (RPS)Enum.Parse(typeof(RPS), userInput.ToLower()); ;

                return userBlow;

            }
        }

        public class RPSApp
        {

            public RPSApp()
            {
                int wins = 0;
                int loses = 0;
                int draws = 0;

                HumanPlayer User = new HumanPlayer();

                Console.Write("Do you wish to battle Medusa or the Golem (m/g)? ");

                string userFoeChoice = Console.ReadLine().ToLower();

                if (userFoeChoice == "g")
                {
                    RockPlayer rock = new RockPlayer();

                    Console.Write("Choose your weapon (rock/paper/scissors): ");

                    string userInput = Console.ReadLine();

                    User.GenerateRPS(userInput);

                    RPS userBlow = User.GenerateRPS(userInput);

                    Console.WriteLine($"{User.Name}: {userBlow}");
                    Console.WriteLine($"{rock.Name}: {rock.GenerateRPS()}");

                    if (userBlow == RPS.rock)
                    {
                        Console.WriteLine("It's a draw!");
                        draws++;
                    }

                    else if (userBlow == RPS.paper)
                    {
                        Console.WriteLine("You have defeated the Golem!");
                        wins++;
                    }

                    else if (userBlow == RPS.scissors)
                    {
                        Console.WriteLine("You have been crushed by the Golem!");
                        loses++;
                    }
                    Console.WriteLine($"Wins: {wins} Loses: {loses} Draws: {draws}");
                }
                else if (userFoeChoice == "m")
                {
                    RandomPlayer random = new RandomPlayer();
                    Console.Write("Choose your weapon (rock/paper/scissors): ");

                    string userInput = Console.ReadLine();

                    RPS userBlow = User.GenerateRPS(userInput);
                    RPS randomBlow = random.GenerateRPS();

                    Console.WriteLine($"{User.Name}: {userBlow}");
                    Console.WriteLine($"{random.Name}: {randomBlow}");

                    if (userBlow == randomBlow)
                    {
                        Console.WriteLine("It's a draw!");
                        draws++;
                    }

                    else if (userBlow == RPS.paper & randomBlow == RPS.rock || userBlow == RPS.rock & randomBlow == RPS.scissors || userBlow == RPS.scissors & randomBlow == RPS.paper)
                    {
                        Console.WriteLine("You have defeated Medusa!");
                        wins++;
                    }

                    else if (randomBlow == RPS.paper & userBlow == RPS.rock || randomBlow == RPS.rock & userBlow == RPS.scissors || randomBlow == RPS.scissors & userBlow == RPS.paper)
                    {
                        Console.WriteLine("Medusa has turned you to stone!");
                        loses++;
                    }

                    Console.WriteLine($"Wins: {wins} Loses: {loses} Draws: {draws}");
                }
            }
        }
    }
}
