using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingBullet : MonoBehaviour
{
    public SpaceshipManager spaceshipManager;
    public float speed = 300f;
    public float lifeTime = 20f;
    public float turnSpeed = 20f;

    //public GameObject[] Enemy;
    public GameObject target;

    public GameObject explode;
    // Start is called before the first frame update
    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        StartCoroutine(SelfDestruct());
        try
        {
            target = spaceshipManager.nearestRival(gameObject);
        }
        catch
        {
            //do nothing
        }
        //Enemy = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = target.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = turnSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment" || (gameObject.tag == "AllyMissle" && other.tag == "Enemy") || (gameObject.tag == "EnemyMissle" && other.tag == "Ally"))
        {
            Destroy(gameObject);
            Instantiate(explode, transform.position, transform.rotation);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        Instantiate(explode, transform.position, transform.rotation);
    }
}
