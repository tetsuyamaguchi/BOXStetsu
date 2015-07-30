using UnityEngine;
using System.Collections;

public class BreakBlock : MonoBehaviour {


	// Use this for initialization
	IEnumerator Start ()
	{
		yield return new WaitForSeconds(0.01F);
		SphereCollider[] temoprary = GetComponentsInChildren<SphereCollider> ();
		foreach (var item in temoprary)
		{
			item.enabled= false;
		}

		Rigidbody[] temoprary2 = GetComponentsInChildren<Rigidbody> ();
		foreach (var item2 in temoprary2)
		{
			Destroy (item2);
		}

		yield return new WaitForSeconds(0.05F);
		Destroy (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
