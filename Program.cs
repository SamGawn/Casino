using System;

namespace Casino
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double odds = .75;
            Guy player = new Guy { Cash = 100, Name = "The Player" };

            while (player.Cash > 0)
            {
                player.WriteMyInfo();
                Console.WriteLine("How much do you want to bet: ");
                string howMuch = Console.ReadLine();
                if (howMuch == "") { return; }
                if (int.TryParse(howMuch, out int amount))
                {
                    int pot = player.GiveCash(amount) * 2;
                    if (pot > 0)
                    {
                        if (random.NextDouble() > odds)
                        {
                            int winnings = pot;
                            Console.WriteLine("You win £" + winnings);
                            player.ReceiveCash(winnings);
                        }
                        else
                        {
                            Console.WriteLine("You lost £" + (pot / 2));
                        }
                    }
                }
            }
            Console.WriteLine("House always wins");
        }
    }
}
