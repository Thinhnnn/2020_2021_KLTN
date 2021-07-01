using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
    //class chứa các thông tin và trạng thái của kẻ địch

    public bool alive;
    //public GameObject HPBar;
    //public Slider slider;

    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public float damage = 20f;

    public GameObject dieEffect;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        UpdateSlider();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlider();
        //if (currentHealth < maxHealth)
        //{
        //    HPBar.SetActive(true);
        //}
        if (currentHealth <= 0)
        {
            Die();
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    void UpdateSlider()
    {
        float value = currentHealth / maxHealth;
        //slider.value = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        //hàm xử lý va chạm

        if (other.tag == "Bullet") //nếu bị bắn bởi đạn
        {
            //tạo âm thanh va chạm
            var x = FindObjectOfType<AudioManager>();
            x.PlaySound("Explotion");
            currentHealth -= StaticClass.normalShootDmg;
        }
        else if (other.tag == "Missle") //nếu bị bắn bởi đạn tìm đường
        {
            //tạo âm thanh va chạm
            var x = FindObjectOfType<AudioManager>();
            x.PlaySound("Explotion");
            currentHealth -= StaticClass.missleDmg;
        }
        else if (other.tag == "Bomb") //nếu bị bắn bởi bom
        {
            Debug.Log(StaticClass.bossShoot);
            currentHealth -= StaticClass.ultimateDmg;
        }
    }

    public void Die()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Die");
        Instantiate(dieEffect, transform.position, transform.rotation);
        alive = false;
        gameObject.SetActive(false);
    }

}
