using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Savedata
{
    //playerdata
    public int coinCount;
    public bool file1Created;
    public string[] fileNames = new string[4] { "a", "a", "a", "a" };
    public int[] files;

    public Savedata(Data data)
    {
        coinCount = data.coinCount;
        file1Created = data.file1Created;
    }

    public Savedata(Generaldata generaldata)
    {
        fileNames = generaldata.fileNames;
        files = new int[4];
        files[0] = generaldata.files[0];
        files[1] = generaldata.files[1];
        files[2] = generaldata.files[2];
        files[3] = generaldata.files[3];
    }
}

