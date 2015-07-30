using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

public class CreateStageControll : MonoBehaviour {
	
	private string pathT;
	private string saveName;
	public List<int> stList = new List<int>();
	public List<GameObject> cubeList = new List<GameObject> ();		//publicでなくgetterにする？Listでもできる？
	private int[] v = new int[4];
	
	private string buf;
	private GameObject setCube;
	
	public GameObject createCubeN;
	public GameObject createCubeR;
	public GameObject createCubeL;
	public GameObject createCubeB;
	
	public int saveType;
	
	private GameObject memoryObj;
	private Memorize memorize;
	private string stageName;
	
	private createStage createstage;
	
	void Awake(){
		pathT = Application.persistentDataPath;
		
		
	}
	
	IEnumerator Start(){
		yield return new WaitForSeconds (1);
		
		memoryObj = GameObject.Find ("MemoryObject");
		if (memoryObj != null) {
			print (memoryObj);
			memorize = memoryObj.GetComponent<Memorize> ();
			stageName = memorize.fGetStageName ();
			
			print(memorize.fGetStageName ());
		}
		print (stageName);
		
		saveName = pathT + "/" + stageName;
/*
		if (saveType == 3) {
			int ln = saveName.Length;
			GameObject.Find ("saveFolderText").GetComponent<Text> ().text = "";
		}
*/		
	}
	
	//後で消すこと
	public void debugMes(){
		Text txt = GetComponent<Text>();
		txt.text = pathT;
	}
	public void setValue(int[] val){
		if (val.Length != 4) {
			print ("ERROR:引数不足");
		} else {
			for (int i=0; i<4; i++) {
				stList.Add (val [i]);
			}
		}
	}
	public void cubeListAdd(int[] addBlock){
		for (int i=0; i<4; i++) {
			stList.Add (addBlock [i]);
		}
	}

	public void setBlock(GameObject setCube,int tmpX, int tmpY, int tmpZ){
		cubeList.Add (Instantiate(setCube,new Vector3((float)tmpX,(float)tmpY,(float)tmpZ),transform.rotation) as GameObject);
	}

	public void setList(int[] ary){
		for (int i=0; i<4; i++) {
			stList.Add(ary [i]);
		}
	}

	public void deleteCubeList(GameObject obj){
		int ind = cubeList.IndexOf (obj);
		print (ind);
		cubeList.RemoveAt (ind);
		if (obj.tag != "Bomb") {
			for (int i=0; i<4; i++) {
				stList.RemoveAt (ind * 4 + 3 - i);
			}
		}
//		print (o.transform.position.x + "," + o.transform.position.y + "," + o.transform.position.z);
	}
	
	public GameObject chkTag(int t){
		switch (t) {
		case 2:
			setCube = createCubeN;
			return setCube;
			break;
		case 4:
			setCube = createCubeR;
			return setCube;
			break;
		case 5:
			setCube = createCubeL;
			return setCube;
			break;
		default:
			return null;
			break;
		}
	}
	
	public void setCubeList(GameObject obj){
		cubeList.Add (obj);
	}

	public void destroyCube(){
		print ("destroyCube?");
		foreach (var item in cubeList) {
			print("destroyCube!");
			Destroy(item);
		}
		stList.Clear ();
	}
}