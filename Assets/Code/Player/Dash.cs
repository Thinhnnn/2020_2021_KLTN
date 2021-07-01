using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashDistance = 1f;
    public float dashSpeed = .5f;

    public GameObject trail;
    public float cooldown = 15f;
    bool is_cd = false;

    float pathX;
    float pathZ;

    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        trail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var sfx = FindObjectOfType<AudioManager>();
        pathX = Input.GetAxisRaw("Horizontal");
        pathZ = Input.GetAxisRaw("Vertical");
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift)) && is_cd == false)
        {
            sfx.PlaySound("Dash");
            StartCoroutine(ShowPath());
            Vector3 path = transform.forward * pathZ + transform.right * pathX;
            Vector3 dash = Vector3.Lerp(Vector3.zero, path * dashDistance, dashSpeed);
            Debug.Log(path);
            //transform.position = dash;
            controller.Move(dash);
        }
    }

    IEnumerator ShowPath()
    {
        is_cd = true;
        trail.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        trail.SetActive(false);
        yield return new WaitForSeconds(cooldown - 1.5f);
        is_cd = false;
    }
}
