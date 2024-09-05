using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogue
{
    public class MoonState : MonoBehaviour
    {

        [SerializeField] private GameObject _mazeSetup;
        [SerializeField] private GameObject _citySetup;
        [SerializeField] private CaveSaveSettings _saveManager;
        private string stateOfExterior;


        // Start is called before the first frame update
        void Start()
        {
            _saveManager.LoadGame();
            SetUpState();


        }

        public void SetUpState()
        {
            stateOfExterior = _saveManager.so.exteriorLoc;

            if (stateOfExterior == "city")
            {
                Debug.Log("SET UP CITY");
                _mazeSetup.SetActive(false);
                _citySetup.SetActive(true);
            }

            else
            {
                Debug.Log("SET UP MAZE");
                _mazeSetup.SetActive(true);
                _citySetup.SetActive(false);

            }


        }


    }
}
