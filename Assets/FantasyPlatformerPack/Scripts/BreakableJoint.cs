using UnityEngine;
using System.Collections;

public class BreakableJoint : MonoBehaviour {

	public void Break()
	{
		Destroy(gameObject.GetComponent<HingeJoint>());
	}
}
