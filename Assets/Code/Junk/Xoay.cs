using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xoay : MonoBehaviour
{
    public float xoaySpeed = 1f; //tốc độ xoay
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //xoay gameObject 1 góc
        transform.Rotate(0f, xoaySpeed * Time.deltaTime, 0f);
    }
}
