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
        public int points = 0;

        public Player(String Name)
        {
            this.name = Name;
        }
    }

    public enum Weapon { scissor, rock, paper, fire, waterbaloon };

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
            new Rule(Weapon.scissor, new List<Weapon>() { Weapon.paper, Weapon.waterbaloon } ),
            new Rule(Weapon.paper, new List<Weapon>() { Weapon.rock, Weapon.waterbaloon }),
            new Rule(Weapon.rock, new List<Weapon>() { Weapon.scissor, Weapon.waterbaloon }),
            new Rule(Weapon.fire, new List<Weapon>() { Weapon.paper, Weapon.rock, Weapon.scissor}),
            new Rule(Weapon.waterbaloon, new List<Weapon>() { Weapon.fire}),
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
        'rules' contains all rules

        Postcondition:
        Winner is found.
        */
        {
            foreach (Rule r in rules)
            {
                if (r.AttackingWeapon.Equals(Weapon1) &&
                    (r.Defeating.Contains(Weapon2)))
                    return 1;
            }

            return 2;
        }

        List<Tuple<int, int>> GenerateGameRounds(List<Player> players)
        /*

                Precondition:
                Player list generated

                Postcondition:
                List of rounds defined

                */

        {
            List<Tuple<int, int>> rounds = new List<Tuple<int, int>>();

            for (int j = 0; j < players.Count(); j++)
            {
                for (int p = 0; p < j; p++)
                {
                    rounds.Add(new Tuple<int, int>(j, p));
                }
            }
            return rounds;
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

            List<Tuple<int, int>> GameRounds = GenerateGameRounds(players);
            Console.WriteLine("Number of rounds:"+ GameRounds.Count()+"\n\n");

            for (int RoundNumber = 0; RoundNumber < GameRounds.Count(); RoundNumber++)
            {
                Console.Write("\n\n\n");

                Console.WriteLine("Round #" +(RoundNumber+1));
                String Name1 = players[GameRounds[RoundNumber].Item1].name;
                String Name2 = players[GameRounds[RoundNumber].Item2].name;


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
                    players[GameRounds[RoundNumber].Item1].points++;
                }
                if (Winner == 2)
                {
                    Console.WriteLine(Name2 + " won!");
                    players[GameRounds[RoundNumber].Item2].points++;
                }                
            }
            Console.Write("\n");

            Console.WriteLine("The game is over");

            List<Player> SortedList = players.OrderByDescending(x => x.points).ToList();
            Console.WriteLine("Highscore:");
            Console.WriteLine(("Points ").PadRight(10,' ')+"Name ");
            for (int nr = 0; nr < SortedList.Count(); nr++)
            {
                Console.WriteLine(SortedList[nr].points.ToString().PadRight(10, ' ') + SortedList[nr].name);
            }

            Console.ReadLine();
        }
    }
}
