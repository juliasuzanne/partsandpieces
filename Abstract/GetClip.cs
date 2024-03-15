using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClip : MonoBehaviour, IPlayable
{
    [SerializeField] private AudioClip clip;

    public AudioClip ReturnAudioClip()
    {
        return clip;
    }
}
