using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource EatCoin;
    public AudioSource EatDiamond;
    public AudioSource Attack1;

    public void PlayEatCoin()
    {
        EatCoin.Play();
    }

    public void PlayEatDiamond()
    {
        EatDiamond.Play();
    }

    public void PlayAttack1()
    {
        Attack1.Play();
    }
}
