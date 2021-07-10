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

    public bool canBeam = false;
    // Start is called before the first frame update
    void Start()
    {
        canBeam = false;
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        StartCoroutine(updateRival());
        StartCoroutine(releaseLaser());
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
                for (int i = 0; i < amount; i++)
                {
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
                }
            }
            else if (mode == 2)
            {
                yield return new WaitForSeconds(reloadTime);
                for (int i = 0; i < amount; i++)
                {
                    GameObject beam = Instantiate(laser) as GameObject;
                    beam.GetComponent<LaserSelfDestruct>().getObject(gun[i], nearestRival);
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
}
