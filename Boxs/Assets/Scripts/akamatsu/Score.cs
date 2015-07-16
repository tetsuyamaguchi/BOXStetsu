using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	// スコア（タイム）を取得してHighScoreクラスへ渡すためのクラス
	
	public static Score scored;
	
	// スコア
	public static float score;
	
	// ハイスコア
	private NCMB.testHighScore highScore;
	private bool isNewRecord;
	
	// PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";
	
	// スコアを表示するGUIText
	public GUIText scoreGUIText;
	// ハイスコアを表示するGUIText
	public GUIText highScoreGUIText;
	private GameObject circleObj;
	private RadialTimerScript radicaltimer;
	private float time;
	
	void Start ()
	{
		Debug.Log ("Score 計測開始");
		Initialize ();
		
		// ハイスコアを取得する。保存されてなければ0点。
		string name = FindObjectOfType<testUserAuth>().currentPlayer();
		highScore = new NCMB.testHighScore( 0, name );
		highScore.fetch();
	}
	
	private void Initialize ()
	{
		circleObj = GameObject.Find ("CircleGageDummy");
		radicaltimer = circleObj.GetComponent<RadialTimerScript> ();
		time = radicaltimer.stageTimeLimit;
		// スコアをに戻す
		score = time;      
		// フラグを初期化する
		isNewRecord = false;
		
		
	} 
	
	void Update ()
	{
		float getTime = TimeScripts.sendTime;
		GetScore (getTime);
		//Debug.Log ("テスト計測中 " + score + " " + highScore.score);
		// スコアがハイスコアより小さければ（短ければ）
		if (highScore.score < score && PlayerControll.isClearedScore == true) {
			isNewRecord = true; // フラグを立てる
			highScore.score = score;
			Debug.Log ("Score内スコア " + score + " " + highScore.score);
			Save ();
		}
		
/*		
		// スコア・ハイスコアを表示する
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.score.ToString ();
*/
	} 
	
	
	/*	
	// ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}
*/
	// スコア（タイム）の取得
	public void GetScore (float nowTime)
	{
//		print ("GetScore");
		score = nowTime;
	}
	
	// ハイスコアの保存
	public void Save ()
	{
//		print ("socre save");
		// ハイスコアを保存する（ただし記録の更新があったときだけ）
		if (isNewRecord) {
			highScore.testSave ();
			highScore.test ();
		}
		PlayerControll.isClearedScore = false;
		
		// ゲーム開始前の状態に戻す
		Initialize ();
		Debug.Log ("スコアscriptのハイスコア機能発動");
	} 
	
	
}
