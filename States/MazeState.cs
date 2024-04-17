using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MazeState : MonoBehaviour
{
    [SerializeField] private Transform pianoPos;
    [SerializeField] private Transform porchPos;

    private string currentStateOfMaze;
    [SerializeField] private Transform player;
    [SerializeField] private CaveSaveSettings saveManager;
    [SerializeField] private UnityEvent onPorch;
    [SerializeField] private UnityEvent onPiano;



    // Start is called before the first frame update
    void Start()
    {

        currentStateOfMaze = saveManager.so.stateOfMaze;

        if (currentStateOfMaze == "enterfromhouse")
        {
            player.position = new Vector2(porchPos.position.x, porchPos.position.y);
            onPorch.Invoke();

        }

        else if (currentStateOfMaze == "returnfrompiano")
        {
            // player.position = new Vector2(pianoPos.position.x, pianoPos.position.y);
            onPiano.Invoke();


        }



    }


}
