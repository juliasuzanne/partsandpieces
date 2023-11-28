using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private bool _stopSpawning = false;

    [SerializeField]
    private GameObject[] _items;
    private SwitchScene _switchScene;

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
        yield return new WaitForSeconds(3f);
        while (_stopSpawning == false)
        {
            Vector3 posToSpawnPowerUp = new Vector3(Random.Range(-5f, 2.5f), -5, 100);
            GameObject newPowerUp = Instantiate(_items[Random.Range(0, 3)], posToSpawnPowerUp, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
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
