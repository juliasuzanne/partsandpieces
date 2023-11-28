using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCaveFall : MonoBehaviour
{
    private ApplySavedColor _applySave;
    [SerializeField]
    private CaveSaveSettings _saveSettings;
    private PlayerMovement _playerMovement;
    private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _applySave = GameObject.Find("Player").GetComponent<ApplySavedColor>();
        _playerAnim = GameObject.Find("Player").GetComponent<Animator>();
        _saveSettings.LoadGame();
        _applySave.ApplyColor();
        _playerAnim.SetTrigger("Start");
        _playerAnim.SetTrigger("Fall");
        _playerMovement.MoveableTrue();
    }

    public void StartGame()
    {
        _saveSettings.LoadGame();
        _applySave.ApplyColor();
        _playerAnim.SetTrigger("Start");
        _playerAnim.SetTrigger("Fall");
        _playerMovement.MoveableTrue();
    }


    // Update is called once per frame
    void Update()
    {

    }
}
