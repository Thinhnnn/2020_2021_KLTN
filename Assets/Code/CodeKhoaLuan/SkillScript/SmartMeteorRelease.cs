using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMeteorRelease : MonoBehaviour
{
    public int amount = 1;
    public GameObject[] gun;
    public float reloadTime = 20f;
    public GameObject meteor;
    public int mode = 1;
    public float fireRate = 2f;

    public bool isPlayer = false;
    public bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayer)
        {
            StartCoroutine(releaseMeteor());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading)
            {
                StartCoroutine(playerReleaseMeteor());
            }
        }
    }

    IEnumerator releaseMeteor()
    {
        if (mode == 1)
        {
            yield return new WaitForSeconds(reloadTime);
            for (int i = 0; i < amount; i++)
            {
                Instantiate(meteor, gun[i].transform.position, gun[i].transform.rotation);
            }
        }
        else if (mode == 2)
        {
            yield return new WaitForSeconds(reloadTime);
            for (int i = 0; i < amount; i++)
            {
                Instantiate(meteor, gun[0].transform.position, gun[0].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
        StartCoroutine(releaseMeteor());
    }

    IEnumerator playerReleaseMeteor()
    {
        isReloading = true;
        if (mode == 1)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(meteor, gun[i].transform.position, gun[i].transform.rotation);
            }
            yield return new WaitForSeconds(reloadTime);
            isReloading = false;
        }
        else if (mode == 2)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(meteor, gun[0].transform.position, gun[0].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForSeconds(reloadTime - fireRate * amount);
            isReloading = false;
        }
    }
}
