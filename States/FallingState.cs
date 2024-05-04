using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace Dialogue
{
    public class FallingState : MonoBehaviour
    {
        [SerializeField] private AIConversant _conversant;
        [SerializeField] private Dialogue dialogueEntry;
        [SerializeField] private Dialogue dialogueAfter;

        [SerializeField] private CaveSaveSettings _saveManager;
        private string currentState;


        // Start is called before the first frame update
        void Start()
        {
            _saveManager.LoadGame();
            currentState = _saveManager.so.stateOfFalling;

            SetUpState();

        }

        void SetUpState()
        {
            if (currentState == "entry")
            {
                _conversant.ChangeDialogue(dialogueEntry);
                _saveManager.ChangeFallingState("after");

            }
            else if (currentState == "after")
            {
                _conversant.ChangeDialogue(dialogueAfter);
                // playSongPanel.SetActive(true);
                // _heartAudioSource.clip = _heartAndSoulClip;
                // _heartAudioSource.Play();
            }



        }


    }
}
