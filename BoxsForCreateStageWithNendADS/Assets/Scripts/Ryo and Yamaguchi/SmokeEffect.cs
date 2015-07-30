using UnityEngine;
using System.Collections;

public class SmokeEffect : MonoBehaviour {

	public GameObject Effect;
	// Use this for initialization
	void Start () {
		print ("SMOKE OFF");
		Effect.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider c){

			print ("SMOKE");
			Effect.SetActive (true);
	}
}
