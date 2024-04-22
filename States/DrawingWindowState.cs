using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingWindowState : MonoBehaviour
{
    [SerializeField] private GameObject drawingManager;
    [SerializeField] private GameObject armsDrawingObject;
    private CaveSaveSettings _saveManager;
    private string stateOfExterior;
    [SerializeField] private GameObject _mazeSetup;
    [SerializeField] private GameObject _citySetup;
    // Start is called before the first frame update
    void Start()
    {
        _saveManager = FindObjectOfType<CaveSaveSettings>();
        SetUpState();

    }

    // Update is called once per frame
    void Update()
    {
        if (_saveManager.so.stateOfWindowDrawing == "hasArms")
        {
            drawingManager.SetActive(false);
            armsDrawingObject.SetActive(true);
        }
        else
        {
            drawingManager.SetActive(true);
            armsDrawingObject.SetActive(false);
        }

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
