﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Library;

public class Editor : MonoBehaviour
{
    private Tilemap background;

    private Dictionary<string, Tile> groundTiles;

    public Grid map;


    // Start is called before the first frame update
    void Start()
    {
        groundTiles = Tools.LoadSprites();

        this.transform.parent.GetChild(3);

        Debug.Log("Getting reference to tilemaps");
        background = map.transform.Find("Background").gameObject.GetComponent<Tilemap>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ////create a ray cast and set it to the mouses cursor position in game
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;
            //if (Physics.Raycast(ray, out hit))
            //{
            //    Debug.Log("Mouse position: " + hit.point);

            //    

            //    Debug.Log("Inserting grass tile ...");

            //    

            //    
            //}

            Debug.Log("Mouse Click: [" + Input.mousePosition.x + "|" + Input.mousePosition.y + "]");

            Vector3Int tilePos = new Vector3Int(Mathf.FloorToInt(Input.mousePosition.x), Mathf.FloorToInt(Input.mousePosition.y), 0);

            Tile grass = groundTiles["grass"];

            background.SetTile(tilePos, grass);
        }
    }


    //private void OnMouseDown()
    //{
    //    Vector3 mousePos = Input.mousePosition;

    //    Debug.Log("Mouse position: " + mousePos.x + " " + mousePos.y + " " + mousePos.z);

    //}
}
