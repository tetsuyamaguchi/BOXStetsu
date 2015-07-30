using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class DropCubBtnKawashima : MonoBehaviour {
	private GameObject main;
	private MainKawashima mainkawashima;
	public bool isSplingNoMore = false;
	public bool isStraightNoMore = false;
	public bool isLeftNoMore = false;
	public bool isRightNoMore = false;
	public bool isBombNoMore = false; // < 0629 igarashi add
	private Image image;
	// Use this for initialization
	void Start () {
		main =  GameObject.Find ("Main");
		mainkawashima = main.GetComponent<MainKawashima> ();
		//image = gameObject.GetComponent<Image> ();
		/*
		Debug.Log ("isRightNoMore = " + isRightNoMore);
		if (isSplingNoMore || isStraightNoMore || isLeftNoMore || isRightNoMore || isBombNoMore) {
			Debug.Log("NoMore Is TRUE");
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fSplingClicked(){
		print ("start fSplingClickedClicked");
		if(isSplingNoMore) {
			image = gameObject.GetComponent<Image> ();
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
			return;
		}
		main.SendMessage ("fSplingUsed");
		mainkawashima.fDrop (0);
	}
	public void fLeftClicked(){
		print ("start fLeftClickedClicked");
		if(isLeftNoMore) {
			image = gameObject.GetComponent<Image> ();
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
			return;
		}
		main.SendMessage ("fLeftUsed");
		mainkawashima.fDrop (1);
	}
	public void fStraightClicked(){
		print("isStraightNoMore =  + isStraightNoMore");
		if(isStraightNoMore) {
			image = gameObject.GetComponent<Image> ();
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
			return;
		}
		print ("start fStraightClicked");
		main.SendMessage ("fStraightUsed");
		mainkawashima.fDrop (2);
	}
	
	public void fRightClicked(){
		print ("start fRightClicked");
		if(isRightNoMore) {
			image = gameObject.GetComponent<Image> ();
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
			return;
		}
		main.SendMessage ("fRightUsed");
		mainkawashima.fDrop (3);
	}
	//********************************************* 0629 igarashi start
	public void fBombClicked() {
		print ("start fBombClicked");
		if(isBombNoMore) {
			image = gameObject.GetComponent<Image> ();
			image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
			return;
		}
		main.SendMessage("fBombUsed");
		mainkawashima.fDrop(4);
	}
	//********************************************* 0629 igarashi end
	public void fSetBooltrueSpring(){
		isSplingNoMore = true;
		image = gameObject.GetComponent<Image> ();
		image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	public void fSetBooltrueLeft(){
		isLeftNoMore = true;
		image = gameObject.GetComponent<Image> ();
		image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	public void fSetBooltrueStraight(){
		isStraightNoMore = true;
		image = gameObject.GetComponent<Image> ();
		image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	public void fSetBooltrueRight(){
		isRightNoMore = true;
		image = gameObject.GetComponent<Image> ();
		image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
	public void fSetBooltrueBomb(){
		isBombNoMore = true;
		image = gameObject.GetComponent<Image> ();
		image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
	}
}