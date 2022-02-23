using Lab02.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Models
{
    public class TeamModel
    {
        //new update 22 02 2022 
        public int id { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        public string League { get; set; }
        public DateTime CreationDate { get; set; } //cambiar a tipo fecha 

       

        public static void Save(TeamModel model)
        {
            Data.Instance.teamList.Add(model);
        }

        public static bool Edit(int id, TeamModel model)
        {
            var position = Data.Instance.teamList.Search(teams => teams.id = id);
            Data.Instance.teamList[position] = new TeamModel
            {
                TeamName = model.TeamName,
                Coach = model.Coach,
                CreationDate = model.CreationDate,
                League = model.League
            };
            return true;
        }
        
    }
   

}


