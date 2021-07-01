using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sounds
{
    //class chứa thông tin của một âm thanh
    public AudioClip sound;

    public string name;

    [Range(0f, 1f)]
    public float volume;
    public bool isLoop;

    [HideInInspector]
    public AudioSource source;
}
