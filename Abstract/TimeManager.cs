using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using System;


public class TimeManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onNightTime;
    [SerializeField] private UnityEvent onDayTime;

    public const int hoursInDay = 24, minutesInHour = 60;
    [SerializeField] private CaveSaveSettings saveSettings;
    private float timeChangeDay = 255f;
    private float timeChangeNight = -255f;
    private bool checkedRain;
    [SerializeField] private RawImage nightPanel;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject rainObject;
    public float dayDuration = 30f;
    private bool nighttime;

    public Text message;
    public event Action onHourChanged;
    [SerializeField] private int day = 1;
    [SerializeField] private string month = "Fall";

    [SerializeField] float totalTime = 0;
    [SerializeField] float currentTime = 0;

    float startTime;



    void Awake()
    {
        saveSettings.LoadGame();
        if (month == "")
        {
            month = "Fall";
        }
        saveSettings = FindObjectOfType<CaveSaveSettings>();
        Debug.Log("before equation " + currentTime);

        Debug.Log("Save settings are " + saveSettings.so.time);

        startTime = saveSettings.so.time;
        currentTime = startTime;
        totalTime = startTime;
        Debug.Log("Set time to " + startTime);

        Debug.Log("after equation " + currentTime);



    }

    public void SaveTime()
    {
        saveSettings.so.time = GetTime();
    }

    public void SaveTotalTime()
    {
        saveSettings.ChangeTotalTime(totalTime);
    }

    public void Setup()
    {
        month = "Fall";
        currentTime = dayDuration;
        totalTime = dayDuration;
        saveSettings.so.time = 0;


    }

    public void CheckRain()
    {

        int rain = UnityEngine.Random.Range(0, 100);
        Debug.Log("Rain odds result:" + rain);
        if (rain > 80)
        {
            saveSettings.so.rain = true;
            saveSettings.SaveGame();
            if (rainObject != null)
            {
                rainObject.SetActive(true);
            }
        }
        else
        {
            saveSettings.so.rain = false;
            saveSettings.SaveGame();

            if (rainObject != null)
            {
                rainObject.SetActive(false);

            }
        }
    }

    public void CheckRainWithOdds()
    {

        int rain = UnityEngine.Random.Range(0, 100);
        Debug.Log("Rain odds result:" + rain);
        if (rain > 50)
        {
            ChangeRain();
        }

    }

    public void ChangeRain()
    {
        Debug.Log("CHANGE RAIN");
        if (rainObject.activeSelf)
        {
            Debug.Log("RAIN TO FALSE");

            saveSettings.so.rain = false;
            saveSettings.SaveGame();
            if (rainObject != null)
            {
                rainObject.SetActive(false);
            }
        }
        else
        {
            saveSettings.so.rain = true;
            saveSettings.SaveGame();
            if (rainObject != null)
            {
                rainObject.SetActive(true);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        day = Mathf.FloorToInt(totalTime / dayDuration);
        if (day > 29)
        {
            totalTime = dayDuration;
            ChangeMonth();
        }
        totalTime += Time.deltaTime;


        currentTime = totalTime % dayDuration;

        if (Mathf.FloorToInt(GetMinutes()) == 0)
        {
            onHourChanged();
            saveSettings.ChangeTime(GetTime());
            saveSettings.SaveGame();
            // Debug.Log("HOUR CHANGED TO: " + GetHour());
        }

        if (message != null)
        {
            message.text = Mathf.FloorToInt(GetHour()).ToString();

        }



        if (nightPanel != null)
        {
            if (Mathf.FloorToInt(GetHour()) == 9)
            {

                checkedRain = false;

                if (anim != null)
                {
                    anim.SetBool("Night", true);
                }
                nightPanel.color = new Color(255f, 255f, 255f, (GetMinutes() * 0.025f));
            }
            if (Mathf.FloorToInt(GetHour()) == 10)
            {
                if (saveSettings.so.nighttime == false)
                {
                    Debug.Log("MAKING NIGHT");
                    saveSettings.so.nighttime = true;
                    saveSettings.SaveGame();
                    nighttime = true;
                    CheckRain();
                    onNightTime.Invoke();

                }
                else
                {
                    Debug.Log("HOUR IS 17 BUT NIGHT TIME IS TRUE");
                }

            }
            if (Mathf.FloorToInt(GetHour()) == 17)
            {
                if (saveSettings.so.nighttime == true)
                {
                    Debug.Log("MAKING DAY");
                    saveSettings.so.nighttime = false;
                    saveSettings.SaveGame();
                    nighttime = false;
                    onDayTime.Invoke();
                }
                else
                {
                    Debug.Log("HOUR IS 5 BUT NIGHT TIME IS FALSE");
                }
            }
            if (Mathf.FloorToInt(GetHour()) == 16)
            {
                // saveSettings.so.nighttime = false;
                // saveSettings.SaveGame();
                if (anim != null)
                {
                    anim.SetBool("Night", false);
                }

                nightPanel.color = new Color(255f, 255f, 255f, ((60f - GetMinutes()) * 0.025f));
            }
        }

    }

    public void ChangeMonth()
    {
        int chancesToGetWeirdWeather = UnityEngine.Random.Range(0, 100);
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

    public void MakeNightTime()
    {
        if (nightPanel != null)
        {
            nightPanel.color = new Color(255f, 255f, 255f, 1f);
            onNightTime.Invoke();

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

    public float GetTotalTime()
    {
        return totalTime;
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