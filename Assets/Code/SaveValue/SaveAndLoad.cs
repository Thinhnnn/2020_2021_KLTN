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
        //string path = "Assets/Code/SaveValue/Money.txt";
        //StreamReader reader = new StreamReader(path);
        //string value = reader.ReadToEnd();
        //reader.Close();
        //return int.Parse(value);
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Gold.txt");
        return int.Parse(value[0].ToString());
    }

    public float myPower(string fileName)
    {
        string path = "Assets/Code/SaveValue/" + fileName;
        StreamReader reader = new StreamReader(path);
        string value = reader.ReadToEnd();
        reader.Close();
        return float.Parse(value);
    }

    public string jetMultipleValue(int index)
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Multiple.txt");
        return value[index];
    }

    public void upgradeMultipleValue(int index)
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Multiple.txt");
        float currentValue = float.Parse(value[index]);
        value[index] = (currentValue + 0.25).ToString();
        File.WriteAllLines("Data/Jet/Multiple.txt", value);
    }

    public int unlockLevel()
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Level.txt");
        return int.Parse(value[0]);
    }

    public void makePayment()
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Gold.txt");
        float currentValue = float.Parse(value[0]);
        value[0] = (currentValue -1000).ToString();
        File.WriteAllLines("Data/Jet/Gold.txt", value);
    }

    public void addGold(int amount)
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Gold.txt");
        float currentValue = float.Parse(value[0]);
        value[0] = (currentValue + amount).ToString();
        File.WriteAllLines("Data/Jet/Gold.txt", value);
    }

    public int selectedShip()
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Selected.txt");
        return int.Parse(value[0]);
    }

    public void setSelectedShip(int index)
    {
        string[] value = System.IO.File.ReadAllLines("Data/Jet/Selected.txt");
        value[0] = index.ToString();
        File.WriteAllLines("Data/Jet/Selected.txt", value);
    }
}
