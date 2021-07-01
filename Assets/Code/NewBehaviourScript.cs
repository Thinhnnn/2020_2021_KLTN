using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed;

    float x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + x * speed * Time.deltaTime, transform.rotation.z);
    }
}
