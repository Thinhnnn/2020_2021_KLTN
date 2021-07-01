using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReleaseMissle : MonoBehaviour
{
    public Transform[] missleGun;
    public GameObject missle;
    public Transform meteorGun;
    public GameObject meteor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(ReleaseMissle());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(ReleaseMeteor());
        }
    }

    IEnumerator ReleaseMissle()
    {
        foreach(Transform gunHead in missleGun)
        {
            Instantiate(missle, gunHead.position, gunHead.rotation);
        }
        yield return new WaitForSeconds(1);
    }
    IEnumerator ReleaseMeteor()
    {
        Instantiate(meteor, meteorGun.position, meteorGun.rotation);
        yield return new WaitForSeconds(1);
    }
}
