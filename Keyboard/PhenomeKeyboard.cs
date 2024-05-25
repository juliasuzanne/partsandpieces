using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhenomeKeyboard : MonoBehaviour
{

    public AudioClip[] phenomes;

    [SerializeField]
    private GameObject[] _char;

    [SerializeField]
    private GameObject _cursor;


    [SerializeField]
    private AudioSource _audioSource;

    private float xPos = -5.9f;
    private float yPos = 3.74f;
    [SerializeField]
    private float xStep = 2f;
    [SerializeField]
    private float yStep = 2f;

    private bool _typing = false;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = phenomes[0];
        _audioSource.Play();

    }

    public void ToggleType()
    {
        if (_typing == false)
        {
            _typing = true;
        }
        else
        {
            _typing = false;
        }
    }



    void PlaySound(int phenome)
    {
        if (_typing == true)
        {
            Vector3 posToSpawn = new Vector3(xPos, yPos, 0);
            xPos = xPos + xStep;

            if (xPos > 7.9f)
            {
                xPos = -5.9f;

                yPos = yPos - yStep;

            }
            if (yPos < -3.9f)
            {
                yPos = 3.74f;

            }
            _audioSource.clip = phenomes[phenome];
            _audioSource.Play();
            GameObject newChar = Instantiate(_char[phenome], posToSpawn, Quaternion.identity);
        }
        else
        {
            _audioSource.clip = phenomes[phenome];
            _audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {

        _cursor.transform.position = new Vector3(xPos, yPos, 3);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaySound(45);
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {

            xPos = -5.9f;
            yPos = 3.74f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlaySound(27);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PlaySound(35);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                PlaySound(21);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                PlaySound(29);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                PlaySound(23);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                PlaySound(31);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                PlaySound(25);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                PlaySound(33);
            }

            else if (Input.GetKeyDown(KeyCode.O))
            {
                PlaySound(26);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                PlaySound(34);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySound(37);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlaySound(38);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlaySound(39);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                PlaySound(36);
            }

            else if (Input.GetKeyDown(KeyCode.G))
            {
                PlaySound(41);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                PlaySound(40);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                PlaySound(42);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                PlaySound(43);
            }



        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Q))
            {
                PlaySound(0);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                PlaySound(1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                PlaySound(2);
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                PlaySound(3);
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                PlaySound(4);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                PlaySound(5);
            }
            else if (Input.GetKeyDown(KeyCode.U))
            {
                PlaySound(6);
            }
            else if (Input.GetKeyDown(KeyCode.I))
            {
                PlaySound(7);
            }

            else if (Input.GetKeyDown(KeyCode.O))
            {
                PlaySound(8);
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                PlaySound(9);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                PlaySound(10);
            }

            else if (Input.GetKeyDown(KeyCode.S))
            {
                PlaySound(11);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                PlaySound(12);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                PlaySound(13);
            }

            else if (Input.GetKeyDown(KeyCode.G))
            {
                PlaySound(14);
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                PlaySound(15);
            }
            else if (Input.GetKeyDown(KeyCode.J))
            {
                PlaySound(16);
            }
            else if (Input.GetKeyDown(KeyCode.K))
            {
                PlaySound(17);
            }
            else if (Input.GetKeyDown(KeyCode.L))
            {
                PlaySound(18);
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                PlaySound(19);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                PlaySound(20);
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                PlaySound(28);
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                PlaySound(22);
            }
            else if (Input.GetKeyDown(KeyCode.B))
            {
                PlaySound(30);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                PlaySound(24);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                PlaySound(32);
            }
        }

    }
}
