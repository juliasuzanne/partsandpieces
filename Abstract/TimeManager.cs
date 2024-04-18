using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public const int hoursInDay = 24, minutesInHour = 60;
    [SerializeField] private CaveSaveSettings saveSettings;
    public float dayDuration = 30f;
    public Text message;

    [SerializeField] private int day = 1;
    [SerializeField] private string month = "Fall";

    float totalTime = 0;
    float currentTime = 0;

    float startTime = 0;



    void Start()
    {
        Debug.Log("before equation " + currentTime);
        if (saveSettings.so.time != null)
        {
            startTime = saveSettings.so.time;
            totalTime = startTime;
        }

        Debug.Log("after equation " + currentTime);
    }

    public void SaveTime()
    {
        saveSettings.ChangeTime(GetTime());
    }

    public void Setup()
    {
        month = "Fall";
        currentTime = 0;
        totalTime = dayDuration;
        saveSettings.so.time = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(currentTime);
        day = Mathf.FloorToInt(totalTime / dayDuration);
        if (day > 29)
        {
            totalTime = dayDuration;
            ChangeMonth();
        }
        totalTime += Time.deltaTime;

        currentTime = totalTime % dayDuration;

        message.text = Mathf.FloorToInt(GetHour()).ToString();


    }

    public void ChangeMonth()
    {
        int chancesToGetWeirdWeather = Random.Range(0, 100);
        if (chancesToGetWeirdWeather == 99)
        {
            Debug.Log("GET WEIRD WEATHER");
        }

        if (month == "Fall")
        {
            month = "Winter";
        }
        else if (month == "Winter")
        {
            month = "Spring";
        }
        else if (month == "Spring")
        {
            month = "Fall";
        }
    }


    public int GetDay()
    {
        return day;
    }

    public float GetHour()
    {
        return currentTime * hoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursInDay * minutesInHour / dayDuration) % minutesInHour;
    }

    public float GetTime()
    {
        return currentTime;
    }



    public string Clock24Hour()
    {
        //00:00
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }

    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(GetHour());
        string abbreviation = "AM";

        if (hour >= 12)
        {
            abbreviation = "PM";
            hour -= 12;
        }


        if (hour == 0) hour = 12;

        return hour.ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00") + " " + abbreviation;
    }
}