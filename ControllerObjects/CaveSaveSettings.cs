using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveSaveSettings : MonoBehaviour
{
    public SaveObject so;
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


}
