using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;


public abstract class DialogTemplate : MonoBehaviour
{
    // Start is called before the first frame update
    protected Transform player;
    [SerializeField]
    protected Text _playerText;
    [SerializeField]
    protected Text _NPCText;
    protected bool collided = false;
    protected int _case;
    protected int _choice;

    [SerializeField]
    protected TMPro.TextMeshProUGUI _AText;
    [SerializeField]
    protected TMPro.TextMeshProUGUI _BText;
    [SerializeField]
    protected string[] NPCText_string;
    [SerializeField]
    protected string[] PlayerText_string;
    [SerializeField]
    protected string[] PlayerText_OptionA;
    [SerializeField]
    protected string[] PlayerText_OptionB;
    [SerializeField]
    protected GameObject _panel;
    [SerializeField]
    protected Button AButton;
    [SerializeField]
    protected Button BButton;

    protected bool runRoutine = true;

    public GameObject clicked_Object;

    protected UIManager _uiManager;

    // protected Player playerScript;

    public void CollidedIsFalse()
    {
        collided = false;
    }

    public void CollidedIsTrue()
    {
        collided = true;
    }


    public void Start()
    {
        _uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        // _NPCText = GameObject.Find("NPC").transform.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Text>();
        _playerText = player.GetChild(0).GetChild(0).gameObject.transform.GetComponent<Text>();


        _playerText.gameObject.SetActive(false);
        _panel = this.gameObject.transform.GetChild(2).gameObject;
        AButton = _panel.transform.GetChild(0).GetComponent<Button>();
        BButton = _panel.transform.GetChild(1).GetComponent<Button>();
        _panel.SetActive(false);
        _NPCText.gameObject.SetActive(true);
        _AText = this.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();
        _BText = this.gameObject.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>();


    }

    void Update()
    {

        Vector3 playerPos = new Vector3(player.position.x, player.position.y, player.position.z);
        _playerText.gameObject.transform.position = playerPos;

    }

    public void AdvanceCases(int caseNum)

    {
        _case = _case + caseNum;
    }



    public void StartTalking()
    {

        if (runRoutine == true && collided == false)
        {
            StartCoroutine("MoveThroughDialogue");
        }

    }

    public void PlayerTalking()
    {
        _playerText.gameObject.SetActive(true);
        _NPCText.gameObject.SetActive(false);

    }
    protected void NPCTalking()
    {
        _playerText.gameObject.SetActive(false);
        _NPCText.gameObject.SetActive(true);

    }

    protected void NPCTalkThenPanel(int NPCstring, int AString, int BString)
    {
        NPCTalking();
        _NPCText.text = NPCText_string[NPCstring];
        _panel.SetActive(true);
        _AText.text = PlayerText_OptionA[AString];
        _BText.text = PlayerText_OptionB[BString];
    }

    protected void PlayerSaySomething(int PlayerString)
    {
        PlayerTalking();
        _panel.SetActive(false);
        _playerText.text = PlayerText_string[PlayerString];
    }

    protected void EndConversation()
    {
        _playerText.gameObject.SetActive(false);
        runRoutine = true;
        _NPCText.gameObject.SetActive(false);
        _panel.SetActive(false);
        // playerScript.MoveableTrue();
    }

    protected void SetupConversation()
    {
        NPCTalking();
        runRoutine = false;
        _uiManager.HideInventory();
        // playerScript.MoveableFalse();
        _NPCText.text = NPCText_string[0];
        _AText.text = PlayerText_OptionA[0];
        _BText.text = PlayerText_OptionB[0];
    }
    protected virtual IEnumerator MoveThroughDialogue()
    {
        //setup for conversation
        SetupConversation();
        //WAIT FOR CLICK, REVEAL PANEL
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);

        // A 0 BUTTON PRESSED
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();
        if (waitForButton.PressedButton == AButton)
        {
            PlayerSaySomething(0);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            NPCTalkThenPanel(1, 1, 1);
            yield return waitForButton.Reset();

            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == AButton)
            {
                PlayerSaySomething(1);                         //SET PLAYER TEXT FROM ARRAY
                yield return new WaitForSeconds(2.0f);
                EndConversation();
                yield break;

            }
            // B 1 BUTTON PRESSED
            else
            {
                PlayerSaySomething(5);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCTalkThenPanel(3, 3, 3);
                waitForButton = new WaitForUIButtons(AButton, BButton);
                yield return waitForButton.Reset();

                if (waitForButton.PressedButton == AButton)
                {
                    PlayerSaySomething(3);                       //SET PLAYER TEXT FROM ARRAY
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                    NPCTalking();
                    _NPCText.text = NPCText_string[4];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;

                }
                // B 3 BUTTON PRESSED
                else
                {

                    PlayerSaySomething(7);
                    yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                    NPCTalking();
                    _NPCText.text = NPCText_string[5];
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                    yield break;
                }

            }


        }
        else
        // B 0 BUTTON PRESSED
        {
            PlayerSaySomething(4);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
            NPCTalkThenPanel(2, 2, 2);
            waitForButton = new WaitForUIButtons(AButton, BButton);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton)
            {
                PlayerSaySomething(2);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCTalking();
                _NPCText.text = NPCText_string[4];
                yield return new WaitForSeconds(2.0f);
                EndConversation();
                yield break;
            }
            // B 2 BUTTON PRESSED
            else
            {
                PlayerSaySomething(6);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));          //WAIT FOR USER TO CLICK
                NPCTalking();
                _NPCText.text = NPCText_string[4];
                EndConversation();
                yield break;
            }

        }


    }

}