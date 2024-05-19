using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSuccessManager : MonoBehaviour
{
    private SpriteRenderer sp;
    [SerializeField] private float timeToWait = .2f;
    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    public void Success()
    {
        StartCoroutine("Good");

    }
    public void NoSuccess()
    {
        StartCoroutine("Bad");
    }

    private IEnumerator Good()
    {
        sp.color = Color.green;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.white;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.green;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.white;
        yield return new WaitForSeconds(timeToWait);
        Destroy(this.gameObject);


    }

    private IEnumerator Bad()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.white;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.red;
        yield return new WaitForSeconds(timeToWait);
        sp.color = Color.white;

    }
}
