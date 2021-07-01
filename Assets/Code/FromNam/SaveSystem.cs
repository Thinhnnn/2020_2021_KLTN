using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static string path = Application.dataPath + "/settings.txt";

    public static void SaveSetting(Setting setting)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream fs = new FileStream(path, FileMode.Create);

        SettingData data = new SettingData(setting);

        formatter.Serialize(fs, data);
        fs.Close();
    }

    public static SettingData LoadData()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            SettingData data = formatter.Deserialize(fs) as SettingData;
            fs.Close();

            return data;
        }
        else
        {
            //Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
