using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //variable to determine if the damage function can be called
    private bool _canDamage = true;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.name);
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null && _canDamage == true)
        {
            hit.Damage();
            _canDamage = false;
            StartCoroutine("ResetAttack");
        }

    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}

