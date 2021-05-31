using System;
namespace Bot.Models
{
    public static class config
    {
        public static string apitoken { get; set; } = "{PandaApiToken}";
        
        public static string TablePlayer { get; set; } = "FavotitePlayer";
        public static string TableTeam { get; set; } = "FavoriteTeam";
        public static string TableHero { get; set; } = "FavoriteHero";
        public static string TableMatch { get; set; } = "FavoriteMatch";

        public static string adress { get; set; } = "https://api.pandascore.co/dota2/";
        public static string awskeyid { get; set; } = "{AwsKeyId}";
        public static string awskey { get; set; } = "{AwsKey}";

    }
}
    