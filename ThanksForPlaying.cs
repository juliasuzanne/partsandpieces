using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThanksForPlaying : MonoBehaviour
{
    private Text _text;
    [SerializeField]
    private CaveSaveSettings _saver;
    // Start is called before the first frame update
    void Start()
    {
        _saver.LoadGame();
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = "Thanks for playing, " + _saver.so.playerName + "!";


    }
}
