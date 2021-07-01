using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRotate : MonoBehaviour
{
    [SerializeField] GameObject vertical;

    [SerializeField] float ySpeed, xSpeed, maxXAngle;
    
    float ySpin, xSpin;

    bool _isPause = false;

    // Start is called before the first frame update
    void Start()
    {
        _isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isPause)
        {
            ySpin = Input.GetAxis("Mouse X");
            xSpin = Input.GetAxis("Mouse Y");

            transform.Rotate(0f, ySpin * ySpeed * Time.deltaTime, 0f);
            xSpin = Mathf.Clamp(xSpin, -maxXAngle, maxXAngle);
            vertical.transform.Rotate(-xSpin * xSpeed * Time.deltaTime, 0f, 0f);
        }
        
    }

    public void doPause()
    {
        _isPause = true;
    }

    public void doContinue()
    {
        _isPause = false;
    }
}
