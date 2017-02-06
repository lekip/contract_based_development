using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissor_paper_game
{
    public enum Weapon { scissor, rock, paper };

    public class Rule
    {
        public Weapon weapon;
        public Weapon defeats;

        public Rule(Weapon weapon, Weapon defeats)
        {
            this.weapon = weapon;
            this.defeats = defeats;
        }
    }

    public class Player
    {
        public String name;
        public Weapon value;

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
            String k;
            do
            {
                k = Console.ReadKey(true).KeyChar.ToString().ToUpper();
            } while (k != "S" &&
                    k != "R" &&
                    k != "P");
            if (k == "S") { this.value = Weapon.scissor; };
            if (k == "R") { this.value = Weapon.rock; };
            if (k == "P") { this.value = Weapon.paper; };            
        }

    }

    class Program
    {
        List<Rule> rules = new List<Rule>()
        {
            new Rule(Weapon.scissor, Weapon.paper),
            new Rule(Weapon.paper, Weapon.rock),
            new Rule(Weapon.rock, Weapon.scissor)
        };


        public String findWinner(Player player1, Player player2)
        {
            if (player1.value.Equals(player2.value))
            {
                return "draw";
            };

            foreach (Rule r in rules)
            {
                if (r.weapon.Equals(player1.value) && r.defeats.Equals(player2.value))
                    return player1.name;
            }

            return player2.name;
        }

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
            Console.WriteLine("Value of " + player1.name + ": " + player1.value.ToString());
            Console.WriteLine("Value of " + player2.name + ": " + player2.value.ToString());

            Console.WriteLine(findWinner(player1,player2));

            Console.ReadLine();
        }
    }
}
