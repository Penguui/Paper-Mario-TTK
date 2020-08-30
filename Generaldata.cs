using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Generaldata : MonoBehaviour
{

    //world data
    public string[] fileNames = new string[4] { "a", "a", "a", "a" };
    public int[] files = new int[4] { 5, 5, 5, 5 };


    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        Saveload.GeneralSave(this);
    }

    public void LoadData()
    {
        Savedata savedata = Saveload.GeneralLoadSave();

        fileNames = savedata.fileNames;
        files = savedata.files;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            LoadData();
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
