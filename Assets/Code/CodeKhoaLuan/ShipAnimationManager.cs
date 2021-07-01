using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShipAnimationManager : MonoBehaviour
{
    public float speedMultipler = 3f;

    public float speedTime = 5f;

    public GameObject[] engines;

    public GameObject speedEffect;

    public bool isSpeedUp;
    // Start is called before the first frame update
    void Start()
    {
        isSpeedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!isSpeedUp)
            {
                isSpeedUp = true;
                StartCoroutine(flyToBattle());
            }
        }
    }

    IEnumerator flyToBattle()
    {
        speedEffect.SetActive(true);
        foreach(GameObject engine in engines)
        {
            engine.transform.DOScale(engine.transform.localScale * speedMultipler, 0.5f);
        }
        yield return new WaitForSeconds(speedTime);
        speedEffect.SetActive(false);
        foreach (GameObject engine in engines)
        {
            engine.transform.DOScale(engine.transform.localScale / speedMultipler, 0.5f);
        }
        yield return new WaitForSeconds(1f);
        isSpeedUp = false;
    }
}
