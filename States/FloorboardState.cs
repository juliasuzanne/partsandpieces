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
    [SerializeField] private GameObject spinachCandy;
    [SerializeField] private GameObject babyCoin;
    [SerializeField] private GameObject strawBerryCandy;
    [SerializeField] private GameObject babyKey;
    [SerializeField] private GameObject babyBaby;

    [SerializeField] private GameObject babyButterscotch;
    [SerializeField] private GameObject babyPaint;





    void Start()
    {
        spinachCandy.SetActive(!saveSettings.so.floorboardState.Contains("spinachCandy"));
        strawBerryCandy.SetActive(!saveSettings.so.floorboardState.Contains("strawberryCandy"));
        pickaxe.SetActive(!saveSettings.so.floorboardState.Contains("pickaxe"));


        if (saveSettings.so.floorboardState.Contains("baby"))
        {
            babyButterscotch.SetActive(!saveSettings.so.floorboardState.Contains("babyBaby"));
            babyFloorboards.SetActive(false);
            babyFloorboardsCollider.SetActive(!saveSettings.so.floorboardState.Contains("babyBaby"));
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
            babyCoin.SetActive(!saveSettings.so.floorboardState.Contains("babyCoin"));

        }
        else
        {
            flashlightFloorboards.SetActive(true);
            flashlightFloorboardsCollider.SetActive(false);

        }
        if (saveSettings.so.floorboardState.Contains("key"))
        {
            babyKey.SetActive(!saveSettings.so.floorboardState.Contains("babyKey"));
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
            babyButterscotch.SetActive(!saveSettings.so.floorboardState.Contains("babyButterscotch"));
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
            babyPaint.SetActive(!saveSettings.so.floorboardState.Contains("babyPaint"));
            butterFloorboards.SetActive(false);
            butterFloorboardsCollider.SetActive(true);

        }
        else
        {
            butterFloorboards.SetActive(true);
            butterFloorboardsCollider.SetActive(false);

        }


    }

    public void AddFloorBoardState(string newState)
    {
        saveSettings.so.floorboardState.Add(newState);
        saveSettings.SaveGame();
    }

}
