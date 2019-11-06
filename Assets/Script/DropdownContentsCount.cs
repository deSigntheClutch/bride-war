using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DropdownContentsCount : MonoBehaviour {

	public GameObject item;

	public int itemCount;

	Vector2 rectSize = new Vector2();

	// Use this for initialization
	void Start () {

		rectSize = transform.GetComponent<RectTransform> ().sizeDelta;
		rectSize.y = item.GetComponent<RectTransform> ().rect.height * itemCount;


		transform.GetComponent<RectTransform> ().sizeDelta = rectSize;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
