using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public float flySpeed = 1f;
    public float turnSpeed = 1f;

    public float curveAngle = 20f;

    public bool chasingState = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (chasingState)
        {
            // Determine which direction to rotate towards
            Vector3 targetDirection = player.transform.position - transform.position;

            // The step size is equal to speed times frame time.
            float singleStep = turnSpeed * Time.deltaTime;

            // Rotate the forward vector towards the target direction by one step
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

            // Calculate a rotation a step closer to the target and applies rotation to this object
            transform.rotation = Quaternion.LookRotation(newDirection);

            transform.position += transform.forward * flySpeed * Time.deltaTime;
        }
        else
        {
            transform.position += transform.forward * flySpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Environment" && chasingState)
        {
            //try to turn around
            StartCoroutine(Take3SecondToCurve());
        }
    }

    IEnumerator Take3SecondToCurve()
    {
        chasingState = false;
        transform.Rotate(transform.rotation.x, transform.rotation.y + curveAngle, transform.rotation.z);
        yield return new WaitForSeconds(3);
        chasingState = true;
    }
}
