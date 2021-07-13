using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingSkill : MonoBehaviour
{
    [Header("NormalShoot")]
    public Image normalShoot;
    public float cooldownNormal = 5f;
    bool isCooldownNormal = false;

    [Header("Missle")]
    public Image missle;
    public float cooldownMissle = 5f;
    bool isCooldownMissle = false;

    [Header("Meteor")]
    public Image meteor;
    public float cooldownMeteor = 5f;
    bool isCooldownMeteor = false;

    [Header("Laser")]
    public Image laser;
    public float cooldownLaser = 5f;
    bool isCooldownLaser = false;

    public GameObject player;
    GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        //skill_1.fillAmount = 0;
        ship = GetChildObject(player.transform, "Ally");
        if (ship != null)
        {
            cooldownNormal = ship.GetComponent<SmartShoot>().reloadTime;
            if (ship.GetComponent<SmartShoot>().ammount != 0)
            {
                cooldownNormal = ship.GetComponent<SmartShoot>().reloadTime;
            }
            else
            {
                cooldownNormal = 0;
                normalShoot.fillAmount = 1;
            }

            if (ship.GetComponent<SmartMissleRelease>().amount != 0)
            {
                cooldownMissle = ship.GetComponent<SmartMissleRelease>().reloadTime;
            }
            else
            {
                cooldownMissle = 0;
                missle.fillAmount = 1;
            }

            if (ship.GetComponent<SmartMeteorRelease>().amount != 0)
            {
                cooldownMeteor = ship.GetComponent<SmartMeteorRelease>().reloadTime;
            }
            else
            {
                cooldownMeteor = 0;
                meteor.fillAmount = 1;
            }

            if (ship.GetComponent<SmartLaser>().amount != 0)
            {
                cooldownLaser = ship.GetComponent<SmartLaser>().reloadTime;
            }
            else
            {
                cooldownLaser = 0;
                laser.fillAmount = 1;
            }
        }
    }

    public GameObject GetChildObject(Transform parent, string _tag)
    {
        GameObject result = new GameObject();
        bool found = false;
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);
            if (child.tag == _tag)
            {
                result =  child.gameObject;
                found = true;
                break;
            }
        }
        if (found)
        {
            return result;
        }
        else
        {
            return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        NormalShoot();
        Missle();
        Meteor();
        Laser();
    }

    void NormalShoot()
    {
        if (cooldownNormal != 0)
        {
            if (Input.GetMouseButtonDown(0) && isCooldownNormal == false)
            {
                isCooldownNormal = true;
                normalShoot.fillAmount = 1;
            }
            if (isCooldownNormal)
            {
                normalShoot.fillAmount -= 1 / cooldownNormal * Time.deltaTime;

                if (normalShoot.fillAmount <= 0)
                {
                    normalShoot.fillAmount = 0;
                    isCooldownNormal = false;
                }
            }
        }
        
    }
    void Missle()
    {
        if (cooldownMissle != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && isCooldownMissle == false)
            {
                isCooldownMissle = true;
                missle.fillAmount = 1;
            }
            if (isCooldownMissle)
            {
                missle.fillAmount -= 1 / cooldownMissle * Time.deltaTime;

                if (missle.fillAmount <= 0)
                {
                    missle.fillAmount = 0;
                    isCooldownMissle = false;
                }
            }
        }
        
    }

    void Meteor()
    {
        if (cooldownMeteor != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2) && isCooldownMeteor == false)
            {
                isCooldownMeteor = true;
                meteor.fillAmount = 1;
            }
            if (isCooldownMeteor)
            {
                meteor.fillAmount -= 1 / cooldownMeteor * Time.deltaTime;

                if (meteor.fillAmount <= 0)
                {
                    meteor.fillAmount = 0;
                    isCooldownMeteor = false;
                }
            }
        }
        
    }


    void Laser()
    {
        if (cooldownLaser != 0)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3) && isCooldownLaser == false)
            {
                isCooldownLaser = true;
                laser.fillAmount = 1;
            }
            if (isCooldownLaser)
            {
                laser.fillAmount -= 1 / cooldownLaser * Time.deltaTime;

                if (laser.fillAmount <= 0)
                {
                    laser.fillAmount = 0;
                    isCooldownLaser = false;
                }
            }
        }
        
    }
}
