using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject ingredientToSpawn;
    private DishController _dishController;
    private GameObject ingredient;


    // Start is called before the first frame update
    void Start()
    {
        _dishController = FindObjectOfType<DishController>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (_dishController.GetCurrentItem() == null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 moveToPos = new Vector3(mousePosition.x, mousePosition.y);
            ingredient = Instantiate(ingredientToSpawn, moveToPos, Quaternion.identity);
            _dishController.ChangeItem(ingredient);
        }
    }
}
