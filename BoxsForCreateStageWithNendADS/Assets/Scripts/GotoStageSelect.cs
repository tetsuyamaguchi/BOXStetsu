using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GotoStageSelect : MonoBehaviour {
	public string changeSceneName;
	//private List<AudioSource> ListAudio;

	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void fGotoStageSelect()
	{
		//再生しているaudioがあれば消す
		AudioSource[] ListAudio = FindObjectsOfType<AudioSource> ();
		foreach (var item in ListAudio) {
			Debug.Log ("audio playing is " + item);
			Debug.Log ("audio.isPlaying = " + item.isPlaying);
			
			if (item.isPlaying) {
				item.Stop();
			}
		}


		print ("GOto" + changeSceneName);
		Sounds.SEcursor ();
		Application.LoadLevel(changeSceneName);
	}

}
