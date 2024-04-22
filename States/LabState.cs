using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Dialogue
{
    public class LabState : MonoBehaviour
    {
        [SerializeField] private AIConversant _conversant;
        [SerializeField] private Dialogue dialogueEntry;
        [SerializeField] private Dialogue dialogueFalling;
        [SerializeField] private string currentState;
        [SerializeField] private GameObject _mazeSetup;
        [SerializeField] private GameObject _citySetup;
        [SerializeField] private Dialogue dialogueGrowArms;
        [SerializeField] private UnityEvent onChangeArms;

        [SerializeField] private CaveSaveSettings _saveManager;
        private string stateOfExterior;


        // Start is called before the first frame update
        void Start()
        {
            stateOfExterior = _saveManager.so.exteriorLoc;
            _saveManager.LoadGame();
            currentState = _saveManager.so.stateOfLab;
            SetUpState();

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
                onChangeArms.Invoke();
                // playSongPanel.SetActive(true);
                // _heartAudioSource.clip = _heartAndSoulClip;
                // _heartAudioSource.Play();
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
