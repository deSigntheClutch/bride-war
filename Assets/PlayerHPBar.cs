using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHPBar : MonoBehaviour {

	private Movement player;
	private Slider hpBar;

	void Start()
	{
		hpBar = gameObject.GetComponent<Slider>();
		Debug.Log(hpBar.value);
		player = GameObject.FindWithTag("Player").GetComponent<Movement>();
	}

	void Update () 
	{
		hpBar.value = player.health.getHealth();
	}
}
