using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Vector3 _startingPos;
    private float _speed = -3f;
    // Start is called before the first frame update
    void Start()
    {
        _startingPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Tear pos: " + transform.position);
        transform.Translate(new Vector3(0, _speed, 0) * Time.deltaTime);

        if (transform.position.y < -7.43f)
        {
            transform.position = _startingPos;
        }

    }

    public void Splashed()
    {
        _speed = 0;
        StartCoroutine("SplashTear");
    }

    IEnumerator SplashTear()
    {
        yield return new WaitForSeconds(0.53f);
        transform.position = _startingPos;
        _speed = -3f;
    }
}
