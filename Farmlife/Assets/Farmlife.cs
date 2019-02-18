using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// for win forms
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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


        //	-----------------------------------------------
        //	create new dictionary to contain all sprites by name
        //	-----------------------------------------------
        sprites = new Dictionary<string, Sprite>();


        //	-----------------------------------------------
        //	Load the sprites
        //	-----------------------------------------------
        // grass
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


        Debug.Log("Creating grass tile ...");

        Tile grass = (Tile)Tile.CreateInstance("Tile");
        
        grass.sprite = sprites["grass"];

        Vector3Int position = new Vector3Int(0,0,0);

        Debug.Log("Inserting grass tile ...");

        ground.SetTile(position, grass);

        Debug.Log("Inserted grass tile!");
    }
}
