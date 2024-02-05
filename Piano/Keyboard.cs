using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{

    public AudioClip[] notes;

    [SerializeField]
    private GameObject[] _playerNotes;

    [SerializeField]
    private GameObject _cursor;


    [SerializeField]
    private AudioSource _audioSource;

    private float xPos = -1f;
    private float yPos = -1f;
    [SerializeField]
    private float xStep = 2f;
    [SerializeField]
    private float yStep = 2f;

    private bool _typing = true;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = notes[0];
        _audioSource.Play();

    }

    // public void ToggleType()
    // {
    //     if (_typing == false)
    //     {
    //         _typing = true;
    //     }
    //     else
    //     {
    //         _typing = false;
    //     }
    // }


    void PlaySound(int note)
    {
        if (_typing == true)
        {
            Vector3 posToSpawn = new Vector3(xPos, yPos, 0);
            _audioSource.clip = notes[note];
            _audioSource.Play();
            GameObject newChar = Instantiate(_playerNotes[note], posToSpawn, Quaternion.identity);
        }
        else
        {
            _audioSource.clip = notes[note];
            _audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(2);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(3);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(4);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(5);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            PlaySound(6);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            PlaySound(7);
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound(8);
        }




    }
}
