using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class FaceState : MonoBehaviour
    {

        [SerializeField] private GameObject _pegbook;

        [SerializeField] private CaveSaveSettings _saveManager;
        private string stateOfFace;


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
            stateOfFace = _saveManager.so.stateOfFace;

            if (stateOfFace == "booktaken")
            {
                Destroy(_pegbook);
            }



        }


    }
}
