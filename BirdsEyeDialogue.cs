using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BirdsEyeDialogue : DialogTemplate
{
    private bool _chosenName = false;
    [SerializeField]
    private TMP_InputField _input;
    [SerializeField]
    private GameObject _inputField;
    private CaveSaveSettings _sceneSaveSettings;


    public override void OnStarting()
    {

        _panel.SetActive(true);
        _inputField.SetActive(false);
        _sceneSaveSettings = GameObject.Find("SceneSaveSettings").GetComponent<CaveSaveSettings>();

    }

    void Awake()
    {
        StartTalking();
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
            }
        }
    }
}