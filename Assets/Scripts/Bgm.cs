using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    public AudioSource f;

    public AudioSource s;

    public AudioSource shoot;

    public AudioSource bridge;

    public AudioSource red;

    public AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        s . clip  =  (AudioClip )Resources . Load ("s.mp3",  typeof (AudioClip ) ) ; 
        f.clip = Resources.Load<AudioClip>("f.mp3");
        shoot.clip = Resources.Load<AudioClip>("shoot.wav");
        bridge.clip = Resources.Load<AudioClip>("bridge.mp3");
        red.clip = Resources.Load<AudioClip>("red.mp3");
        bgm.clip = Resources.Load<AudioClip>("bgm.wav");
        s.Play();
        f.Play();
        shoot.Play();
        bridge.Play();
        red.Play();
        bgm.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
