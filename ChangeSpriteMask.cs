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
    private int arrCount;
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
        for (int i = 0; i < _sprites.Length; i++)
        {
            yield return new WaitForSeconds(_timeToChange);
            _spriteMask.sprite = _sprites[i];
            if (i == 14)
            {
                i = -1;
            }
        }

    }
}
