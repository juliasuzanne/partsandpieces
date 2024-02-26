using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
  public int Health { get; set; }
  [SerializeField]
  private GameObject acid_prefab;
  // Use for initialization
  public override void Init()
  {
    base.Init();
    Health = base.health;
  }

  public override void Movement()
  {
    //sit still
  }
  // public override void Damage()
  // {
  //   Health = Health - 1;
  //   if (Health < 0)
  //   {
  //     animator.SetTrigger("Death");
  //     // Destroy(this.gameObject);
  //   }
  //   Debug.Log("Damage");
  // }

  public override void Attack()
  {
    Instantiate(acid_prefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
  }
}


