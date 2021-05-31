using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Bot.Database;
using Bot.Models;
using Bot.Extension;
using Bot.Response;
using Bot.Dota2;
namespace Bot.Clients
{
    public class DynamoClient : IDynamoDBClient
    {
        public string _tableplayer;
        public string _tableteam;
        public string _tablehero;
        public string _tablematch;

        private readonly IAmazonDynamoDB _dynamoDb;
        public DynamoClient(IAmazonDynamoDB dynamoDB)
        {
            _dynamoDb = dynamoDB;
            _tableplayer = config.TablePlayer;
            _tableteam = config.TableTeam;
            _tablehero = config.TableHero;
            _tablematch = config.TableMatch;
        }
        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task<FavoriteDB> GetFavoritePlayer(string User)
        {


            var item = new GetItemRequest
            {
                TableName = _tableplayer,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User",new AttributeValue{S=User} }
                    }
            };
            var responce = await _dynamoDb.GetItemAsync(item);
            if (responce.Item == null || !responce.IsItemSet)
                return null;
            var result = responce.Item.ToClass<FavoriteDB>();
            return result;


        }
        public async Task<FavoriteDB> GetFavoriteTeam(string User)
        {


            var item = new GetItemRequest
            {
                TableName = _tableteam,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User",new AttributeValue{S=User} }
                    }
            };
            var responce = await _dynamoDb.GetItemAsync(item);
            if (responce.Item == null || !responce.IsItemSet)
                return null;
            var result = responce.Item.ToClass<FavoriteDB>();
            return result;


        }
        public async Task<FavoriteDB> GetFavoriteHero(string User)
        {


            var item = new GetItemRequest
            {
                TableName = _tablehero,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User",new AttributeValue{S=User} }
                    }
            };
            var responce = await _dynamoDb.GetItemAsync(item);
            if (responce.Item == null || !responce.IsItemSet)
                return null;
            var result = responce.Item.ToClass<FavoriteDB>();
            return result;


        }
        public async Task<MatchesResponce> GetFavoriteMatch(string User)
        {


            var item = new GetItemRequest
            {
                TableName = _tablematch,
                Key = new Dictionary<string, AttributeValue>
                    {
                        {"User",new AttributeValue{S=User} }
                    }
            };
            var responce = await _dynamoDb.GetItemAsync(item);
            if (responce.Item == null || !responce.IsItemSet)
                return null;
            var result = responce.Item.ToClass<MatchesResponce>();
            return result;


        }

        public async Task<bool> PostPlayerToOb(PlayerResponceData data)
        {
            var request = new PutItemRequest
            {
                TableName = _tableplayer,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"User", new AttributeValue{S=data.User} },
                    {"NamePlayer", new AttributeValue{S=data.Name} },
                //    {"NameTeam", new AttributeValue{S=data.NameTeam} },
                  
                 //   {"idTeam", new AttributeValue{S=data.idTeam} },
                    {"image_urlPlayer", new AttributeValue{S=data.image}},
                  //  {"image_urlTeam", new AttributeValue{S=data.image_urlTeam} },
                }
            };
            try
            {
                var responce = await _dynamoDb.PutItemAsync(request);
                return responce.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch(Exception e)
            {
                Console.WriteLine("Here is mistake"+e);
                return false;
            }

        }
        public async Task<bool> PostHeroToOb(HeroResponceData data)
        {
            var request = new PutItemRequest
            {
                TableName = _tablehero,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"User", new AttributeValue{S=data.User} },
                    {"NameHero", new AttributeValue{S=data.name} },
                //    {"NameTeam", new AttributeValue{S=data.NameTeam} },
                    {"Localized_name", new AttributeValue{S=data.localized_name} },
                 //   {"idTeam", new AttributeValue{S=data.idTeam} },
                    {"image_urlHero", new AttributeValue{S=data.image}},

                  //  {"image_urlTeam", new AttributeValue{S=data.image_urlTeam} },
                }
            };
            try
            {
                var responce = await _dynamoDb.PutItemAsync(request);
                return responce.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is mistake" + e);
                return false;
            }

        }
        public async Task<bool> PostTeamToOb(TeamsResponseData data)
        {
            var request = new PutItemRequest
            {
                TableName = _tableteam,
                Item = new Dictionary<string, AttributeValue>
                {
                    {"User", new AttributeValue{S=data.User} },
                   // {"NamePlayer", new AttributeValue{S=data.NamePlayer} },
                    {"NameTeam", new AttributeValue{S=data.Name} },
                 //   {"idPlayer", new AttributeValue{S=data.idPlayer } },
               
                    //{"image_urlPlayer", new AttributeValue{S=data.image_urlPlayer}},
                    {"image_urlTeam", new AttributeValue{S=data.image} },

                  
                }
            };
            try
            {
                var responce = await _dynamoDb.PutItemAsync(request);
                return responce.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is mistake" + e);
                return false;
            }
        }
        public async Task<bool> PostMatchToOb(MatchesResponce data)
        {
            var request = new PutItemRequest
            {
                TableName = _tablematch,
                Item = new Dictionary<string, AttributeValue>
                {

                    {"User", new AttributeValue{S=data.User} },
                   // {"NamePlayer", new AttributeValue{S=data.NamePlayer} },
                    {"Name", new AttributeValue{S=data.Name} },
                    {"Begin_at", new AttributeValue{S=data.Begin_at} },

                 //   {"idPlayer", new AttributeValue{S=data.idPlayer } },
               
                    //{"image_urlPlayer", new AttributeValue{S=data.image_urlPlayer}},
                    {"id", new AttributeValue{S=data.id} },


                }
            };
            try
            {
                var responce = await _dynamoDb.PutItemAsync(request);
                return responce.HttpStatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine("Here is mistake" + e);
                return false;
            }
        }


        public Task UpdateDataInfoDb()
        {
            throw new NotImplementedException();
        }
    }
}
