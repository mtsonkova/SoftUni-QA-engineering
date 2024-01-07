using System.Linq;
using System.Numerics;

namespace TeamProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int num = int.Parse(Console.ReadLine());

            for(int i = 0; i < num; i++)
            {
                string[] teamInfo = Console.ReadLine().Split("-");
                string creatorName = teamInfo[0];
                string teamName = teamInfo[1];
                Team team = new Team(teamName, creatorName);

                if(teams.Count == 0)
                {
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                else
                {
                    bool containsTeamName = teams.Any(team => team.name == teamName);
                    bool containsTeamCreator = teams.Any(team => team.creator == creatorName);

                    if (containsTeamName)
                    {
                        Console.WriteLine($"Team {teamName} was already created!");
                    }
                    else if (containsTeamCreator)
                    {
                        Console.WriteLine($"{creatorName} cannot create another team!");
                    }

                    else
                    {
                        teams.Add(team);
                        Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                    }                    
                }
               
            }
            string userInput = Console.ReadLine();

            while(userInput != "end of assignment")
            {
                string[] teamInfo = userInput.Split("->");
                string member = teamInfo[0];
                string teamName = teamInfo[1];

                bool containsTeamName = teams.Any(team => team.name == teamName);
                bool containsMember = teams.Any(team => team.members.Contains(member));

                if(containsTeamName == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                } 
                else if(containsMember) 
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                   Team currentTeam = teams.Find(team => team.name == teamName);
                    currentTeam.members.Add(member);
                }

                userInput = Console.ReadLine();
            }

        }
    }
}