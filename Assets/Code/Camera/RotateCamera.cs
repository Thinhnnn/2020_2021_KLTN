using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    //class xử lý xoay góc nhìn theo thao tác chuột

    public float mouseSensitivity = 200f; //độ nhạy chuột
    public float maxRotateAngle = 15f; //góc xoay lên/xuống tối đa

    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SettingData data = SaveSystem.LoadData();
        if (data != null)
        {
            mouseSensitivity = data.speed_mouse;
        }
        else
        {
            mouseSensitivity = 200f;
        }
        //lấy thông tin thay đổi tọa độ của chuột
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxRotateAngle, maxRotateAngle);  //giới hạn góc nhìn lên và xuống
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f); //hàm xoay
        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
