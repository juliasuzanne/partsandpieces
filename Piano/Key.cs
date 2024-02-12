using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, INoteable
{
    [SerializeField] private string _noteType;
    [SerializeField] private bool _endingNote;
    [SerializeField] private AudioClip _note;
    [SerializeField] private float yOffset;




    // Start is called before the first frame update
    void Start()
    {
    }


    public string GetNote()
    {
        return _noteType;
    }
    public float GetOffset()
    {
        return yOffset;
    }

    public AudioClip GetClip()
    {
        return _note;
    }
    public void SuccessNote()
    {
        Debug.Log("SUCCESS");
    }
    public void WrongNote()
    {
        Debug.Log("WRONG");

    }

    public void AfterExit()
    {
        transform.localScale -= new Vector3(.69f, .69f, .69f);
        GetComponent<CircleCollider2D>().enabled = false;

    }

    public void AfterEnter()
    {
        transform.localScale += new Vector3(.69f, .69f, .9f);
    }

    public void CheckIfEnd()
    {
        if (_endingNote == true)
        {

        }
    }








}
