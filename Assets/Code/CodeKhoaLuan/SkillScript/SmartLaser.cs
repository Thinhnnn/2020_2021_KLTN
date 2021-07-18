using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartLaser : MonoBehaviour
{
    public int amount = 1;
    public GameObject[] gun;
    public float reloadTime = 20f;
    public GameObject laser;
    public int mode = 1;
    public float fireRate = 2f;

    public float fightRange = 1500f;
    public SpaceshipManager spaceshipManager;
    public GameObject nearestRival;
    public float refreshTime = 1f;
    public AudioManager audioManager;

    public float damage = 100f;

    public bool canBeam = false;

    public bool isPlayer = false;
    public bool isReloading = false;
    string sound;

    public float multipleValue;
    // Start is called before the first frame update
    void Start()
    {
        sound = randomSound();
        canBeam = false;
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        StartCoroutine(updateRival());
        if (!isPlayer)
        {
            StartCoroutine(releaseLaser());
        }
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
        if (nearestRival != null)
        {
            if (Vector3.Distance(nearestRival.transform.position, transform.position) < fightRange)
            {
                canBeam = true;
            }
            else
            {
                canBeam = false;
            }
        }
        else
        {
            canBeam = false;
        }

        if (isPlayer)
        {
            if(Input.GetKeyDown(KeyCode.Alpha3) && !isReloading)
            {
                StartCoroutine(playerReleaseLaser());
            }
        }
    }
    public string randomSound()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            return "Laser1";
        }
        else
        {
            return "Laser2";
        }
    }
    IEnumerator updateRival()
    {
        nearestRival = spaceshipManager.nearestRival(this.gameObject);
        yield return new WaitForSeconds(refreshTime);
        StartCoroutine(updateRival());
    }

    IEnumerator releaseLaser()
    {
        if (canBeam)
        {
            if (mode == 1)
            {
                yield return new WaitForSeconds(reloadTime); 
                audioManager.PlaySound(sound);
                for (int i = 0; i < amount; i++)
                {
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
                    nearestRival.GetComponent<HpManager>().takeLaserDamage(damage);
                }
            }
            else if (mode == 2)
            {
                yield return new WaitForSeconds(reloadTime);
                for (int i = 0; i < amount; i++)
                {
                    audioManager.PlaySound(sound);
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
                    nearestRival.GetComponent<HpManager>().takeLaserDamage(damage);
                    yield return new WaitForSeconds(fireRate);
                }
            }
            StartCoroutine(releaseLaser());
        }
        else
        {
            yield return new WaitForSeconds(reloadTime);
            StartCoroutine(releaseLaser());
        }
    }

    IEnumerator playerReleaseLaser()
    {
        isReloading = true;
        if (canBeam)
        {
            //string sound = randomSound();
            if (mode == 1)
            {
                audioManager.PlaySound(sound);
                for (int i = 0; i < amount; i++)
                {
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
                    nearestRival.GetComponent<HpManager>().takeLaserDamage(damage * multipleValue);
                }
                yield return new WaitForSeconds(reloadTime);
                isReloading = false;
            }
            else if (mode == 2)
            {
                for (int i = 0; i < amount; i++)
                {
                    audioManager.PlaySound(sound);
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
                    nearestRival.GetComponent<HpManager>().takeLaserDamage(damage * multipleValue);
                    yield return new WaitForSeconds(fireRate);
                }
                yield return new WaitForSeconds(reloadTime - fireRate * amount);
                isReloading = false;
            }
        }
        else
        {
            yield return new WaitForSeconds(fireRate);
            isReloading = false;
        }
    }
}
