using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipManager : MonoBehaviour
{
    #region khởi tạo các biến
    public GameObject[] Allies;
    public GameObject[] Enemys;
    public float refreshTime = 1f;
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(UpdateList());
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
        getAllAllies();
        getAllEnemys();
        yield return new WaitForSeconds(refreshTime);
        StartCoroutine(UpdateList());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
