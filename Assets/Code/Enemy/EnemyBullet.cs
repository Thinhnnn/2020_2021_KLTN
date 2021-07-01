using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //class quản lý 1 viên đạn    
    public float speed = 1f;    //tốc độ bay của viên đạn
    public float lifeTime = 5f; //thời gian tồn tại của viên đạn
    // Start is called before the first frame update

    public GameObject explode;
    void Start()
    {
        //khi được bắn ra, bắt đầu đếm ngược thời gian tồn tại (xem hàm đếm ngược ở dưới)
        StartCoroutine(DeleteBullet());
    }

    // Update is called once per frame
    void Update()
    {
        //di chuyển viên đạn theo hướng của nó theo thời gian
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    IEnumerator DeleteBullet()
    {
        //hàm đếm ngược thời gian tồn tại của đạn, khi hết thời gian tồn tại, hủy nó
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
        Instantiate(explode, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Environment")
        {
            Destroy(gameObject);
            Instantiate(explode, transform.position, transform.rotation);
        }
    }
}
