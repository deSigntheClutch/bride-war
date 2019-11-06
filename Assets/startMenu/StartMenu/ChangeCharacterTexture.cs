using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterTexture : MonoBehaviour
{

    public Texture[] textures;
    public int currentTexture;
    public Renderer rend;

    void Start()
    {
        GameController.SavePrincessSkin(textures[0]);
    }

    public void characterText() {
        currentTexture++;
        currentTexture %= textures.Length;
        rend.material.mainTexture = textures[currentTexture];
        GameController.SavePrincessSkin(textures[currentTexture]);
    }



}
