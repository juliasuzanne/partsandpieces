using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookSuccessManager : MonoBehaviour
{
    private SpriteRenderer sp;
    private IRequestable _cookRequest;
    [SerializeField] private GameObject nextRequestor;
    [SerializeField] private float timeToWait = .2f;
    private void Start()
    {
        sp = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        _cookRequest = this.transform.GetChild(0).GetChild(0).GetComponent<IRequestable>();
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
        sp.color = new Color(0f, 0f, 0f, 0f);
        this.transform.GetChild(0).gameObject.SetActive(false);
        _cookRequest.ResetChoice();
        yield return new WaitForSeconds(Random.Range(0.2f, 7f));
        sp.color = Color.white;
        this.transform.GetChild(0).gameObject.SetActive(true);




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
