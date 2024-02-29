using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSandwich : MonoBehaviour
{

    [SerializeField] private float yMin, xMax, xMin, step;
    private float rotateSpeed;
    private Vector2 posToMoveTowards;
    // Start is called before the first frame update
    void Start()
    {
        rotateSpeed = Random.Range(-20, 20);
        posToMoveTowards = new Vector2(Random.Range(xMax, xMin), yMin);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, posToMoveTowards, step);
        transform.Rotate(0, 0, Time.deltaTime * rotateSpeed);
        if (transform.position.y == yMin)
        {
            Destroy(this.gameObject);
        }

    }

    public void ChangeRotateSpeed(float newSpeed)
    {
        rotateSpeed = newSpeed;
    }

    public void DropItem()
    {
        posToMoveTowards = new Vector2(transform.position.x, transform.position.y);


    }

    void OnMouseDown()
    {
        Debug.Log("clicked " + transform.gameObject.name);
    }
}
