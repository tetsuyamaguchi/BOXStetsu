using UnityEngine;
using System.Collections;

public class LogOutManager : MonoBehaviour {

	// playerプレハブ
	public GameObject player;

	// タイトル
	private GameObject title;

	// ボタンが押されると対応する変数がtrueになる
	private bool logOutButton;

	// Use this for initialization
	void Start () {
		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");
	}

	void OnGUI(){
		if (!IsPlaying ()) {
			drawButton();

			// ログアウトボタンが押されたら
			if(logOutButton){
				FindObjectOfType<testUserAuth>().logOut();
			}
/*			// 画面タップでゲームスタート
			if(Event.current.type == EventType.MouseDown){
				GameStart();
			}
*/
		}
/*			if (FindObjectOfType<testUserAuth> ().currentPlayer () == null) {
			Application.LoadLevel("Title");
		}
*/
	}

	void GameStart(){
		//　StageSelectシーンに遷移
		Application.LoadLevel("StageSelect");
	}

	public void GameOver(){ 
		// Scoreを記録する
		//FindObjectOfType<Score> ().Save ();
		// (暫定的に)ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}

	public bool IsPlaying(){
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}

	private void drawButton() {
		//ボタンの配置する
		int btnW = 140;
		int btnH = 50;
		GUI.skin.button.fontSize = 18;

		logOutButton = GUI.Button (new Rect (2 * btnW, 0, btnW, btnH), "Log Out");
	}

}
