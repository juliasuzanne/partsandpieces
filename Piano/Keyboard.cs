using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public AudioClip[] notes;
    [SerializeField] private GameObject[] _playerNotes;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;
    private float xPos = -1f;
    private float yPos = -1f;
    [SerializeField] private float xStep = 2f;
    [SerializeField] private float yStep = 2f;
    [SerializeField] private CheckNote _conductor;
    private bool _typing = true;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = notes[0];

    }

    void PlaySound(int note)
    {
        if (_typing == true)
        {
            Vector2 posToSpawn = _conductor.GetConductorPos();
            // Debug.Log("Typing, conductor pos: " + posToSpawn);
            _audioSource.clip = notes[note];
            _audioSource.Play();
            // GameObject newChar = Instantiate(_playerNotes[note], posToSpawn, Quaternion.identity);
        }
        else
        {
            // _audioSource.clip = notes[note];
            // _audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        PlaySoundOnKeyDown();
        transform.Translate(new Vector3((_speed), 0, 0) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            transform.position = new Vector2(0, 0);

        }

    }

    public void PlaySoundOnKeyDown()
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
