using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Transform local;
    public Transform lerp;

    float z;
    public float lerpSpeed = .5f;
    public Camera cam;
    public float fieldOfView = 60f;
    public float fieldOfLerp = 80f;
    //Vector3 smooth;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        z = Input.GetAxis("Vertical");
        //Debug.Log(z);
        if (z > 0)
        {
            //smooth = Vector3.Lerp(transform.position, lerp.position, lerpSpeed);
            //transform.position = smooth;
            float smooth = Mathf.Lerp(cam.fieldOfView, fieldOfLerp, lerpSpeed);
            cam.fieldOfView = smooth;
        }
        else
        {
            //smooth = Vector3.Lerp(transform.position, local.position, 3 * lerpSpeed);
            //transform.position = smooth;
            float smooth = Mathf.Lerp(cam.fieldOfView, fieldOfView, 3 * lerpSpeed);
            cam.fieldOfView = smooth;
        }
    }
}
