using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorboardState : MonoBehaviour
{
    [SerializeField] private CaveSaveSettings saveSettings;
    [SerializeField] private GameObject babyFloorboards;
    [SerializeField] private GameObject keyFloorboards;
    [SerializeField] private GameObject butterFloorboards;
    [SerializeField] private GameObject bearFloorboards;
    [SerializeField] private GameObject flashlightFloorboards;

    [SerializeField] private GameObject pickaxe;



    void Start()
    {
        if (saveSettings.so.floorboardState.Contains("baby"))
        {
            babyFloorboards.SetActive(false);
        }
        else
        {
            babyFloorboards.SetActive(true);
        }
        if (saveSettings.so.floorboardState.Contains("flashlight"))
        {
            flashlightFloorboards.SetActive(false);
        }
        else
        {
            flashlightFloorboards.SetActive(true);
        }
        if (saveSettings.so.floorboardState.Contains("key"))
        {
            keyFloorboards.SetActive(false);
        }
        else
        {
            keyFloorboards.SetActive(true);
        }
        if (saveSettings.so.floorboardState.Contains("bear"))
        {
            bearFloorboards.SetActive(false);
        }
        else
        {
            bearFloorboards.SetActive(true);
        }
        if (saveSettings.so.floorboardState.Contains("butterscotch"))
        {
            butterFloorboards.SetActive(false);
        }
        else
        {
            butterFloorboards.SetActive(true);
        }
        if (saveSettings.so.floorboardState.Contains("pickaxe"))
        {
            pickaxe.SetActive(false);
        }
        else
        {
            pickaxe.SetActive(true);
        }

    }

    public void AddFloorBoardState(string newState)
    {
        saveSettings.so.floorboardState.Add(newState);
        saveSettings.SaveGame();
    }

}
