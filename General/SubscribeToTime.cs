using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using System;




public class SubscribeToTime : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    private int hour;
    [SerializeField] private int targetHour;
    [SerializeField] private UnityEvent onTrigger;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();
        timeManager.onHourChanged += UpdateHour;
        UpdateHour();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHour()
    {
        hour = Mathf.FloorToInt(timeManager.GetHour());
        if (targetHour == hour)
        {
            onTrigger.Invoke();
        }

    }
}
