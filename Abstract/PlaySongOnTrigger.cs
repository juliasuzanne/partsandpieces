using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySongOnTrigger : MonoBehaviour
{
    [SerializeField] private AudioSource _defaultAudio;

    public void PlaySound()
    {
        _defaultAudio.Play();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        IPlayable hit = other.GetComponent<IPlayable>();
        if (hit != null)
        {
            _defaultAudio.clip = hit.ReturnAudioClip();
            _defaultAudio.Play();

        }
        else
        {
            Debug.Log("hit is null");
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {

        IPlayable hit = other.GetComponent<IPlayable>();
        if (hit != null)
        {
            _defaultAudio.Pause();

        }
        else
        {
            Debug.Log("hit is null");
        }


    }
}
