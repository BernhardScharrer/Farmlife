using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Farmlife : MonoBehaviour
{
    public Grid map;
    private Dictionary<string, Sprite> sprites;

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
        Debug.Log("Updated");
    }



    private void LoadSprites()
    {
        Debug.Log("Loading sprites ...");

        sprites = new Dictionary<string, Sprite>();

        Debug.Log("grass");
        
        sprites.Add("grass", Resources.Load<Sprite>("Sprites/Ground/grass"));

        Debug.Log("Loaded sprites!");
    }



    private void LoadMap()
    {
        LoadSprites();

        Debug.Log("Getting reference to ground");
        Tilemap ground = map.transform.Find("Ground").gameObject.GetComponent<Tilemap>();
        //Tilemap bushes = map.transform.Find("Bushes").gameObject.GetComponent<Tilemap>();
        //Tilemap fields = map.transform.Find("Fields").gameObject.GetComponent<Tilemap>();
        //Tilemap crops = map.transform.Find("Crops").gameObject.GetComponent<Tilemap>();
        //Tilemap pavement = map.transform.Find("Pavement").gameObject.GetComponent<Tilemap>();
        //Tilemap structures = map.transform.Find("Structures").gameObject.GetComponent<Tilemap>();


        Debug.Log("Creating do");
        Tile grass = (Tile)Tile.CreateInstance("Tile");

        

        grass.sprite = sprites["grass"];

        Vector3Int position = new Vector3Int(0,0,0);

        ground.SetTile(position, grass);
    }
}
