using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookEnemy : MonoBehaviour
{
    public EnemyHPManager HPBar;
    //class xác định mục tiêu để bắn

    public float range = 300f;      //khoảng cách xa nhất có thể xác định được kẻ địch
    public GameObject LookAtEnemy;  //biến lưu thông tin hướng nhắm mà player sẽ bắn
    public GameObject[] Enemy;      //mảng các kẻ địch có trong scene này
    GameObject LookedEnemy;         //biến lưu thông tin kẻ địch đang nhắm vào
    public float maxAimAngle = 45f;        //giới gạn góc bắn, nếu kẻ địch nằm ở góc lệch quá lớn, không thể nhắm vào kẻ địch đó

    public GameObject basicAim;      //biến lưu hướng nhắm mặc định, nếu không nhắm vào kẻ địch sẽ nhìn theo hướng này

    public Camera cam;              //biến camera
    public string TargetName = null;

    public GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        LookedEnemy = basicAim;     //gán đối tượng ngắm bắn mặc định
        LookAtEnemy.transform.LookAt(basicAim.transform);   //gán hướng nhắm mặc định
        //Enemy = GameObject.FindGameObjectsWithTag("Enemy");     //thêm tất cả các kẻ địch trong scene vào mảng kẻ địch
        LoadEnemy();
    }

    public void LoadEnemy()
    {
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        GetEnemy();
        LookAtEnemy.transform.LookAt(LookedEnemy.transform);    //hàm chuyển hướng nhắm thẳng vào kẻ địch đã được xác định
        
        float currentAngle = Vector3.Angle(LookAtEnemy.transform.forward, basicAim.transform.forward);
        if (currentAngle > maxAimAngle)
        {
            LookedEnemy = basicAim;     //gán đối tượng ngắm bắn mặc định
            LookAtEnemy.transform.LookAt(basicAim.transform);   //gán hướng nhắm mặc định
        }
    }

    void GetEnemy()
    {
        RaycastHit hit; //khởi tạo 1 biến để nhận về thông tin đối tượng bắt được (nếu có)
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)) //nếu hướng nhìn hiện tại có gì đó
        {
            if (hit.transform.name != null && hit.transform.tag == "Enemy")
            {
                //Debug.Log(hit.transform.name);
                crosshair.SetActive(true);
                TargetName = hit.transform.name;
                LookedEnemy = GetInfo(hit.transform.name);
                HPBar.GetTarget(hit.transform.name);
            }
            else
            {
                crosshair.SetActive(false);
                LookedEnemy = basicAim;
            }
        }
        else
        {
            crosshair.SetActive(false);
            LookedEnemy = basicAim;
        }
    }

    public GameObject GetInfo(string name)
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].transform.name == name)
            {
                return Enemy[i];
            }
        }
        return null;
    }
}
