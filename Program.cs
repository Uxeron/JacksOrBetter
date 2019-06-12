using System;
using System.Text;

namespace JacksOrBetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var game = new Game();
            do
            {
                game.Run();
                Console.WriteLine("Press SPACE to play again");
            } while (Console.ReadKey().KeyChar == ' ');
        }
    }
}
