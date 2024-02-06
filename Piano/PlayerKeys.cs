using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] private string _note;
    private string _collidedNote;
    [SerializeField] private SpriteRenderer _sp;
    // Start is called before the first frame update
    void Start()
    {
        _sp = GetComponent<SpriteRenderer>();
    }

    public string GetNote()
    {
        return _note;
    }


    public void WrongNote()
    {
        _sp.color = Color.red;
    }
    public void SuccessNote()
    {
        _sp.color = Color.green;
    }



    // Update is called once per frame
    void Update()
    {

    }
}
