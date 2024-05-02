using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrinkTheFountainWater : MonoBehaviour
{
    [SerializeField] private RawImage drinkFilterPanel;
    [SerializeField] private CaveSaveSettings _saveManager;
    private TimeManager tm;
    private float timePassed = 0;
    private float timeDown = 5;

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

        StartCoroutine("DrankWater");

    }

    private IEnumerator DrankWater()
    {
        timePassed += Time.deltaTime;
        drinkFilterPanel.color = new Color(255f, 255f, 255f, timePassed / 10);
        yield return new WaitForSeconds(20f);
        timeDown -= Time.deltaTime / 5;
        Debug.Log("TIME DOWN" + timeDown);
        drinkFilterPanel.color = new Color(255f, 255f, 255f, timeDown);
        yield return new WaitForSeconds(10f);
        drink = false;
        _saveManager.NoWaterFilter();
    }


    // Update is called once per frame
    void Update()
    {

        if (drink == true)
        {
            Drink();
        }

    }
}
