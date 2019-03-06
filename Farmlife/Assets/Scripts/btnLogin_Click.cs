using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Library;


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
