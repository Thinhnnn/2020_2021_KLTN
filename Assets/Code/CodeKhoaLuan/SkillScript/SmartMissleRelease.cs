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
    public AudioManager audioManager;

    public bool isPlayer = false;
    public bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayer)
        {
            StartCoroutine(releaseMissle());
        }
        audioManager = FindObjectOfType<AudioManager>();
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

    public string randomSound()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            return "Missle";
        }
        else
        {
            return "Missle2";
        }
    }

    IEnumerator releaseMissle()
    {
        string sound = randomSound();
        if (mode == 1)
        {
            yield return new WaitForSeconds(reloadTime);
            audioManager.PlaySound(sound);
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
                audioManager.PlaySound(sound);
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
        StartCoroutine(releaseMissle());
    }

    IEnumerator playerReleaseMissle()
    {
        string sound = randomSound();
        isReloading = true;
        if (mode == 1)
        {
            audioManager.PlaySound(sound);
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
                audioManager.PlaySound(sound);
                Instantiate(missle, gun[i].transform.position, gun[i].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForSeconds(reloadTime - fireRate * amount);
            isReloading = false;
        }
    }
}
