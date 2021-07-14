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

    public GameObject[] gun;
    public int bulletPerOneShoot = 1;

    public bool isPlayer = false;
    string sound;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sound = randomSound();
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(updateRival());
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (nearestRival != null)
                {
                    if ((Vector3.Distance(transform.position, nearestRival.transform.position) < fightRange) && reloading == false)
                    {
                        StartCoroutine(normalShoot());
                    }
                }
            }
        }
        else
        {
            if (nearestRival != null)
            {
                if ((Vector3.Distance(transform.position, nearestRival.transform.position) < fightRange) && reloading == false)
                {
                    StartCoroutine(normalShoot());
                }
            }
        }
    }

    IEnumerator updateRival()
    {
        nearestRival = spaceshipManager.nearestRival(this.gameObject);
        yield return new WaitForSeconds(refreshTime);
        StartCoroutine(updateRival());
    }

    public string randomSound()
    {
        int i = Random.Range(0, 4);
        if (i == 0)
        {
            return "Shoot";
        }
        else if (i == 1)
        {
            return "Shoot2";
        }
        else if (i == 2)
        {
            return "Shoot3";
        }
        else
        {
            return "Shoot4";
        }
    }

    IEnumerator normalShoot()
    {
        reloading = true;
        switch (bulletPerOneShoot)
        {
            case 1: //mode bắn lần lượt từng viên
                {
                    for (int i = 0; i < ammount; i++)
                    {
                        //tạo ra âm thanh bắn
                        //var x = FindObjectOfType<AudioManager>();
                        //audioManager.PlaySound("Shoot");
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[0].transform.position, gun[0].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                    }
                    break;
                }
            case 2: //mode bắn 2 viên cùng lúc
                {
                    for (int i = 0; i < ammount; i+=2)
                    {
                        //tạo ra âm thanh bắn
                        //var x = FindObjectOfType<AudioManager>();
                        //audioManager.PlaySound("Shoot");
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[0].transform.position, gun[0].transform.rotation);
                        Instantiate(bullet, gun[1].transform.position, gun[1].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                    }
                    break; 
                }
            case 3: //mode bắn 3 viên cùng lúc
                {
                    for (int i = 0; i < ammount; i += 3)
                    {
                        //tạo ra âm thanh bắn
                        //var x = FindObjectOfType<AudioManager>();
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[0].transform.position, gun[0].transform.rotation);
                        Instantiate(bullet, gun[1].transform.position, gun[1].transform.rotation);
                        Instantiate(bullet, gun[2].transform.position, gun[2].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                    }
                    break; 
                }
            case 4: //mode bắn nhiều lần 2 viên
                {
                    for (int i = 0; i < ammount; i += 4)
                    {
                        //tạo ra âm thanh bắn
                        //var x = FindObjectOfType<AudioManager>();
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[i + 0].transform.position, gun[i + 0].transform.rotation);
                        Instantiate(bullet, gun[i + 1].transform.position, gun[i + 1].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[i + 2].transform.position, gun[i + 2].transform.rotation);
                        Instantiate(bullet, gun[i + 3].transform.position, gun[i + 3].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                    }
                    break; 
                }
            case 5: //mode bắn 5 viên cùng lúc
                {
                    for (int i = 0; i < ammount; i += 4)
                    {
                        //tạo ra âm thanh bắn
                        //var x = FindObjectOfType<AudioManager>();
                        audioManager.PlaySound(sound);
                        Instantiate(bullet, gun[0].transform.position, gun[0].transform.rotation);
                        Instantiate(bullet, gun[1].transform.position, gun[1].transform.rotation);
                        Instantiate(bullet, gun[2].transform.position, gun[2].transform.rotation);
                        Instantiate(bullet, gun[3].transform.position, gun[3].transform.rotation);
                        Instantiate(bullet, gun[4].transform.position, gun[4].transform.rotation);
                        yield return new WaitForSeconds(fireRate);
                    }
                    break; 
                }
        }
        
        yield return new WaitForSeconds(reloadTime);
        reloading = false;
    }
}
