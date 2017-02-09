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
        public HandType AttackingHand;
        public List<HandType> DefeatingOpponents;

        public Weapon(HandType AttackingHand, List<HandType> DefeatingOpponents)
        {
            this.AttackingHand = AttackingHand;
            this.DefeatingOpponents = DefeatingOpponents;
        }
    }

    public class Player
    {
        public String name;
        public HandType playerWeapon;

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
        List<Weapon> defaultRules = new List<Weapon>()
        {
            new Weapon(HandType.scissor, new List<HandType>() { HandType.paper, HandType.waterbaloon } ),
            new Weapon(HandType.paper, new List<HandType>() { HandType.rock, HandType.waterbaloon }),
            new Weapon(HandType.rock, new List<HandType>() { HandType.scissor, HandType.waterbaloon }),
            new Weapon(HandType.fire, new List<HandType>() { HandType.paper, HandType.rock, HandType.scissor}),
            new Weapon(HandType.waterbaloon, new List<HandType>() { HandType.fire}),
        };
        
        
        public HandType enterValue()
        /*

        Precondition:

        Postcondition:
        Handtype selected
        
        */
        {


            int nr = 0;
            var values = Enum.GetValues(typeof(HandType));
            foreach (HandType weapon in values)
            {
                nr++;
                Console.WriteLine(nr + ")" + weapon.ToString());
            }

            int sel = int.Parse(Console.ReadKey(true).KeyChar.ToString());
            return (HandType)(values.GetValue(sel - 1));
        }


        public String findWinner(Player player1, Player player2, List<Weapon> rules)
        /*
        Precondition: 
        player1.value is initialized, player2.value is initialized
        'rules' contains all rules

        Postcondition:
        Winner is found.
        */
        {
            if (player1.playerWeapon.Equals(player2.playerWeapon))
            {
                return "draw";
            };

            foreach (Weapon r in rules)
            {
                if (r.AttackingHand.Equals(player1.playerWeapon) &&
                    (r.DefeatingOpponents.Contains(player2.playerWeapon)))
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
            player1.playerWeapon=enterValue();
            Console.Clear();
            Console.WriteLine();
            Player player2 = new Player("Player 2");
            Console.WriteLine("Choose " + player2.name + " value:");
            player2.playerWeapon = enterValue();
            Console.Clear();
            Console.WriteLine("Value of " + player1.name + ": " + player1.playerWeapon.ToString());
            Console.WriteLine("Value of " + player2.name + ": " + player2.playerWeapon.ToString());

            Console.WriteLine(findWinner(player1,player2, defaultRules));

            Console.ReadLine();
        }
    }
}
