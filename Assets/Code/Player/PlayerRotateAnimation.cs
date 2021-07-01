using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotateAnimation : MonoBehaviour
{
    //class tạo hiệu ứng tàu nghiêng qua khi chuyển hướng

    public float curveAmount = 20f; //độ nghiêng của tàu
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float curve = Input.GetAxis("Horizontal"); //xác định hướng mà tàu chuyển hướng
        transform.localRotation = Quaternion.Euler(0f, 0f, -curve * curveAmount); //hàm nghiêng người
    }
}
