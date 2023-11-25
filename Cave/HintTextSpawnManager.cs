using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTextSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject textObjectPrefab;
    private Transform _player;
    private bool _keepInstantiating = false;
    private bool _continue = true;
    private Transform _targetPos;
    [SerializeField]
    private float _secondsBetweenSpawn = 1f;
    void Start()
    {
        _player = GameObject.Find("Player").transform;
        _targetPos = gameObject.transform.GetChild(0).transform;
    }

    void Update()
    {
        if (_keepInstantiating == true)
        {
            _keepInstantiating = false;
            StartCoroutine("CreateText");
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER COLLISION");
            _keepInstantiating = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER EXIT");
            _continue = false;
        }
    }

    IEnumerator CreateText()
    {
        _keepInstantiating = false;
        Debug.Log("INSTANTIATE");
        Instantiate(textObjectPrefab, new Vector3(_targetPos.position.x, _targetPos.position.y, 0f), Quaternion.Euler(0f, 0f, Random.Range(-30f, 30f)));
        yield return new WaitForSeconds(_secondsBetweenSpawn);
        if (_continue == true)
        {
            _keepInstantiating = true;
        }

    }
}
