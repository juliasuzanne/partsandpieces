using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingWindowState : MonoBehaviour
{
    [SerializeField] private GameObject drawingManager;
    [SerializeField] private GameObject armsDrawingObject;
    private CaveSaveSettings _saveManager;
    // Start is called before the first frame update
    void Start()
    {
        _saveManager = FindObjectOfType<CaveSaveSettings>();

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
}
