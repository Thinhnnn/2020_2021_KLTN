using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class MenuAudioManager : MonoBehaviour
{
    //class quản lý âm thanh của scene Menu

    public Sounds[] audios; //mảng các âm thanh sẽ sử dụng
    // Start is called before the first frame update
    void Awake()
    {
        //khi bắt đầu scene, load toàn bộ âm thanh sẽ sử dụng lên
        foreach (Sounds s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.loop = s.isLoop;
        }
    }

    void Start()
    {
        //bật nhạc nền khi chạy scene
        //Play("MenuBGM");
    }

    public void Play(string name)
    {
        //hàm mở một âm thanh
        Sounds s = Array.Find(audios, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        //hàm tắt một âm thanh
        Sounds s = Array.Find(audios, sound => sound.name == name);
        s.source.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
