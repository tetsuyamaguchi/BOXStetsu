using UnityEngine;
using System.Collections;

public class RollArrow : MonoBehaviour {
	float rollSpeed = 5;
	public GameObject turnCanvas;
	GameObject clone;

	public GameObject effect;
	public bool isEffect;
	
	//-------------------------------------------------igarashi add
	public bool isGround = false;
	public bool IsGround { get { return isGround; } }
	//---------------------------------------------------------------

	//-------------------------------------------------0715 kawashima add
	private MainKawashima mainkawashima;
	private Stage01ControlKawashima stagecontroll;

	private string origin;


	private PlayerControll playercontroll;
	private createStage createstage;

	private const int BLOCK = 2;
	private const int TURNR = 4;
	private const int TURNL = 5;

	private int addFlg=0;

	private CreateStageControll createstagecontroll;
	// Use this for initialization

	void Start ()
	{
		playercontroll = GameObject.Find ("Boxs2nd2").GetComponent<PlayerControll> ();
		createstagecontroll = GameObject.Find ("Main").GetComponent<CreateStageControll> ();

		origin = gameObject.tag;

		StartCoroutine ("fBlockIsOnGroundFlag");
		
		if (gameObject.tag == "TurnL")
		{
			clone = Instantiate (turnCanvas, transform.position, Quaternion.Euler (90, 0, 0)) as GameObject;
			
			clone.transform.SetParent(transform);
			
			StartCoroutine ("fRollLObject");
		}
		
		if (gameObject.tag == "TurnR")
		{
			
			clone = Instantiate (turnCanvas, transform.position, Quaternion.Euler (90, 0, 0)) as GameObject;
			clone.transform.localScale = new Vector3(-1 * clone.transform.localScale.x,
			                                         clone.transform.localScale.y,
			                                         clone.transform.localScale.z);
			
			clone.transform.SetParent(transform);
			
			StartCoroutine ("fRollRObject");
		}
		
		//********************************************* 0629 igarashi start
		if (gameObject.tag == "Bomb") 
		{
			StartCoroutine ("fBombObject");
		}
		//********************************************* 0629 igarashi end
		//-------------------------------------------------0715 kawashima add
		mainkawashima = GameObject.Find ("Main").GetComponent<MainKawashima> ();
		stagecontroll = GameObject.Find ("Main").GetComponent<Stage01ControlKawashima> ();

	}
	
	// Update is called once per frame
	void Update () {
	//	if(gameObject.tag ==
	}

	IEnumerator fChkBox(){
		print ("fChkBox");
		for (int i=0; i<3; i++) {
			yield return new WaitForSeconds (1f);
		}
		gameObject.tag = origin;
	}
	
	IEnumerator fRollLObject()
	{
		while (true)
		{
			clone.transform.Rotate (0, 0, rollSpeed);
			yield return new WaitForSeconds (0.01F);
		}
	}
	
	IEnumerator fRollRObject()
	{
		while (true)
		{
			//			////print ("aaaa");
			//			////print (rollSpeed);
			clone.transform.Rotate (0, 0, -rollSpeed);
			yield return new WaitForSeconds (0.01F);
		}
	}
	
	//-------------------------------------------------------------0702 method change by igarashi
	//fBombObject
	
	IEnumerator fBombObject()
	{
		//print ("来てる");
		
		Collider collider;
		
		float prePos;
		float nowPos;
		
		while (true)
		{
			prePos = transform.localPosition.y;
			yield return new WaitForSeconds (0.03F);
			nowPos = transform.localPosition.y;

			if ((prePos -nowPos) < 0.01F)
			{
				bool flag = Physics.CheckSphere(new Vector3 (transform.localPosition.x,
				                                             transform.localPosition.y - 1,
				                                             transform.localPosition.z), 0.1F);
				if (flag == true)
				 {
					Collider[] c = Physics.OverlapSphere (new Vector3 (transform.localPosition.x,
					                                                   transform.localPosition.y - 1,
					                                                   transform.localPosition.z), 0.1F);
					collider = c[0];
					break;
				}
			}
				          
/*
			if ((prePos -nowPos) < 0.01F) {
				Collider[] c = Physics.OverlapSphere (new Vector3 (transform.localPosition.x,
				                                                   transform.localPosition.y - 1,
				                                                   transform.localPosition.z), 0.1F);
				collider = c[0];
				break;
			}
*/
		}
		
		//sound
		Sounds.SEbomb ();

		if (collider.gameObject.tag == "Floor") {
			Destroy (gameObject,0.5f);
		}

		if (collider.gameObject.tag == "Block" ||
		    collider.gameObject.tag == "Bomb" ||
		    collider.gameObject.tag == "TurnR" ||
		    collider.gameObject.tag == "TurnL")
		{
			Destroy (collider.gameObject,0.5f);
			collider.gameObject.GetComponent<createStageSetCube>().deleteCubeList();
			createstagecontroll.deleteCubeList (transform.root.gameObject);
			Destroy (gameObject,0.5f);

			//*************************************************0722 yamaguchi start
			//爆弾でlistを消去



			//*************************************************0722 yamaguchi finish

			//-------------------------------------------------0715 kawashima add
			stagecontroll.fSelectedisFalse();
			mainkawashima.fIsSelectedFalse();
			mainkawashima.fEffectboxDisabele();

		}
	}
	
	//--------------------------------------------------------------------0702 method change by igarashi
	//fFlagAvoid()
	//ブロックがおりきったときの判定
	IEnumerator fBlockIsOnGroundFlag ()
	{
		float prePos;
		float nowPos;
		
		while (true)
		{
			//if (searchForAvoid == true) break;
			
			prePos = transform.localPosition.y;
			yield return new WaitForSeconds (0.01F);
			nowPos = transform.localPosition.y;
			
			if ((prePos -nowPos) < 0.01F)
			{
				bool onGround = Physics.CheckSphere (new Vector3 (transform.position.x + 0.25F,
				                                                  transform.position.y - 1,
				                                                  transform.position.z + 0.25F), 0.1F);
				if (onGround == true)
				{
					//					//print ("設置完了");
					isGround = true;
					//if(effect!=null){
					//	effect.SetActive(true);
					//}

					if(isEffect != true){
						effect.SetActive(true);
					}

					if(addFlg==0){
						addList();
						addFlg=1;
					}

					break;
				}
			}
		}
		
	} // end fFlagAvoid()


	
	void OnTriggerEnter(Collider c)
	{
		print ("tag = " + c.tag);
		if (c.tag == "SensorForAvoidBlock")	
		{
			//PlayerControllスクリプトのfAvoid
			c.gameObject.GetComponentInParent<PlayerControll> ().StartCoroutine("fAvoidBlock", gameObject);
			//searchForAvoid = true;
		}
		
		
		if (c.tag == "SensorFrontUP")
		{
			if (isGround == true) return;
			c.gameObject.GetComponentInParent<PlayerControll> ().StartCoroutine("fWaitPlayer", gameObject);
		}


	}

	private void addList(){
		if (isGround == true && playercontroll.cnt < 0) {
			print ("setBlock called from cube" + addFlg);

			if(gameObject.tag != "Bomb"){
			createstagecontroll.setList (new int[]{
				(int)Mathf.Round( transform.position.x),
				(int)Mathf.Round(transform.position.y-0.1f),
				(int)Mathf.Round(transform.position.z),
				chkTag()
			});
			}

//			createstagecontroll.setCubeList(GetComponentInParent<GameObject>());
		}



	}

	private int chkTag(){
		if (tag == "Block") {
			return 2;
		} else if (tag == "TurnR") {
			return 4;
		} else if (tag == "TurnL") {
			return 5;
		} else {
			return -1;
		}

	}

}
