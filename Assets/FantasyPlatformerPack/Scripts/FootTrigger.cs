using UnityEngine;
using System.Collections;

public class FootTrigger : MonoBehaviour {

	private CharacterMove player;
    bool isTouched = false;
	void Start()
	{
        isTouched = false;
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
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {//检测玩家是否碰到了敌人
            GameObject.Find("Player_Prefab").GetComponent<CharacterMove>().isTouched = true;
        }
    }
}
