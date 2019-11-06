using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleSender : MonoBehaviour {

	public Text ToggleText;

	public string ToggleOn;
	public string ToggleOff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.GetComponent<Toggle> ().isOn) {
			ToggleText.text = ToggleOn;
		}
		else
		{
			ToggleText.text = ToggleOff;

		}

	}
}
