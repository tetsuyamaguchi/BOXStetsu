using UnityEngine;
using System.Collections;

public class testJumpToLogIn : MonoBehaviour {

	// testLogIn2シーンへの遷移のためのスクリプト

	public string changeSceneName;

	public void fJumptoLogIn()
	{
		Application.LoadLevel(changeSceneName);
	}
}
