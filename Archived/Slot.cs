using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour

{
    public int slot;
    private Inventory inventory;
    // private Image m_Image;
 
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void CombineItem(){
    //     foreach (Transform child in transform){
    //         // child.sprite = rb_Sprite;
    //         m_Image = child.GetComponent<Image>();
    //         m_Image.sprite = m_Sprite_Rock_Band;
    //         }
    //     }

    public void DropItem(){
        foreach (Transform child in transform){
            child.GetComponent<Spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
            inventory.isFull[slot - 1] = false;
            inventory.items[slot -1 ] = null;

        }
    }

}
