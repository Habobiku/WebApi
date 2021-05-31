using System;
namespace Bot.Database
{
    public class FavoriteDB
    {


        public string User { get; set; }
        //----------------------Player----------------------//

        public string NamePlayer { get; set; }
        public string idPlayer { get; set; }
        public string image_urlPlayer { get; set; }
        //----------------------Teams----------------------//
        public string NameTeam { get; set; }
        public string idTeam { get; set; }
        public string image_urlTeam { get; set; }
        //----------------------hero----------------------//
        public string NameHero { get; set; }
        public string Localized_name { get; set; }
        public string image_urlHero { get; set; }
        //----------------------tournamet----------------------//



    }
}
