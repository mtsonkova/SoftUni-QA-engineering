using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProjects
{
    public class Team
    {
        public string name { get; set; }
        public string creator { get; set; }
        public List<string> members { get; set; }

        public Team(string name, string creator)
        {
            this.name = name;
            this.creator = creator;
        }
    }
}
