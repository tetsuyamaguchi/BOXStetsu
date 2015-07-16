using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Stage01ControlKawashima : MonoBehaviour {
	
	public int cubeSpling;
	public int cubeLeft;
	public int cubeStraight;
	public int cubeRight;
	public int cubeBomb; // < 0629 igarashi add
	
	private GameObject main;
	private MainKawashima mainkawashima;
	
	private Text splingTxt;
	private Text straightTxt;
	private Text leftTxt;
	private Text rightTxt;
	private Text bombTxt;  // < 0629 igarashi add
	
	private GameObject splingObj;
	private GameObject straightObj;
	private GameObject leftObj;
	private GameObject rightObj;
	private GameObject bombObj;  // < 0629 igarashi add
	
	private GameObject splingBtn;
	private GameObject straightBtn;
	private GameObject leftBtn;
	private GameObject rightBtn;
	private GameObject bombBtn;  // < 0629 igarashi add
	
	private DropCubBtnKawashima dropcubeJ;
	private DropCubBtnKawashima dropcubeS;
	private DropCubBtnKawashima dropcubeL;
	private DropCubBtnKawashima dropcubeR;
	private DropCubBtnKawashima dropcubeB;  // < 0629 igarashi add
	
	private bool isSelected = false;
	
	// Use this for initialization
	void Start () {
		main =  GameObject.Find ("Main");
		mainkawashima = main.GetComponent<MainKawashima> ();
		
		splingObj = GameObject.Find ("NumberSplingText");
		splingTxt = splingObj.GetComponent<Text>();
		splingTxt.text = cubeSpling.ToString();
		splingBtn = GameObject.Find ("ButtonDropSpling");
		dropcubeJ = splingBtn.GetComponent<DropCubBtnKawashima> ();
		
		straightObj = GameObject.Find ("NumberStraightText");
		straightTxt = straightObj.GetComponent<Text>();
		straightTxt.text = cubeStraight.ToString();
		straightBtn = GameObject.Find ("ButtonDropStraight");
		dropcubeS = straightBtn.GetComponent<DropCubBtnKawashima> ();
		
		leftObj = GameObject.Find ("NumberLeftText");
		leftTxt = leftObj.GetComponent<Text>();
		leftTxt.text = cubeLeft.ToString();
		leftBtn = GameObject.Find ("ButtonDropLeft");
		dropcubeL = leftBtn.GetComponent<DropCubBtnKawashima> ();
		
		
		rightObj = GameObject.Find ("NumberRightText");
		rightTxt = rightObj.GetComponent<Text>();
		rightTxt.text = cubeRight.ToString();
		rightBtn = GameObject.Find ("ButtonDropRight");
		dropcubeR = rightBtn.GetComponent<DropCubBtnKawashima> ();
		
		
		//********************************************* 0629 igarashi start
		bombObj = GameObject.Find ("NumberBombText");
		bombTxt = bombObj.GetComponent<Text>();
		bombTxt.text = cubeBomb.ToString();
		bombBtn = GameObject.Find ("ButtonDropBomb");
		dropcubeB= bombBtn.GetComponent<DropCubBtnKawashima> ();
		//********************************************* 0629 igarashi end
		
		if (cubeSpling <=0) {
			dropcubeJ.fSetBooltrueSpring();
			//isSelected = true;
			Debug.Log("Send dropcubeJ.isSplingNoMore = true");
		}
		if (cubeStraight <=0) {
			dropcubeS.fSetBooltrueStraight();
			//isSelected = true;
			Debug.Log("Send dropcubeS.isStraightNoMore = true");
		}
		if (cubeLeft <=0) {
			dropcubeL.fSetBooltrueLeft();
			//isSelected = true;
			Debug.Log("Send dropcubeL.isLeftNoMore = true");
		}
		if (cubeRight <=0) {
			dropcubeR.fSetBooltrueRight();
			//isSelected = true;
			Debug.Log("Send dropcubeR.isRightNoMore = true");
		}
		if (cubeBomb <=0) {
			dropcubeB.fSetBooltrueBomb();
			//isSelected = true;
			Debug.Log("Send dropcubeB.isBombNoMore = true");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void fSplingUsed(){
		if (isSelected == false){
			return;
		}
		if (cubeSpling > 0) {
			cubeSpling --;
		}
		
		splingTxt.text = cubeSpling.ToString ();
		
		if (cubeSpling <= 0) {
			dropcubeJ.fSetBooltrueSpring();
			return;
		}
	}
	public void fStraightUsed(){
		if (isSelected == false){
			return;
		}
		if (cubeStraight > 0) {
			cubeStraight --;
		}
		straightTxt.text = cubeStraight.ToString ();
		
		if (cubeStraight <= 0) {
			dropcubeS.fSetBooltrueStraight();
			return;
		}
	}
	public void fLeftUsed(){
		if (isSelected == false){
			return;
		}
		if (cubeLeft > 0) {
			cubeLeft --;
		}
		leftTxt.text = cubeLeft.ToString ();
		
		if (cubeLeft <= 0) {
			dropcubeL.fSetBooltrueLeft();
			return;
		}
	}
	public void fRightUsed(){
		if (isSelected == false){
			return;
		}
		if (cubeRight > 0) {
			cubeRight --;
		}
		rightTxt.text = cubeRight.ToString ();
		
		if (cubeRight <= 0) {
			dropcubeR.fSetBooltrueRight();
			return;
		}
	}
	
	
	//********************************************* 0629 igarashi start
	public void fBombUsed() {
		if (isSelected == false){
			return;
		}
		if (cubeBomb > 0) {
			cubeBomb --;
		}
		bombTxt.text = cubeBomb.ToString ();
		
		if (cubeBomb <= 0) {
			dropcubeB.fSetBooltrueBomb();
			return;
		}
	}
	//********************************************* 0629 igarashi end
	
	public void fSelectedisFalse(){
		isSelected = false;
	}
	public void fSelectedisTrue(){
		isSelected = true;
	}
}
