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
    public AudioManager audioManager;

    public bool isPlayer = false;
    public bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!isPlayer)
        {
            StartCoroutine(releaseMeteor());
        }
        audioManager = FindObjectOfType<AudioManager>();
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
    public string randomSound()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            return "Meteor1";
        }
        else
        {
            return "Meteor2";
        }
    }

    IEnumerator releaseMeteor()
    {
        string sound = randomSound();
        if (mode == 1)
        {
            yield return new WaitForSeconds(reloadTime); 
            audioManager.PlaySound(sound);
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
                audioManager.PlaySound(sound);
                Instantiate(meteor, gun[0].transform.position, gun[0].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
        }
        StartCoroutine(releaseMeteor());
    }

    IEnumerator playerReleaseMeteor()
    {
        string sound = randomSound();
        isReloading = true;
        if (mode == 1)
        {
            audioManager.PlaySound(sound);
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
                audioManager.PlaySound(sound);
                Instantiate(meteor, gun[0].transform.position, gun[0].transform.rotation);
                yield return new WaitForSeconds(fireRate);
            }
            yield return new WaitForSeconds(reloadTime - fireRate * amount);
            isReloading = false;
        }
    }
}
