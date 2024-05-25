using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    public GameObject item2;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void SpawnItem() {
        Vector2 playerPos = new Vector2(player.position.x + 1, player.position.y);
        Vector2 playerPos2 = new Vector2(player.position.x + 1, player.position.y + 2);
        Instantiate(item, playerPos, Quaternion.identity);
        if (item2){
            Instantiate(item2, playerPos2, Quaternion.identity);
        }
    }
}
