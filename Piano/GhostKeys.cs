using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostKeys : MonoBehaviour
{
  [SerializeField] private GameObject[] _playerNotes;
  [SerializeField] private int[] _melody;
  [SerializeField] private int _timeBetweenNotes;

  void Start()
  {
    // _audioSource = GameObject.Find("Keyboard").GetComponent<AudioSource>();
    StartCoroutine("PlayMelody");
  }

  IEnumerator PlayMelody()
  {
    for (int i = 0; i < _melody.Length; i++)
    {
      yield return new WaitForSeconds(_timeBetweenNotes);
      PlayAsNextNote(_melody[i]);
    }

  }

  public void PlayAsNextNote(int note)
  {
    Instantiate(_playerNotes[note], _playerNotes[note].GetComponent<Key>().GetSpawnPos(), Quaternion.identity);
  }


  // Update is called once per frame
  void Update()
  {
    transform.position += transform.up *
               10 * Time.deltaTime;

  }

  // void OnTriggerEnter2D(Collider2D other)
  // {
  //   _audioSource.clip = note;
  //   _audioSource.Play();
  // }

}
