using System;


namespace Deliverable11
{

    class RPSApp
    {
        static void Main(string[] args)
        {
            int wins = 0;
            int loses = 0;
            int draws = 0;

            string answer = "";

            Console.WriteLine("Welcome to the Rock, Paper, Scissors Arena!");
            HumanPlayer User = new HumanPlayer();

            do
            {
                Console.Write("Do you wish to battle Medusa or the Golem (M/G)? ");

                string userFoeChoice = Console.ReadLine().ToLower();

                if (userFoeChoice == "g")
                {
                    RPS userBlow = User.GenerateRPS();
                    RockPlayer rock = new RockPlayer();

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
                    RPS userBlow = User.GenerateRPS();

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
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    answer = "y";
                }

                Console.Write("Battle again (y/n)? ");
                answer = Console.ReadLine();
                if (answer == "n")
                {
                    Console.Write("Farewell!");
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                    answer = "y";
                }

            } while (answer == "y");

        }
    }
}