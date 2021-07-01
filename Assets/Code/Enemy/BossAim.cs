using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAim : MonoBehaviour
{
    public GameObject player;

    public GameObject[] bullet;

    public GameObject[] aimVector;

    public int round = 20;

    public float reloadTime = 8f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(reloadTime);
        var x = FindObjectOfType<AudioManager>();
        foreach (GameObject vector in aimVector)
        {
            x.PlaySound("BossShoot");
            Instantiate(bullet[round % 3], vector.transform.position, vector.transform.rotation);
            round -= 1;
            if (round <= 0)
            {
                round = 20;
            }
        }
        if (reloadTime > 2f)
        {
            reloadTime -= Time.deltaTime;
        }
        StartCoroutine(Shoot());
    }
}
