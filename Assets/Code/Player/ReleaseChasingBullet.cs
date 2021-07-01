using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseChasingBullet : MonoBehaviour
{
    //class xử lý hành động bắn đạn tự tìm kẻ địch của player
    public GameObject ObjectToShoot;    //vật thể được bắn ra
    public Transform direct;            //hướng bắn ra của đạn

    public float ammount;
    public float cooldownTime = 30f;
    public bool isCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && Time.timeScale != 0)
        {
            StartCoroutine(ReleaseMissle());
        }
    }

    IEnumerator ReleaseMissle()
    {
        var sfx = FindObjectOfType<AudioManager>();
        if (!isCooldown)
        {
            isCooldown = true;
            for (int i = 0; i < ammount; i++)
            {
                sfx.PlaySound("Missle");
                Instantiate(ObjectToShoot, direct.position, direct.rotation);
                yield return new WaitForSeconds(0.2f);
            }
            yield return new WaitForSeconds(cooldownTime - 0.5f * ammount);
            isCooldown = false;
        }
         
    }
}
