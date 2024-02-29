using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : MonoBehaviour
{
    public AudioClip[] notes;
    [SerializeField] private GameObject[] _playerNotes;
    [SerializeField] private Sprite[] _keyDowns;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _speed;
    [SerializeField] private SpriteRenderer _activeKey;
    private float xPos = -1f;
    private float yPos = -1f;
    [SerializeField] private float xStep = 2f;
    [SerializeField] private float yStep = 2f;
    [SerializeField] private CheckNote _conductor;
    [SerializeField] private SongCreator song;
    private bool _typing = true;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = notes[0];
        _activeKey.sprite = null;

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

    public void MakeKeyActive(int keyNum)
    {
        if (_conductor.IsSongPlaying())
        {

        }
        else
        {
            song.AddToPlayerOrder(keyNum);
        }
        StartCoroutine(PlayNote(keyNum));
    }

    IEnumerator PlayNote(int keyNum)
    {
        _activeKey.sprite = _keyDowns[keyNum];
        yield return new WaitForSeconds(0.2f);
        _activeKey.sprite = null;

    }

    public void PlaySoundOnKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound(0);
            MakeKeyActive(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(1);
            MakeKeyActive(1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(2);
            MakeKeyActive(2);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(3);
            MakeKeyActive(3);
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(4);
            MakeKeyActive(4);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(5);
            MakeKeyActive(5);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            PlaySound(6);
            MakeKeyActive(6);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            PlaySound(7);
            MakeKeyActive(7);
        }

        else if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound(8);
            MakeKeyActive(8);
        }

    }
}
