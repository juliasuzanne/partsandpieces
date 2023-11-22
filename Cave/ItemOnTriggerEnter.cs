using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemOnTriggerEnter : MonoBehaviour
{
    private string collisionGameobjectName;
    private Text description_text;
    private GameObject description_object;
    private bool _onPlayer;
    private AbovePlayer _abovePlayer;

    void Start()
    {
        description_object = this.transform.GetChild(0).gameObject;
        description_text = this.transform.GetChild(0).GetComponent<Text>();
        _abovePlayer = GameObject.Find("AbovePlayer").GetComponent<AbovePlayer>();

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        collisionGameobjectName = collision.gameObject.name;
        description_object.SetActive(true);
        description_text.text = "Use " + gameObject.name + " with " + collisionGameobjectName;
        if (collision.gameObject.tag == "Player")
        {
            _onPlayer = true;
        }

    }

    void OnTriggerExit2D(Collider2D collision)
    {
        collisionGameobjectName = null;
        description_object.SetActive(false);
        description_text.text = "";
        _onPlayer = false;

    }

    void Update()
    {
        Debug.Log(_onPlayer);
        if (Input.GetMouseButtonDown(0))
        {
            if (_onPlayer == true)
            {
                _abovePlayer.showColorChangePanel();
            }
        }

    }

}
