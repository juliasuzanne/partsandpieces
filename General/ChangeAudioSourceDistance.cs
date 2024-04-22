using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAudioSourceDistance : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform other;
    private float distance;
    [SerializeField] private float startDistance;
    [SerializeField] private AudioSource audioSourceToMinimize;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(other.position, player.transform.position);
        if (distance > startDistance)

        {
            if (audioSourceToMinimize.volume < 1)
            {
                audioSourceToMinimize.volume = audioSourceToMinimize.volume += Time.deltaTime * 0.2f;
            }
        }
        else if (distance < startDistance)
        {
            if (audioSourceToMinimize.volume > 0.1)
            {
                audioSourceToMinimize.volume = audioSourceToMinimize.volume -= Time.deltaTime * 0.2f;
            }
        }

    }
}
