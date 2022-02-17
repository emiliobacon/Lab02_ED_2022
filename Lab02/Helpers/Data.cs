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
                TeamName = "Pericos",
                CreationDate = 01102010,
                Coach = "JuanLuis",
                id = 00123,
                League = "Gold"
            }
        
        };

        public GenericList<PlayerModel> playerList = new GenericList<PlayerModel>
        {
            
        };
   }

    
}
