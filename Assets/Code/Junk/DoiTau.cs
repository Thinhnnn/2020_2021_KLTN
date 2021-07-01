using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoiTau : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //tạo 1 vecto lưu khoảng cách dịch chuyển của camera
        Vector3 move = new Vector3(100f, 0f, 0f);
        //nếu nhấn nút A, dịch trái camera 1 khoảng
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += move * -1;
        }
        //nếu nhấn nút D, dịch phải camera 1 khoảng
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += move * 1;
        }
    }
}
