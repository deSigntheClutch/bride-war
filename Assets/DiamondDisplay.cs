using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondDisplay : MonoBehaviour
{
    private int diamondCount = 0;
    public Text diamondText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        diamondText.text = diamondCount.ToString();
    }

    public void GainDiamond(int numDiamondGained)
    {
        diamondCount += numDiamondGained;
    }
}
