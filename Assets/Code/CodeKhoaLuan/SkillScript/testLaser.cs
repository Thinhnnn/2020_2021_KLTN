using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testLaser : MonoBehaviour
{
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(g.transform.position, new Vector3(0,1,0), 36 * Time.deltaTime);
    }
}
