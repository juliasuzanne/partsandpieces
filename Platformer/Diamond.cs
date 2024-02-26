using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private PlatformerPlayer _player;
    [SerializeField]
    private int numToAdd = 2;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("PlayerPlayer").GetComponent<PlatformerPlayer>();

    }


    // ontriggerenter to collect
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            _player.AddDiamonds(numToAdd);
            Destroy(this.gameObject);
        }
        else
        {
            return;
        }
    }
    // check for the player
    // add the value of the diamond to the player
    //
}
