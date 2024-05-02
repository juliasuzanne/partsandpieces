using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MazeState : MonoBehaviour
{
    [SerializeField] private Transform pianoPos;
    [SerializeField] private Transform porchPos;
    [SerializeField] private GameObject torso;

    private string currentStateOfMaze;
    [SerializeField] private Transform player;
    [SerializeField] private CaveSaveSettings saveManager;
    [SerializeField] private UnityEvent onPorch;
    [SerializeField] private UnityEvent onPiano;
    [SerializeField] private UnityEvent onPianoSuccess;
    [SerializeField] private UnityEvent onPianoSuccessFirst;

    [SerializeField] private GrowingPlant[] poppy;
    [SerializeField] private float[] startingTime;
    [SerializeField] private float[] localStartingTime;
    [SerializeField] private GameObject thisPerson;
    private List<string> sceneList = new List<string>();






    // Start is called before the first frame update
    void Start()
    {
        // if (saveManager.so.mazePlantStartTime == null)
        // {
        //     saveManager.so.mazePlantStartTime = localStartingTime;

        // }
        // else
        // {
        //     int count = 0;
        //     foreach (float newTime in saveManager.so.mazePlantStartTime)
        //     {
        //         poppy[count].ChangeStartTime(newTime);
        //         count = count + 1;

        //     }
        // }

        sceneList = saveManager.so.stateOfExteriorSceneList;

        currentStateOfMaze = saveManager.so.stateOfMaze;

        if (currentStateOfMaze == "enterfromhouse")
        {
            player.position = new Vector2(porchPos.position.x, porchPos.position.y);
            onPorch.Invoke();

        }

        else if (currentStateOfMaze == "piano")
        {
            // player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
            onPianoSuccess.Invoke();


        }

        else if (currentStateOfMaze == "failpiano")
        {
            // player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
            onPiano.Invoke();


        }

        else if (currentStateOfMaze == "successpiano")
        {
            onPianoSuccessFirst.Invoke();
            saveManager.ChangeMazeState("piano");
        }


        thisPerson.SetActive(sceneList.Contains("thisPerson"));



    }

    public void ChangeLocalStartingTime(GrowingPlant updatedPlant)
    {
        localStartingTime[updatedPlant.GetID()] = updatedPlant.GetStartTime();
        SaveStartingTime();
    }

    public void SaveStartingTime()
    {
        saveManager.so.mazePlantStartTime = localStartingTime;
    }


}
