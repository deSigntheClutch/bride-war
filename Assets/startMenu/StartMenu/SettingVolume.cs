using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void setLevel(float sliderValue) {
        mixer.SetFloat("MusicVol", -1 * sliderValue * 20);
    }
}
