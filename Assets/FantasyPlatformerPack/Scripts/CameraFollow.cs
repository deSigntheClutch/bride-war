using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public float xMargin = 1.0f;
	public float yMargin = 1.0f;
	public float xSmooth = 10.0f;
	public float ySmooth = 10.0f;
	public Vector2 maxXandY;
	public Vector2 minXandY;
	public Transform cameraTarget;
	
	bool CheckXMargin(){
		return Mathf.Abs(gameObject.transform.position.x - cameraTarget.position.x) > xMargin;
	}
	bool CheckYMargin(){
		return Mathf.Abs(gameObject.transform.position.y - cameraTarget.position.y) > yMargin;
	}
	
	void FixedUpdate () {
		TrackPlayer();
	}

	void TrackPlayer(){
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		if(CheckXMargin())
		{
			targetX = Mathf.Lerp(transform.position.x, cameraTarget.position.x, xSmooth * Time.deltaTime);
		}
		if(CheckYMargin())
		{
			targetY = Mathf.Lerp(transform.position.y, cameraTarget.position.y, ySmooth * Time.deltaTime);
		}
		targetX = Mathf.Clamp(targetX,minXandY.x,maxXandY.x);
		targetY = Mathf.Clamp(targetY,minXandY.y,maxXandY.y);
		transform.position = new Vector3(targetX,targetY,transform.position.z);
	}
}
