using Lab02.Helpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Models
{
    public class TeamModel 
    {
        public int id { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string League { get; set; }
        public int CreationDate { get; set; }

        public static void Save(TeamModel model)
        {
            Data.Instance.teamList.InsertNew(model);
        }
        public List<TeamMembers> Members { get; set; }
    }

    public class TeamMembers
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rol { get; set; }
        public float KDA { get; set; }
        public int CreepScore { get; set; }
        public string Team { get; set; }
    }

}
