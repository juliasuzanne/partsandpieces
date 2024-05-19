using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Dialogue
{
    public class MazeState : MonoBehaviour
    {
        [SerializeField] private Transform pianoPos;
        [SerializeField] private Transform porchPos;
        [SerializeField] private GameObject torso;
        [SerializeField] private GameObject coin1;
        [SerializeField] private GameObject coin2;
        [SerializeField] private GameObject coin3;
        [SerializeField] private GameObject treasureSpot1;
        [SerializeField] private GameObject treasureSpot2;
        [SerializeField] private GameObject treasureSpot3;
        [SerializeField] private GameObject treasureSpot4;
        [SerializeField] private GameObject treasureSpot5;
        [SerializeField] private GameObject treasureSpot6;
        [SerializeField] private GameObject treasureSpot7;
        [SerializeField] private GameObject treasureSpot8;
        [SerializeField] private GameObject treasureSpot9;

        private string currentStateOfMaze;
        [SerializeField] private Dialogue pianoFirstSuccessNoHeard;
        [SerializeField] private Dialogue pianoFirstSuccessYesHeard;
        [SerializeField] private Dialogue pianoReturnNoHeard;
        [SerializeField] private Dialogue pianoReturnYesHeard;
        [SerializeField] private Transform player;
        [SerializeField] private AIConversant conversant;
        [SerializeField] private CaveSaveSettings saveManager;
        [SerializeField] private UnityEvent onPorch;
        [SerializeField] private UnityEvent onPiano;
        [SerializeField] private UnityEvent onPianoReturnOnly;

        [SerializeField] private UnityEvent onPianoSuccess;
        [SerializeField] private UnityEvent onPianoSuccessFirst;
        [SerializeField] private MoveTowards _torsoIdleMovement;

        [SerializeField] private GrowingPlant[] poppy;
        [SerializeField] private float[] startingTime;
        [SerializeField] private float[] localStartingTime;
        [SerializeField] private GameObject thisPerson;
        [SerializeField] private GameObject sheetMusic;



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
            coin1.SetActive(!saveManager.so.mazeitems.Contains("coin1"));
            coin2.SetActive(!saveManager.so.mazeitems.Contains("coin2"));
            coin3.SetActive(!saveManager.so.mazeitems.Contains("coin3"));

            sheetMusic.SetActive(saveManager.so.stateOfPiano == "heartandsoul");

            treasureSpot1.SetActive(!saveManager.so.mazeitems.Contains("treasure1"));
            treasureSpot2.SetActive(!saveManager.so.mazeitems.Contains("treasure2"));
            treasureSpot3.SetActive(!saveManager.so.mazeitems.Contains("treasure3"));
            treasureSpot4.SetActive(!saveManager.so.mazeitems.Contains("treasure4"));
            treasureSpot5.SetActive(!saveManager.so.mazeitems.Contains("treasure5"));
            treasureSpot6.SetActive(!saveManager.so.mazeitems.Contains("treasure6"));
            treasureSpot7.SetActive(!saveManager.so.mazeitems.Contains("treasure7"));
            treasureSpot8.SetActive(!saveManager.so.mazeitems.Contains("treasure8"));
            treasureSpot9.SetActive(!saveManager.so.mazeitems.Contains("treasure9"));




            currentStateOfMaze = saveManager.so.stateOfMaze;

            if (currentStateOfMaze == "enterfromhouse" || currentStateOfMaze == "entry")
            {
                player.position = new Vector2(porchPos.position.x, porchPos.position.y);
                onPorch.Invoke();
                if (saveManager.so.hasTorso == false && !sceneList.Contains("thisPerson") && saveManager.so.didFrankenstein == false && saveManager.so.connectedTorso == false && !(saveManager.so.stateOfLab == "AttachedTorsoReturn"))
                {
                    torso.SetActive(true);
                    _torsoIdleMovement.IdlingTrue();
                }
                else
                {
                    torso.SetActive(false);

                }

            }

            else if (currentStateOfMaze == "piano")
            {
                player.position = new Vector2(porchPos.position.x, porchPos.position.y);
                onPorch.Invoke();
                // player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
                onPianoSuccess.Invoke();
                if (saveManager.so.heardStory == true)
                {
                    conversant.ChangeDialogue(pianoReturnYesHeard);
                }
                else
                {
                    conversant.ChangeDialogue(pianoReturnNoHeard);
                }


            }

            else if (currentStateOfMaze == "failpiano")
            {
                // player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
                onPiano.Invoke();


            }

            else if (currentStateOfMaze == "successpiano")
            {
                onPianoSuccessFirst.Invoke();
                saveManager.ChangePianoState("success");
                saveManager.ChangeMazeState("piano");
                saveManager.SaveGame();
                if (saveManager.so.heardStory == true)
                {
                    conversant.ChangeDialogue(pianoFirstSuccessYesHeard);
                }
                else
                {
                    conversant.ChangeDialogue(pianoFirstSuccessNoHeard);
                }

            }

            else if (currentStateOfMaze == "returnfrompiano")
            {
                player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
                onPianoReturnOnly.Invoke();
                if (saveManager.so.hasTorso == false && !sceneList.Contains("thisPerson") && saveManager.so.connectedTorso == false && !(saveManager.so.stateOfPiano == "heartandsoul") && !saveManager.so.inventoryitems.Contains("sheet music"))
                {
                    torso.SetActive(true);
                    _torsoIdleMovement.IdlingTrue();
                }
                else
                {
                    torso.SetActive(false);

                }

            }

            else if (currentStateOfMaze == "gottorso")
            {
                player.position = new Vector2(porchPos.position.x, porchPos.position.y);
                onPorch.Invoke();
                torso.SetActive(false);

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


}