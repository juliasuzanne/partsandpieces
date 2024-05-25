using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phenome : MonoBehaviour
{
    public AudioClip phenome;

    [SerializeField]
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GameObject.Find("Keyboard").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource.clip = phenome;
        _audioSource.Play();

    }
}
