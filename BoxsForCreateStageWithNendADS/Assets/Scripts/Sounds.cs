﻿using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {
	
	public AudioClip stage;
	static AudioSource stageAudio;
	
	public AudioClip cursor;
	static AudioSource cursorAudio;
	public AudioClip cursor2;
	static AudioSource cursor2Audio;
	
	public AudioClip decision;
	static AudioSource decisionAudio;
	
	public AudioClip bomb;
	static AudioSource bombAudio;
	
	public AudioClip shine;
	static AudioSource shineAudio;
	
	public AudioClip union;
	static AudioSource unionAudio;
	
	public AudioClip select;
	static AudioSource selectAudio;
	
	public AudioClip cancel;
	static AudioSource cancelAudio;
	
	public AudioClip error;
	static AudioSource errorAudio;
	
	public AudioClip shutter;
	static AudioSource shutterAudio;
	
	public AudioClip cleared;
	static AudioSource clearedAudio;
	
	public AudioClip hanabi;
	static AudioSource hanabiAudio;

	public AudioClip gameover;
	static AudioSource gameoverAudio;

	public AudioClip jihou;
	static AudioSource jihouAudio;


	// Use this for initialization
	void Start ()
	{
		//stage
		stageAudio = gameObject.AddComponent<AudioSource> ();
		stageAudio.clip = stage;
		stageAudio.loop = true;
		stageAudio.volume = 1F;
		
		
		//cursor
		cursorAudio = gameObject.AddComponent<AudioSource> ();
		cursorAudio.clip = cursor;
		cursorAudio.loop = false;
		cursorAudio.volume = 1F;
		//cursor2
		cursor2Audio = gameObject.AddComponent<AudioSource> ();
		cursor2Audio.clip = cursor2;
		cursor2Audio.loop = false;
		cursor2Audio.volume = 1F;
		
		//dicision
		decisionAudio = gameObject.AddComponent<AudioSource> ();
		decisionAudio.clip = decision;
		decisionAudio.loop = false;
		decisionAudio.volume = 1F;
		
		//bomb
		bombAudio = gameObject.AddComponent<AudioSource> ();
		bombAudio.clip = bomb;
		bombAudio.loop = false;
		bombAudio.volume = 1F;
		
		//shine
		shineAudio = gameObject.AddComponent<AudioSource> ();
		shineAudio.clip = shine;
		shineAudio.loop = false;
		shineAudio.volume = 1F;
		
		//union
		unionAudio = gameObject.AddComponent<AudioSource> ();
		unionAudio.clip = union;
		unionAudio.loop = false;
		unionAudio.volume = 1F;
		
		//select
		selectAudio = gameObject.AddComponent<AudioSource> ();
		selectAudio.clip = select;
		selectAudio.loop = false;
		selectAudio.volume = 1F;
		
		//cancel
		cancelAudio = gameObject.AddComponent<AudioSource> ();
		cancelAudio.clip = cancel;
		cancelAudio.loop = false;
		cancelAudio.volume = 1F;
		
		//error
		errorAudio = gameObject.AddComponent<AudioSource> ();
		errorAudio.clip = error;
		errorAudio.loop = false;
		errorAudio.volume = 1F;
		
		//shutter
		shutterAudio = gameObject.AddComponent<AudioSource> ();
		shutterAudio.clip =shutter;
		shutterAudio.loop = false;
		shutterAudio.volume = 1F;
		
		//cleared
		clearedAudio = gameObject.AddComponent<AudioSource> ();
		clearedAudio.clip = cleared;
		clearedAudio.loop = false;
		clearedAudio.volume = 1F;
		
		//hanabi
		hanabiAudio = gameObject.AddComponent<AudioSource> ();
		hanabiAudio.clip = hanabi;
		hanabiAudio.loop = false;
		hanabiAudio.volume = 1F;

		//gameover
		gameoverAudio = gameObject.AddComponent<AudioSource> ();
		gameoverAudio.clip = gameover;
		gameoverAudio.loop = false;
		gameoverAudio.volume = 1F;

		//jihou
		jihouAudio = gameObject.AddComponent<AudioSource> ();
		jihouAudio.clip = jihou;
		jihouAudio.loop = false;
		jihouAudio.volume = 1F;
	}
	
	public static void BGMstage() { stageAudio.Play (); }
	public static void BGMstageStop() {
		stageAudio.Stop ();
	}//Kawashima added 0710
	public static void SEcursor() { cursorAudio.Play (); }
	public static void SEcursor2() { cursor2Audio.Play (); }
	
	public static void SEdecision() { decisionAudio.Play (); }
	
	public static void SEbomb() { bombAudio.Play (); }
	public static void SEshine() { shineAudio.Play (); }
	public static void SEunion() { unionAudio.Play (); }
	
	public static void SEselect() { selectAudio.Play (); }
	public static void SEcancel() { cancelAudio.Play (); }
	public static void SEerror() { errorAudio.Play (); }
	
	public static void SEshutter() { shutterAudio.Play (); }
	public static void BGMcleared() { clearedAudio.Play (); }
	public static void SEhanabi() { hanabiAudio.PlayDelayed (7);}
	public static void BGMgameover() { gameoverAudio.Play (); }
	public static void SEjihou() { jihouAudio.Play (); }
	public static void SEjihouStop() { jihouAudio.Stop (); }
}
