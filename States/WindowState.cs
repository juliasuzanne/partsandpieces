using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class WindowState : MonoBehaviour
    {

        [SerializeField] private GameObject _mazeSetup;
        [SerializeField] private GameObject _citySetup;
        [SerializeField] private Sprite _mazeDrawing;
        [SerializeField] private GameObject yellowPaint;
        [SerializeField] private Sprite _cityDrawing;
        [SerializeField] private SpriteRenderer sp_panel;
        [SerializeField] private SpriteRenderer sp_wall;
        private List<string> windowsillitems = new List<string>();


        [SerializeField] private CaveSaveSettings _saveManager;
        private string stateOfExterior;


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

            stateOfExterior = _saveManager.so.exteriorLoc;
            windowsillitems = _saveManager.so.windowsillitems;
            yellowPaint.SetActive(!_saveManager.so.mazeitems.Contains("yellowPaint"));

            if (stateOfExterior == "city")
            {
                Debug.Log("SET UP CITY");
                _mazeSetup.SetActive(false);
                _citySetup.SetActive(true);
                sp_wall.sprite = _cityDrawing;
                sp_panel.sprite = _cityDrawing;
            }

            else
            {
                Debug.Log("SET UP MAZE");

                _mazeSetup.SetActive(true);
                _citySetup.SetActive(false);
                sp_wall.sprite = _mazeDrawing;
                sp_panel.sprite = _mazeDrawing;


            }


        }


    }
}
