using UnityEngine;
using System.Collections;

public class BreakableObject : MonoBehaviour {

	public GameObject breakablePrefab;
	public AudioClip destroySound;

	public void Break()
	{
		StartCoroutine(Wait());
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(0.05f);
		if(destroySound)
			AudioSource.PlayClipAtPoint(destroySound, transform.position);
		Instantiate(breakablePrefab, transform.position,transform.rotation);
		Destroy(gameObject);
	}
}
