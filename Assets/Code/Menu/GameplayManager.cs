using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
    public GameObject SettingPanel;
    // Start is called before the first frame update
    void Start()
    {
        SettingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var x = FindObjectOfType<AudioManager>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            x.PlaySound("Click");
            if (Time.timeScale == 0)
            {
                SettingPanel.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                SettingPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void BackToMenu()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click");
        SceneManager.LoadScene("Menu");
    }

    public void MinimizeSetting()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click");
        SettingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Retry()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click");
        SceneManager.LoadScene("GamePlay 1");
    }

    public void SummonBoss()
    {

    }
}
