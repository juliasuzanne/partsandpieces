using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SetCutArmsTriggers : MonoBehaviour
{
    [SerializeField] UnityEvent onTrigger;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private CaveSaveSettings saveManager;

    [SerializeField] private bool consumable;
    // Start is called before the first frame update

    void Start()
    {
        if (saveManager == null)
        {
            saveManager = FindObjectOfType<CaveSaveSettings>();

        }
    }
    public void TriggerCutArms()
    {
        saveManager.CutOffArms();
        saveManager.ChangeStateOfLab("cutArms");
        onTrigger.Invoke();

        if (consumable == true)
        {
            Destroy(this.gameObject);
        }
    }

    public void PlaySound()
    {
        _audioSource.Play();
    }

}
