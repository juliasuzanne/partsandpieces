using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnearthSpawner : MonoBehaviour
{
    //spawn a random item from list on click
    private Vector2 posToSpawn;
    private SpriteRenderer _sp;
    [SerializeField] private GameObject[] _items;

    void Start()
    {
        _sp = transform.GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {

        posToSpawn = new Vector2(transform.position.x + 2f, transform.position.y);
        GameObject newItem = Instantiate(_items[Random.Range(0, _items.Length)], posToSpawn, Quaternion.identity);

    }


}
