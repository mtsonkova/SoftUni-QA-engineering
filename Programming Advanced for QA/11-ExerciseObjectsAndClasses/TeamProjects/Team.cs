using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjects
{
    public class Team
    {
        private string name { get; set; }
        private string creator { get; set; }
        private List<string> members { get; set; }

        public Team(string name, string creator)
        {
            this.name = name;
            this.creator = creator;
            members = new List<string>();
        }

        public string getName()
        { 
            return this.name;
        }

        public string getCreator()
        {
            return this.creator;
        }

        public List<string> getMembers()
        {
            return this.members;
        }
    }
}
