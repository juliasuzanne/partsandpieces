using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(Camera))]
public class SnapshotCam : MonoBehaviour
{
    Camera snapCam;
    [SerializeField] private CaveSaveSettings _saveSettings;
    string newestFileName;
    int resWidth = 512;
    int resHeight = 512;
    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(resWidth, resHeight, 24);
        }
        else
        {
            resWidth = snapCam.targetTexture.width;
            resHeight = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);

    }

    // Update is called once per frame

    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        //create texture, applying render to texture, turn into file and save
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(resWidth, resHeight, TextureFormat.RGBA32, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            byte[] bytes = ImageConversion.EncodeToPNG(snapshot);
            string fileName = SnapshotName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log(fileName);
            AssetDatabase.Refresh();
            _saveSettings.SaveSandwichPath1(fileName);
            Debug.Log("Snapshot taken!");
            snapCam.gameObject.SetActive(false);
        }

    }

    public string GetFileName()
    {
        return newestFileName;
    }

    string SnapshotName()
    // string fullPath = Application.persistentDataPath + directory + fileName;
    {
        return string.Format("{0}/Resources/Snapshots/snap_{1}x{2}_{3}.png",
        Application.dataPath,
        resWidth,
        resHeight,
        System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }

}
