using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGetDamage : MonoBehaviour
{
    public Slider HPBar;

    public float maxHP = 100f;
    public float currentHP = 100f;

    public Shake_Camera shake;

    public float duration = 0.15f;
    public float magnitude = 0.4f;

    public GameObject jet;
    public GameObject dieEffect;
    public bool died = false;

    public GameObject losePanel;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            currentHP = 0;
            if (!died)
            {
                died = true;
                Die();
            }
        }
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("shaked");
            //DoShake();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullet")
        {
            var x = FindObjectOfType<AudioManager>();
            x.PlaySound("Explotion");
            //StartCoroutine(shake.Shake(duration, magnitude));
            currentHP -= StaticClass.enemyShoot;
            LoadHP();
        }
        else if (other.tag == "BossBullet")
        {
            var x = FindObjectOfType<AudioManager>();
            x.PlaySound("Explotion");
            //StartCoroutine(shake.Shake(duration, magnitude));
            currentHP -= StaticClass.bossShoot;
            LoadHP();
        }
    }

    void LoadHP()
    {
        HPBar.value = (currentHP / maxHP);
    }

    public void Die()
    {
        jet.SetActive(false);
        StartCoroutine(castDieAnimation());
    }
    IEnumerator castDieAnimation()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Die");
        Instantiate(dieEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        losePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
