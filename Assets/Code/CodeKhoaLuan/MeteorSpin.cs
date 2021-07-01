using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpin : MonoBehaviour
{
    public float speed = 300f;
    public float spinSpeed = 20f;
    public float lifeTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        transform.Rotate(0f, 0f, spinSpeed);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
