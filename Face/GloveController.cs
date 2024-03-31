using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GloveController : MonoBehaviour
{
    private Vector3 _startingPos;
    private Vector3 _moveToPos;
    private GameObject _currentGlove;
    [SerializeField] private GameObject textMeshPro;
    // [SerializeField] Cinemachine.CinemachineVirtualCamera c_VirtualCamera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (_currentGlove != null)
        {
            textMeshPro.SetActive(true);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 moveToPos = new Vector3(mousePosition.x, mousePosition.y, _currentGlove.transform.position.z);
            _currentGlove.transform.position = moveToPos;

        }
        else
        {
            textMeshPro.SetActive(false);

        }
        if (Input.GetKeyDown("x"))
        {
            Debug.Log("X key was pressed");
            DropItem();

        }



    }

    public GameObject GetCurrentItem()
    {
        return _currentGlove;
    }


    public void ChangeItem(GameObject item)
    {
        _currentGlove = item;
        // c_VirtualCamera.m_LookAt = item.transform.GetChild(1).transform;
        // c_VirtualCamera.m_Follow = item.transform.GetChild(1).transform;

    }

    public void DropItem()
    {
        _currentGlove = null;

    }

    public void MakeItemNull()
    {
        if (_currentGlove != null)
        {
            Vector3 posToMove = new Vector3(_currentGlove.transform.position.x, _currentGlove.transform.position.y, _currentGlove.transform.position.z);
            _currentGlove.transform.position = posToMove;
            _currentGlove = null;

        }


    }



}
