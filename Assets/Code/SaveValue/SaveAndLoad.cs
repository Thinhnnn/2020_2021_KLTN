using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveAndLoad
{
    public void WriteString(string fileName, string value)
    {
        string path = "Assets/Code/SaveValue/" + fileName;

        File.WriteAllText(path, value);
    }

    public void ReadString(string fileName)
    {
        string path = "Assets/Code/SaveValue/" + fileName;

        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }

    public int MyMoney()
    {
        string path = "Assets/Code/SaveValue/Money.txt";
        StreamReader reader = new StreamReader(path);
        string value = reader.ReadToEnd();
        reader.Close();
        return int.Parse(value);
    }

    public float myPower(string fileName)
    {
        string path = "Assets/Code/SaveValue/" + fileName;
        StreamReader reader = new StreamReader(path);
        string value = reader.ReadToEnd();
        reader.Close();
        return float.Parse(value);
    }
}
