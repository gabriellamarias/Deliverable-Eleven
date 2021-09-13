using System;
using static Deliverable11.Interface1;

namespace Deliverable11
{
   
    class Program
    {
        static void Main(string[] args)
        {
            bool userContinue = true;
            Console.WriteLine("Welcome to the Rock, Paper, Scissors Arena!");

            while (userContinue == true)
            {
                RPSApp user = new RPSApp();
                Console.Write("Battle again (y/n)? ");
                if (Console.ReadLine().ToLower() == "y")
                {
                    userContinue = true;
                }
                else if (Console.ReadLine().ToLower() == "n")
                {
                    userContinue = false;
                }
            }         
        }
    }
}
