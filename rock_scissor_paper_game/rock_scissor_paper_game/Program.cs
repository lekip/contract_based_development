using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissor_paper_game
{
    public class Player
    {
        public String name;
        public String value;

        public Player(String Name)
        {
            this.name = Name;
        }

        public void enterValue()
        {
            Console.WriteLine("Choose " + this.name + " value:");
            Console.WriteLine("S) Scissors");
            Console.WriteLine("R) Rock");
            Console.WriteLine("P) Paper");
            do
            {
                this.value = Console.ReadKey(true).KeyChar.ToString().ToUpper();
            } while (this.value != "S" &&
                    this.value != "R" &&
                    this.value != "P");
        }

        public String compare(Player oppenent)
        {

            if (this.value == "S" && oppenent.value == "R")
            {
                return ("The winner is " + oppenent.name);
            }
            else if (this.value == "R" && oppenent.value == "P")
            {
                return ("The winner is " + oppenent.name);
            }
            else if (this.value == "P" && oppenent.value == "S")
            {
                return ("The winner is " + oppenent.name);
            }

            else if (this.value == "S" && oppenent.value == "P")
            {
                return ("The winner is " + this.name);
            }
            else if (this.value == "R" && oppenent.value == "S")
            {
                return ("The winner is " + this.name);
            }
            else if (this.value == "P" && oppenent.value == "R")
            {
                return ("The winner is " + this.name);
            }
            else
            {
                return "It's a tie";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            while (true)
            {
                // Escape static 
                myProgram.run();
            }
        }

        void run()
        {
            Console.Clear();
            Player player1 = new Player("Player 1");
            player1.enterValue();
            Console.Clear();
            Console.WriteLine();
            Player player2 = new Player("Player 2");
            player2.enterValue();
            Console.Clear();
            Console.WriteLine("Value of " + player1.name + ": " + player1.value);
            Console.WriteLine("Value of " + player2.name + ": " + player2.value);

            Console.WriteLine(player1.compare(player2));

            Console.ReadLine();
        }
    }
}
