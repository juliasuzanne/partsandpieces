using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Dialogue
{
    public class LabState : MonoBehaviour
    {
        [SerializeField] private AIConversant _conversant;
        [SerializeField] private AIConversant _torsoConversant;
        [SerializeField] private Dialogue dialogueTorsoFrankenstein;
        [SerializeField] private Dialogue dialogueTorsoGrowArms;
        [SerializeField] private Dialogue dialogueTorsoFirst;
        [SerializeField] private Dialogue dialogueTorsoSecond;
        [SerializeField] private Dialogue dialogueMentorHasArms;
        [SerializeField] private Dialogue dialogueTorsoHasArms;

        [SerializeField] private Dialogue dialogueFrankenstein;

        [SerializeField] private Dialogue dialogueEntry;
        [SerializeField] private Dialogue dialogueFalling;
        [SerializeField] private string currentState;
        [SerializeField] private GameObject _mazeSetup;
        [SerializeField] private GameObject _citySetup;
        [SerializeField] private Dialogue dialogueGrowArms;
        [SerializeField] private Dialogue dialogueMentorAttachTorso;
        [SerializeField] private GameObject torsoHead;
        [SerializeField] private GameObject sleepingHead;

        [SerializeField] private UnityEvent onChangeArms;
        [SerializeField] private UnityEvent onThisPerson;


        [SerializeField] private CaveSaveSettings _saveManager;
        private string stateOfExterior;


        // Start is called before the first frame update
        void Start()
        {
            stateOfExterior = _saveManager.so.exteriorLoc;
            _saveManager.LoadGame();
            currentState = _saveManager.so.stateOfLab;
            SetUpState();

            if (_saveManager.so.connectedTorso == true && _saveManager.so.connectedLegs == false)
            {
                torsoHead.SetActive(true);
                sleepingHead.SetActive(false);
            }
            if (_saveManager.so.connectedTorso == false && _saveManager.so.connectedLegs == false)
            {
                torsoHead.SetActive(false);
                sleepingHead.SetActive(true);

            }

        }

        public void StopPlaying()
        {
            // _audioSource.Stop();
        }

        public void ChangeStateDebug(string newState)
        {
            currentState = newState;
            SetUpState();
        }

        void SetUpState()
        {
            if (currentState == "entry")
            {
                _conversant.ChangeDialogue(dialogueEntry);
                // playCustomSongPanel.SetActive(true);
                // songPlayer.SwitchToPlayerSong();
                // songPlayer.MakeSongActive();
            }
            else if (currentState == "falling")
            {
                _conversant.ChangeDialogue(dialogueFalling);
                // playSongPanel.SetActive(true);
                // _heartAudioSource.clip = _heartAndSoulClip;
                // _heartAudioSource.Play();
            }
            else if (currentState == "growArms")
            {

                _conversant.ChangeDialogue(dialogueGrowArms);
                _torsoConversant.ChangeDialogue(dialogueTorsoGrowArms);
                onChangeArms.Invoke();
                _saveManager.ChangeStateOfLab("grewArms");


                // playSongPanel.SetActive(true);
                // _heartAudioSource.clip = _heartAndSoulClip;
                // _heartAudioSource.Play();
            }
            else if (currentState == "AttachedTorso")
            {
                torsoHead.SetActive(true);
                sleepingHead.SetActive(false);
                _conversant.ChangeDialogue(dialogueMentorAttachTorso);
                _torsoConversant.ChangeDialogue(dialogueTorsoFirst);
                _torsoConversant.StartConversation();
                _saveManager.so.stateOfLab = "AttachedTorsoReturn";
                _saveManager.SaveGame();
            }

            else if (currentState == "AttachedTorsoReturn")
            {
                torsoHead.SetActive(true);
                sleepingHead.SetActive(false);
                _conversant.ChangeDialogue(dialogueMentorAttachTorso);
                _torsoConversant.ChangeDialogue(dialogueTorsoSecond);
            }

            else if (currentState == "justGotLegs")
            {
                _conversant.ChangeDialogue(dialogueFrankenstein);
                _torsoConversant.ChangeDialogue(dialogueTorsoFrankenstein);
                onThisPerson.Invoke();

            }

            else if (currentState == "grewArms")
            {
                if (_saveManager.so.cutOffExtraArms == false)
                {
                    _conversant.ChangeDialogue(dialogueGrowArms);
                    _torsoConversant.ChangeDialogue(dialogueTorsoGrowArms);
                }
                else
                {
                    _conversant.ChangeDialogue(dialogueMentorHasArms);
                    _torsoConversant.ChangeDialogue(dialogueTorsoHasArms);
                }
            }

            else
            {
                _conversant.ChangeDialogue(dialogueEntry);

            }

            if (stateOfExterior == "city")
            {
                _mazeSetup.SetActive(false);
                _citySetup.SetActive(true);

            }
            else
            {
                _mazeSetup.SetActive(true);
                _citySetup.SetActive(false);


            }

        }


    }
}
