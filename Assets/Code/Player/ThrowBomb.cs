using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
    public GameObject bomb;

    public float reloadTime = 30f;
    public bool isReload = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && Time.timeScale != 0)
        {
            if (!isReload)
            {
                StartCoroutine(ReleaseBomb());
            }
        }
    }

    IEnumerator ReleaseBomb()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Bomb2");
        isReload = true;
        Instantiate(bomb, transform.position, Quaternion.Euler(transform.rotation.x-30f, 0f, 0f));
        yield return new WaitForSeconds(reloadTime);
        isReload = false;
    }
}
