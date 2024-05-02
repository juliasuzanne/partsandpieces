using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnMovement : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private PlayerMovement playerMovement;
    private bool walking;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

    }



    // Update is called once per frame
    void Update()
    {
        float horizontal = Mathf.Abs(Input.GetAxisRaw("Horizontal")); //provides inputs, raw makes binary not float
        float vertical = Mathf.Abs(Input.GetAxisRaw("Vertical"));
        Debug.Log(horizontal + ", " + vertical);
        if (vertical + horizontal > 0.1)
        {
            if (walking == false)
            {
                StartWalking();
            }
            walking = true;
        }
        else
        {
            if (walking == true)
            {
                StopWalking();
            }
            walking = false;
        }

    }

    public void SetWalkingTrue()
    {
        walking = true;
    }



    public void StartWalking()
    {
        if (playerMovement.GetMoveable())
        {
            _audioSource.Play();
        }
    }

    public void StopWalking()
    {
        _audioSource.Pause();
    }
}
