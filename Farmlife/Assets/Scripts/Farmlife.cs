using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Library;

public class Farmlife : MonoBehaviour
{
    public Grid map;
    public Dictionary<string, Tile> groundTiles { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Initializing ...");
        
        LoadMap();
        
        Debug.Log("Initialized");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Updated");
    }



    



    private void LoadMap()
    {
        groundTiles = Tools.LoadSprites();

        Debug.Log("Getting reference to tilemaps");
        Tilemap background = map.transform.Find("Background").gameObject.GetComponent<Tilemap>();
        Tilemap foreground = map.transform.Find("Foreground").gameObject.GetComponent<Tilemap>();


        Debug.Log("Creating position ...");

        Vector3Int position = new Vector3Int(0,0,0);

        Debug.Log("Inserting grass tile ...");

        background.SetTile(position, groundTiles["grass"]);

        position = new Vector3Int(1, 0, 0);

        background.SetTile(position, groundTiles["field"]);

        Debug.Log("Inserted grass tile!");




        Background test = new Background(background);

        string testString = JsonUtility.ToJson(test);

        Background test2 = JsonUtility.FromJson<Background>(testString);


        test2.ToTilemap(background, groundTiles);
    }
}
