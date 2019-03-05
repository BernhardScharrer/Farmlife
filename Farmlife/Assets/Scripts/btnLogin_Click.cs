using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using System;


public class btnLogin_Click : MonoBehaviour
{
    public Button btnLogin;

    public InputField txtUsername;
    public InputField txtPassword;

    

    // Start is called before the first frame update
    void Start()
    {

        //	-----------------------------------------------
        //	Add listener for Login button
        //	-----------------------------------------------
        Debug.Log("Adding listener for login button ...");

        btnLogin.onClick.AddListener(btnLogin_OnClick);

        Debug.Log("Added listener for login button!");
    }



    // Update is called once per frame
    void Update()
    {

    }
    


    void btnLogin_OnClick()
    {
        Message login = new Message(txtUsername.text, txtPassword.text);
        
        Debug.Log("Posting login data to server ...");
        string responseString = ServerComm.Get(login);
        Debug.Log("Done posting login data to server!");

        Auth response = JsonUtility.FromJson<Auth>(responseString);

        if (response.auth)
        {
            Debug.Log("Loading new scene ...");

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
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