using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// for server communication
using System.Net.Http;
using System.Text;

public class btnLogin_Click : MonoBehaviour
{
    public Button btnLogin;

    public InputField txtUsername;
    public InputField txtPassword;

    private string postTarget = "https://fforganizer.at/farmlife/login.php";
    

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
        ServerComm.Get(postTarget);

        if (ServerComm.lastResponse == "true")
        {
            Debug.Log("Loading new scene ...");

            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }

    void btnLogin_OnClick()
    {
        string message = "{\n";
        message += "\"Username\": \"" + txtUsername.text + "\",\n";
        message += "\"Password\": \"" + txtPassword.text + "\"\n";
        message += "}";


        Debug.Log("Sending username and password to server:\n" + message);

        ServerComm.Post(postTarget, message);
    }
}
