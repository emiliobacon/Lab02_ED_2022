using Lab02.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Models
{
    public class PlayerModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Rol { get; set; }
        [Required]
        public float KDA { get; set; }
        [Required]
        public int CreepScore { get; set; }
        [Required]
        public string Team { get; set; }

        public static void Save(PlayerModel model)
        {
            Data.Instance.playerList.Add(model);
        }
    }
}
