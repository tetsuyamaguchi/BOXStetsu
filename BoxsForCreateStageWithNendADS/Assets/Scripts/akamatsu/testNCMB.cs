using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class testNCMB : MonoBehaviour {

	// Use this for initialization
	void Start () {
		NCMBObject testClass = new NCMBObject("TestClass");
		testClass["message"] = "Hello, NCMB!";
		testClass.SaveAsync();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
