using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrinkTheFountainWater : MonoBehaviour
{
    [SerializeField] private RawImage drinkFilterPanel;
    [SerializeField] private CaveSaveSettings _saveManager;
    private TimeManager tm;
    private bool continuing;
    private float timePassed = 0;
    private float timeDown = 5;
    private float timeContinue = 3;

    [SerializeField] private bool drink = false;
    // Start is called before the first frame update
    void Start()
    {
        if (_saveManager == null)
        {
            _saveManager = FindObjectOfType<CaveSaveSettings>();

        }
    }

    public void SetDrinkTrue()
    {
        _saveManager.YesWaterFilter();
        drink = true;
        timePassed = 0;
        timeDown = 5f;

    }

    public void Drink()
    {

        DrankWater();
    }

    private void DrankWater()
    {
        timePassed += Time.deltaTime;
        drinkFilterPanel.color = new Color(255f, 255f, 255f, timePassed / 10);
        StartCoroutine("Waitfor20");


    }

    private IEnumerator Waitfor20()
    {
        yield return new WaitForSeconds(20f);
        ContinueFilter();

    }

    public void ResetAllValues()
    {
        timePassed = 0;
        timeDown = 5;
        timeContinue = 3;
    }

    public void ContinueFilter()
    {
        continuing = true;
    }


    private void NextSceneContinue()
    {
        if (timeContinue > 0f)
        {
            drinkFilterPanel.color = new Color(255f, 255f, 255f, 255f);
            timeContinue -= Time.deltaTime / 5;
            Debug.Log("TIME DOWN" + timeDown);
            drinkFilterPanel.color = new Color(255f, 255f, 255f, timeContinue);

        }
        else
        {
            ResetAllValues();
            continuing = false;
            drink = false;
            _saveManager.NoWaterFilter();
        }


    }


    // Update is called once per frame
    void Update()
    {
        if (continuing == true)
        {
            NextSceneContinue();
        }
        else if (drink == true)
        {
            Drink();
        }
        else
        {

        }


    }
}
