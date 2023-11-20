using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteMask : MonoBehaviour
{
    [SerializeField]
    private SpriteMask _spriteMask;
    private Sprite _sprite;
    [SerializeField]
    private float _timeToChange = 5f;
    [SerializeField]
    private Sprite[] _sprites;
    // Start is called before the first frame update
    void Start()
    {
        _spriteMask = GetComponent<SpriteMask>();
        _sprite = _spriteMask.sprite;
        StartCoroutine("GetNextSpriteMask");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_spriteMask.sprite.name);

    }

    IEnumerator GetNextSpriteMask()
    {

        yield return new WaitForSeconds(_timeToChange);
        Debug.Log("SUPPOSED TO CHANGE 1");
        _spriteMask.sprite = _sprites[1];
        yield return new WaitForSeconds(_timeToChange);
        Debug.Log("SUPPOSED TO CHANGE 2");
        _spriteMask.sprite = _sprites[2];

    }
}
