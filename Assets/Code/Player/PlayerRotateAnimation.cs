using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateAnimation : MonoBehaviour
{
    //class tạo hiệu ứng tàu nghiêng qua khi chuyển hướng

    public float curveAmount = 20f; //độ nghiêng của tàu

    GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        ship = GetChildObject(transform, "Ally");
        
    } 

    // Update is called once per frame
    void Update()
    {
        float curve = Input.GetAxis("Horizontal"); //xác định hướng mà tàu chuyển hướng
        if (ship != null)
        {
            ship.transform.localRotation = Quaternion.Euler(0f, 0f, -curve * curveAmount); //hàm nghiêng người
        }
        
    }

    public GameObject GetChildObject(Transform parent, string _tag)
    {
        GameObject result = new GameObject();
        bool found = false;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                result = child.gameObject;
                found = true;
                break;
            }
        }
        if (found)
        {
            return result;
        }
        else
        {
            return null;
        }
    }
}
