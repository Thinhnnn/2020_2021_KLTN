using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartShoot : MonoBehaviour
{
    #region khai báo các biến
    public SpaceshipManager spaceshipManager;
    public AudioManager audioManager;
    public GameObject nearestRival;
    public float refreshTime = 1f;

    public float fightRange = 1500f;
    public GameObject aimVector;
    public GameObject bullet;
    public int ammount = 3;
    public float fireRate = .2f;
    public float reloadTime = 1f;
    public bool reloading;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(updateRival());
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestRival != null)
        {
            if ((Vector3.Distance(transform.position, nearestRival.transform.position) < fightRange) && reloading == false)
            {
                StartCoroutine(normalShoot());
            }
        }
    }

    IEnumerator updateRival()
    {
        nearestRival = spaceshipManager.nearestRival(this.gameObject);
        yield return new WaitForSeconds(refreshTime);
        StartCoroutine(updateRival());
    }

    IEnumerator normalShoot()
    {
        reloading = true;
        for(int i = 0; i < ammount; i++)
        {
            //tạo ra âm thanh bắn
            //var x = FindObjectOfType<AudioManager>();
            audioManager.PlaySound("Shoot");
            Instantiate(bullet, aimVector.transform.position, aimVector.transform.rotation); 
            yield return new WaitForSeconds(fireRate);
        }
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
