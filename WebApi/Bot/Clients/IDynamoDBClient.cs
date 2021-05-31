using System;
using System.Threading.Tasks;
using Bot.Database;
using Bot.Response;
using Bot.Dota2;
namespace Bot.Clients
{
    public interface IDynamoDBClient
    {
        public Task<FavoriteDB> GetFavoritePlayer(string name);
        public Task<FavoriteDB> GetFavoriteTeam(string name);
        public Task<FavoriteDB> GetFavoriteHero(string name);
        public Task<MatchesResponce> GetFavoriteMatch(string name);
        public Task<bool> PostPlayerToOb(PlayerResponceData data);
        public Task<bool> PostHeroToOb(HeroResponceData data);
        public Task<bool> PostTeamToOb(TeamsResponseData data);
        public Task<bool> PostMatchToOb(MatchesResponce data);

        public Task UpdateDataInfoDb();
        public Task Delete();
    }
}
