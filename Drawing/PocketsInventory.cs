using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketsInventory : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnMouseDown()
    {
        StartCoroutine(OpenInventory());

    }

    IEnumerator OpenInventory()
    {
        anim.SetBool("OpenInventory", true);
        yield return new WaitForSeconds(2.7f);
        inventory.CheckItemLocation();
        uiManager.ShowInventory();

    }
    // Update is called once per frame
    void Update()
    {

    }
}
