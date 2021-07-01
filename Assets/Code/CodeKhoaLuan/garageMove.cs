using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garageMove : MonoBehaviour
{
    float x, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");


    }
}
