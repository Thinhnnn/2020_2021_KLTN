using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;    //textMeshPro

public class MenuUIEvent : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject helpPanel;
    public GameObject settingPanel;
    public GameObject jetProfilePanel;
    public GameObject levelSelectPanel;
    public Text myMoney;

    [SerializeField] GameObject moveScript, mouseScript;

    [SerializeField] GameObject player, playerPos;

    //public Animator doorAnimator;
    //public Animator Jet1Animator;
    //public Animator Jet2Animator;
    //public Animator Jet3Animator;

    SaveAndLoad a;
    public Text multipleValue;
    //public Animator Jet4Animator;

    public GameObject[] jetList, unlockBtn, lockBtn;
    public TextMeshProUGUI[] multipleTextMesh;
    public int jetIndex = 0;

    #region base method
    // Start is called before the first frame update
    void Start()
    {
        a = new SaveAndLoad();
        myMoney.text = a.MyMoney().ToString();
        multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString();
        HideAllJet();
        ShowJetWithIndex(a.selectedShip());
        //jetList = GameObject.FindGameObjectsWithTag("SelectJet");

        loadJetMultipleValue();
        loadJetUnlockStatus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region system method
    public void resesetPlayerPos()
    {
        StartCoroutine(resetPos());
    }

    IEnumerator resetPos()
    {
        doPause();
        player.transform.DOMove(playerPos.transform.position,1f);
        yield return new WaitForSeconds(1f);
        doContinue();
    }

    public void doPause()
    {
        moveScript.GetComponent<playerMove>().doPause();
        mouseScript.GetComponent<mouseRotate>().doPause();
    }

    public void doContinue()
    {
        moveScript.GetComponent<playerMove>().doContinue();
        mouseScript.GetComponent<mouseRotate>().doContinue();
    }
    #endregion

    #region Button event
    public void BtnExitClick()
    {
        if(exitPanel.active == true)
        {
            doContinue();
        }
        else
        {
            doPause();
        }
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        exitPanel.SetActive(!exitPanel.activeSelf);
    }

    public void BtnExitConfirm()
    {
        doContinue();
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        exitPanel.SetActive(!exitPanel.activeSelf);
        Application.Quit();
    }

    public void BtnHelpClick()
    {
        if (helpPanel.active == true)
        {
            doContinue();
        }
        else
        {
            doPause();
        }
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        helpPanel.SetActive(!helpPanel.activeSelf);
    }

    public void BtnSettingClick()
    {
        if (settingPanel.active == true)
        {
            doContinue();
        }
        else
        {
            doPause();
        }
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void BtnSettingCancel()
    {
        doContinue();
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        settingPanel.SetActive(!settingPanel.activeSelf);
    }

    public void BtnJetProfileClick()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        jetProfilePanel.SetActive(!jetProfilePanel.activeSelf);
    }

    public void BtnPlayMouseHover()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("DoorOpen");
        //doorAnimator.SetTrigger("Open");
    }

    public void BtnPlayMouseOut()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("DoorClose");
        //doorAnimator.SetTrigger("Close");
    }

    public void BtnPlayMouseClick()
    {
        doPause();
        levelSelectPanel.SetActive(true);
        //StartCoroutine(jetFlyOut());
    }

    public void BtnLevelClick()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        levelSelectPanel.SetActive(false);
        StaticClass.jetIndex = this.jetIndex + 1;
        //StartCoroutine(jetFlyOut());
    }

    public void BtnCancelLevelClick()
    {
        doContinue();
        levelSelectPanel.SetActive(false);
    }
    #endregion

    #region save and load value

    public void loadJetUnlockStatus()
    {

        for(int i = 0; i < jetList.Length; i++)
        {
            if (i < a.unlockLevel())
            {
                unlockBtn[i].SetActive(true);
                unlockBtn[i + jetList.Length].SetActive(true);
                lockBtn[i].SetActive(false);
            }
            else
            {
                unlockBtn[i].SetActive(false);
                unlockBtn[i + jetList.Length].SetActive(false);
                lockBtn[i].SetActive(true);
            }
        }
    }

    public void loadJetMultipleValue()
    {
        for (int i = 0; i < multipleTextMesh.Length; i++)
        {
            multipleTextMesh[i].text = a.jetMultipleValue(i) + "x";
        }
    }

    public void upgradeJetMultipleValue(int index)
    {
        a.upgradeMultipleValue(index);
        loadJetMultipleValue();
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        if (a.MyMoney() >= 1000)
        {
            a.makePayment();
            myMoney.text = a.MyMoney().ToString();
        }
    }
    #endregion

    #region jet Event

    public void ShowJetWithIndex(int index)
    {
        HideAllJet();
        jetList[index].SetActive(true);
        jetIndex = index;
        a.setSelectedShip(index);
        //switch (jetIndex)
        //{
        //    case 0: { multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString(); break; }
        //    case 1: { multipleValue.text = "Power x " + a.myPower("jet2.txt").ToString(); break; }
        //    case 2: { multipleValue.text = "Power x " + a.myPower("jet3.txt").ToString(); break; }
        //}
    }

    public void jetUpgrade()
    {
        //switch (jetIndex)
        //{
        //    case 0: { a.WriteString("jet1.txt", (a.myPower("jet1.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString(); break; }
        //    case 1: { a.WriteString("jet2.txt", (a.myPower("jet2.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet2.txt").ToString(); break; }
        //    case 2: { a.WriteString("jet3.txt", (a.myPower("jet3.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet3.txt").ToString(); break; }
        //}
    }

    public void HideAllJet()
    {
        foreach (GameObject jet in jetList)
        {
            jet.SetActive(false);
        }
    }
    #endregion

    #region load scene method
    public void switchToLevel(int index)
    {
        Loader.Load(Loader.Scene.Level1_Earth);
    }
    #endregion
}
