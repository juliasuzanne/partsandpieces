using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
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
    //         // Destroy(this.gameObject);
    //     }

    //     animator.SetTrigger("Hit");
    //     isHit = true;
    //     animator.SetBool("InCombat", true);

    // }

}
