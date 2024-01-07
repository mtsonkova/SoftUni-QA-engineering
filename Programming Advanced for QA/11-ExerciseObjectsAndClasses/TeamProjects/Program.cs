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
                    for(int j = 0; i <  teams.Count; i++)
                    {
                        if (teams[i].name == teamName)
                        {
                            Console.WriteLine($"Team {teamName} was already created!");
                            break;
                        }
                        
                        else if (teams[i].creator == creatorName)
                        {
                            Console.WriteLine($"{creatorName} cannot create another team!");
                            break;
                        }
                    }

                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
                }
            }
        }
    }
}