using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    public float sound;
    public float music;
    public float speed_mouse;
    public int screen_size;
    public bool is_mute_sound;
    public bool is_mute_music;

    public Slider music_slider;
    public Slider sound_slider;
    public Slider speed_mouse_slider;
    public Dropdown screen_size_dropdown;
    public Toggle mute_sound;
    public Toggle mute_music;

    Resolution[] resolutions;

    public void SaveSetting()
    {
        var x = FindObjectOfType<AudioManager>();
        x.PlaySound("Click");
        SaveSystem.SaveSetting(this);
    }

    public void LoadSetting()
    {
        SettingData data = SaveSystem.LoadData();

        sound = data.sound;
        music = data.music;
        speed_mouse = data.speed_mouse;
        screen_size = data.screen_size;
        is_mute_sound = data.is_mute_sound;
        is_mute_music = data.is_mute_music;

        // Hiển thị các giá trị lên giao diện
        sound_slider.value = sound;
        music_slider.value = music;
        speed_mouse_slider.value = speed_mouse;
        screen_size_dropdown.value = screen_size;
        mute_sound.isOn = is_mute_sound;
        mute_music.isOn = is_mute_music;
    }

    public void LoadDefaultSetting()
    {
        sound = .5f;
        music = .5f;
        speed_mouse = 200f;
        screen_size = 0;
        is_mute_sound = false;
        is_mute_music = false;

        // Hiển thị các giá trị lên giao diện
        sound_slider.value = sound;
        music_slider.value = music;
        speed_mouse_slider.value = speed_mouse;
        screen_size_dropdown.value = screen_size;
        mute_sound.isOn = is_mute_sound;
        mute_music.isOn = is_mute_music;
    }
    
    public void ChangeSound(Slider sound_slider)
    {
        sound = sound_slider.value;
    }

    public void ChangeMusic(Slider music_slider)
    {
        music = music_slider.value;
    }

    public void ChangeSpeedMouse(Slider speed_mouse_slider)
    {
        speed_mouse = speed_mouse_slider.value;
    }

    public void ChangeScreenSize(Dropdown screen_size_dropdown)
    {
        screen_size = screen_size_dropdown.value;
    }

    public void ChangeMuteMusic(Toggle music_toggle)
    {
        is_mute_music = music_toggle.isOn;
    }

    public void ChangeMuteSound(Toggle sound_toggle)
    {
        is_mute_sound = sound_toggle.isOn;
    }

    public void SetResolution()
    {
        //resolutions = Screen.resolutions;

        //resolutions[0].width = 1280;
        //resolutions[0].height = 720;

        //resolutions[1].width = 1920;
        //resolutions[1].height = 1080;

        if (screen_size == resolutions.Length)
        {
            Resolution resolution = resolutions[screen_size - 1];
            Screen.SetResolution(resolution.width, resolution.height, true); // (fullscreen = true) chuyển sang chế độ toàn màn hình
        }
        else
        {
            Resolution resolution = resolutions[screen_size];
            Screen.SetResolution(resolution.width, resolution.height, false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resolutions = new Resolution[2];

        resolutions[0].width = 1280;
        resolutions[0].height = 720;

        resolutions[1].width = 1920;
        resolutions[1].height = 1080;

        screen_size_dropdown.ClearOptions();

        List<string> options = new List<string>();

        //int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            //if (resolutions[i].width == Screen.currentResolution.width &&
            //    resolutions[i].height == Screen.currentResolution.height)
            //{
            //    currentResolutionIndex = i;
            //}
        }

        options.Add("Full Screen");

        screen_size_dropdown.AddOptions(options);
        //screen_size_dropdown.value = currentResolutionIndex;
        screen_size_dropdown.RefreshShownValue();

        if (SaveSystem.LoadData() != null)
        {
            LoadSetting();
        }
        else
        {
            LoadDefaultSetting();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
