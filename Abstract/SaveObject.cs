using System.Collections.Generic;
using UnityEngine;


[System.Serializable]


public class SaveObject
{
    public bool drankFountainWater;
    public bool hasBaby;
    public bool cutOffExtraArms;
    public bool connectedTorso;
    public bool connectedLegs;
    public bool hasTicket;
    public int coinCount;
    public int enteredCoinsCount;
    public bool hasTorso;
    public string playerName;
    public int playerLevel;
    public float red;
    public float blue;
    public float green;
    public string rockName;
    public string sadThing;
    public string currentQuest;
    public float time;
    public bool rain;
    public bool heardStory;
    public float totalTime;
    public bool hasExtraArms;
    public bool didFrankenstein;
    public int[] playerSong;
    public string sandwichpath1;
    public string stateOfMeatPiano;
    public string stateOfExteriorScene;
    public List<string> stateOfExteriorSceneList = new List<string>();
    public string stateOfLab;
    public string stateOfMaze = "entry";
    public string stateOfFace;
    public string stateOfPiano;
    public string stateOfFalling;
    public bool nighttime;

    public string stateOfWindowDrawing;
    public List<string> floorboardState = new List<string>();
    public List<string> inventoryitems = new List<string>();
    public List<string> mazeitems = new List<string>();
    public float[] mazePlantStartTime;
    public List<string> windowsillitems = new List<string>();
    public List<string> storageitems = new List<string>();
    public List<string> wishes = new List<string>();
    public string exteriorLoc;
    public Color bootColor = new Color(.2f, .22f, .3f);
    public Color gloveColor = new Color(.3f, .78f, .57f);
    public Color skinColor = new Color(.65f, .52f, .4f);
    public Color skirtColor = new Color(.3f, .32f, .55f);
    public Color shirtColor = new Color(.47f, .34f, .52f);
    public Color lipColor = new Color(.77f, .51f, .68f);


}
