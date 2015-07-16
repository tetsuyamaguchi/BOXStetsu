using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RetryBtn : MonoBehaviour {
	public GameObject startBtn;
	public GameObject confirmPanel;
	public GameObject retryConfirmBtn;
	public GameObject cancelBtn;
	private StartBtn startbtnScript;
	private string stagename;
	private Button button;
	private Button buttonconfirm;
	private Button buttonCancel;
	private MainKawashima mainkawashima;
	private Text confirmTxt;
	// Use this for initialization
	void Start () {

		
		//startBtn = GameObject.Find ("ButtonStart");
		print (startBtn);
		mainkawashima = GameObject.Find ("Main").GetComponent<MainKawashima> ();
		stagename = Application.loadedLevelName;
		startbtnScript = startBtn.GetComponent<StartBtn> ();
		button = gameObject.GetComponent<Button>();
		buttonconfirm = retryConfirmBtn.GetComponent<Button>();
		buttonCancel = cancelBtn.GetComponent<Button>();


		confirmPanel.GetComponent<IsThisUi> ().enabled = false;
		confirmPanel.SetActive (false);

		
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void fLetsRetry(){
		confirmPanel.SetActive (true);
		confirmTxt = GameObject.Find ("ConfirmText").GetComponent<Text> ();
		confirmTxt.text = "Retry";
		confirmPanel.GetComponent<IsThisUi> ().enabled = true;
		button.enabled = false;
		buttonconfirm.onClick.AddListener (() => {
			Debug.Log ("Clicked.");
			Sounds.BGMstageStop();
			Sounds.SEjihouStop();
			Application.LoadLevel (stagename);
			startbtnScript.fStartBtnOn ();
			confirmPanel.GetComponent<IsThisUi> ().enabled = false;
			confirmPanel.SetActive (false);
			button.enabled = true;
			mainkawashima.fIsUiFalse ();
		});
			

		buttonCancel.onClick.AddListener (() => {
			confirmPanel.GetComponent<IsThisUi> ().enabled = false;
			confirmPanel.SetActive (false);
			button.enabled = true;
			mainkawashima.fIsUiFalse ();
		});

	}
}