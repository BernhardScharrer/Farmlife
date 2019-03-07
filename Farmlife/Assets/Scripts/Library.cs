using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Library
{

    static class Tables
    {
        static public string textureTable = "Assets/Resources/TextureTable.txt";
    }


    [Serializable]
    public class Login
    {
        [SerializeField]
        public string username;

        [SerializeField]
        public string password;

        public Login()
        {

        }

        public Login(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }



    [Serializable]
    public class Message
    {
        [SerializeField]
        public Login login;

        public Message()
        {
            login = new Login();
        }

        public Message(string username, string password)
        {
            login = new Login(username, password);
        }

    }



    [Serializable]
    public class Auth
    {
        [SerializeField]
        public bool auth;

        public Auth()
        {

        }
    }



    [Serializable]
    public class Map
    {
        [SerializeField]
        Background background { get; set; }

        public Map()
        {

        }
    }



    [Serializable]
    public class Background
    {
        [SerializeField]
        int[,] sprites;

        [SerializeField]
        int xMin;

        [SerializeField]
        int yMin;

        [SerializeField]
        int xMax;

        [SerializeField]
        int yMax;
        
        public Background(Tilemap tilemap)
        {
            BoundsInt bounds = tilemap.cellBounds;

            xMin = bounds.xMin;
            yMin = bounds.yMin;
            xMax = bounds.xMax;
            yMax = bounds.yMax;


            //	--------------------------------------------------------
            //	Load textureTable with codes and save it to a dictionary
            //	--------------------------------------------------------
            Dictionary<string, int> textureTable = new Dictionary<string, int>();
            

            using (StreamReader streamReader = new StreamReader(Tables.textureTable))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');

                    textureTable.Add(data[0], Convert.ToInt32(data[1]));
                }

                streamReader.Close();
            }



            //	--------------------------------------------------------------------
            //	Save every tiles actual sprite as sprite number to the sprites array
            //	--------------------------------------------------------------------
            sprites = new int[xMax - xMin, yMax - yMin];


            for (int x = 0; x < xMax - xMin; x++)
            {
                for (int y = 0; y < yMax - yMin; y++)
                {
                    Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));

                    if (tile != null)
                    {
                        sprites[x, y] = textureTable[tile.name];
                    }
                    
                }
            }
        }

        public Tilemap ToTilemap(Dictionary<string, Tile> groundTiles)
        {
            //	--------------------------------------------------------
            //	Load textureTable with codes and save it to a dictionary
            //	--------------------------------------------------------
            Dictionary<int, string> textureTable = new Dictionary<int, string>();


            using (StreamReader streamReader = new StreamReader(Tables.textureTable))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] data = line.Split(' ');

                    textureTable.Add(Convert.ToInt32(data[1]), data[0]);
                }

                streamReader.Close();
            }


            Tilemap tilemap = new Tilemap();



            //	-----------------------------------------------
            //	Convert the 
            //	-----------------------------------------------
            for (int x = 0; x < xMax - xMin; x++)
            {
                for (int y = 0; y < yMax - yMin; y++)
                {
                    if (sprites[x, y] != 0)
                    {
                        string spriteName = textureTable[sprites[x, y]];

                        tilemap.SetTile(new Vector3Int(xMin + x, yMin + y, 0), groundTiles[spriteName]);
                    }

                }
            }


            return tilemap;
        }
    }
}
