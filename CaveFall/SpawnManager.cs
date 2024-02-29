using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] _items;
    private SwitchScene _switchScene;
    [SerializeField] private float timeToWait;

    [SerializeField] private float xMin = -5f;

    [SerializeField]
    private float xMax = 2.5f;
    [SerializeField] private float yMax = -5f;
    [SerializeField] private float zPos = 100;

    void Start()
    {
        _switchScene = GameObject.Find("SceneSwitcher").GetComponent<SwitchScene>();
        StartCoroutine("SpawnRoutine");

    }

    void Update()
    {

    }


    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(timeToWait);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(xMin, xMax), yMax, zPos);
            GameObject newPowerUp = Instantiate(_items[Random.Range(0, _items.Length)], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }

    public void StopSpawning()
    {
        _stopSpawning = true;


    }

    public void OnPlayerLand()
    {
        _stopSpawning = true;


    }


    public void FinishGame()
    {
        _switchScene.Finish();

    }


}
