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
        [SerializeField] private GameObject pianoCollider;



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




            currentStateOfMaze = saveManager.so.stateOfMaze;

            if (currentStateOfMaze == "enterfromhouse" || currentStateOfMaze == "entry")
            {
                player.position = new Vector2(porchPos.position.x, porchPos.position.y);
                onPorch.Invoke();
                _torsoIdleMovement.IdlingTrue();

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
                saveManager.ChangeMazeState("piano");
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

            }

            else if (currentStateOfMaze == "gottorso")
            {
                player.position = new Vector2(porchPos.position.x, porchPos.position.y);
                onPorch.Invoke();
                torso.SetActive(false);

            }



            thisPerson.SetActive(sceneList.Contains("thisPerson"));
            pianoCollider.SetActive(sceneList.Contains("thisPerson"));


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