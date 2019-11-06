using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleValue : MonoBehaviour {

	public bool ToggleBool;

	// Use this for initialization
	void Start () {

		ToggleBool = !ToggleBool;

//		transform.GetComponent<ToggleValue>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
