using UnityEngine;
using System.Collections;

public class RollArrow : MonoBehaviour {
	float rollSpeed = 5;
	public GameObject turnCanvas;
	GameObject clone;

	public GameObject effect;
	public bool isEffect;
	
	//-------------------------------------------------igarashi add
	bool isGround = false;
	public bool IsGround { get { return isGround; } }
	//---------------------------------------------------------------

	//-------------------------------------------------0715 kawashima add
	private MainKawashima mainkawashima;
	private Stage01ControlKawashima stagecontroll;

	private string origin;
	// Use this for initialization

	void Start ()
	{
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
		
		if (collider.gameObject.tag == "Block" ||
		    collider.gameObject.tag == "Bomb" ||
		    collider.gameObject.tag == "TurnR" ||
		    collider.gameObject.tag == "TurnL")
		{
			Destroy (collider.gameObject,0.5f);
			Destroy (gameObject,0.5f);
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
					break;
				}
			}
		}
		
	} // end fFlagAvoid()
	
	void OnTriggerEnter(Collider c)
	{
		//print ("ここにはきてるか");
		//print("tag = " + c.tag);
		if (c.tag == "SensorForAvoidBlock")	
		{
			print ("こらあstep3");
			
			//PlayerControllスクリプトのfAvoid
			c.gameObject.GetComponentInParent<PlayerControll> ().StartCoroutine("fAvoidBlock", gameObject);
			//searchForAvoid = true;
		}
		
		
		if (c.tag == "SensorFrontUP")
		{
			print ("こここここらあstep3");
			if (isGround == true) return;
			c.gameObject.GetComponentInParent<PlayerControll> ().StartCoroutine("fWaitPlayer", gameObject);
		}
		
	}
}
