using System.Collections.Generic;
using UnityEngine;


[System.Serializable]


public class SaveObject
{
    public string playerName;
    public int playerLevel;
    public float red;
    public float blue;
    public float green;
    public string rockName;
    public string sadThing;
    public string currentQuest;
    public int[] playerSong;
    public string sandwichpath1;
    public string stateOfMeatPiano;
    public string stateOfLab;
    public string stateOfMaze;
    public List<string> inventoryitems = new List<string>();
    public List<string> mazeitems = new List<string>();
    public string exteriorLoc;
    public Color bootColor;
    public Color gloveColor;
    public Color skinColor;
    public Color skirtColor;
    public Color shirtColor;
    public Color lipColor;


}
