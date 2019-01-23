using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GameEngine;
using Newtonsoft.Json;


namespace HackermanLudoApi.Models
{
    static public class GamSesssion
    {
        static public List<LudoEngine> GameList = new List<LudoEngine>();



        static public void SaveGame(LudoEngine gameToSave)
        {
            bool found = false;
            LoadGame();
            for (int i = 0; i < GameList.Count && !found; i++)
            {
                if (GameList[i].GameName == gameToSave.GameName)
                {
                    GameList.RemoveAt(i);
                    found = true;
                }
            }
            GameList.Add(gameToSave);
            var json = JsonConvert.SerializeObject(GameList.ToArray());
            File.WriteAllText(@"c:/test/ludo.json", json);
        }

        static public List<LudoEngine> LoadGame()
        {
            if (File.Exists(@"c:/test/ludo.json"))
            {
                using (var r = new StreamReader(@"c:/test/ludo.json"))
                {
                    var json = r.ReadToEnd();
                    var list = JsonConvert.DeserializeObject<List<LudoEngine>>(json);
                    GameList = list;
                }
            }
            return GameList;
        }


    }
}
