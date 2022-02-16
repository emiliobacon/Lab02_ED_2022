using Lab02.Models;
using System.Collections.Generic;

namespace Lab02.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

        public List<TeamModel> TeamList = new List<TeamModel>
        {
            new TeamModel
            {
                id = 2970,
                TeamName = "Los Castrosos",
                Coach = "Don Cangreso",
                League = "Gold",
                CreationDate = 10122020,

            }

         };

        public List<PlayerModel> PlayerList = new List<PlayerModel>
        {
            new PlayerModel
            {
                Name = "Juan",
                LastName = "Perez",
                KDA = 12, 
                CreepScore = 500, 
                Rol = "Tanque",
                Team = "Los Castrosos",
            }
        };
    }
}
