using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class Tile : ScriptableObject {
    [Space]
    [Header("Tile Type")]
    public TileType type; 

    [Space]
    [Header("Description")]
    public string tileName;
    public string description;

    [Space]
    [Header("Position")]
    public int tileX;
    public int tileZ;
    
    [Header("Entry Costs")]
    public float entryCost = 1.0f;

    [Header("Map")]
    public TileMap map;

    //Movement Data
    public float getEntryCost(){
        return entryCost;
    }

}
