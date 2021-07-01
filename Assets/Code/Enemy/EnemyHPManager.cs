using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHPManager : MonoBehaviour
{
    public GameObject HPBar;
    public Slider slider;
    public Text EnemyName;

    public EnemyHP[] enemyHP;

    public EnemyHP currentEnemy;

    public float damage = 20f;

    public GameObject winPanel;
    public GameObject[] enemy;

    public GameObject Boss;
    public bool bossFight = false;
    public LookEnemy reloadEnemyList;

    SaveAndLoad a;
    // Start is called before the first frame update
    void Start()
    {
        a = new SaveAndLoad();
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //GetTarget(FindObjectOfType<LookEnemy>().TargetName);
        if (currentEnemy != null && currentEnemy.currentHealth > 0)
        {
            HPBar.SetActive(true);
            UpdateSlider();
        }
        else
        {
            HPBar.SetActive(false);
            CheckWin();
        }
    }

    void UpdateSlider()
    {
        float value = currentEnemy.currentHealth / currentEnemy.maxHealth;
        slider.value = value;
    }

    public void GetTarget(string name)
    {
        HPBar.SetActive(true);
        EnemyName.text = name;
        EnemyHP target = Array.Find(enemyHP, a => a.name == name);
        currentEnemy = target;
    }

    public void CheckWin()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemy.Length == 0 && bossFight == false)
        {
            StartCoroutine(changeBGM());
        }
        else if(enemy.Length == 0 && bossFight)
        {
            StartCoroutine(win());
        }
    }

    IEnumerator changeBGM()
    {
        var x = FindObjectOfType<AudioManager>();
        x.StopMusic("BGM");
        yield return new WaitForSeconds(2);
        Boss.SetActive(true);
        bossFight = true;
        reloadEnemyList.LoadEnemy();
        x.PlayMusic("BossBGM");
    }
     IEnumerator win()
    {
        yield return new WaitForSeconds(1);
        int newMoney = a.MyMoney() + 1500;
        a.WriteString("Money.txt", newMoney.ToString());
        winPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
