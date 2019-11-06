 using UnityEngine;

 // CoinRewarder.cs
 // Attach this to any game object that can reward coins for whatever reason
 // (be it an enemy kill reward, collectable coin, gold, etc).
 public sealed class CoinRewarder : MonoBehaviour
 {
     [SerializeField]
     private int minimumCoinReward = 3;
     [SerializeField]
     private int maximumCoinReward = 5;
     [SerializeField]
     private GameObject reward = null;
 
     public float yPosition;
     
     public AudioSource BossDied;

     public int MinimumCoinReward {
         get { return this.minimumCoinReward; }
         set { this.minimumCoinReward = value; }
     }
 
     public int MaximumCoinReward {
         get { return this.maximumCoinReward; }
         set { this.maximumCoinReward = value; }
     }
    public GameObject RewardObject{
         get { return this.reward; }
         set { this.reward = value; }
     }
 
     public void Reward()
     {
         // Randomly pick a coin reward within the given range.
         int coins = Random.Range(this.MinimumCoinReward, this.MaximumCoinReward);
         for (int i = 0; i < coins; ++i) {
             GameObject player = GameObject.FindWithTag("Player");
             if (player != null) {
                 Instantiate(this.reward, new Vector3 (34, yPosition, player.transform.position.z + 5 * (i+1)), Quaternion.identity);
             }
         }

         BossDied.Play();
     }
 }