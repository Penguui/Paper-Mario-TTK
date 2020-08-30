using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class Saveload
{

    public static void Save(Data data)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.mario";
        FileStream stream = new FileStream(path, FileMode.Create);

        Savedata savedata = new Savedata(data);

        formatter.Serialize(stream, savedata);
        stream.Close();
    }

    public static void GeneralSave(Generaldata generaldata)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/generalsave.mario";
        FileStream stream = new FileStream(path, FileMode.Create);

        Savedata savedata = new Savedata(generaldata);

        formatter.Serialize(stream, savedata);
        stream.Close();
    }

    public static Savedata LoadSave()
    {
        string path = Application.persistentDataPath + "/save.mario";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Savedata savedata = formatter.Deserialize(stream) as Savedata;
            stream.Close();

            return savedata;

        }

        return null;
    }

    public static Savedata GeneralLoadSave()
    {
        string path = Application.persistentDataPath + "/generalsave.mario";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Savedata savedata = formatter.Deserialize(stream) as Savedata;
            stream.Close();

            return savedata;

        }

        return null;
    }

}
