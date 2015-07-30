﻿using UnityEngine;
using System.Collections;

public class StartBtn : MonoBehaviour {
	private GameObject playerObj;
	private PlayerControll playercontroll;
	
	private GameObject startCube;
	private startCubeAnim startcubeanim;
	
	public GameObject retryBtn;
	public GameObject confirmPanel;
	private GameObject memoryObj;
	private Memorize memorize;
	//public GameObject retryConfirmBtn;
	//public GameObject cancelBtn;
	
	// Use this for initialization
	void Start () {
		print ("StartBtn.Start() called");
		gameObject.SetActive (true);
		playerObj = GameObject.Find("Boxs2nd2");
		playercontroll = playerObj.GetComponent<PlayerControll>();
		
		//retryBtn = GameObject.Find ("ButtonRetry");
		confirmPanel.SetActive (false);
		retryBtn.SetActive (false);
		
		startCube = GameObject.Find ("StartCube");
		startcubeanim = startCube.GetComponent<startCubeAnim> ();
		
		memoryObj = GameObject.Find ("MemoryObject");
		memorize = memoryObj.GetComponent<Memorize> ();
		memorize.fMemoryStageName ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void fLetsStart(){

		retryBtn.SetActive (true);
		gameObject.SetActive (false);
		playercontroll.fStartButton ();
		//playercontroll.fNextMove();
		
		Sounds.SEjihouStop ();

	}
	public void fStartBtnOn(){
		gameObject.SetActive (true);
		retryBtn.SetActive (false);
	}
	public void fStartBtnOff(){
		gameObject.SetActive (false);
		retryBtn.SetActive (true);
	}
}