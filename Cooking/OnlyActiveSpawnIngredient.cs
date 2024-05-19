using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyActiveSpawnIngredient : MonoBehaviour
{
    public float pickup_distance;
    [SerializeField] private SpawnIngredient _spawnIngredient;
    public bool debug;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _spawnIngredient = GetComponent<SpawnIngredient>();
        _spawnIngredient.enabled = false;
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
            _spawnIngredient.enabled = true;
        }
        else
        {
            _spawnIngredient.enabled = false;

        }

    }



}


