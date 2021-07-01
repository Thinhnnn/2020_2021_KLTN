using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    float x, z;

    [SerializeField] GameObject vision;

    [SerializeField] float speed = 100f;

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
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            transform.position += (vision.transform.forward * z + vision.transform.right * x) * speed * Time.deltaTime;
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
