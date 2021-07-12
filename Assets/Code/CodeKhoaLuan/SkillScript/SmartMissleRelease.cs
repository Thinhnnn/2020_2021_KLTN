using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMissleRelease : MonoBehaviour
{
    public int amount = 1;      //không dùng
    public GameObject[] gun;
    public float reloadTime = 20f;
    public GameObject missle;
    public int mode = 1;
    public float fireRate = 0.5f;

    public bool isPlayer = false;
    public bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayer)
        {
            StartCoroutine(releaseMissle());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1) && !isReloading)
            {
                StartCoroutine(playerReleaseMissle());
            }
        }
    }

    IEnumerator releaseMissle()
    {
        if (mode == 1)
        {
            yield return new WaitForSeconds(reloadTime);
            for (int i = 0; i < amount; i++)
            {
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
            }
        }
        else if (mode == 2)
        {
            yield return new WaitForSeconds(reloadTime);
            for (int i = 0; i < amount; i++)
            {
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
        StartCoroutine(releaseMissle());
    }

    IEnumerator playerReleaseMissle()
    {
        isReloading = true;
        if (mode == 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
            }
            yield return new WaitForSeconds(reloadTime);
            isReloading = false;
        }
        else if (mode == 2)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForSeconds(reloadTime - fireRate * amount);
            isReloading = false;
        }
    }
}
