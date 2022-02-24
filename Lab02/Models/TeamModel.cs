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
            return true;
        }
        
    }
   

}


