using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyActiveCookRequest : MonoBehaviour
{
    public float pickup_distance;
    [SerializeField] private int requestorId;
    [SerializeField] private CookRequest _cookRequest;
    public bool debug;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _cookRequest = GetComponent<CookRequest>();
        _cookRequest.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        requestorId = _cookRequest.GetRequestorId();

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
            _cookRequest.enabled = true;
        }
        else
        {
            _cookRequest.enabled = false;

        }

    }

    void OnMouseDown()
    {
        if (!_cookRequest.enabled)
        {
            switch (requestorId)
            {
                case 1:
                    {
                        player.GetComponent<NavMoveCooking>().SetDestinationRequest1();
                        break;
                    }
                case 2:
                    {
                        player.GetComponent<NavMoveCooking>().SetDestinationRequest2();
                        break;
                    }
            }
        }
    }



}


