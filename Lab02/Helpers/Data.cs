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

        public GenericList<TeamModel> teamList = new GenericList<TeamModel>
        {
          new TeamModel
          {
              Coach = "Emilio",
              CreationDate = 123,
              id = 1234,
              League = "bronce",
              TeamName = "Gatos",

          }
        };

        public GenericList<PlayerModel> playerList = new GenericList<PlayerModel>
        {
            
        };
   }

    
}
