using Lab02.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab02.Models
{
    public class TeamModel
    {
        //new update 22 02 2022 
        [Required]
        public int id { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string Coach { get; set; }
        [Required]
        public string League { get; set; }
        [Required]
        public DateTime CreationDate { get; set; } //cambiar a tipo fecha 

       

        public static void Save(TeamModel model)
        {
            Data.Instance.teamList.Add(model);
        }
        
    }
   

}


