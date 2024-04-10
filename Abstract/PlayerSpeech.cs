using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpeech : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] GameObject playerSpeechObject;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlayerTalkingForSeconds(string newText)
    {
        StartCoroutine(SaySomething(newText));
    }

    IEnumerator SaySomething(string newText)
    {
        text.text = newText;
        playerSpeechObject.SetActive(true);
        yield return new WaitForSeconds(4f);
        playerSpeechObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
