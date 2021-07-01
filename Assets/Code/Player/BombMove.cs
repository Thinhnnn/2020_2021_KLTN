using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMove : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;

    public GameObject Die;
    public SphereCollider myCollider;

    public GameObject myAvatar;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(lifeTime);
        myAvatar.SetActive(false);
        myCollider.enabled = true;
        Instantiate(Die, transform.position, transform.rotation);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
