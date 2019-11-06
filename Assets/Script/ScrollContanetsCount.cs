using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollContanetsCount : MonoBehaviour {

	public GameObject ScrollView;
	public int contentsCount;
	Vector2 contentsSize = new Vector2();
	Vector3 contentsPos =  new Vector3(0f,0f,0f);

	// Use this for initialization
	void Start () {
		contentsPos =  transform.GetComponent<RectTransform> ().position;

		if (ScrollView.GetComponent<ScrollRect> ().horizontal == true)
		{
			contentsSize.x = (transform.GetComponent<GridLayoutGroup> ().cellSize.x * contentsCount) + (transform.GetComponent<GridLayoutGroup> ().spacing.x * (contentsCount + 1));
			contentsSize.y = transform.GetComponent<GridLayoutGroup> ().cellSize.y;

			transform.GetComponent<RectTransform> ().sizeDelta = contentsSize;

			contentsPos.x = 1000f;
			transform.GetComponent<RectTransform> ().position = contentsPos;
		} 
		else if (ScrollView.GetComponent<ScrollRect> ().vertical == true)
		
		{
			contentsSize.x = transform.GetComponent<GridLayoutGroup> ().cellSize.x;
			contentsSize.y = (transform.GetComponent<GridLayoutGroup> ().cellSize.y * contentsCount)+(transform.GetComponent<GridLayoutGroup>().spacing.y * (contentsCount + 1));

			transform.GetComponent<RectTransform> ().sizeDelta = contentsSize;

			contentsPos.y = 0f;
			transform.GetComponent<RectTransform> ().position = contentsPos;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
