using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

/*
 *
 *setValue()
 *
 *saveData()
 *
 *loadData()
 * 
 */
using UnityEngine.UI;

public class loadTextTest : MonoBehaviour {

	private string pathT;
	List<int> stList = new List<int>();
	private int[] v = new int[4];

	void Awake(){
		pathT = Application.persistentDataPath;
	}

	void Start(){

		setValue(new int[] {1,2,3,4});

		for (int i=0; i<4; i++) {
			print (stList [i]);
		}

		saveData ("a");
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
	
	public void saveData(string str){
		StreamWriter sw;
//		FileInfo fi;
		
//		fi = new FileInfo (pathT + "/test.txt");
		print (pathT + "test.txt");
//		sw = fi.AppendText ();	//追加はappendText
		sw = new StreamWriter (pathT + "/test.txt", false);	//上書き
		sw.Write (str);

//		for (int i=0; i<stDic.Count; i++) {
//			sw.WriteLine (stDic[i]);
//		}
		sw.Flush ();
		sw.Close ();
	}

	public void loadData(){
		StreamReader sr;

		sr = new StreamReader (pathT + "/test.txt");
//		string[] txt = {"aho","aho"};

		print (sr.Peek ());

		while(sr.Peek()>-1){
			print (sr.ReadLine());
		}

	}
}