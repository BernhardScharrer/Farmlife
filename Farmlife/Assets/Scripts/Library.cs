using System;
using System.Collections.Generic;
using UnityEngine;

namespace Library
{
    


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



        public Background()
        {

        }
    }
}
