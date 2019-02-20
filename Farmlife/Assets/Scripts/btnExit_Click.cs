using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class btnExit_Click : MonoBehaviour
{
    public Button btnExit;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Adding listener for exit button ...");

        btnExit.onClick.AddListener(btnExit_OnClick);

        Debug.Log("Added listener for exit button!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void btnExit_OnClick()
    {
        Debug.Log("Exiting game ...");

        if (UnityEditor.EditorApplication.isPlaying)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }
}
