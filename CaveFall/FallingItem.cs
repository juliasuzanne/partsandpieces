using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingItem : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private List _list;
    private ChangeSprite powerup1;
    private ChangeSprite powerup2;
    private ChangeSprite powerup3;
    [SerializeField]
    private GameObject prefab1;
    [SerializeField]
    private GameObject prefab2;
    [SerializeField]
    private GameObject prefab3;

    [SerializeField]
    private int _powerupID;
    private Inventory _inventory;

    // Start is called before the first frame update
    void Start()
    {
        _list = GameObject.Find("List").GetComponent<List>();
        powerup1 = _list.transform.GetChild(0).GetComponent<ChangeSprite>();
        powerup2 = _list.transform.GetChild(1).GetComponent<ChangeSprite>();
        powerup3 = _list.transform.GetChild(2).GetComponent<ChangeSprite>();
        _inventory = GameObject.Find("Player").transform.GetComponent<Inventory>();

    }

    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3
        //will not be reused
        //when we leave the screen, destroy this object
        transform.Translate(new Vector3(0, _speed, 0) * Time.deltaTime);

        if (transform.position.y > 15)
        {
            //
            Destroy(this.gameObject);
        }
    }



    //check for collisions
    //OnTriggerCollison2D
    //use tages to collect by player only
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            switch (_powerupID)
            {
                case 0:
                    _list.ChangeObj1(prefab1);
                    Debug.Log("add band to inventory");
                    powerup1.ChangeTheSprite();
                    _list.CheckObjs();

                    Destroy(this.gameObject);

                    break;
                case 1:
                    _list.ChangeObj2(prefab2);
                    powerup2.ChangeTheSprite();
                    Destroy(this.gameObject);
                    _list.CheckObjs();

                    break;
                case 2:
                    _list.ChangeObj3(prefab3);
                    powerup3.ChangeTheSprite();
                    _list.CheckObjs();
                    Destroy(this.gameObject);

                    break;
            }

        }
    }


}
