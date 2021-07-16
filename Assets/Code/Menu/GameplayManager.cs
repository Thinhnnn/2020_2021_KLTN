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
        //SceneManager.LoadScene("Menu");
        Loader.Load(Loader.Scene.Menu);
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
        //SceneManager.LoadScene("GamePlay 1");
        switch (CacheLevel.currentLevel)
        {
            case 0: { Loader.Load(Loader.Scene.Level1_Mercury); break; }
            case 1: { Loader.Load(Loader.Scene.Level2_Venus); break; }
            case 2: { Loader.Load(Loader.Scene.Level3_Earth); break; }
            case 3: { Loader.Load(Loader.Scene.Level4_Mars); break; }
            case 4: { Loader.Load(Loader.Scene.Level5_Jupiter); break; }
            case 5: { Loader.Load(Loader.Scene.Level6_Saturn); break; }
            case 6: { Loader.Load(Loader.Scene.Level7_Uranus); break; }
            case 7: { Loader.Load(Loader.Scene.Level8_Neptune); break; }
        }
        //Loader.Load(Loader.Scene.Level1_Earth);
    }

    public void SummonBoss()
    {

    }
}
