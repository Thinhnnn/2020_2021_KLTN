using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Transform spawmPoint1;
    public Transform spawmPoint2;
    public GameObject effectToSpawm;

    public float reloadSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(reloadSpeed); 
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("EShoot");
        Instantiate(effectToSpawm, spawmPoint1.position + spawmPoint1.transform.forward, spawmPoint1.rotation);
        Instantiate(effectToSpawm, spawmPoint2.position + spawmPoint2.transform.forward, spawmPoint2.rotation);
        StartCoroutine(Shoot());
    }
}
