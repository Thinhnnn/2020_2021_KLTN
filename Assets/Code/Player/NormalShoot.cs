using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoot : MonoBehaviour
{
    //class xử lý hành động bắn đạn thường của player

    public GameObject ObjectToShoot;    //vật thể được bắn ra
    public Transform direct;            //hướng bắn ra của đạn

    public float reloadTime = 0.2f;
    public bool isReload = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lateUpdate sẽ được gọi sau khi các hàm update của các class khác được chạy
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0)   //Fire1 mặc định là nút chuột trái
        {
            
            //gọi hàm bắn đạn
            Shoot();
        }
    }

    void Shoot()
    {
        //hàm bắn đạn
        if (!isReload)
        {
            //tạo ra âm thanh bắn
            var x = FindObjectOfType<AudioManager>();
            x.PlaySound("Shoot");
            Instantiate(ObjectToShoot, direct.position, direct.rotation);
            isReload = true;
            StartCoroutine(reload());
        }
        
    }

    IEnumerator reload()
    {
        yield return new WaitForSeconds(reloadTime);
        isReload = false;
    }
}
