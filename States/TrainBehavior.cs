using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBehavior : MonoBehaviour
{
    [SerializeField] private int speed;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _clip;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private bool trainComing;
    [SerializeField] private bool trainLeaving;
    [SerializeField] private Vector2 _trainStop;
    [SerializeField] private Vector2 _trainLeaves;
    [SerializeField] private Vector2 _trainStart;


    void Update()
    {
        if (trainComing)
        {
            TrainComes();
        }
        else if (trainLeaving)
        {
            TrainLeaves();
        }
    }

    public void TrainIsComing()
    {
        _audioSource.Play();
        transform.position = _trainStart;
        trainComing = true;
        trainLeaving = false;

    }

    public void TrainIsLeaving()
    {
        _audioSource.Play();
        trainComing = false;
        trainLeaving = true;
    }


    private void TrainComes()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _trainStop, step);
        if (transform.position.x == _trainStop.x)
        {
            StartCoroutine("TrainStop");
        }

    }

    private IEnumerator TrainStop()
    {
        _collider.enabled = true;
        // _audioSource.Stop();
        yield return new WaitForSeconds(10f);
        TrainIsLeaving();
        _collider.enabled = false;


    }

    private void TrainLeaves()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _trainLeaves, step);

    }
}
