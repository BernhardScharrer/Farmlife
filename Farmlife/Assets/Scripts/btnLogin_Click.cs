using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// for server communication
using System.Net;
using System.Net.Http;

public class btnLogin_Click : MonoBehaviour
{
    public Button btnLogin;

    public Text txtUsername;
    public Text txtPassword;

    private HttpWebRequest serverAddress;
    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Adding listener for login button ...");

        btnLogin.onClick.AddListener(btnLogin_OnClick);

        Debug.Log("Added listener for login button!");

        serverAddress = HttpWebRequest.CreateHttp("https://fforganizer.at/farmlife/login.php");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void btnLogin_OnClick()
    {
        Debug.Log("Loading new scene ...");

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);

        Debug.Log("Scene loaded!");
    }

    void sendLoginData()
    {
        
    }
}
