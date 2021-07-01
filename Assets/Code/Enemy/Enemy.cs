using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //không dùng class này nữa


    //class chứa các thông tin và trạng thái của kẻ địch

    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //hàm xử lý va chạm

        if (other.tag == "Bullet") //nếu bị bắn bởi đạn
        {
            //tạo âm thanh va chạm
            var x = FindObjectOfType<AudioGameplayManager>();
            x.Play("Explotion");
            //tự hủy
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        gameObject.SetActive(false);
    }
}
