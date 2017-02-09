using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissor_paper_game
{
    public enum Weapon { scissor, rock, paper, fire, waterbaloon };

    public class Rule
    {
        public Weapon AttackingHand;
        public List<Weapon> Defeating;

        public Rule(Weapon weapon, List<Weapon> Defeating)
        {
            this.AttackingHand = weapon;
            this.Defeating = Defeating;
        }
    }

    public class Player
    {
        public String name;
        public Weapon weapon;

        public Player(String Name)
        {
            this.name = Name;
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
        List<Rule> defaultRules = new List<Rule>()
        {
            new Rule(Weapon.scissor, new List<Weapon>() { Weapon.paper, Weapon.waterbaloon } ),
            new Rule(Weapon.paper, new List<Weapon>() { Weapon.rock, Weapon.waterbaloon }),
            new Rule(Weapon.rock, new List<Weapon>() { Weapon.scissor, Weapon.waterbaloon }),
            new Rule(Weapon.fire, new List<Weapon>() { Weapon.paper, Weapon.rock, Weapon.scissor}),
            new Rule(Weapon.waterbaloon, new List<Weapon>() { Weapon.fire}),
        };
        
        
        public Weapon enterValue()
        /*

        Precondition:

        Postcondition:
        Weapon selected
        
        */
        {


            int nr = 0;
            var values = Enum.GetValues(typeof(Weapon));
            foreach (Weapon weapon in values)
            {
                nr++;
                Console.WriteLine(nr + ")" + weapon.ToString());
            }

            int sel = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            return (Weapon)(values.GetValue(sel - 1));
        }


        public String findWinner(Player player1, Player player2, List<Rule> rules)
        /*
        Precondition: 
        player1.value is initialized, player2.value is initialized
        'rules' contains all rules

        Postcondition:
        Winner is found.
        */
        {
            if (player1.weapon.Equals(player2.weapon))
            {
                return "draw";
            };

            foreach (Rule r in rules)
            {
                if (r.AttackingHand.Equals(player1.weapon) &&
                    (r.Defeating.Contains(player2.weapon)))
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
            Console.WriteLine("Choose " + player1.name + " value:");
            player1.weapon=enterValue();
            Console.Clear();
            Console.WriteLine();
            Player player2 = new Player("Player 2");
            Console.WriteLine("Choose " + player2.name + " value:");
            player2.weapon = enterValue();
            Console.Clear();
            Console.WriteLine("Value of " + player1.name + ": " + player1.weapon.ToString());
            Console.WriteLine("Value of " + player2.name + ": " + player2.weapon.ToString());

            Console.WriteLine(findWinner(player1,player2, defaultRules));

            Console.ReadLine();
        }
    }
}
