using Lab02.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02.Models
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Rol { get; set; }
        public float KDA { get; set; }
        public int CreepScore { get; set; }
        public string Team { get; set; }

        public static void Save(PlayerModel model)
        {
            Data.Instance.playerList.Add(model);
        }

        public static void Delete(PlayerModel model)
        {
            Data.Instance.playerList.Delete(model);
        }
    }
}
