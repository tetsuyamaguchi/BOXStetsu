using UnityEngine;
using System.Collections;

public class BreakHitEffect : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}


}
