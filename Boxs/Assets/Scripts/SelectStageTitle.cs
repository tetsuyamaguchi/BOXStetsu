using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SelectStageTitle : MonoBehaviour {
	public string stageNumber;
	private Text stageNameTxt;
	public List<GameObject> listCubes;
	public Material BaseMaterial; 
	public Material TouchedMaterial; 



	// Use this for initialization
	void Start () {
		stageNameTxt = GameObject.Find ("stageSelectNumber").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void fStageName(){
		stageNameTxt.text = stageNumber;
		Sounds.SEcursor ();
		
		MeshRenderer hitMeshRenderer;
		
		foreach (var item in listCubes) {
			hitMeshRenderer = item.GetComponent<MeshRenderer> ();
			hitMeshRenderer.material = BaseMaterial;
		}
		int numCube = int.Parse (stageNumber) - 1;
		hitMeshRenderer = listCubes[numCube].GetComponent<MeshRenderer> ();
		hitMeshRenderer.material = TouchedMaterial;
		
	}




}
