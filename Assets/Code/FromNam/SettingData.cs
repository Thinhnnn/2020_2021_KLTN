using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SettingData
{
    public float sound;
    public float music;
    public float speed_mouse;
    public int screen_size;
    public bool is_mute_sound;
    public bool is_mute_music;

    public SettingData(Setting setting)
    {
        sound = setting.sound;
        music = setting.music;
        speed_mouse = setting.speed_mouse;
        screen_size = setting.screen_size;
        is_mute_sound = setting.is_mute_sound;
        is_mute_music = setting.is_mute_music;
    }
}
