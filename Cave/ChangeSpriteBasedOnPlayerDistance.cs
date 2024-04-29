using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteBasedOnPlayerDistance : MonoBehaviour
{

    public float[] spritedistances;
    public bool debug;
    private SpriteRenderer _sp;
    [SerializeField] private Sprite[] sprites;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        _sp = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (debug == true)
        {
            Debug.Log("distance is " + distance + " from " + transform.name);

        }
        if (distance < spritedistances[3])
        {
            _sp.sprite = sprites[3];
        }
        else if (distance < spritedistances[2])
        {
            _sp.sprite = sprites[2];
        }
        else if (distance < spritedistances[1])
        {
            _sp.sprite = sprites[1];
        }
        else
        {
            _sp.sprite = sprites[0];
        }

    }



}




