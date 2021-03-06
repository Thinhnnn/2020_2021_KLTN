using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpManager : MonoBehaviour
{
    public GameObject HPBar;
    public Slider HPSlider;
    public Camera cam;
    public float maxHP = 1000f;
    public float currentHP = 1000f;

    public float bulletDmg = 2f;
    public float missleDmg = 10f;
    public float meteorDmg = 100f;
    public AudioManager audioManager;

    public GameObject explotion;

    public float multipleValue;
    // Start is called before the first frame update
    void Start()
    {
        getCamera();
        currentHP = maxHP;
        UpdateHP();
        audioManager = FindObjectOfType<AudioManager>();
        multipleValue = 1f;
        StartCoroutine(delayGetMultipleValue());
    }

    IEnumerator delayGetMultipleValue()
    {
        yield return new WaitForSeconds(1f);
        SaveAndLoad a = new SaveAndLoad();
        multipleValue = float.Parse(a.jetMultipleValue(a.selectedShip()));
        Debug.Log(multipleValue);
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(cam.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if ((gameObject.tag == "Enemy" && other.tag == "Bullet") || (gameObject.tag == "Ally" && other.tag == "EnemyBullet"))
        //{
        //    //currentHP -= 100f;
        //    currentHP -= 100f;
        //    UpdateHP();
        //}

        if(gameObject.tag == "Enemy")
        {
            if(other.tag == "Bullet")
            {
                currentHP -= bulletDmg;
            }
            else if(other.tag == "AllyMissle")
            {
                currentHP -= missleDmg;
            }
            else if (other.tag == "AllyMeteor")
            {
                currentHP -= meteorDmg;
            }

            else if (other.tag == "PlayerBullet")
            {
                currentHP -= bulletDmg * multipleValue;
            }
            else if (other.tag == "PlayerMissle")
            {
                currentHP -= missleDmg * multipleValue;
            }
            else if (other.tag == "PlayerMeteor")
            {
                currentHP -= meteorDmg * multipleValue;
            }
            UpdateHP();
        }
        else if (gameObject.tag == "Ally")
        {
            if (other.tag == "EnemyBullet")
            {
                currentHP -= bulletDmg;
            }
            else if (other.tag == "EnemyMissle")
            {
                currentHP -= missleDmg;
            }
            else if (other.tag == "EnemyMeteor")
            {
                currentHP -= meteorDmg;
            }
            UpdateHP();
        }
    }

    void UpdateHP()
    {
        float value = currentHP / maxHP;
        HPSlider.value = value;
        if (currentHP <= 0f)
        {
            gameObject.SetActive(false); 
            audioManager.PlaySound("Die");
            Instantiate(explotion, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
    }

    public void takeLaserDamage(float value)
    {
        currentHP -= value;
        UpdateHP();
    }

    #region tìm camera - vì sẽ có nhiều camera trong 1 scene, nên cần tìm đúng camera để look at
    void getCamera()
    {
        Camera[] listCam = FindObjectsOfType<Camera>();
        foreach(Camera camera in listCam)
        {
            if (camera.tag == "MainCamera")
            {
                cam = camera;
                break;
            }
        }
    }
    #endregion
}
