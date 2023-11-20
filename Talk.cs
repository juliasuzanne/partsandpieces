using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    private GravityChanger _gravity;
    private Text text;
    private int count = 0;
    [SerializeField]
    private float _fallSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        _gravity = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<GravityChanger>();
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        text.text = "What is this place?";

    }

    public void StepForward()
    {
        switch (count)
        {
            case 3:
                transform.gameObject.SetActive(false);
                _gravity.Fall(_fallSpeed);
                break;

            case 2:
                text.text = "Is that me?";
                count = 3;
                break;

            case 1:
                text.text = "I don't remember anything.";
                count = 2;
                break;
            case 0:
                text.text = "What am I doing here?";
                count = 1;
                break;

        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
