using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Animator doorAnimator;
    public Animator JetAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            doorAnimator.SetTrigger("Open");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            doorAnimator.SetTrigger("Close");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            JetAnimator.SetTrigger("Up");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            JetAnimator.SetTrigger("Straight");
        }
    }
}
