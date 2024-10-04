﻿using BoardGameGeekClient.Model;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace BoardGameGeekClient
{
    public class BoardGameGeekService
    {
        public const string BASE_URL = "https://www.boardgamegeek.com/xmlapi2";

        public async Task<GameDetails> GetGameByIdAsync(int gameId)
        {
            try
            {
                Uri teamDataURI = new Uri(string.Format(BASE_URL + "/thing?id={0}&stats=1", gameId));
                XDocument xDoc = await ReadData(teamDataURI);

                // LINQ to XML.
                IEnumerable<GameDetails> gameCollection = from Boardgame in xDoc.Descendants("items")
                                                            select new GameDetails
                                                            {
                                                                Name = (from p in Boardgame.Element("item").Elements("name") where p.Attribute("type").Value == "primary" select p.Attribute("value").Value).SingleOrDefault(),
                                                                GameId = int.Parse(Boardgame.Element("item").Attribute("id").Value),
                                                                Artists = (from p in Boardgame.Element("item").Elements("link") where p.Attribute("type").Value == "boardgameartist" select p.Attribute("value").Value).ToList(),
                                                                //AverageRating = double.Parse(Boardgame.Element("item").Element("statistics").Element("ratings").Element("average").Attribute("value").Value),
                                                                //BGGRating = double.Parse(Boardgame.Element("item").Element("statistics").Element("ratings").Element("bayesaverage").Attribute("value").Value),
                                                                Description = Boardgame.Element("item").Element("description").Value,
                                                                Designers = (from p in Boardgame.Element("item").Elements("link") where p.Attribute("type").Value == "boardgamedesigner" select p.Attribute("value").Value).ToList(),
                                                                Image = Boardgame.Element("item").Element("image") != null ? Boardgame.Element("item").Element("image").Value : string.Empty,
                                                                Thumbnail = Boardgame.Element("item").Element("thumbnail") != null ? Boardgame.Element("item").Element("thumbnail").Value : string.Empty,
                                                                MaxPlayers = int.Parse(Boardgame.Element("item").Element("maxplayers").Attribute("value").Value),
                                                                MinPlayers = int.Parse(Boardgame.Element("item").Element("minplayers").Attribute("value").Value),
                                                                Publishers = (from p in Boardgame.Element("item").Elements("link") where p.Attribute("type").Value == "boardgamepublisher" select p.Attribute("value").Value).ToList(),
                                                                YearPublished = int.Parse(Boardgame.Element("item").Element("yearpublished").Attribute("value").Value)
                                                            };

                return gameCollection.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
                //return null;
            }
        }

        public async Task<IEnumerable<Game>> GetGameByNameAsync(string gameName)
        {
            try
            {
                Uri teamDataURI = new Uri(string.Format(BASE_URL + "/search?query={0}&type=boardgame", gameName));
                XDocument xDoc = await ReadData(teamDataURI);

                // LINQ to XML.
                IEnumerable<Game> games = from Boardgame in xDoc.Descendants("item")
                                                           select new Game
                                                           {
                                                               Name = (from p in Boardgame.Elements("name") where p.Attribute("type").Value == "primary" select p.Attribute("value").Value).SingleOrDefault(),
                                                               GameId = int.Parse(Boardgame.Attribute("id").Value),
                                                               YearPublished = int.Parse(Boardgame.Element("yearpublished").Attribute("value").Value)
                                                           };
                
                return games;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Game>> GetHotGameAsync()
        {
            try
            {
                Uri teamDataURI = new Uri(BASE_URL + "/hot?thing=boardgame");
                XDocument xDoc = await ReadData(teamDataURI);

                // LINQ to XML.
                IEnumerable<Game> games = from Boardgame in xDoc.Descendants("item")
                                             select new Game
                                             {
                                                 Name = Boardgame.Element("name").Attribute("value").Value,
                                                 YearPublished = Boardgame.Element("yearpublished") != null ? int.Parse(Boardgame.Element("yearpublished").Attribute("value").Value) : 0,
                                                 Thumbnail = Boardgame.Element("thumbnail").Attribute("value").Value,
                                                 GameId = int.Parse(Boardgame.Attribute("id").Value),
                                                 Rank = int.Parse(Boardgame.Attribute("rank").Value)
                                             };

                return games;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<XDocument> ReadData(Uri requestUrl)
        {
            Debug.WriteLine("Downloading " + requestUrl.ToString());

            XDocument data = null;
            int retries = 0;
            while (data == null && retries < 60)
            {
                retries++;
                var request = WebRequest.CreateHttp(requestUrl);
                request.Timeout = 15000;
                using (var response = (HttpWebResponse)(await request.GetResponseAsync()))
                {
                    if (response.StatusCode == HttpStatusCode.Accepted)
                    {
                        await Task.Delay(500);
                        continue;
                    }
                    using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        data = XDocument.Parse(await reader.ReadToEndAsync());
                    }
                }
            }

            if (data != null)
            {
                return data;
            }
            else
            {
                throw new Exception("Failed to download BGG data.");
            }
        }
    }
}