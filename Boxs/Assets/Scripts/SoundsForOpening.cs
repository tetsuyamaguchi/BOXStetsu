using UnityEngine;
using System.Collections;

public class SoundsForOpening : MonoBehaviour {

	public AudioClip opening;
	static AudioSource openingAudio;
	// Use this for initialization
	void Start () {
		//opening
		openingAudio = gameObject.AddComponent<AudioSource> ();
		openingAudio.clip = opening;
		openingAudio.loop = true;
		openingAudio.volume = 1F;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public static void BGMopening() { openingAudio.Play (); }
	public static void BGMopeningStop() { openingAudio.Stop (); }
}
