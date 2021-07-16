using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpaceshipManager : MonoBehaviour
{
    #region khởi tạo các biến
    public GameObject[] Allies;
    public GameObject[] Enemys;
    public float refreshTime = 1f;
    public GameObject winPanel, losePanel;

    public TextMeshProUGUI allyCount, enemyCount;

    bool winAnimation = false;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        allyCount.text = "";
        enemyCount.text = "";
        //StartCoroutine(delayShipCount());
        StartCoroutine(UpdateList());
    }

    IEnumerator delayShipCount()
    {
        yield return new WaitForSeconds(1f);
        allyCount.text = Allies.Length.ToString();
        enemyCount.text = Enemys.Length.ToString();
    }

    #region cập nhật danh sách các đối tượng
    public void getAllAllies()
    {
        Allies = GameObject.FindGameObjectsWithTag("Ally");
    }
    public void getAllEnemys()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Enemy");
    }
    #endregion

    public GameObject nearestRival(GameObject self)
    {
        int nearestIndex = 0;
        if (self.tag == "Enemy" || self.tag == "EnemyMissle")
        {
            for (int i = 1; i < Allies.Length; i++)
            {
                if (Vector3.Distance(self.transform.position, Allies[i].transform.position) < Vector3.Distance(self.transform.position, Allies[nearestIndex].transform.position))
                {
                    nearestIndex = i;
                }
            }
            return Allies[nearestIndex];
        }
        else if (self.tag == "Ally" || self.tag == "AllyMissle")
        {
            for (int i = 1; i < Enemys.Length; i++)
            {
                if (Vector3.Distance(self.transform.position, Enemys[i].transform.position) < Vector3.Distance(self.transform.position, Enemys[nearestIndex].transform.position))
                {
                    nearestIndex = i;
                }
            }
            return Enemys[nearestIndex];
        }
        else
        {
            return self;
        }
    }

    IEnumerator UpdateList()
    {
        allyCount.text = Allies.Length.ToString();
        enemyCount.text = Enemys.Length.ToString();
        getAllAllies();
        getAllEnemys();
        yield return new WaitForSeconds(refreshTime);
        if (Enemys.Length == 0 && winAnimation == false)
        {
            winAnimation = true;
            StartCoroutine(Win());
        }
        else
        {
            winAnimation = false;
        }
        StartCoroutine(UpdateList());
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(3f);
        winPanel.SetActive(true);
        SaveAndLoad s = new SaveAndLoad();
        if(CacheLevel.currentLevel == s.unlockLevel() - 1)
        {
            s.unlockNewLevel();
        }
        s.addGold(1500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
