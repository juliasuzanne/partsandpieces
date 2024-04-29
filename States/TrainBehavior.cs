using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainBehavior : MonoBehaviour
{
    [SerializeField] private int speed;

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
        transform.position = _trainStart;
        trainComing = true;
        trainLeaving = false;

    }

    public void TrainIsLeaving()
    {
        trainComing = false;
        trainLeaving = true;
    }


    private void TrainComes()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _trainStop, step);

    }

    private void TrainLeaves()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, _trainLeaves, step);

    }
}
