using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorStairState : MonoBehaviour
{
    [SerializeField] private GameObject openVault;
    [SerializeField] private GameObject closeVault;
    [SerializeField] private GameObject items;

    private CaveSaveSettings _saveManager;

    // Start is called before the first frame update
    void Start()
    {
        _saveManager = FindObjectOfType<CaveSaveSettings>();
        openVault.SetActive(_saveManager.so.stateOfExteriorSceneList.Contains("openVault"));
        closeVault.SetActive(!_saveManager.so.stateOfExteriorSceneList.Contains("openVault"));
        items.SetActive(!_saveManager.so.stateOfExteriorSceneList.Contains("vaultItems"));

    }

    // Update is called once per frame
    void Update()
    {

    }
}
