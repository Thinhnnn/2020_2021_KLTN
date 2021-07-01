using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingSkill : MonoBehaviour
{
    [Header("Skill 1")]
    public Image skill_1;
    public float cooldown_1 = 5f;
    bool isCooldown_1 = false;

    [Header("Skill 2")]
    public Image skill_2;
    public float cooldown_2 = 5f;
    bool isCooldown_2 = false;

    [Header("Skill 3")]
    public Image skill_3;
    public float cooldown_3 = 5f;
    bool isCooldown_3 = false;

    [Header("Dash")]
    public Image dash_img;
    public float cooldown_dash = 5f;
    bool isCooldown_dash = false;

    // Start is called before the first frame update
    void Start()
    {
        skill_1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Skill_1();
        Skill_2();
        Skill_3();
        Dash();
    }

    void Skill_1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && isCooldown_1 == false)
        {
            isCooldown_1 = true;
            skill_1.fillAmount = 1;
        }
        if (isCooldown_1)
        {
            skill_1.fillAmount -= 1 / cooldown_1 * Time.deltaTime;

            if (skill_1.fillAmount <= 0)
            {
                skill_1.fillAmount = 0;
                isCooldown_1 = false;
            }
        }
    }

    void Skill_2()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && isCooldown_2 == false)
        {
            isCooldown_2 = true;
            skill_2.fillAmount = 1;
        }
        if (isCooldown_2)
        {
            skill_2.fillAmount -= 1 / cooldown_2 * Time.deltaTime;

            if (skill_2.fillAmount <= 0)
            {
                skill_2.fillAmount = 0;
                isCooldown_2 = false;
            }
        }
    }

    void Skill_3()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3) && isCooldown_3 == false)
        {
            isCooldown_3 = true;
            skill_3.fillAmount = 1;
        }
        if (isCooldown_3)
        {
            skill_3.fillAmount -= 1 / cooldown_3 * Time.deltaTime;

            if (skill_3.fillAmount <= 0)
            {
                skill_3.fillAmount = 0;
                isCooldown_3 = false;
            }
        }
    }

    void Dash()
    {
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && isCooldown_dash == false)
        {
            isCooldown_dash = true;
            dash_img.fillAmount = 1;
        }
        if (isCooldown_dash)
        {
            dash_img.fillAmount -= 1 / cooldown_dash * Time.deltaTime;

            if (dash_img.fillAmount <= 0)
            {
                dash_img.fillAmount = 0;
                isCooldown_dash = false;
            }
        }
    }
}
