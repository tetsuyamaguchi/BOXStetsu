using UnityEngine;
using System.Collections;

public class createStageSetCube : MonoBehaviour {

	private CreateStageControll createstagecontroll;
	// Use this for initialization
	void Start () {
		createstagecontroll = GameObject.Find ("Main").GetComponent<CreateStageControll> ();
		setCubeList ();

//		deleteCubeList ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setCubeList(){
		print ("BLOCK CREATE" + transform.root.gameObject);
		createstagecontroll.setCubeList(transform.root.gameObject);
	}

	public void deleteCubeList(){
		createstagecontroll.deleteCubeList (transform.root.gameObject);
	}


}
