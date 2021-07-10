using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer LD;

    public GameObject enemy;

    bool beam;
    // Start is called before the first frame update
    void Start()
    {
        beam = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            beam = true;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            beam = false;
        }
        if (beam)
        {
            LD.SetPosition(0, transform.position);
            LD.SetPosition(1, enemy.transform.position);
        }
        else
        {
            LD.SetPosition(0, transform.position);
            LD.SetPosition(1, transform.position);
        }
    }
}
