using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rock_scissor_paper_game
{

    public class Player
    {
        public String Name;
        public int Points = 0;

        public Player(String Name)
        {
            this.Name = Name;
        }
        
    }

    public enum Weapon { SCISSOR, ROCK, PAPER, FIRE, WATERBALOON };

    public class Rule
    {
        public Weapon AttackingWeapon;
        public List<Weapon> Defeating;

        public Rule(Weapon AttackingWeapon, List<Weapon> Defeating)
        {
            this.AttackingWeapon = AttackingWeapon;
            this.Defeating = Defeating;
        }
    }

    class Program
    {
        List<Rule> DefaultRules = new List<Rule>()
        {
            new Rule(Weapon.SCISSOR, new List<Weapon>() { Weapon.PAPER, Weapon.WATERBALOON } ),
            new Rule(Weapon.PAPER, new List<Weapon>() { Weapon.ROCK, Weapon.WATERBALOON }),
            new Rule(Weapon.ROCK, new List<Weapon>() { Weapon.SCISSOR, Weapon.WATERBALOON }),
            new Rule(Weapon.FIRE, new List<Weapon>() { Weapon.PAPER, Weapon.ROCK, Weapon.SCISSOR}),
            new Rule(Weapon.WATERBALOON, new List<Weapon>() { Weapon.FIRE}),
        };

        /*
        List<Rule> BoringRules = new List<Rule>()
        {
            new Weapon(Weapon.scissor, new List<Weapon>() { HandType.paper } ),
            new Weapon(Weapon.paper, new List<Weapon>() { HandType.rock }),
            new Weapon(Weapon.rock, new List<Weapon>() { HandType.scissor } )
        };
        */

        public int findWinner(Weapon Weapon1, Weapon Weapon2, List<Rule> rules)
        /*
        Precondition: 
        'Weapon1', 'Weapon2' is defined
        'rules' contains all rules for the choocen weapons

        Postcondition:
        Winner is found.
        */
        {
            if (Weapon1.Equals(Weapon2)) { throw new Exception(); }

            /*
            if (rules.Where(
                  x => x.AttackingWeapon.Equals(Weapon1))
                  .Defeating
                  .Contains(Weapon2)
                ) return 1;
            */

            foreach (Rule r in rules)
            {                
                if (r.AttackingWeapon.Equals(Weapon1) &&
                    (r.Defeating.Contains(Weapon2)))
                    return 1;
            }

            return 2;
        }

        List<Tuple<int, int>> GenerateGames(int PlayerCount)
        /*  Precondition:
            Player list contains 2 players at minimum
            Postcondition:
            List of games defined  */
        {
            List<Tuple<int, int>> games = new List<Tuple<int, int>>();

            for (int j = 0; j < PlayerCount; j++)
            {
                for (int p = 0; p < j; p++)
                {
                    games.Add(new Tuple<int, int>(j, p));
                }
            }
            return games;
        }

        public Weapon selectWeapon()
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

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            
            // Escape static 
            myProgram.run();            
        }

        void run()
        {
            Console.Clear();
            List<Player> players = new List<Player>();

            Console.WriteLine("How many players?");
            int PlayerCount = int.Parse(Console.ReadLine());

            for (int nr = 0; nr < PlayerCount; nr++)
            {
                Console.Write("\n");
                Console.WriteLine("Choose name for player #" + (nr+1));
                String Name = Console.ReadLine();
                Player player = new Player(Name);
                players.Add(player);
                
            }

            List<Tuple<int, int>> Games = GenerateGames(players.Count());
            Console.WriteLine("Number of games:"+ Games.Count()+"\n\n");

            for (int GameNumber = 0; GameNumber < Games.Count(); GameNumber++)
            {
                Console.Write("\n\n\n");
                Console.WriteLine("Game #" +(GameNumber+1));
                String Name1 = players[Games[GameNumber].Item1].Name;
                String Name2 = players[Games[GameNumber].Item2].Name;
                Console.WriteLine(Name1 +" vs "+Name2);

                Weapon Weapon1;
                Weapon Weapon2;

                do
                {
                    Console.WriteLine("Chooce weapon for "+ Name1);
                    Weapon1 = selectWeapon();
                    Console.WriteLine("Chooce weapon for " + Name2);
                    Weapon2 = selectWeapon();

                    if (Weapon1.Equals(Weapon2))
                    {
                        Console.WriteLine("Same weapon selected - please try again");
                    }
                } while (Weapon1.Equals(Weapon2));

                Console.Write("\n");
                Console.WriteLine(Name1 + " selected " + Weapon1.ToString());
                Console.WriteLine(Name2 + " selected " + Weapon2.ToString());
                
                int Winner = findWinner(Weapon1, Weapon2, DefaultRules);
                if (Winner == 1)
                {
                    Console.WriteLine(Name1 + " won!");
                    players[Games[GameNumber].Item1].Points++;
                }
                if (Winner == 2)
                {
                    Console.WriteLine(Name2 + " won!");
                    players[Games[GameNumber].Item2].Points++;
                }                
            }
            Console.Write("\n");

            Console.WriteLine("The game is over");

            List<Player> SortedList = players.OrderByDescending(x => x.Points).ToList();
            Console.WriteLine("Highscore:");
            Console.WriteLine(("Points ").PadRight(10,' ')+"Name ");
            for (int nr = 0; nr < SortedList.Count(); nr++)
            {
                Console.WriteLine(SortedList[nr].Points.ToString().PadRight(10, ' ') + SortedList[nr].Name);
            }

            Console.ReadLine();
        }
    }
}
