using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnMapEditor_Click : MonoBehaviour
{
    public Button btnMapEditor;

    // Start is called before the first frame update
    void Start()
    {
        //	-----------------------------------------------
        //	Add listener for Login button
        //	-----------------------------------------------
        Debug.Log("Adding listener for login button ...");

        btnMapEditor.onClick.AddListener(btnMapEditor_OnClick);

        Debug.Log("Added listener for login button!");
    }
    
    void btnMapEditor_OnClick()
    {
        Debug.Log("Loading new scene ...");

        SceneManager.LoadScene("MapEditor", LoadSceneMode.Single);
    }
}
