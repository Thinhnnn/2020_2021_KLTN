using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelfDestruct : MonoBehaviour
{
    public float lifeTime = 3f;
    public GameObject parent, enemy;
    public LineRenderer LR;
    // Start is called before the first frame update
    void Start()
    {
        LR = this.GetComponent<LineRenderer>();
        StartCoroutine(SelfDestruct());
    }

    // Update is called once per frame
    void Update()
    {
        if(parent!=null && enemy != null && LR!=null)
        {
            LR.SetPosition(0, parent.transform.position);
            LR.SetPosition(1, enemy.transform.position);
        }
    }

    public void getObject(GameObject parent, GameObject enemy)
    {
        this.parent = parent;
        this.enemy = enemy;
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
