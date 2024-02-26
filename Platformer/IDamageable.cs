using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface is like a contract, any object we apply it to 
public interface IDamageable
{
    //no implementation here, requires the following from what it's applied to
    int Health { get; set; }
    void Damage();
}
