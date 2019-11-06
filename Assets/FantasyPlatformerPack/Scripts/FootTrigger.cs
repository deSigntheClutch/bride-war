using UnityEngine;
using System.Collections;

public class FootTrigger : MonoBehaviour {

	private CharacterMove player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMove>();
	}

	void OnTriggerEnter(Collider other)
	{
		//If player lands, call Land function from CharacterMove to apply landing animation in Mecanim
		if(other.gameObject.tag != "Player")
		{
			player.Land();
		}
		//If player lands on object, that has Breakable Joint functionality, brake it
		if(other.gameObject.GetComponent<BreakableJoint>() != null)
		{
			other.gameObject.GetComponent<BreakableJoint>().Break();
		}
		//If player lands destructable object, brake it
		if(other.gameObject.GetComponent<BreakableObject>() != null)
		{
			other.gameObject.GetComponent<BreakableObject>().Break();
		}
	}
}
