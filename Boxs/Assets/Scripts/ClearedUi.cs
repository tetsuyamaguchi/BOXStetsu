using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClearedUi : MonoBehaviour {
	//private GameObject clearedObj;
	//private Text text;
	private GameObject fullScreenBtnObj;//Kawashima 0710
	//private Button gotoSelectStageBtn;//Kawashima 0710

	// Use this for initialization
	void Start () {
		//clearedObj = GameObject.Find ("TextCleared");
		//text = clearedObj.GetComponent<Text>();
		//text.enabled = false;
		//Kawashima 0710
		gameObject.GetComponent<Image> ().enabled = false;
		fullScreenBtnObj = GameObject.Find ("FullScreenButton");
		fullScreenBtnObj.SetActive (false);
		//gotoSelectStageBtn = fullScreenBtnObj.GetComponent<Button> ();
		//gotoSelectStageBtn.enabled = false;
		//Kawashima 0710 end

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void fClearedOn(){
		//text.enabled = true;
		gameObject.GetComponent<Image> ().enabled = true;
		fullScreenBtnObj.SetActive (true);
		//gotoSelectStageBtn.enabled = true;
		Debug.Log ("Cleared Text setActive(true)");
	}
}
