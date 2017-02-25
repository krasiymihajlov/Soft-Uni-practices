namespace _03.Football_League
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class FootballLeague
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            key = Regex.Escape(key);
            var pattern = $@"{key}(.*?){key}.+?{key}(.*?){key}.+?(\d+):(\d+)";

            var regex = new Regex(pattern);
            var result = new Dictionary<string, Team>();

            var teams = Console.ReadLine();

            while (teams != "final")
            {
                var match = regex.Match(teams);

                var firstTeam = new string(match.Groups[1].Value.Reverse().ToArray()).ToUpper();
                var secondTeam = new string(match.Groups[2].Value.Reverse().ToArray()).ToUpper();
                var firstTeamGoals = int.Parse(match.Groups[3].Value);
                var secondTeamGoals = int.Parse(match.Groups[4].Value);                  

                if (!result.ContainsKey(firstTeam))
                {
                    result[firstTeam] = new Team
                    {
                        Goals = firstTeamGoals,
                        Name = firstTeam,
                        Score = 0
                    };                   
                }
                else
                {
                    result[firstTeam].Goals += firstTeamGoals; 
                }

                if (!result.ContainsKey(secondTeam))
                {
                    result[secondTeam] = new Team
                    {
                        Goals = secondTeamGoals,
                        Name = secondTeam,
                        Score = 0
                    };
                }
                else
                {
                    result[secondTeam].Goals += secondTeamGoals;
                }

                if (firstTeamGoals > secondTeamGoals)
                {
                    result[firstTeam].Score += 3;
                }
                else if (secondTeamGoals > firstTeamGoals)
                {
                    result[secondTeam].Score += 3;
                }
                else
                {
                    result[firstTeam].Score++;
                    result[secondTeam].Score++;
                }

                teams = Console.ReadLine();
            }

            Console.WriteLine("League standings:");
            var count = 1;

            foreach (var team in result.Values
                .OrderByDescending(x => x.Score)
                .ThenBy(x => x.Name))
            {    
                Console.WriteLine($"{count}. {team.Name} {team.Score}");
                count++;
            }

            Console.WriteLine("Top 3 scored goals:");

            
            foreach (var team in result.Values
                .OrderByDescending(x => x.Goals)
                .ThenBy(x => x.Name)
                .Take(3))
            {                
                    Console.WriteLine($"- {team.Name} -> {team.Goals}");               
            }
        }

    }

    public class Team
    {
        public long Goals { get; set; }
        public long Score { get; set; }
        public string Name { get; set; }
    }
}
