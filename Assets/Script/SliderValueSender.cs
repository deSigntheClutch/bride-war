using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SliderValueSender : MonoBehaviour {

	public GameObject SliderValueTarget;

	public float SliderValue = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		SliderValue = transform.GetComponent<Slider>().value;

		SliderValueTarget.GetComponent<Text> ().text = ((int)SliderValue).ToString();
	}
}