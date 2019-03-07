using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Library
{
    private static string logFile = "Assets/log.txt";

    struct Tables
    {
        string textureTable = "";
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
        public bool auth;

        public Auth()
        {

        }
    }



    [Serializable]
    public class Map
    {
        Background background { get; set; }

        public Map()
        {

        }
    }



    [Serializable]
    public class Background
    {
        int[,] sprites;
        int xMin;
        int yMin;
        int xMax;
        int yMax;
        
        public Background()
        {

        }

        public Background(Tilemap tilemap)
        {
            BoundsInt bounds = tilemap.cellBounds;

            xMin = bounds.xMin;
            yMin = bounds.yMin;
            xMax = bounds.xMax;
            yMax = bounds.yMax;

            for (int y = 0; y < bounds.yMax; y++)
            {
                for (int x = 0; x < bounds.xMax; x++)
                {
                    Tile tile = tilemap.GetTile<Tile>(new Vector3Int(x, y, 0));

                    using (StreamWriter streamWriter = new StreamWriter(logFile))
                    {
                        streamWriter.Write("Sent: " + dataString);
                        streamWriter.Close();
                    }
                }
            }
        }
    }
}
