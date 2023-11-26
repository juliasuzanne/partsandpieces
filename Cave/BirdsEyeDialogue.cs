using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdsEyeDialogue : DialogTemplate
{
    private bool _chosenName = false;
    private bool _gotRocks = false;
    private bool _hitRock = false;


    [SerializeField]
    private TMP_InputField _input;
    [SerializeField]
    private TMP_InputField _inputRock;
    [SerializeField]
    private GameObject _inputField;
    [SerializeField]
    private GameObject _giveRocksToPlayer;
    [SerializeField]
    private GameObject _inputFieldRock;
    [SerializeField]
    private GameObject _inputFieldSadThing;
    [SerializeField]
    private TMP_InputField _inputSadThing;
    private Animator _abovePlayerAnimator;
    [SerializeField]
    private GameObject _getInventoryButtonCut;



    private Inventory _inventory;

    [SerializeField]
    private GameObject _rocksPrefab;

    private CaveSaveSettings _sceneSaveSettings;

    [SerializeField]
    private GameObject _inventoryButton;
    private Animator _animator;
    [SerializeField]
    private GameObject _gatherTears;
    private StartConversation _conversationManager;


    public override void OnStarting()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        _panel.SetActive(true);
        _inputField.SetActive(false);
        _inputFieldRock.SetActive(false);
        _inputFieldSadThing.SetActive(false);
        _sceneSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();
        _animator = GameObject.Find("RockFaces").GetComponent<Animator>();
        _conversationManager = GameObject.Find("RockFaces").GetComponent<StartConversation>();
        _abovePlayerAnimator = GameObject.Find("AbovePlayer").GetComponent<Animator>();


    }

    public void RubRocks()
    {
        if (runRoutine == true)
        {
            StartCoroutine("RockOnRock");
        }
    }

    protected override void EndConversation()
    {
        base.EndConversation();
        _conversationManager.ComeBackFromConversation();
        _animator.SetBool("Talk", false);

    }

    void Awake()
    {
        StartTalking();
    }

    protected IEnumerator RockOnRock()
    {
        runRoutine = false;
        NPCTalking();
        _panel.SetActive(false);
        _NPCText.text = NPCText_string[16];
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _NPCText.text = NPCText_string[17];
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _NPCText.text = NPCText_string[18];
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _gatherTears.SetActive(true); EndConversation();

    }


    protected override IEnumerator MoveThroughDialogue()
    {
        OnStarting();
        SetupConversation();
        _panel.SetActive(true);

        // A 0 BUTTON PRESSED
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();

        if (waitForButton.PressedButton == AButton)
        {
            Debug.Log("A BUTTON PRESSED");
            NPCTalkThenPanel(1, 1, 1);
            _animator.SetBool("Talk", true);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
            {
                NPCSaySomething(3);
                yield return new WaitForSeconds(2.0f);
                //GET NAME
                _inputField.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                {
                    _sceneSaveSettings.ChangeUserName(_input.text);
                    _inputField.SetActive(false);
                    NPCText_string[5] = _sceneSaveSettings.so.playerName + ", is that right?";
                    NPCTalkThenPanel(5, 8, 8);
                    yield return waitForButton.Reset();
                    if (waitForButton.PressedButton == AButton)
                    {
                        NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                        NPCSaySomething(5);
                        _chosenName = true;


                    }
                    else
                    {
                        NPCText_string[5] = "Okay, make sure you get it right this time.";
                        NPCSaySomething(5);
                        _inputField.SetActive(true);
                        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                        {
                            _sceneSaveSettings.ChangeUserName(_input.text);
                            _inputField.SetActive(false);
                            NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                            NPCSaySomething(5);
                            _chosenName = true;


                        }

                    }
                }
                //END GET NAME


            }

        }
        else if (waitForButton.PressedButton == BButton)
        {
            NPCTalkThenPanel(2, 2, 2);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton)
            {
                //GET NAME
                _inputField.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                {
                    _sceneSaveSettings.ChangeUserName(_input.text);
                    _inputField.SetActive(false);
                    NPCText_string[5] = _sceneSaveSettings.so.playerName + ", is that right?";
                    NPCTalkThenPanel(5, 8, 8);
                    yield return waitForButton.Reset();
                    if (waitForButton.PressedButton == AButton)
                    {
                        NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                        NPCSaySomething(5);
                        _chosenName = true;


                    }
                    else
                    {
                        NPCText_string[5] = "Okay, make sure you get it right this time.";
                        NPCSaySomething(5);
                        _inputField.SetActive(true);
                        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                        {
                            _sceneSaveSettings.ChangeUserName(_input.text);
                            _inputField.SetActive(false);
                            NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                            NPCSaySomething(5);
                            _chosenName = true;


                        }

                    }
                }
                //END GET NAME

            }
            else
            {
                NPCSaySomething(4);
                yield return new WaitForSeconds(2.0f);
                //GET NAME
                _inputField.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                {
                    _sceneSaveSettings.ChangeUserName(_input.text);
                    _inputField.SetActive(false);
                    NPCText_string[5] = _sceneSaveSettings.so.playerName + ", is that right?";
                    NPCTalkThenPanel(5, 8, 8);
                    yield return waitForButton.Reset();
                    if (waitForButton.PressedButton == AButton)
                    {
                        NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                        NPCSaySomething(5);
                        _chosenName = true;



                    }
                    else
                    {
                        NPCText_string[5] = "Okay, make sure you get it right this time.";
                        NPCSaySomething(5);
                        _inputField.SetActive(true);
                        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                        {
                            _sceneSaveSettings.ChangeUserName(_input.text);
                            _inputField.SetActive(false);
                            NPCText_string[5] = "Hello, " + _sceneSaveSettings.so.playerName + ".";
                            NPCSaySomething(5);
                            _chosenName = true;


                        }

                    }
                }
                //END GET NAME


            }
        }

        if (_chosenName == true)
        {
            NPCTalkThenPanel(5, 3, 9);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
            {
                NPCSaySomething(6);
                yield return new WaitForSeconds(2.0f);
                _inputFieldRock.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                {
                    _sceneSaveSettings.ChangeRockName(_inputRock.text);
                    _inputFieldRock.SetActive(false);
                    NPCText_string[7] = _sceneSaveSettings.so.rockName + ", I like it. Let me give you something in return.";
                    NPCTalkThenPanel(7, 4, 3);
                    _getInventoryButtonCut.SetActive(true);
                    // _inventoryButton.SetActive(true);
                    yield return waitForButton.Reset();
                    if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                    {
                        NPCTalkThenPanel(8, 5, 4);
                        yield return waitForButton.Reset();
                        if (waitForButton.PressedButton == AButton)
                        {
                            NPCSaySomething(9);
                            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                            _giveRocksToPlayer.SetActive(true);
                            _inventory.AddItemToInventory(_rocksPrefab);
                            _animator.SetTrigger("RemoveRocks");
                            _gotRocks = true;
                        }
                        else if (waitForButton.PressedButton == BButton)
                        {
                            NPCSaySomething(10);
                            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                            _giveRocksToPlayer.SetActive(true);
                            _inventory.AddItemToInventory(_rocksPrefab);
                            _animator.SetTrigger("RemoveRocks");
                            _gotRocks = true;
                        }


                    }
                }
            }
        }
        if (_gotRocks == true)
        {

            NPCTalkThenPanel(11, 5, 5);
            yield return waitForButton.Reset();
            if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
            {
                NPCTalkThenPanel(12, 6, 6);
                yield return waitForButton.Reset();
                if (waitForButton.PressedButton == AButton)
                {
                    NPCSaySomething(13);
                    yield return new WaitForSeconds(2.0f);
                    _inputFieldSadThing.SetActive(true);
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
                    {
                        _sceneSaveSettings.ThinkOfSomethingSad(_inputSadThing.text);
                        _inputFieldSadThing.SetActive(false);
                        NPCText_string[15] = _sceneSaveSettings.so.sadThing + ", oh, that is so very, very sad.";
                        NPCSaySomething(15);
                        yield return new WaitForSeconds(2.0f);
                        _gatherTears.SetActive(true); EndConversation();

                    }
                }
                else if (waitForButton.PressedButton == BButton)
                {
                    NPCSaySomething(14);
                    yield return new WaitForSeconds(2.0f);
                    EndConversation();
                }

            }
        }


    }
}