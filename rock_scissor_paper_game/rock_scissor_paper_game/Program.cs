using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissor_paper_game
{
    public enum HandType { scissor, rock, paper, fire, waterbaloon };

    public class Weapon
    {
        public HandType weapon;
        public List<HandType> defeats;

        public Weapon(HandType weapon, List<HandType> defeats)
        {
            this.weapon = weapon;
            this.defeats = defeats;
        }
    }

    public class Player
    {
        public String name;
        public HandType value;

        public Player(String Name)
        {
            this.name = Name;
        }

        public void enterValue()
        {
            Console.WriteLine("Choose " + this.name + " value:");

            int nr = 0;
            var values = Enum.GetValues(typeof(HandType));
            foreach (HandType weapon in values)
            {
                nr++;
                Console.WriteLine(nr + ")" + weapon.ToString());
            }
            int sel = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            this.value = (HandType) (values.GetValue(sel - 1));
            
        }

    }

    class Program
    {
        /*
        List<Weapon> defaultRules = new List<Weapon>()
        {
            new Weapon(HandType.scissor, new List<HandType>() { HandType.paper } ),
            new Weapon(HandType.paper, new List<HandType>() { HandType.rock }),
            new Weapon(HandType.rock, new List<HandType>() { HandType.scissor } )
        };
        */
        List<Weapon> defaultRules = new List<Weapon>()
        {
            new Weapon(HandType.scissor, new List<HandType>() { HandType.paper, HandType.waterbaloon } ),
            new Weapon(HandType.paper, new List<HandType>() { HandType.rock, HandType.waterbaloon }),
            new Weapon(HandType.rock, new List<HandType>() { HandType.scissor, HandType.waterbaloon }),
            new Weapon(HandType.fire, new List<HandType>() { HandType.paper, HandType.rock, HandType.scissor}),
            new Weapon(HandType.waterbaloon, new List<HandType>() { HandType.fire}),
        };


        public String findWinner(Player player1, Player player2, List<Weapon> rules)
        {
            if (player1.value.Equals(player2.value))
            {
                return "draw";
            };

            foreach (Weapon r in rules)
            {
                if (r.weapon.Equals(player1.value) &&
                    (r.defeats.Contains(player2.value)))
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

            Console.WriteLine(findWinner(player1,player2, defaultRules));

            Console.ReadLine();
        }
    }
}
