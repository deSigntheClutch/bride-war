using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public GameObject coinPickupParticles;
	public AudioClip coinPickupAudio;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			//Add coin to player
			other.GetComponent<PlayerManager>().AddCoins(1);
			//--If there are any coin pickup sound, play it--
			if(coinPickupAudio)
			AudioSource.PlayClipAtPoint(coinPickupAudio, transform.position);
			//--If there are any coin pickup particle effect - instantate it--
			if(coinPickupParticles)
			Instantiate(coinPickupParticles,transform.position,Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
