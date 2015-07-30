using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

/*
 *
 * 
 */

public class createStage : MonoBehaviour {
	
	private string pathT;
	private string saveName;
	List<int> stList = new List<int>();
	List<GameObject> cubeList = new List<GameObject> ();
	private int[] v = new int[4];

	private string buf;
	private GameObject setCube;

	public GameObject createCubeN;
	public GameObject createCubeR;
	public GameObject createCubeL;

	public int saveType;

	private GameObject memoryObj;
	private Memorize memorize;
	private string stageName;

	private CreateStageControll createstagecontroll;
	private SendMail sendmail;
	
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

		if (saveType == 3) {
			int ln = saveName.Length;
			GameObject.Find ("saveFolderText").GetComponent<Text> ().text = "all system green　";
		}
	
		createstagecontroll = GameObject.Find ("Main").GetComponent<CreateStageControll> ();
		sendmail = GameObject.Find ("Main").GetComponent<SendMail> ();
	}
	
	//後で消すこと
	public void debugMes(){
		Text txt = GetComponent<Text>();
		txt.text = pathT;
	}

/*
	public void setValue(int[] val){
		if (val.Length != 4) {
			print ("ERROR:引数不足");
		} else {
			for (int i=0; i<4; i++) {
				stList.Add (val [i]);
			}
		}
	}

	public void stListAdd(int[] addBlock){
		for (int i=0; i<4; i++) {
			stList.Add (addBlock [i]);
		}
	}
*/

	//
	public void saveCube(int type){

		//まずはtxtFileを初期化
		StreamWriter sw;

		string saveName2 = saveName + "_" + type + ".txt";

		print (saveName2);

		sw= new StreamWriter (saveName2, false);	//上書き
		sw.Write ("");
		sw.Flush();
		sw.Close();

		FileInfo fi;

		fi = new FileInfo (saveName2);

		sw = fi.AppendText ();	//追加はappendText
		//sw = new StreamWriter (pathT + "/test.txt", false);	//上書き
		//sw.Write (str);

		stList = createstagecontroll.stList;

		for (int i=0; i<stList.Count/4; i++) {
			sw.WriteLine (stList[4*i] + "," + stList[4*i+1] + "," + stList[4*i+2] + "," + stList[4*i+3]);
//			print (stList[4*i] + "," + stList[4*i+1] + "," + stList[4*i+2] + "," + cubeList[4*i+3]);
		}


		sw.Flush ();
		sw.Close ();
	}


	//TODO
	//txtが存在するかchkが必要
	//なかった場合は存在しないとメッセージを表示し
	//空のtxtを作る
	public void loadData(int type){

		StartCoroutine (fLoadData (type));
	}

	IEnumerator fLoadData(int type){

		print ("fDestroyBlock called in setBlock");
		yield return StartCoroutine (fDestroyBlock ());

//		print ("Destroy?");
//		StartCoroutine (fDestroyBlock());

//		GameObject.Find ("ButtonRetry").GetComponent<RetryBtn> ().fLetsRetry ();

		StreamReader sr;

		print ("load data = " + saveName + "_" + type + ".txt");
		sr = new StreamReader (saveName + "_" + type + ".txt");
		//		string[] txt = {"aho","aho"};
		
		while(sr.Peek()>-1){
			buf = sr.ReadLine();
//			print(buf);

			string[] tmp = new string[4];
			int tmpX=0;
			int tmpY=0;
			int tmpZ=0;
			int intTmpTag=0;
			string tmpTag="";

			for(int i=0;i<4;i++){
				tmp = buf.Split(',');
				if(i==0){
					tmpX = int.Parse(tmp[i]);
					print (tmpX);
				}

				switch (i) {
				case 0:
					tmpX = int.Parse(tmp[i]);
					print (tmpX);
					break;
				case 1:
					tmpY = int.Parse(tmp[i]);
					print (tmpY);
					break;
				case 2:
					tmpZ = int.Parse(tmp[i]);
					print (tmpZ);
					break;
				case 3:
					intTmpTag = int.Parse(tmp[i]);
					tmpTag = chkTag(int.Parse(tmp[i]));
					print (tmpTag);
					break;
				default:
				break;
				}
			}
			StartCoroutine( setBlock(tmpX,tmpY,tmpZ,intTmpTag));

		}

		sr.Close ();

		yield return new WaitForSeconds(0.01f);
	}

	private IEnumerator setBlock(int tmpX, int tmpY, int tmpZ,int intTmpTag){


		print ("setBlock start");
//		yield return new WaitForSeconds (5);
		createstagecontroll.setCubeList (Instantiate(setCube,new Vector3((float)tmpX,(float)tmpY,(float)tmpZ),transform.rotation) as GameObject);
//		createstagecontroll.setList (new int[]{tmpX,tmpY,tmpZ,intTmpTag});
		yield return new WaitForSeconds (0.01f);
	}

	private string chkTag(int t){
		switch (t) {
		case 2:
			setCube = createCubeN;
			return "Block";
			break;
		case 4:
			setCube = createCubeR;
			return "TurnR";
			break;
		case 5:
			setCube = createCubeL;
			return "TurnL";
			break;
		default:
			return "ERROR";
			break;
		}
	}

	public void destroyBlock(){
		StartCoroutine ("fDestroyBlock");
	}

	IEnumerator fDestroyBlock(){

		if (createstagecontroll.stList.Count == 0) {
			yield break;
		}

		print (createstagecontroll.stList[0]);

		createstagecontroll.stList.Clear ();


		string str = "";

		for (int i=0; i<3; i++) {
			switch (i) {
			case 0:
				str = "CubeN(Clone)";
				break;
			case 1:
				str = "CubeR(Clone)";
				break;
			case 2:
				str = "CubeL(Clone)";
				break;
			default:
			break;
			}

			GameObject obj=GameObject.Find (str);

			while (obj != null) {
				print (
				"Clone cube is " +
					GameObject.Find (str).transform.position.x + "," +
					GameObject.Find (str).transform.position.y + "," +
					GameObject.Find (str).transform.position.z
				);
				print (obj);
			
				Destroy (GameObject.Find (str));

				yield return new WaitForSeconds (0.01f);

				obj = GameObject.Find (str);
			}
		}

		createstagecontroll.cubeList.Clear ();

		print ("fDestroBlock finished");
		yield return new WaitForSeconds (0.1f);

	}

	public void fSend(){
		string str = "";

		stList = createstagecontroll.stList;
		
		for (int i=0; i<stList.Count/4; i++) {
			str += stList[4*i] + "," + stList[4*i+1] + "," + stList[4*i+2] + "," + stList[4*i+3] + ",";
		}

		sendmail.fSendMail (str);
	}

	public void fMessage(string str){
		GameObject.Find ("saveFolderText2").GetComponent<Text> ().text = str;
	}

	public void fMessageOFF(){
		GameObject.Find ("saveFolderText2").GetComponent<Text> ().text = "";
	}
}