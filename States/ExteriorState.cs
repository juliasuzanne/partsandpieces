using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ExteriorState : MonoBehaviour
{
    private CaveSaveSettings _saveManager;
    [SerializeField] private GameObject EnterDoor;
    [SerializeField] private UnityEvent setAnimUnlocked;
    private List<string> sceneList = new List<string>();
    [SerializeField] private GameObject thisPerson;

    private string currentState;
    void Start()
    {
        _saveManager = FindObjectOfType<CaveSaveSettings>();
        _saveManager.LoadGame();
        currentState = _saveManager.so.stateOfExteriorScene;
        sceneList = _saveManager.so.stateOfExteriorSceneList;
        SetUpState();

    }

    void SetUpState()
    {
        if (currentState == "entry")
        {
            EnterDoor.SetActive(false);

        }
        else if (currentState == "unlocked")
        {
            EnterDoor.SetActive(true);
            setAnimUnlocked.Invoke();
        }
        thisPerson.SetActive(sceneList.Contains("thisPerson"));



    }

}
