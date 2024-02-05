using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip note;
    [SerializeField] private string _noteType;
    [SerializeField] private float _outOfBoundsY;
    [SerializeField] private float _moveSpeed;

    [SerializeField] private Vector2 posToSpawn;


    [SerializeField] private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GameObject.Find("Keyboard").GetComponent<AudioSource>();
    }

    public string GetNote()
    {
        return _noteType;
    }

    public Vector2 GetSpawnPos()
    {
        return posToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * _moveSpeed *
                    Time.deltaTime;
        if (transform.position.y > _outOfBoundsY)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource.clip = note;
        _audioSource.Play();
    }

}
