using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleActiveOnClick : MonoBehaviour
{
  [SerializeField] private GameObject itemToToggle;
  [SerializeField] UnityEvent onToggle;
  [SerializeField] UnityEvent onDefault;
  [SerializeField] private bool toggled;




  void Start()
  {
    toggled = false;


  }

  void Update()
  {

  }

  public void ToggleItem()
  {
    if (toggled == true)
    {
      toggled = false;
      itemToToggle.SetActive(false);
      onDefault.Invoke();
    }
    else
    {
      toggled = true;
      itemToToggle.SetActive(true);
      onToggle.Invoke();


    }


  }


}
