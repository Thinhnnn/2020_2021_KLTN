using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioGameplayManager : MonoBehaviour
{
    //class quản lý âm thanh khi chơi game

    //tạo 1 mảng các âm thanh
    public Sounds[] audios;
    void Awake()
    {
        //load các âm thanh sẽ sử dụng trong scene này
        foreach (Sounds s in audios)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.sound;
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.loop = s.isLoop;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //mở nhạc nền khi bắt đầu chạy scene này
        Play("GameBGM");
    }
    public void Play(string name)
    {
        //hàm phát 1 âm thanh theo tên của nó
        Sounds s = Array.Find(audios, sound => sound.name == name);
        s.source.Play();
    }

    public void Stop(string name)
    {
        //hàm tắt 1 âm thanh theo tên của nó
        Sounds s = Array.Find(audios, sound => sound.name == name);
        s.source.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
