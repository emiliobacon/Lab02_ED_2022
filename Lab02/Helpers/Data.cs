using Lab02.Models;
using System.Collections.Generic;
using ClassLibrary1;

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
