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
        if (timeManager == null)
        {
            timeManager = FindObjectOfType<TimeManager>();

        }

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
    public void AddItemToStorage(string newItem)
    {
        so.storageitems.Add(newItem);
    }


    public void RemoveItemFromStorage(string itemName)
    {
        so.storageitems.Remove(itemName);
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

    public void ChangeExteriorSceneState(string newState)
    {
        so.stateOfExteriorScene = newState;
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

    public void AddItemToMaze(string newItem)
    {
        so.mazeitems.Add(newItem);
    }
    public void AddItemToExteriorScene(string newItem)
    {
        so.stateOfExteriorSceneList.Add(newItem);
    }
    public void RemoveItemFromExteriorScene(string newItem)
    {
        so.stateOfExteriorSceneList.Remove(newItem);
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
        so.stateOfLab = "growArms";
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

    public void CheckMazeStateForReEntry()
    {
        if (so.stateOfMaze == "returnfrompiano" || so.stateOfMaze == "failpiano")
        {
            so.stateOfMaze = "enterfromhouse";
        }
        else
        {

        }

    }

    public void ChangeFallingState(string newState)
    {
        so.stateOfFalling = newState;
    }

    public void RemoveCoin()
    {
        so.enteredCoinsCount = so.enteredCoinsCount + 1;
        so.coinCount = so.coinCount - 1;
    }
    public void AddCoin()
    {
        so.coinCount = so.coinCount + 1;

    }

    public void CutOffArms()
    {
        so.hasExtraArms = false;
        so.cutOffExtraArms = true;
    }

    public void UseExtraCutOffArms()
    {
        so.cutOffExtraArms = false;
        so.connectedTorso = true;
        so.didFrankenstein = true;
        SaveGame();

    }

    public void GetBaby()
    {
        so.hasBaby = true;

    }

    public void YesWaterFilter()
    {
        so.drankFountainWater = true;

    }

    public void NoWaterFilter()
    {
        so.drankFountainWater = false;

    }

    public void GetTorso()
    {
        so.hasTorso = true;
    }

    public void GetTicket()
    {
        so.hasTicket = true;
    }

    public void LoseBaby()
    {
        so.hasBaby = false;

    }

    public void UseTorso()
    {
        so.hasTorso = false;
        so.connectedTorso = true;
    }

    public void ThisPersonDidFrankenstein()
    {
        so.didFrankenstein = true;
    }

    public void HeardStory()
    {
        so.heardStory = true;
    }




    public void Reset()
    {
        so.rain = false;
        so.stateOfPiano = "entry";
        so.nighttime = false;
        so.connectedTorso = false;
        so.connectedLegs = false;
        so.cutOffExtraArms = false;
        so.hasTorso = false;
        so.hasBaby = false;
        so.hasTicket = false;
        so.heardStory = false;
        so.coinCount = 0;
        so.enteredCoinsCount = 0;
        so.drankFountainWater = false;
        so.stateOfLab = "entry";
        so.hasExtraArms = false;
        so.stateOfFalling = "entry";
        so.stateOfMaze = "entry";
        so.stateOfFace = "entry";
        so.exteriorLoc = "maze";
        so.stateOfExteriorScene = "entry";
        so.stateOfExteriorSceneList = new List<string>();
        so.stateOfWindowDrawing = "entry";
        so.shirtColor = new Color(.47f, .34f, .52f);
        so.gloveColor = new Color(.3f, .78f, .57f);
        so.skirtColor = new Color(.3f, .32f, .55f);
        so.bootColor = new Color(.2f, .22f, .3f);
        so.skinColor = new Color(.65f, .52f, .4f);
        so.lipColor = new Color(.77f, .51f, .68f);
        so.storageitems = new List<string>();
        so.inventoryitems = new List<string>();
        so.windowsillitems = new List<string>();
        so.floorboardState = new List<string>();
        so.mazeitems = new List<string>();
        so.playerName = "Self";
        so.didFrankenstein = false;
        so.stateOfMeatPiano = "entry";
        SaveGameNoTime();
        LoadGame();
    }

}
