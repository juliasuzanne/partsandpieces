using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorStairPaperController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private GameObject _panel;
    [SerializeField] private int frontSortNum;
    [SerializeField] private int backSortNum;
    [SerializeField] private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void OnMouseEnter()
    {
        _audioSource.Play();
        sp.sortingOrder = frontSortNum;

    }
    void OnMouseExit()
    {
        sp.sortingOrder = backSortNum;

    }

    void OnMouseDown()
    {
        _audioSource.Play();
        _panel.SetActive(true);
        sp.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
