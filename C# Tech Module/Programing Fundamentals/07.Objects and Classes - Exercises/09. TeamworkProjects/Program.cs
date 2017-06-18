namespace _09.TeamworkProjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ObjectAndClassesExer
    {
        public static void Main()
        {
            int teamNumber = int.Parse(Console.ReadLine());            
            var project = new List<Teams>();
            var massages = new List<string>();

            for (int i = 0; i < teamNumber; i++)
            {
                var teamRegistar = Console.ReadLine().Split('-');
                if (teamRegistar.Length < 2)
                {
                    teamRegistar = Console.ReadLine().Split('-');
                    i--;
                    continue;
                }

                var creator = teamRegistar[0];
                var teamName = teamRegistar[1];

                if (project.Any(x => x.TeamName == teamName))
                {
                    massages.Add($"Team {teamName} was already created!");
                    continue;
                }
                else if (project.Any(y => y.Creator == creator))
                {
                    massages.Add($"{creator} cannot create another team!");
                }
                else
                {
                    var currentTeams = new Teams
                    {
                        Creator = creator,
                        Members = new List<string>(),
                        TeamName = teamName
                    };

                    project.Add(currentTeams);
                    massages.Add($"Team {teamName} has been created by {creator}!");
                }
            }

            var membersLine = Console.ReadLine();

            while (membersLine != "end of assignment")
            {
                var sepMember = membersLine.Split(
                    new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                if (sepMember.Length < 2)
                {
                    membersLine = Console.ReadLine();
                    continue;
                }

                var member = sepMember[0];
                var teamName = sepMember[1];

                if (!project.Any(x => x.TeamName == teamName))
                {
                    massages.Add($"Team {teamName} does not exist!");
                }
                else
                {
                    var currentTeam = project.Where(x => x.TeamName == teamName).First();

                    if (project.Exists(x => x.Creator == member) ||
                        project.Select(y => y.Members).Any(x => x.Contains(member)))
                    {
                        massages.Add($"Member {member} cannot join team {teamName}!");
                    }
                    else
                    {
                        currentTeam.Members.Add(member);
                    }
                }

                membersLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, massages));

            var teamMembers = project
                .OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .Where(x => x.Members.Count > 0)
                .ToList();

            foreach (var team in teamMembers)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");

                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            var teamDisband = project
                .OrderBy(x => x.TeamName)                
                .Where(x => x.Members.Count == 0)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (var disband in teamDisband)
            {                
                Console.WriteLine($"{disband.TeamName}");
            }

        }
    }

    public class Teams
    {
        public List<string> Members { get; set; }
        public string TeamName { get; set; }
        public string Creator { get; set; }
    }
}
