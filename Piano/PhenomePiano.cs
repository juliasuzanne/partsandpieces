using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomePiano : MonoBehaviour
{
    public AudioClip[] notes;
    private bool record = false;
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
            if (record == true)
            {
                song.AddToPlayerOrder(keyNum);

            }
        }
        StartCoroutine(PlayNote(keyNum));
    }

    public void Record()
    {
        record = true;
    }

    IEnumerator PlayNote(int keyNum)
    {
        if (keyNum < _keyDowns.Length)
            _activeKey.sprite = _keyDowns[keyNum];
        yield return new WaitForSeconds(0.2f);
        _activeKey.sprite = null;
    }

    public void PlaySoundOnKeyDown()
    {


        // _cursor.transform.position = new Vector3(xPos, yPos, 3);
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     PlaySound(45);
        // }

        // if (Input.GetKeyDown(KeyCode.Backspace))
        // {

        //     xPos = -5.9f;
        //     yPos = 3.74f;
        // }

        // if (Input.GetKey(KeyCode.LeftShift))

        if (Input.GetKeyDown(KeyCode.Alpha1))
        //was Q
        {
            PlaySound(27);
            MakeKeyActive(27);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //was W
            PlaySound(35);
            MakeKeyActive(35);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // E
            PlaySound(21);
            MakeKeyActive(21);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //R
            PlaySound(29);
            MakeKeyActive(29);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            //T
            PlaySound(23);
            MakeKeyActive(23);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            //Y
            PlaySound(31);
            MakeKeyActive(31);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            //U
            PlaySound(25);
            MakeKeyActive(25);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            //I
            PlaySound(33);
            MakeKeyActive(33);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            //O
            PlaySound(26);
            MakeKeyActive(26);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            //P
            PlaySound(34);
            MakeKeyActive(34);
        }
        else if (Input.GetKeyDown(KeyCode.Minus))
        {
            //A
            PlaySound(37);
            MakeKeyActive(37);
        }

        else if (Input.GetKeyDown(KeyCode.Equals))
        {
            //S
            PlaySound(38);
            MakeKeyActive(38);
        }
        else if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            //D
            PlaySound(39);
            MakeKeyActive(39);
        }
        else if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            //F
            PlaySound(36);
            MakeKeyActive(36);
        }

        else if (Input.GetKeyDown(KeyCode.Backslash))
        {
            //G
            PlaySound(41);
            MakeKeyActive(41);
        }
        else if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            //H
            PlaySound(40);
            MakeKeyActive(40);
        }
        else if (Input.GetKeyDown(KeyCode.Quote))
        {
            //J
            PlaySound(42);
            MakeKeyActive(42);
        }
        else if (Input.GetKeyDown(KeyCode.Comma))
        {
            //K
            PlaySound(43);
            MakeKeyActive(43);
        }






        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PlaySound(0);
            MakeKeyActive(0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PlaySound(1);
            MakeKeyActive(1);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PlaySound(2);
            MakeKeyActive(2);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            PlaySound(3);
            MakeKeyActive(3);
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            PlaySound(4);
            MakeKeyActive(4);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            PlaySound(5);
            MakeKeyActive(5);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            PlaySound(6);
            MakeKeyActive(6);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            PlaySound(7);
            MakeKeyActive(7);
        }

        else if (Input.GetKeyDown(KeyCode.O))
        {
            PlaySound(8);
            MakeKeyActive(8);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            PlaySound(9);
            MakeKeyActive(9);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PlaySound(10);
            MakeKeyActive(10);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(11);
            MakeKeyActive(11);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            PlaySound(12);
            MakeKeyActive(12);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            PlaySound(13);
            MakeKeyActive(13);
        }

        else if (Input.GetKeyDown(KeyCode.G))
        {
            PlaySound(14);
            MakeKeyActive(14);
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            PlaySound(15);
            MakeKeyActive(15);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            PlaySound(16);
            MakeKeyActive(16);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            PlaySound(17);
            MakeKeyActive(17);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            PlaySound(18);
            MakeKeyActive(18);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            PlaySound(19);
            MakeKeyActive(19);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            PlaySound(20);
            MakeKeyActive(20);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            PlaySound(28);
            MakeKeyActive(28);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            PlaySound(22);
            MakeKeyActive(22);
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            PlaySound(30);
            MakeKeyActive(30);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            PlaySound(24);
            MakeKeyActive(24);
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            PlaySound(32);
            MakeKeyActive(32);
        }


    }


}
