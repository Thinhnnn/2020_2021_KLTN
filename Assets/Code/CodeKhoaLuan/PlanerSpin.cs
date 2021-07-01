using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class PlanerSpin : MonoBehaviour
{
    public float spinTime = 36f;
    public float spinAngle = 36f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spin()
    {
        //transform.DORotate(new Vector3(0f, spinAngle, 0f), spinTime, RotateMode.LocalAxisAdd);
        yield return new WaitForSeconds(spinTime);
        StartCoroutine(spin());
    }
}
