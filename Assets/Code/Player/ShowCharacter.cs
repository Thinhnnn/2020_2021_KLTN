using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public int selectedChar = 1;

    public GameObject[] jetList;

    SaveAndLoad a;
    // Start is called before the first frame update
    void Start()
    {
        a = new SaveAndLoad();
        selectedChar = StaticClass.jetIndex;
        HideAllJet();
        LoadPower();
        jetList[selectedChar - 1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void HideAllJet()
    {
        foreach(GameObject jet in jetList)
        {
            jet.SetActive(false);
        }
    }

    public void LoadPower()
    {
        float multipleValue = 1;
        switch (selectedChar)
        {
            case 1: { multipleValue = a.myPower("jet1.txt"); break; }
            case 2: { multipleValue = a.myPower("jet2.txt"); break; }
            case 3: { multipleValue = a.myPower("jet3.txt"); break; }
        }
        StaticClass.normalShootDmg = StaticClass.normalShootDmg * multipleValue;
        StaticClass.missleDmg = StaticClass.missleDmg * multipleValue;
        StaticClass.ultimateDmg = StaticClass.ultimateDmg * multipleValue;
    }
}
