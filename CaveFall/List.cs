using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    private bool _obj1 = false;
    private bool _obj2 = false;
    private bool _obj3 = false;

    private Inventory _inventory;
    private SpawnManager _spawnManager;
    private GravityChanger _gravityChanger;
    private Animator _playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _gravityChanger = GameObject.Find("Player").GetComponent<GravityChanger>();
        _playerAnim = GameObject.Find("Player").GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckObjs()
    {
        if (_obj1 == true && _obj2 == true && _obj3 == true)
        {
            _playerAnim.SetTrigger("Land");
            _gravityChanger.SetGravity(2f);
            _spawnManager.OnPlayerLand();
        }

    }

    public void ChangeObj1(GameObject prefab)
    {
        if (_obj1 == false)
        {
            _inventory.AddItemToInventory(prefab);
        }
        _obj1 = true;

    }

    public void ChangeObj2(GameObject prefab)
    {
        if (_obj2 == false)
        {
            _inventory.AddItemToInventory(prefab);
        }
        _obj2 = true;

    }

    public void ChangeObj3(GameObject prefab)
    {
        if (_obj3 == false)
        {
            _inventory.AddItemToInventory(prefab);
        }
        _obj3 = true;
    }
}
