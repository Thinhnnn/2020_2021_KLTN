using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList
{
    //class chứa thông tin của nhiều kẻ địch trong một màn chơi
    public GameObject[] list;

    public GameObject GetInfo(string name)
    {
        for(int i = 0; i < list.Length; i++)
        {
            if (list[i].transform.name == name)
            {
                return list[i];
            }
        }
        return null;
    }

    public void a()
    {

    }
}
