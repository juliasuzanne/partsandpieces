using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayer : MonoBehaviour
{
    private Animator _animator;
    [SerializeField]
    private GameObject startingDialogPanel;
    private HangingDialogue _hangingDialogue;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GameObject.Find("Player").GetComponent<Animator>();
        startingDialogPanel.SetActive(false);

        _hangingDialogue = startingDialogPanel.GetComponent<HangingDialogue>();
    }
    void OnMouseDown()
    {
        _animator.SetTrigger("Start");

        startingDialogPanel.SetActive(true);
        _hangingDialogue.StartTalking();


    }
}
