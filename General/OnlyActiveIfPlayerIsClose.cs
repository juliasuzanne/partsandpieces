using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyActiveIfPlayerIsClose : MonoBehaviour
{
    public float pickup_distance;
    private BoxCollider2D boxColliderTrigger;
    private UIManager _uiManager;
    public bool debug;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        boxColliderTrigger = transform.GetComponent<BoxCollider2D>();
        boxColliderTrigger.enabled = false;
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (debug == true)
        {
            Debug.Log("distance is " + distance + " from " + transform.name);

        }
        if (distance < pickup_distance)
        {
            boxColliderTrigger.enabled = true;
        }
        else
        {
            boxColliderTrigger.enabled = false;

        }

    }



}


