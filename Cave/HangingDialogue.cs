using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingDialogue : DialogTemplate
{
    private float xInput, yInput;
    [SerializeField]
    private GameObject _start;

    private GravityChanger _gravity;
    [SerializeField]
    private GameObject _speechBubble;


    public override void OnStarting()
    {
        _panel.SetActive(true);
        _gravity = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<GravityChanger>();
        _start.SetActive(false);
        _speechBubble.SetActive(true);
    }

    protected override void EndConversation()
    {
        base.EndConversation();
        Cursor.visible = true;
        _speechBubble.SetActive(false);

    }

    public override void Init()
    {
        base.Init();
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");
        // Debug.Log("XINPUT " + xInput);
    }
    // Start is called before the first frame update
    protected override IEnumerator MoveThroughDialogue()
    {
        OnStarting();
        //setup for conversation
        SetupConversation();
        //WAIT FOR CLICK, REVEAL PANEL
        // yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        _panel.SetActive(true);

        // A 0 BUTTON PRESSED
        var waitForButton = new WaitForUIButtons(AButton, BButton);
        yield return waitForButton.Reset();

        if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
        {
            Debug.Log("A BUTTON PRESSED");
            NPCTalkThenPanel(1, 0, 0);
            yield return waitForButton.Reset();

            // A 1 BUTTON PRESSED
            if (waitForButton.PressedButton == BButton)
            {
                NPCSaySomething(2);                         //SET PLAYER TEXT FROM ARRAY
                yield return new WaitForSeconds(2.0f);
                _start.SetActive(true);
                EndConversation();
                this.gameObject.SetActive(false);
                yield break;

            }
            // B 1 BUTTON PRESSED
            else
            {
                NPCSaySomething(3);
                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                NPCSaySomething(4);
                //wait for input
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.RightArrow));
                AdvanceCases(1);
                NPCTalkThenPanel(5, 1, 1);
                yield return waitForButton.Reset();
                if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                {
                    NPCTalkThenPanel(7, 2, 2);
                    yield return waitForButton.Reset();
                    if (waitForButton.PressedButton == AButton)
                    {
                        NPCTalkThenPanel(9, 3, 3);
                        yield return waitForButton.Reset();
                        if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                        {
                            EndConversation();
                            _gravity.Fall(3f);
                        }


                    }
                    else
                    {
                        NPCTalkThenPanel(8, 4, 4);
                        yield return waitForButton.Reset();
                        if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                        {
                            EndConversation();
                            _gravity.Fall(3f);
                        }
                    }



                }
                // yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.LeftArrow));
                // {
                //     AdvanceCases(1);
                //     NPCTalkThenPanel(6, 1, 1);
                //     yield return waitForButton.Reset();
                //     if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                //     {
                //         NPCTalkThenPanel(7, 2, 2);
                //         yield return waitForButton.Reset();
                //         if (waitForButton.PressedButton == AButton)
                //         {
                //             NPCTalkThenPanel(9, 3, 3);
                //             yield return waitForButton.Reset();
                //             if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                //             {
                //                 EndConversation();
                //                 _gravity.Fall(3f);
                //             }
                //         }

                //         else
                //         {
                //             NPCTalkThenPanel(8, 4, 4);
                //             yield return waitForButton.Reset();
                //             if (waitForButton.PressedButton == AButton || waitForButton.PressedButton == BButton)
                //             {
                //                 EndConversation();
                //                 _gravity.Fall(3f);
                //             }
                //         }

                //     }

                // }
            }
        }
    }
}