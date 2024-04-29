using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveStartingPos : MonoBehaviour
{
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    public void ReturnToStartingPos()
    {
        transform.position = new Vector3(startingPos.x, startingPos.y, 0f);

    }
}
