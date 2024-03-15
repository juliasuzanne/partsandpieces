using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour
{
    [SerializeField] private KickRock kickrock;
    [SerializeField]
    private string kickDirection;
    // Start is called before the first frame update
    private void OnMouseDown()
    {
        kickrock.Kick(kickDirection);
    }


}
