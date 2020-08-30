using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Data : MonoBehaviour
{
    //player data
    public int coinCount;
    public int starPoints;
    public int health;
    public int level;

    //world data
    public int chapter;
    public bool file1Created;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void SaveData()
    {
        Saveload.Save(this);
    }

    public void LoadData()
    {
        Savedata savedata = Saveload.LoadSave();

        coinCount = savedata.coinCount;
        file1Created = savedata.file1Created;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LoadData();
        }

    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
