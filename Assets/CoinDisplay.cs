using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    private int coinCount = 0;
    public Text coinText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 6)
        {
            coinText.text = GameObject.Find("Player_Prefab").GetComponent<PlayerManager>().coins.ToString();

        } else {
            coinText.text = coinCount.ToString();
        }
    }

    public void GainCoin(int numCoinGained)
    {
        coinCount += numCoinGained;
    }
}
