using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dads_Site.Models
{
    public class Comic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IssueNumber { get; set; }
        public string Writer { get; set; }
        public string Artist { get; set; }
        public string Publisher { get; set; }

        public Comic()
        {

        }
    }
}
