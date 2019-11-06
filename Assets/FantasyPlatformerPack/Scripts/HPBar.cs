using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

	private PlayerManager player;
	private Slider hpBar;

	void Start()
	{
		hpBar = gameObject.GetComponent<Slider>();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
	}

	void Update () 
	{
		hpBar.value = player.hp;
	}
}
