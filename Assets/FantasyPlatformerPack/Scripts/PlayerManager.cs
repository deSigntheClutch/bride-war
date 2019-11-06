using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int hp = 3;
	public int maxHP = 3;
	public int coins = 0;

	public void Awake()
	{
		//Load saved stats
		LoadStats();
	}
	//Add HP to player
	public void AddHP(int count)
	{
		if(hp + count <= maxHP)
		hp = hp + count;
		else
		hp = maxHP;
	}
	//Reduce player HP
	public void ReduceHP(int count)
	{
		if(hp - count >= 0)
		hp = hp - count;
		else
		Die();
	}
	//Add coins to player
	public void AddCoins(int count)
	{
		coins = coins + count;
	}
	//Reduce player coins
	public void ReduceCoins(int count)
	{
		coins = coins - count;
	}

	public void SaveStats()
	{
		//--Save hp and coins--
		PlayerPrefs.SetInt("HP",hp);
		PlayerPrefs.SetInt("Coins",coins);
	}

	public void LoadStats()
	{
		//---If save game exists load coins and hp from last save--
		//--If not exist set health to maximum and coins to zero--
		if(PlayerPrefs.HasKey("HP"))
		hp = PlayerPrefs.GetInt("HP");
		else
		hp = maxHP;
		if(PlayerPrefs.HasKey("Coins"))
	    coins = PlayerPrefs.GetInt("Coins");
		else
		coins = 0;
	}
	//What happens when player dies
	private void Die()
	{
		//-- Show Died UI Panel--
	}
}
