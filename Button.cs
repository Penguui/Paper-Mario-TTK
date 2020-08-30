using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool closed;
    public Animator animator;
    public Animator ncAnimator;
    public int fileNum;
    public bool canStartFile = true;

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "Button (0)")
        {
            fileNum = 1;
        } else if (this.gameObject.name == "Button (1)")
        {
            fileNum = 2;
        } else if (this.gameObject.name == "Button (2)")
        {
            fileNum = 3;
        } else if (this.gameObject.name == "Button (3)")
        {
            fileNum = 4;
        }
    }

    // Update is called once per frame
    void Update()
    { 

        Debug.Log(FileCreated(fileNum));

        animator = GetComponent<Animator>();
        ncAnimator = GameObject.Find("NameCreator").GetComponent<Animator>();

        if (FileCreated(fileNum) == true)
        {
            GameObject.Find("FileName" + (fileNum - 1)).GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Data").GetComponent<Generaldata>().fileNames[fileNum - 1];
        }
    }

    public void StartFile()
    {
        canStartFile = false;
        StartCoroutine(Close());
        GameObject.Find("NameCreator").GetComponent<NameCreator>().fileNum = fileNum;
        if (!FileCreated(fileNum))
        {
            Debug.Log("gotto3");
            GameObject.Find("NameCreator").GetComponent<NameCreator>().beginNameEnter = true;
            canStartFile = true;
        } else
        {
            Debug.Log("ERROR");
            canStartFile = true;
        }

    }

    IEnumerator Close()
    {
        

        Debug.Log("Coroutine started for : " + fileNum);

        
        for (int i = 0; i < 4; i++)
        {
            GameObject.Find("Button (" + i + ")").GetComponent<Animator>().Play("New Animation");
        }
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length / 2);
        Debug.Log("gotto1");
        GameObject.Find("NameCreator").GetComponent<Animator>().Play("open");
        Debug.Log("gotto2");
        yield return new WaitForSeconds(GameObject.Find("NameCreator").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        StopAllCoroutines();
        
    }

    public bool FileCreated(int file)
    {
        if (Array.Exists(GameObject.Find("Data").GetComponent<Generaldata>().files, element => element == file))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void createFile(int fileToCreate)
    {
        GameObject.Find("Data").GetComponent<Generaldata>().files[fileToCreate - 1] = fileToCreate;
        return;
    }
}
