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
            
        };

        public GenericList<PlayerModel> playerList = new GenericList<PlayerModel>
        {
            
        };
   }

    
}
