﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pickCoin;
    public static AudioClip throwCoin;
    void Start()
    {
        audioSrc=GetComponent<AudioSource>();
        pickCoin=Resources.Load<AudioClip>("PickCoin");
        throwCoin=Resources.Load<AudioClip>("ThrowCoin");
    }

       void Update()
    {
        
    }
    public static void PlayPickCoinClip()
    {
         audioSrc.PlayOneShot(pickCoin);
    }
    public static void PlayThrowCoinClip()
    {  
         audioSrc.PlayOneShot(throwCoin);
    }
}
