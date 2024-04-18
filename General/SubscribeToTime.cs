using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;



public class SubscribeToTime : MonoBehaviour
{
    [SerializeField] private TimeManager timeManager;
    [SerializeField] private int hour;
    [SerializeField] private int targetHour;
    [SerializeField] private UnityEvent onTrigger;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = FindObjectOfType<TimeManager>();


    }

    // Update is called once per frame
    void Update()
    {
        timeManager.onHourChanged += UpdateHour;

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
