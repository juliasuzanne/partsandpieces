using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    [SerializeField]
    private float _speed = 1f;
    private bool _isMoving = false;


    [SerializeField]
    private float yStart;

    [SerializeField]
    private float yStep = 2f;


    // Start is called before the first frame update
    void Update()
    {
        if (_isMoving == true)
        {
            transform.Translate(new Vector3(0, (_speed), 0) * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                _isMoving = false;
                transform.position = new Vector3(-8.16f, yStart, 0);
            }
            if (transform.position.x > 9f)
            {
                if (transform.position.y < -3.9f)
                {
                    _isMoving = false;
                    transform.position = new Vector3(-8.16f, yStart, 0);
                }
                else
                {
                    transform.position = new Vector3(-8.16f, transform.position.y - yStep, 0);
                }

            }

        }
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Debug.Log("Mouse Down on play");
        _isMoving = true;



    }
}
