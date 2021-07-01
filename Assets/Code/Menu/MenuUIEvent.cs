using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuUIEvent : MonoBehaviour
{
    public GameObject exitPanel;
    public GameObject helpPanel;
    public GameObject settingPanel;
    public GameObject jetProfilePanel;
    public GameObject levelSelectPanel;

    [SerializeField] GameObject moveScript, mouseScript;

    [SerializeField] GameObject player, playerPos;

    public Animator doorAnimator;
    public Animator Jet1Animator;
    public Animator Jet2Animator;
    public Animator Jet3Animator;

    SaveAndLoad a;
    public Text multipleValue;
    //public Animator Jet4Animator;

    public GameObject[] jetList;
    public int jetIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        a = new SaveAndLoad();
        multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString();
        //jetList = GameObject.FindGameObjectsWithTag("SelectJet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        doorAnimator.SetTrigger("Open");
    }

    public void BtnPlayMouseOut()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("DoorClose");
        doorAnimator.SetTrigger("Close");
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
        StartCoroutine(jetFlyOut());
    }

    public void BtnCancelLevelClick()
    {
        doContinue();
        levelSelectPanel.SetActive(false);
    }

    IEnumerator jetFlyOut()
    {
        //kiểm tra cửa mở, mở ra trước khi bay
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("DoorOpen");
        doorAnimator.SetTrigger("Open");
        //animation bay
        doorAnimator.SetBool("KeepOpen", true);
        x.PlaySound("FlyUp");
        Jet1Animator.SetTrigger("Up");
        Jet2Animator.SetTrigger("Up");
        Jet3Animator.SetTrigger("Up");
        //Jet4Animator.SetTrigger("Up");
        yield return new WaitForSeconds(1f);
        x.PlaySound("FlyStraight");
        Jet1Animator.SetTrigger("Straight");
        Jet2Animator.SetTrigger("Straight");
        Jet3Animator.SetTrigger("Straight");
        //Jet4Animator.SetTrigger("Straight");
        yield return new WaitForSeconds(2f);
        doorAnimator.SetBool("KeepOpen", false);
        x.PlaySound("DoorClose");
        doorAnimator.SetTrigger("Close");
        x.StopMusic("BGM");
        //Sau đó chuyển đến level
        SceneManager.LoadScene("GamePlay 1");
    }

    public void JetChangeLeft()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        HideAllJet();
        if (jetIndex > 0)
        {
            jetIndex -= 1;
        }
        else
        {
            jetIndex = jetList.Length - 1;
        }
        //if(jetIndex == 0)
        //{
        //    jetIndex = jetList.Length -1;
        //}
        ShowJetWithIndex(jetIndex);
    }

    public void JetChangeRight()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click2");
        HideAllJet();
        if (jetIndex < jetList.Length - 1)
        {
            jetIndex += 1;
        }
        else
        {
            jetIndex = 0;
        }
        ShowJetWithIndex(jetIndex);
    }

    void ShowJetWithIndex(int index)
    {
        jetList[jetIndex].SetActive(true);
        switch (jetIndex)
        {
            case 0: { multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString(); break; }
            case 1: { multipleValue.text = "Power x " + a.myPower("jet2.txt").ToString(); break; }
            case 2: { multipleValue.text = "Power x " + a.myPower("jet3.txt").ToString(); break; }
        }
    }

    public void jetUpgrade()
    {
        switch (jetIndex)
        {
            case 0: { a.WriteString("jet1.txt", (a.myPower("jet1.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet1.txt").ToString(); break; }
            case 1: { a.WriteString("jet2.txt", (a.myPower("jet2.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet2.txt").ToString(); break; }
            case 2: { a.WriteString("jet3.txt", (a.myPower("jet3.txt") + 0.1f).ToString()); multipleValue.text = "Power x " + a.myPower("jet3.txt").ToString(); break; }
        }
    }

    void HideAllJet()
    {
        foreach (GameObject jet in jetList)
        {
            jet.SetActive(false);
        }
    }
}
