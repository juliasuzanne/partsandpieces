using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CaveSaveSettings : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    public SaveObject so;

    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();

    }



    public void SaveColor(float Red, float Green, float Blue, float Alpha)
    {
        so.red = Red;
        so.green = Green;
        so.blue = Blue;
        SaveManager.Save(so);
    }
    public void ChangeUserName(string _name)
    {
        so.playerName = _name;
    }

    public void ChangeRockName(string _rockName)
    {
        so.rockName = _rockName;
    }

    public void ThinkOfSomethingSad(string _somethingSad)
    {
        so.sadThing = _somethingSad;
    }


    public void SaveGame()
    {
        timeManager.SaveTime();
        SaveManager.Save(so);
    }


    public void SaveGameNoTime()
    {
        timeManager.Setup();
        so.time = 0f;
        so.totalTime = 0f;
        SaveManager.Save(so);
    }

    public void LoadGame()
    {
        so = SaveManager.Load();

    }

    public void ChangeQuest(string _newQuest)
    {
        so.currentQuest = _newQuest;

    }

    public void SaveSong(int[] newSongArray)
    {
        so.playerSong = newSongArray;
        SaveGame();
    }

    public int[] GetSong()
    {
        LoadGame();
        return so.playerSong;
    }

    public void SaveSandwichPath1(string newPath)
    {
        string pathToRemove = Application.dataPath + "/Resources/";
        newPath = newPath.Replace(pathToRemove, "");
        string removeExtension = ".png";
        newPath = newPath.Replace(removeExtension, "");
        so.sandwichpath1 = newPath;
        SaveGame();
    }

    public string SandwichPath1()
    {
        LoadGame();
        return so.sandwichpath1;
    }

    public void ChangeStateOfMeatPiano(string newState)
    {
        so.stateOfMeatPiano = newState;
        SaveGame();
    }

    public string GetStateOfMeatPiano()
    {
        LoadGame();
        return so.stateOfMeatPiano;
    }

    public void AddItemToWindowSill(string newItem)
    {
        if (!so.windowsillitems.Contains(newItem))
        {
            so.windowsillitems.Add(newItem);
        }
        else
        {
        }

    }


    public void RemoveItemFromWindowSill(string itemName)
    {
        so.windowsillitems.Remove(itemName);
    }

    public void SaveItemInInventory(string newItem)
    {
        so.inventoryitems.Add(newItem);
    }

    public void RemoveItemInInventory(string newItem)
    {
        so.inventoryitems.Remove(newItem);

    }

    public void ChangeExteriorLocation(string newLoc)
    {
        so.exteriorLoc = newLoc;
        SaveGame();
    }

    public void ChangeMazeState(string newState)
    {
        so.stateOfMaze = newState;
    }

    public string GetMazeState()
    {
        return so.stateOfMaze;
    }

    public void ChangeStateOfLab(string labState)
    {
        so.stateOfLab = labState;
        SaveGame();
    }


    public void ChangeFaceState(string newState)
    {
        so.stateOfFace = newState;
        SaveGame();
    }

    public void ChangePianoState(string newState)
    {
        so.stateOfPiano = newState;
        SaveGame();
    }

    public void AddWish(TMP_InputField newWish)
    {
        so.wishes.Add(newWish.text);
    }

    public void ChangeTime(float newTime)
    {
        so.time = newTime;
    }

    public void ChangeTotalTime(float newTime)
    {
        so.totalTime = newTime;
    }

    public void MakeExtraArms()
    {
        so.hasExtraArms = true;
        ChangeWindowDrawingState("hasArms");

    }

    public void RemoveExtraArms()
    {
        so.hasExtraArms = false;
        ChangeWindowDrawingState("noArms");
    }

    public void ChangeWindowDrawingState(string newState)
    {
        so.stateOfWindowDrawing = newState;
    }



    public void Reset()
    {
        so.stateOfLab = "entry";
        so.hasExtraArms = false;
        so.stateOfMaze = "entry";
        so.stateOfFace = "entry";
        so.exteriorLoc = "maze";
        so.bootColor = Color.white;
        so.lipColor = Color.white;
        so.shirtColor = Color.white;
        so.gloveColor = Color.white;
        so.skirtColor = Color.white;
        so.skinColor = Color.white;
        so.inventoryitems = new List<string>();
        so.windowsillitems = new List<string>();
        so.floorboardState = new List<string>();
        so.mazeitems = new List<string>();
        so.playerName = "Self";
        so.stateOfMeatPiano = "entry";
        SaveGameNoTime();
        LoadGame();
    }

}
