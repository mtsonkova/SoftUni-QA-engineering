using System.Text;

namespace CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();
            string userInput = Console.ReadLine();

            while(userInput != "End")
            {
                string[] companyInfo = userInput.Split(" -> ");
                string companyName = companyInfo[0];
                string employerID = companyInfo[1];

                if(companies.ContainsKey(companyName) == false) 
                {
                    companies[companyName] = new List<string>() { employerID};
                }
                else
                {
                    if (companies[companyName].Contains(employerID) == false)
                    {
                        companies[companyName].Add(employerID);
                    }
                }

                userInput = Console.ReadLine();
            }

            foreach (KeyValuePair<string, List<string>> company in companies)
            {
                Console.WriteLine(company.Key);
                foreach (string employerIDs in company.Value)
                {
                    Console.WriteLine("-- " + employerIDs);

                }
            }
        }
    }
}