using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblesMovingUp : MonoBehaviour
{
    [SerializeField] private float yMax, yMin, xMax, xMin, speed;
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > yMax)
        {
            transform.position = new Vector2(Random.Range(xMin, xMax), yMin);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

        }

    }
}
