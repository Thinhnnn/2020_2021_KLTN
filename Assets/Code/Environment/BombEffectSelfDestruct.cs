using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffectSelfDestruct : MonoBehaviour
{
    public float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(selfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator selfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
