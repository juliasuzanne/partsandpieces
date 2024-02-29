using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckNote : MonoBehaviour
{
    [SerializeField] private GameObject[] _playerNotes;
    [SerializeField] private float yStart;
    [SerializeField] private float yStep;
    [SerializeField] private float xMax = 9f;
    [SerializeField] private Text _messageText;
    [SerializeField] private Text _successCount;
    private INoteable hit = null;
    [SerializeField] private AudioSource _defaultAudio;
    [SerializeField] private float yMin = -3.9f;
    [SerializeField] private float xStart = -1f;
    [SerializeField] private float _speed = 1f;
    private string currentKey;
    private string _collidedNote;
    private bool wasPlayed = false;
    private int successfulNotes = 0;
    private bool _isMoving = false;
    private bool canNotPlay = true;

    private bool isSongPlaying = false;

    void Update()
    {
        // Update is called once per frame
        // Debug.Log("WASPLAYED IS: " + wasPlayed);
        // Debug.Log("CURRENT KEY: " + currentKey);
        // Debug.Log("SUCCESSFUL NOTES: " + successfulNotes);
        Debug.Log("CAN NOT PLAY : " + canNotPlay);
        if (_isMoving == true)
        {
            // transform.Translate(new Vector3(0, (_speed), 0) * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                // StartOver();
            }
            if (transform.position.x > xMax)
            {
                if (transform.position.y < yMin)
                {
                    // _isMoving = false;
                    transform.position = new Vector3(xStart, yStart, 0);
                }
                else
                {
                    transform.position = new Vector3(xStart, transform.position.y - yStep, 0);
                }


            }


        }

        _successCount.text = "Successful Notes: " + successfulNotes + " PLAYING: " + currentKey;

    }


    void OnGUI()
    {
        Event e = Event.current;
        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1 && char.IsLetter(e.keyCode.ToString()[0]))
        {
            currentKey = e.keyCode.ToString();

            if (canNotPlay == true)
            {
                _messageText.text = "Note played out of time";
                successfulNotes--;
                currentKey = null;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isSongPlaying = true;
        canNotPlay = false;
        // Debug.Log("Hit " + other.name);
        INoteable hit = other.GetComponent<INoteable>();
        if (hit != null)
        {
            hit.AfterEnter();
            _collidedNote = hit.GetNote();
            if (_collidedNote == "END")
            {
                Debug.Log("END SONG");
                isSongPlaying = false;
            }
            _defaultAudio.clip = hit.GetClip();
            _defaultAudio.Play();
            _messageText.text = "PLAY " + _collidedNote;

        }
        else
        {
            Debug.Log("hit is null");
        }


    }

    public void SongIsPlaying()
    {
        isSongPlaying = true;
    }

    public bool IsSongPlaying()
    {
        return isSongPlaying;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        canNotPlay = false;
        INoteable hit = other.GetComponent<INoteable>();

        // Debug.Log("CURRENT KEY: " + currentKey);
        // Debug.Log("COLLIDED NOTE: " + _collidedNote);
        if (currentKey != null)
        {
            if (currentKey.Equals(_collidedNote))
            {
                _messageText.text = currentKey.ToString() + "EQUALS " + _collidedNote;
                wasPlayed = true;
                hit.AfterExit();


            }
            else
            {
                _messageText.text = "WRONG";
                // Debug.Log("SAYING " + currentKey + "DOES NOT EQUAL " + _collidedNote);
            }
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        INoteable hit = other.GetComponent<INoteable>();

        if (wasPlayed == true)
        {
            successfulNotes++;
        }
        else if (wasPlayed == false)
        {
            hit.AfterExit();
            successfulNotes--;
        }
        wasPlayed = false;
        currentKey = null;
        canNotPlay = true;
        hit = null;
    }



    // Update is called once per frame
    void OnMouseDown()
    {
        // Debug.Log("Mouse Down on play");
        _isMoving = true;
    }

    public Vector2 GetConductorPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }



}
