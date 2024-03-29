using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveInventory : MonoBehaviour
{
    [SerializeField] GameObject animatedGlove;
    private GameObject madeGlove;
    [SerializeField] FollowMouseNoChangeCursor gloveCursor;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddAnimatedGlove()
    {
        if (madeGlove == null)
        {
            madeGlove = Instantiate(animatedGlove, new Vector3(0f, 0f, 0f), Quaternion.Euler(0f, 0f, Random.Range(-30f, 30f)));
            gloveCursor = madeGlove.GetComponent<FollowMouseNoChangeCursor>();
        }
    }

    public void AllowGloveMove()
    {
        gloveCursor.AllowMove();
        Debug.Log("ALLOW MOVE");
    }

    public void DontAllowGloveMove()
    {
        Debug.Log("DONT ALLOW MOVE");
        gloveCursor.DontAllowMove();
    }


}
