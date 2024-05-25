using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIngredient : MonoBehaviour
{
    [SerializeField] private GameObject ingredientToSpawn;
    private DishController _dishController;
    private GameObject ingredient;
    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        _dishController = FindObjectOfType<DishController>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        if (this.enabled)
        {
            if (_dishController.GetCurrentItem() == null)
            {
                Vector2 playerPos = new Vector2(player.transform.GetChild(6).position.x, player.transform.GetChild(6).position.y);
                ingredient = Instantiate(ingredientToSpawn, playerPos, Quaternion.identity, player.transform.GetChild(6));
                _dishController.ChangeItem(ingredient);
            }
        }

    }
}
