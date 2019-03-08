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
        static public string textureTable = "Assets/Resources/Data/TextureTable.txt";
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
        int[][] sprites;

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
                    
                    textureTable.Add(data[1].Replace(Environment.NewLine, ""), Convert.ToInt32(data[0]));
                }

                streamReader.Close();
            }



            //	--------------------------------------------------------------------
            //	Save every tiles actual sprite as sprite number to the sprites array
            //	--------------------------------------------------------------------
            sprites = new int[xMax - xMin][];



            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i] = new int[yMax - yMin];
            }



            for (int x = 0; x < xMax - xMin; x++)
            {
                for (int y = 0; y < yMax - yMin; y++)
                {
                    Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));

                    if (tile != null)
                    {
                        sprites[x][y] = textureTable[tile.name];
                    }
                    
                }
            }
            
            Debug.Log("[0|0]: " + sprites[0][0]);
        }



        public void ToTilemap(Tilemap background, Dictionary<string, Tile> groundTiles)
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

                    textureTable.Add(Convert.ToInt32(data[0]), data[1].Replace(Environment.NewLine, ""));
                }

                streamReader.Close();
            }




            //	-----------------------------------------------
            //	Convert the 
            //	-----------------------------------------------
            for (int x = 0; x < xMax - xMin; x++)
            {
                for (int y = 0; y < yMax - yMin; y++)
                {

                    Debug.Log("x: " + x + " y: " + y);
                    Debug.Log(sprites[x][y]);

                    if (sprites[x][y] != 0)
                    {
                        string spriteName = textureTable[sprites[x][y]];
                        
                        Vector3Int position = new Vector3Int(x, y, 0);
                        
                        background.SetTile(position, groundTiles[spriteName]);
                    }

                }
            }
        }
    }
}
