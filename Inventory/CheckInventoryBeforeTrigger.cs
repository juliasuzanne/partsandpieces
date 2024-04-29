using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CheckInventoryBeforeTrigger : MonoBehaviour
{
    private Inventory _inventory;
    private PlayerSpeech _playerSpeech;
    [SerializeField] private UnityEvent onTrigger;

    private int numEmptySlots;
    // Start is called before the first frame update
    void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _playerSpeech = FindObjectOfType<PlayerSpeech>();
    }

    public void Check()
    {
        numEmptySlots = _inventory.CheckEmptySlots();
        if (numEmptySlots > 2)
        {
            onTrigger.Invoke();
        }
        else
        {
            _playerSpeech.PlayerTalkingForSeconds("I need to get rid of some items before I do that.");
        }

    }


}
