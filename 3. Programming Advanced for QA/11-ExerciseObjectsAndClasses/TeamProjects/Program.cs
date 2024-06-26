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
                    team.getMembers().Add(creatorName);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
                else
                {
                    bool containsTeamName = teams.Any(team => team.getName() == teamName);
                    bool containsTeamCreator = teams.Any(team => team.getCreator() == creatorName);

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
                        team.getMembers().Add(creatorName);
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

                bool containsTeamName = teams.Any(team => team.getName() == teamName);
                bool containsMember = false;
               
               for(int j = 0; j < teams.Count; j++)
                {
                    List<string> currentTeamMembers = teams[j].getMembers();
                    if(currentTeamMembers.Contains(member))
                    {
                        containsMember = true;
                        break;
                    }
                }

                if (containsTeamName == false)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                } 
                else if(containsMember) 
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                   Team currentTeam = teams.Find(team => team.getName() == teamName);
                    currentTeam.getMembers().Add(member);
                }

                userInput = Console.ReadLine();
            }

            List<Team> validTeams = teams.FindAll(team => team.getMembers().Count > 1);

            List<Team> teamsToDisband = teams.FindAll(team => team.getMembers().Count == 1);

            var sortedValidTeams = validTeams
                .OrderByDescending(team => team.getMembers().Count())
                .ThenBy(team => team.getName())
                .ToList();

            var sortedTeamsToDisband = teamsToDisband.OrderBy(team => team.getName()).ToList();

            List<string> validMembersList = new List<string>();
            // Print valid Teams
            
            foreach (Team team in sortedValidTeams)
            {
                Console.WriteLine(team.getName());
                Console.WriteLine($"-{team.getCreator()}");
               
               validMembersList = team.getMembers();
                
                for(int i = 1; i < validMembersList.Count; i++)
                {
                    string currentName = validMembersList[i];
                    Console.WriteLine($"--{currentName}");
                }
            }

            Console.WriteLine("Teams to disband:");
            foreach(Team invalidTeam in sortedTeamsToDisband)
            {
                Console.WriteLine(invalidTeam.getName());
            }
            
        }        
    }
}