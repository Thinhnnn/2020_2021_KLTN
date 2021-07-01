using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] musics;
    public Sound[] sounds;

    public static AudioManager instance;

    List<AudioSource> myMusicAS = new List<AudioSource>();
    List<AudioSource> mySoundAS = new List<AudioSource>();

    public float sound;
    public float music;
    public bool is_mute_sound;
    public bool is_mute_music;

    // Start is called before the first frame update
    void Start()
    {
        if (is_mute_music == false)
        {
            PlayMusic("BGM");
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //DontDestroyOnLoad(gameObject);
        
        LoadAudioSetting();

        foreach (Sound s in musics)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            myMusicAS.Add(s.source);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            //s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            mySoundAS.Add(s.source);
        }
    }

    public float GetVolumeMusic(AudioClip clip)
    {
        Sound s = Array.Find(musics, music => music.clip == clip);
        return s.volume;
    }

    public float GetVolumeSound(AudioClip clip)
    {
        Sound s = Array.Find(sounds, sound => sound.clip == clip);
        return s.volume;
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musics, music => music.name == name);
        s.source.Play();
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.PlayOneShot(s.clip);
        //s.source.Play();
    }

    public void StopMusic(string name)
    {
        Sound s = Array.Find(musics, music => music.name == name);
        s.source.Stop();
    }

    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void ChangeSound(Slider sound_slider)
    {
        sound = sound_slider.value;
    }

    public void ChangeMusic(Slider music_slider)
    {
        music = music_slider.value;
    }

    public void ChangeMuteMusic(Toggle music_toggle)
    {
        is_mute_music = music_toggle.isOn;
    }

    public void ChangeMuteSound(Toggle sound_toggle)
    {
        is_mute_sound = sound_toggle.isOn;
    }

    public void UpdateMusic()
    {
        foreach (AudioSource ads in myMusicAS)
        {
            ads.volume = music * GetVolumeMusic(ads.clip);
        }
    }

    public void MuteMusic()
    {
        foreach (AudioSource ads in myMusicAS)
        {
            ads.mute = is_mute_music;
        }
        if (is_mute_music == false)
        {
            PlayMusic("BGM");
        }
    }

    public void UpdateSound()
    {
        foreach (AudioSource ads in mySoundAS)
        {
            ads.volume = sound * GetVolumeSound(ads.clip);
        }
    }

    public void MuteSound()
    {
        foreach (AudioSource ads in mySoundAS)
        {
            ads.mute = is_mute_sound;
        }
    }

    public void LoadAudioSetting()
    {
        SettingData data = SaveSystem.LoadData();
        if (data != null)
        {
            sound = data.sound;
            music = data.music;
            is_mute_sound = data.is_mute_sound;
            is_mute_music = data.is_mute_music;
        }
        else
        {
            sound = .5f;
            music = .5f;
            is_mute_sound = false;
            is_mute_music = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
