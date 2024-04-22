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
    [SerializeField] private BoxCollider2D babyCollider;


    [SerializeField] private GameObject babyFloorboardsCollider;
    [SerializeField] private GameObject keyFloorboardsCollider;
    [SerializeField] private GameObject butterFloorboardsCollider;
    [SerializeField] private GameObject bearFloorboardsCollider;
    [SerializeField] private GameObject flashlightFloorboardsCollider;




    void Start()
    {
        if (saveSettings.so.floorboardState.Contains("baby"))
        {
            babyFloorboards.SetActive(false);
            babyFloorboardsCollider.SetActive(true);
            babyCollider.enabled = true;
        }
        else
        {
            babyFloorboards.SetActive(true);
            babyFloorboardsCollider.SetActive(false);
            babyCollider.enabled = false;


        }
        if (saveSettings.so.floorboardState.Contains("flashlight"))
        {
            flashlightFloorboards.SetActive(false);
            flashlightFloorboardsCollider.SetActive(true);

        }
        else
        {
            flashlightFloorboards.SetActive(true);
            flashlightFloorboardsCollider.SetActive(false);

        }
        if (saveSettings.so.floorboardState.Contains("key"))
        {
            keyFloorboards.SetActive(false);
            keyFloorboardsCollider.SetActive(true);

        }
        else
        {
            keyFloorboards.SetActive(true);
            keyFloorboardsCollider.SetActive(false);

        }
        if (saveSettings.so.floorboardState.Contains("bear"))
        {
            bearFloorboards.SetActive(false);
            bearFloorboardsCollider.SetActive(true);

        }
        else
        {
            bearFloorboards.SetActive(true);
            bearFloorboardsCollider.SetActive(false);

        }
        if (saveSettings.so.floorboardState.Contains("butterscotch"))
        {
            butterFloorboards.SetActive(false);
            butterFloorboardsCollider.SetActive(true);

        }
        else
        {
            butterFloorboards.SetActive(true);
            butterFloorboardsCollider.SetActive(false);

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
