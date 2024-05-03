using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteBasedOnPlayerDistance : MonoBehaviour
{

    public float[] spritedistances;
    public bool debug;
    private SpriteRenderer _sp;
    private AudioSource _audioSource;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private AudioClip[] clips;
    private GameObject player;
    private bool playing;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        _sp = GetComponent<SpriteRenderer>();
        _audioSource.volume = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (debug == true)
        {
            // Debug.Log("distance is " + distance + " from " + transform.name);

        }
        if (distance < spritedistances[3])
        {
            _sp.sprite = sprites[3];
            _audioSource.clip = clips[2];
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else if (distance < spritedistances[2])
        {
            _sp.sprite = sprites[2];
            _audioSource.clip = clips[1];

            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else if (distance < spritedistances[1])
        {
            _sp.sprite = sprites[1];
            _audioSource.clip = clips[0];
            if (!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _sp.sprite = sprites[0];
        }

    }




}




