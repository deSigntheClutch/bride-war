using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueReciver : MonoBehaviour {

	public GameObject SliderController;

	public float SliderValue = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		SliderValue = SliderController.GetComponent<Slider>().value;

		transform.GetComponent<Slider> ().value = SliderValue;
	}
}