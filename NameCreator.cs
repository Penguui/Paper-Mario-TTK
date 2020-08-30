using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCreator : MonoBehaviour
{
    public string fileName;
    public int fileNum;
    public bool nameEntered;
    public bool beginNameEnter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("fileNum: " + fileNum);
        Debug.Log(beginNameEnter);

        if (beginNameEnter == true && GameObject.Find("Button (" + (fileNum - 1) + ")").GetComponent<Button>().FileCreated(fileNum) == false)
        {
            if (nameEntered == false)
            {
                Debug.Log("enter name");

                if (!Input.GetKeyDown(KeyCode.Backspace))
                {
                    foreach (char letter in Input.inputString)
                    {
                        if (fileName.Length < 10)
                        {
                            fileName += letter;
                        }
                    }
                }

                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    fileName = fileName.Substring(0, fileName.Length - 1);
                }

                GameObject.Find("Name").GetComponent<UnityEngine.UI.Text>().text = fileName;

                if (Input.GetKeyDown(KeyCode.Return))
                {
                    nameEntered = true;
                }
            }
            else
            {
                GameObject.Find("Name").GetComponent<UnityEngine.UI.Text>().text = "";
                GameObject.Find("Button (" + (fileNum - 1) + ")").GetComponent<Button>().createFile(fileNum);
                GameObject.Find("Data").GetComponent<Generaldata>().fileNames[fileNum - 1] = fileName;
            }
        } else if (GameObject.Find("Button (" + (fileNum - 1) + ")").GetComponent<Button>().FileCreated(fileNum) == true)
        {
            GameObject.Find("Text").GetComponent<UnityEngine.UI.Text>().text = "File " + fileNum + " : " + GameObject.Find("Data").GetComponent<Generaldata>().fileNames[fileNum - 1];
        }
    }
}
