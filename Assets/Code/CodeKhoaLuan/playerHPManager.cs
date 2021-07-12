using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHPManager : MonoBehaviour
{
    public Slider HPBar;

    public GameObject losePanel;

    public float maxHP, curentHP;

    public TextMeshProUGUI txtShipName, txtHP;

    public GameObject player;
    GameObject ship;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayGetHP());
    }

    // Update is called once per frame
    void Update()
    {
        if (ship != null)
        {
            curentHP = ship.GetComponent<HpManager>().currentHP;
            if (curentHP <= 0)
            {
                losePanel.SetActive(true);
                Time.timeScale = 0;
            }
            HPBar.value = curentHP / maxHP;
            txtHP.text = curentHP.ToString() + "/" + maxHP.ToString();
        }
    }

    IEnumerator delayGetHP()
    {
        yield return new WaitForSeconds(1f);
        ship = GetChildObject(player.transform, "Ally");
        if (ship != null)
        {
            maxHP = ship.GetComponent<HpManager>().maxHP;
            curentHP = maxHP;
            txtShipName.text = ship.name;
            txtHP.text = curentHP.ToString() + "/" + maxHP.ToString();
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
                result = child.gameObject;
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
}
