using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NCMB
{
public class testHighScore : MonoBehaviour {

		// mobile backendとやりとりしてハイスコアの保存と取得を行うクラス

		public float score { get; set; }
		public string name { get; private set; }

		// コンストラクタ
		public testHighScore(float _score, string _name){
			score = _score;
			name = _name;
		}

		// サーバーにハイスコアを保存する
		public void testSave(){
			Debug.Log ("testHighScore内スコア " + score + name);
			// データストアの「HighScore」クラスから,Nameをキーにして検索する
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
			query.WhereEqualTo ("Name", name);
			query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
				//検索が成功した場合
				if (e == null) {
					objList [0] ["Score"] = score; // Score.scoreで誤魔化す？
					objList [0].SaveAsync ();
					Debug.Log ("testHighScore内スコア保存メソッド発動 " + score); 
				}else{
					Debug.Log("NEETなう");
				}
			});
		}

		// サーバーからハイスコアを取得する
		public void fetch(){
			Debug.Log ("fetch　name　" + name);
			// データストアの「HighScore」から,Nameをキーにして検索する
			NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject> ("HighScore");
			query.WhereEqualTo ("Name", name);
			query.FindAsync ((List<NCMBObject> objList ,NCMBException e) => {
				//検索が成功した場合
				if (e == null) {
					// ハイスコアが未登録だった場合
					if (objList.Count == 0) {
						NCMBObject obj = new NCMBObject ("HighScore");
						obj ["Name"] = name;
						obj ["Score"] = 0;
						obj.SaveAsync ();
						//score = 0;
						Debug.Log ("取得１");
					}
					// ハイスコアが登録済みだった場合
					else {
						score = System.Convert.ToInt32 (objList [0] ["Score"]);
						Debug.Log ("取得２");
					}
				}
			});
		}
		// テスト用メソッド
		public void test(){
			Debug.Log ("メソッド正常起動 " + Score.score + " " + score);

		}
		// テスト用startメソッド
		public void start(){

		}
		// ランキングで表示するために文字列を整形 -----------
		public string print()
		{
			return name + ' ' + score;
		}
	}
}

/*

ハイスコアの取得と保存には、NCMBQueryクラスを用い,
WhereEqualToメソッドで条件を指定したあと,
FindAsyncメソッドでレコードを取得,というのが基本的な流れ.
クエリ参照：http://mb.cloud.nifty.com/doc/current/sdkguide/unity/query.html#tocAnchor-1-3

今回はこのHighScore.csをGame Objectにアタッチしないで使用する.
ゲームオブジェクトにアタッチせずに使う利点は,
•Unityに依存しない (Startメソッドなどを実装しない) コードを書くことができる点
•他のシーンでも、そのクラスを使うことができる点
今回実装したHighScoreクラスは,MVCデザインパターンでいうモデルクラスにあたる.
その場合,このようにUnityに依存しない形でコードを書くほうがよい.

*/
