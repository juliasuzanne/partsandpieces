using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private SpriteRenderer sp;
    [SerializeField]
    private Sprite _newSprite;


    // Start is called before the first frame update
    void Start()
    {
        sp = transform.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void ChangeTheSprite()
    {
        sp.sprite = _newSprite;
    }
}
