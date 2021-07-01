using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMove : MonoBehaviour
{
    #region khai báo biến
    // Start is called before the first frame update
    public float fightRange = 500f;//tầm giao tranh
    public GameObject target;
    public GameObject aimVector;
    public GameObject rightVector;
    public GameObject rightDodge;
    public GameObject leftDodge;
    public float flySpeed = 50f;
    public float turnSpeed = 50f;
    public GameObject wayToDodge;
    public bool isDodging;
    public float dodgeTime = 1f;
    public SpaceshipManager spaceshipManager;
    public AudioManager audioManager;
    public float refreshTargetTime = 5f;
    #endregion

    void Start()
    {
        spaceshipManager = FindObjectOfType<SpaceshipManager>();
        audioManager = FindObjectOfType<AudioManager>();
        target = spaceshipManager.nearestRival(gameObject);
        StartCoroutine(CheckTarget());
        isDodging = false;
    }

    // Update is called once per frame
    void Update()
    {

        //hướng về kẻ địch
        aimVector.transform.LookAt(target.transform);  

        //tính toán di chuyển
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > fightRange)
        {
            FlyMode_Find();
        }
        else
        {
            FlyMode_Fight();
        }
 
    }

    #region Fly mode
    void FlyMode_Find()
    {
        //tìm đến kẻ địch
        // Determine which direction to rotate towards
        Vector3 targetDirection;
        if (isDodging)
        {
            targetDirection = wayToDodge.transform.position - transform.position;
        }
        else
        {
            targetDirection = target.transform.position - transform.position;
        }      

        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position += transform.forward * flySpeed * Time.deltaTime;
    }
    void FlyMode_Fight()
    {
        //giao chiến
        // Determine which direction to rotate towards
        Vector3 targetDirection;
        if (isDodging)
        {
            targetDirection = wayToDodge.transform.position - transform.position;
        }
        else
        {
            targetDirection = rightVector.transform.position - transform.position;
        }
        // The step size is equal to speed times frame time.
        float singleStep = turnSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);

        transform.position += transform.forward * flySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        //nếu sắp va phải vật gì đó, và đang KHÔNG trong trạng thái né
        if ((other.tag == "Ally" || other.tag == "Enemy" || other.tag == "Environment"))
        {
            //Debug.Log(gameObject.name + " hit " + other.name);
            if(Vector3.Distance(other.transform.position, rightDodge.transform.position) > Vector3.Distance(other.transform.position, leftDodge.transform.position))
            {
                wayToDodge = rightDodge;
            }
            else
            {
                wayToDodge = leftDodge;
            }
            StartCoroutine(FLyMode_Dodge());
        }
    }
    IEnumerator FLyMode_Dodge()
    {
        //né khẩn cấp       
        isDodging = true;
        turnSpeed *= 1.5f;
        yield return new WaitForSeconds(dodgeTime);
        isDodging = false;
        turnSpeed /= 1.5f;
    }
    #endregion

    #region thay đổi mục tiêu mới khi mục tiêu đã bị bắn hạ
    IEnumerator CheckTarget()
    {
        if (target.active == false || target == null)
        {
            try
            {
                target = spaceshipManager.nearestRival(gameObject);
            }
            catch
            {

            }
        }
        yield return new WaitForSeconds(refreshTargetTime);
        StartCoroutine(CheckTarget());
    }
    #endregion
}
