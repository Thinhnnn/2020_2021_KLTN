using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionSaveLoad : MonoBehaviour
{
    public Text money;
    SaveAndLoad a;
    public MenuUIEvent eventUpgrade;

    // Start is called before the first frame update
    void Start()
    {
        a = new SaveAndLoad();
        money.text = a.MyMoney().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void jetUpgrade()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        if (a.MyMoney() >= 1000)
        {
            int newMoney = a.MyMoney() - 1000;
            a.WriteString("Money.txt", newMoney.ToString());
            money.text = a.MyMoney().ToString();
            eventUpgrade.jetUpgrade();
        }
    }
}
