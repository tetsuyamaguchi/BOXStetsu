using UnityEngine;
using System.Collections;

public class SendMail : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void fSendMail(string str){
		print ("mailer :" + str);
		Application.OpenURL("mailto:ymgchi2015@gmail.com?subject=何も編集せず送信してください&body=" + str);
	}
}
