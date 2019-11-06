using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]

public class PaletteApply : MonoBehaviour {

	GameObject[] BG_001;
	GameObject[] BG_002;
	GameObject[] Spot_001;
	GameObject[] Spot_002;
	GameObject[] Icon_001;
	GameObject[] Text_001;
	GameObject[] Text_002;


	Color BG_001_color;
	Color BG_002_color;
	Color Spot_001_color;
	Color Spot_002_color;
	Color Icon_001_color;
	Color Text_001_color;
	Color Text_002_color;

	string paletteName;



	public void ApplyColor(){

		paletteName = transform.parent.name;

		PlayerPrefs.SetString ("paletteName", paletteName);

		BG_001_color = transform.parent.FindChild ("Image_BG_001").GetComponent<Image>().color;
		BG_002_color = transform.parent.FindChild ("Image_BG_002").GetComponent<Image>().color;
		Spot_001_color = transform.parent.FindChild ("Image_Spot_001").GetComponent<Image>().color;
		Spot_002_color = transform.parent.FindChild ("Image_Spot_002").GetComponent<Image>().color;
		Icon_001_color = transform.parent.FindChild ("Image_Icon_001").GetComponent<Image>().color;
		Text_001_color = transform.parent.FindChild ("Text_001").GetComponent<Text>().color;
		Text_002_color = transform.parent.FindChild ("Text_002").GetComponent<Text>().color;

		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().BG_001 = BG_001_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().BG_002 = BG_002_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().Spot_001 = Spot_001_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().Spot_002 = Spot_002_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().Icon_001 = Icon_001_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().Text_001 = Text_001_color;
		GameObject.Find ("UI_ColorManager").GetComponent<ColorManager> ().Text_002 = Text_002_color;

		PlayerPrefs.SetString ("BG_001", BG_001_color.ToString());
		Debug.Log (BG_001_color.ToString ());

		BG_001 = GameObject.FindGameObjectsWithTag("BG_001");
		for (int i = 0; i < BG_001.Length; i++) {

			BG_001 [i].GetComponent<Image> ().color = BG_001_color;
		}

		BG_002 = GameObject.FindGameObjectsWithTag("BG_002");
		for (int i = 0; i < BG_002.Length; i++) {

			BG_002 [i].GetComponent<Image> ().color = BG_002_color;
		}

		Spot_001 = GameObject.FindGameObjectsWithTag("Spot_001");
		for (int i = 0; i < Spot_001.Length; i++) {

			Spot_001 [i].GetComponent<Image> ().color = Spot_001_color;
		}

		Spot_002 = GameObject.FindGameObjectsWithTag("Spot_002");
		for (int i = 0; i < Spot_002.Length; i++) {

			Spot_002 [i].GetComponent<Image> ().color = Spot_002_color;
		}

		Icon_001 = GameObject.FindGameObjectsWithTag("Icon_001");
		for (int i = 0; i < Icon_001.Length; i++) {

			Icon_001 [i].GetComponent<Image> ().color = Icon_001_color;
		}

		Text_001 = GameObject.FindGameObjectsWithTag("Text_001");
		for (int i = 0; i < Text_001.Length; i++) {

			Text_001 [i].GetComponent<Text> ().color = Text_001_color;
		}


		Text_002 = GameObject.FindGameObjectsWithTag("Text_002");
		for (int i = 0; i < Text_002.Length; i++) {

			Text_002 [i].GetComponent<Text> ().color = Text_002_color;
		}




	}
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}
}
