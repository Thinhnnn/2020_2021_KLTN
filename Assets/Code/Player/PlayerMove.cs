using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //class xử lý di chuyển của player

    public CharacterController controller; //đại diện cho player
    public float speed = 1f;        //tốc độ bay thẳng
    public float turnSpeed = 1f;    //tốc độ rẽ hướng trái/phải
    public float curveSpeed = 1f;   //tốc độ lượn lên, xuống

    public GameObject[] engines;       //biến lưu động cơ tên lửa, sẽ bật lên khi di chuyển
    public GameObject[] subEngines;

    float x;    //biến lấy thông tin trục x
    float z;    //biến lấy thông tin trục z

    public float speedUpTime = 5f;
    public float speedUpValue = 50f;
    public bool isSpeedUp = false;
    public float speedUpCooldown = 20f;
    public bool SpeedUpIsCooldown = false;

    public bool isFly = false;

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject engine in engines)
        {
            engine.SetActive(false);
        }
        foreach (GameObject Sengine in subEngines)
        {
            Sengine.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var sfx = FindObjectOfType<AudioManager>();
        //nhận tín hiệu di chuyển
        x = Input.GetAxis("Horizontal");    
        z = Input.GetAxis("Vertical");

        if (z != 0)
        {
            if (isFly == false)
            {
                isFly = true;
                sfx.PlaySound("Fly");
            }
        }
        else
        {
            isFly = false;
            sfx.StopSound("Fly");
        }

        transform.Rotate(0f, x * turnSpeed * Time.deltaTime, 0f);   //xoay player sang hướng rẽ trái/phải nếu có
        controller.Move(transform.forward * z * speed * Time.deltaTime);    //di chuyển theo tín hiệu từ bàn phím

        //code lượn lên/xuống khi nhấn các nút Q,E
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(-curveSpeed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(curveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            sfx.PlaySound("SpeedUp");
            SpeedUp();
        }

        if (z > 0)
        {
            //nếu đang có bay về phía trước, bật động cơ lên
            foreach (GameObject engine in engines)
            {
                engine.SetActive(true);
            }
        }
        else
        {
            //ngược lại, tắt động cơ đi
            foreach (GameObject engine in engines)
            {
                engine.SetActive(false);
            }
        }
    }

    void SpeedUp()
    {
        if (!isSpeedUp && !SpeedUpIsCooldown)
        {
            isSpeedUp = true;
            SpeedUpIsCooldown = true;
            speed += speedUpValue;
            StartCoroutine(AnimateSpeedUp());
        }
    }

    IEnumerator AnimateSpeedUp()
    {
        foreach (GameObject Sengine in subEngines)
        {
            Sengine.SetActive(true);
        }
        yield return new WaitForSeconds(speedUpTime);
        isSpeedUp = false;
        foreach (GameObject Sengine in subEngines)
        {
            Sengine.SetActive(false);
        }
        speed -= speedUpValue;
        yield return new WaitForSeconds(speedUpCooldown - speedUpTime);
        SpeedUpIsCooldown = false;
    }
}
