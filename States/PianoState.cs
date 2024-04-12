using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class PianoState : MonoBehaviour
    {

        [SerializeField] private GameObject _heartAndSoul;
        [SerializeField] private GameObject _blankSheet;

        [SerializeField] private CaveSaveSettings _saveManager;
        private string pianoState;


        // Start is called before the first frame update
        void Start()
        {
            _saveManager.LoadGame();
            SetUpState();

        }

        public void StopPlaying()
        {
            // _audioSource.Stop();
        }

        // public void ChangeStateDebug(string newState)
        // {
        //     currentState = newState;
        //     SetUpState();
        // }

        public void SetUpState()
        {
            pianoState = _saveManager.so.stateOfPiano;

            if (pianoState == "heartandsoul")
            {
                Debug.Log("heartandsoul");
                _heartAndSoul.SetActive(true);
                _blankSheet.SetActive(false);

            }

            else
            {


            }

        }


    }
}
