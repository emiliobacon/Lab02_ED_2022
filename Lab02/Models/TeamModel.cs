using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Models
{
    public class TeamModel
    {
        public int id { get; }
        public string TeamName { get; }
        public string Coach { get; }
        public string League { get; }
        public int CreationDate { get; }
    }
}
