using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] _items;

    void Start()
    {
        StartCoroutine("SpawnRoutine");

    }

    void Update()
    {

    }


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(2.25f, 6.75f), -9, 100);
            GameObject newPowerUp = Instantiate(_items[Random.Range(0, 3)], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

    public void OnPlayerLand()
    {
        _stopSpawning = true;
    }


}
