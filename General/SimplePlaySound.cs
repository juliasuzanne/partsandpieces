using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    // Start is called before the first frame update
    void PlaySound()
    {
        _audioSource.Play();
    }
}
