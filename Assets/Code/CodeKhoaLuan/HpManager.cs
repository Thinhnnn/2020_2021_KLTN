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
    // Start is called before the first frame update
    void Start()
    {
        getCamera();
        currentHP = maxHP;
        UpdateHP();
    }

    // Update is called once per frame
    void Update()
    {
        HPBar.transform.LookAt(cam.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((gameObject.tag == "Enemy" && other.tag == "Bullet") || (gameObject.tag == "Ally" && other.tag == "EnemyBullet"))
        {
            currentHP -= 100f;
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
        }
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
