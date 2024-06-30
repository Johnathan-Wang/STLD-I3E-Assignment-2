
/*
 * Author: Wang Johnathan Zhiwen
 * Date: 30/06/2024
 * Description: 
 * Change audio volume
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void BGMVolume (float bgmvolume)
    {
        audioMixer.SetFloat("bgmvolume", bgmvolume);
    }

    public void SFXVolume(float sfxvolume)
    {
        audioMixer.SetFloat("sfxvolume", sfxvolume);
    }

}
