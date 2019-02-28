using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// for server communication
using Newtonsoft.Json;

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
        if (ServerComm.lastResponse != null)
        {
            Debug.Log(ServerComm.lastResponse);
        }
        

        if (ServerComm.lastResponse == "Hello World!")
        {
            Debug.Log("Loading new scene ...");

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
    
    void btnLogin_OnClick()
    {
        Login login = new Login(txtUsername.text, txtPassword.text);
        
        Debug.Log("Sending username and password to server:\n" + JsonConvert.SerializeObject(login));

        ServerComm.Post("[1,2,3]");//JsonConvert.SerializeObject(login));
    }
}
