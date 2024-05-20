using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class CookObject : MonoBehaviour, IDishable

{
  public string DishName { get; set; }
  public string SecondDishName { get; set; }

  public string ThirdDishName { get; set; }

  public GameObject ObjectToStack { get; set; }


  [SerializeField] private string dishName;
  [SerializeField] private string dishSecondName;
  [SerializeField] private string dishThirdName;

  private DishController _dishController;

  [SerializeField] private string dishType;
  [SerializeField] private Transform stackPos;
  [SerializeField] private GameObject secondStackedObject;
  public Transform TargetPos { get; set; }

  [SerializeField] private bool stacked = false;
  [SerializeField] private bool secondStacked = false;
  [SerializeField] private GameObject dishObjectToStack;
  private ICookable hit;
  private IDishable targetDish;

  public Transform GetStackPos()
  {
    return TargetPos;
  }

  public GameObject GetGameObject()
  {
    return gameObject;
  }


  void Start()
  {
    ObjectToStack = dishObjectToStack;
    TargetPos = stackPos;
    DishName = dishName;
    SecondDishName = dishSecondName;
    ThirdDishName = dishThirdName;
    _dishController = FindObjectOfType<DishController>();

  }

  public void ChangeSecondName(string newName)
  {
    SecondDishName = newName;
  }

  public void ChangeThirdName(string thirdName)
  {
    ThirdDishName = thirdName;
  }
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      CheckForHit();
      CheckForStack();
    }

  }




  public void CheckForStack()
  {

    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
    RaycastHit2D raycast = Physics2D.Raycast(mousePos2D, Vector2.zero);
    if (raycast.collider != null)
    {
      if (raycast.collider.gameObject.GetComponent<IDishable>() != null)
      {
        targetDish = raycast.collider.gameObject.GetComponent<IDishable>();
      }
    }
    if (targetDish != null && _dishController.GetCurrentItem() != null && targetDish == this.GetComponent<IDishable>())
    {

      Debug.Log("CALL THIS SCRIPT from " + this.GetGameObject());


      if (targetDish.Stacked() == false)
      {
        // Debug.Log("TRIGGERED OBJ FIRST" + targetDish.DishName);
        targetDish.ChangeStacked();
        targetDish.SpawnStack(_dishController.GetCurrentItem().GetComponent<IDishable>().ObjectToStack);
        targetDish.ChangeSecondName(_dishController.GetCurrentItem().GetComponent<IDishable>().DishName);
        targetDish = null;
        Destroy(_dishController.GetCurrentItem());

      }
      else if (targetDish.SecondStacked() == false && targetDish.Stacked() == true)
      {
        targetDish.ChangeSecondStacked();
        // Debug.Log("Current item stack item: " + _dishController.GetCurrentItem().GetComponent<IDishable>().ObjectToStack);
        targetDish.SpawnThirdStack(_dishController.GetCurrentItem().GetComponent<IDishable>().ObjectToStack);
        // Debug.Log("TRIGGERED OBJ" + targetDish.DishName);
        // Debug.Log("DISH NAME" + dishName);
        targetDish.ChangeThirdName(_dishController.GetCurrentItem().GetComponent<IDishable>().DishName);
        targetDish = null;
        Destroy(_dishController.GetCurrentItem());

      }

      else
      {
        targetDish = null;
        Debug.Log("StackFull");
      }

    }
    else if (targetDish != null && _dishController.GetCurrentItem() == null)
    {
      Debug.Log("GET OBJECT FROM PLATE");
      Debug.Log("TARGET DISH: " + targetDish);
      Debug.Log("TARGET DISH: " + targetDish.GetGameObject());
      _dishController.GiveItemToPlayer(targetDish.GetGameObject());
      targetDish = null;
    }

  }


  public void CheckForHit()
  {
    if (hit == null)
    {
      Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
      RaycastHit2D raycast = Physics2D.Raycast(mousePos2D, Vector2.zero);
      if (raycast.collider != null)
      {


        if (raycast.collider.gameObject.GetComponent<ICookable>() != null)
        {
          hit = raycast.collider.gameObject.GetComponent<ICookable>();
        }
      }
      Debug.Log("RAYCAST" + hit);
      if (hit != null)
      {
        if (hit.Name == _dishController.GetCurrentItem().GetComponent<IDishable>().DishName && hit.SecondName == _dishController.GetCurrentItem().GetComponent<IDishable>().SecondDishName && hit.ThirdName == _dishController.GetCurrentItem().GetComponent<IDishable>().ThirdDishName)
        {
          Debug.Log("FIRST: " + _dishController.GetCurrentItem().GetComponent<IDishable>().DishName + "AND " + hit.Name);
          Debug.Log("SECOND: " + _dishController.GetCurrentItem().GetComponent<IDishable>().SecondDishName + "AND " + hit.SecondName);
          Debug.Log("THIRD: " + _dishController.GetCurrentItem().GetComponent<IDishable>().ThirdDishName + "AND " + hit.ThirdName);
          Debug.Log("MATCH");
          hit.Match(_dishController.GetCurrentItem());
          hit = null;
          // Destroy(this.gameObject);
        }
        else
        {
          Debug.Log("WRONG MATCH");
          hit.NoMatch();
          hit = null;
        }
      }

    }
  }


  public bool Stacked()
  {
    return stacked;
  }

  public bool SecondStacked()
  {
    return secondStacked;
  }

  public void ChangeStacked()
  {
    stacked = true;
  }

  public void ChangeSecondStacked()
  {
    secondStacked = true;
  }

  public void ChangeSecondStackedObject(GameObject newObject)
  {
    secondStackedObject = _dishController.GetCurrentItem();
  }

  public GameObject GetSecondStackedObject()
  {
    return secondStackedObject;
  }



  void OnMouseDown()
  {
    // if (_dishController.GetCurrentItem() == null)
    // {
    //   _dishController.ChangeItem(this.gameObject);
    // }


    // Debug.Log("HIT!" + hit);
    // else if (hit != null)
    // {
    //   Debug.Log("HIT: " + hit.Name);

    //   if (hit.Name == dishName && hit.SecondName == dishSecondName && hit.ThirdName == dishThirdName)
    //   {
    //     Debug.Log("MATCH");
    //     hit.Match(this.gameObject);
    //     // Destroy(this.gameObject);
    //   }
    //   else
    //   {
    //     hit.NoMatch();
    //     Debug.Log("WRONG MATCH");
    //   }
    // }
    // else if (targetDish != null)
    // {
    //   if (targetDish.Stacked() == false)
    //   {
    //     targetDish.ChangeStacked();
    //     targetDish.SpawnStack(_dishController.GetCurrentItem().GetComponent<IDishable>().ObjectToStack);
    //     targetDish.ChangeSecondName(dishName);
    //     Destroy(this.gameObject);

    //   }
    //   else if (targetDish.SecondStacked() == false)
    //   {
    //     targetDish.ChangeSecondStacked();
    //     targetDish.SpawnThirdStack(_dishController.GetCurrentItem().GetComponent<IDishable>().ObjectToStack);
    //     Debug.Log("TRIGGERED OBJ" + targetDish.DishName);
    //     Debug.Log("DISH NAME" + dishName);
    //     targetDish.ChangeThirdName(dishName);
    //     Destroy(this.gameObject);

    //   }

    //   else
    //   {

    //     Debug.Log("StackFull");
    //   }
    // }
  }

  public void SpawnStack(GameObject prefab)
  {
    secondStackedObject = Instantiate(prefab, new Vector3(stackPos.position.x, stackPos.position.y, 0f), Quaternion.identity, stackPos);
  }

  public void SpawnThirdStack(GameObject prefab)
  {
    Instantiate(prefab, new Vector3(secondStackedObject.transform.GetChild(0).position.x, secondStackedObject.transform.GetChild(0).position.y, 0f), Quaternion.identity, secondStackedObject.transform.GetChild(0));
  }


  void OnTriggerEnter2D(Collider2D other)
  {
    // hit = other.GetComponent<ICookable>();
    // Debug.Log(hit);
    // if (_dishController.GetCurrentItem() != null)
    // {
    //   if (_dishController.GetCurrentItem() != other.gameObject && _dishController.GetCurrentItem().GetComponent<IDishable>().Stacked() == false)
    //   {
    //     targetDish = other.GetComponent<IDishable>();
    //   }
    // }


  }

  void OnTriggerExit2D(Collider2D other)
  {
    // if (other.GetComponent<ICookable>() == hit)
    // {
    //   hit = null;
    //   Debug.Log("exit");
    // }
    // if (other.GetComponent<IDishable>() == targetDish)
    // {
    //   targetDish = null;
    //   Debug.Log("exit trigger");
    // }


  }

  public string GetName()
  {
    return dishName;
  }



}

