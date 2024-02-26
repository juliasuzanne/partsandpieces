using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//only can inherit from one class, but can include as many interfaces as you want
public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }
    // Use for initialization
    public override void Init()
    {
        base.Init();
        Health = base.health;
    }


    // public void Damage()
    // {
    //     Debug.Log("Damage");
    //     Debug.Log("Health is at " + Health);
    //     Health = Health - 1;
    //     if (Health < 1)
    //     {
    //         isDead = true;
    //         animator.SetTrigger("Death");
    //         for (var i = 0; i < gems; i++)
    //         {
    //             Instantiate(prefab, player_pos.x, Quaternion.identity);
    //         }
    //         //spawn a diamond
    //         //change value of diamond to gem count

    //         // Destroy(this.gameObject);
    //     }

    //     animator.SetTrigger("Hit");
    //     isHit = true;
    //     animator.SetBool("InCombat", true);

    // }

}
