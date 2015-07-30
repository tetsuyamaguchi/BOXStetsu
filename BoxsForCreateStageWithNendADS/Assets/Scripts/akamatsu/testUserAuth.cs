using UnityEngine;
using System.Collections;
using NCMB;
using System.Collections.Generic;

public class testUserAuth : MonoBehaviour {

	// nifty mobile backendと通信して、ログインや新規登録を行うクラス

	private string currentPlayerName;

	// mobile backendに接続してログイン
	public void logIn(string id, string pw) {
		NCMBUser.LogInAsync (id, pw, (NCMBException e) => {
			// 接続成功後
			if (e == null) {
				currentPlayerName = id;
			}
		});
	}

	// mobile backendに接続して新規会員登録
	public void signUp( string id, string mail, string pw) {
		NCMBUser user = new NCMBUser ();
		user.UserName = id;
		//user.Email = mail;
		user.Password = pw;
		user.SignUpAsync ((NCMBException e) => {
			if (e == null) {
				currentPlayerName = id;
			}
		});
	}

	// mobile backendに接続してログアウト
	public void logOut() {
		NCMBUser.LogOutAsync ((NCMBException e) => {
			if (e == null) {
				currentPlayerName = null;
			}
		});
	}

	// 現在のプレイヤー名を返す
	public string currentPlayer() {
		return currentPlayerName;
	}


	//　testUserAuthクラスのメソッドは使いまわすことが多いのでシングルトン化する
	private testUserAuth instance = null;
	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (gameObject);

			string name = gameObject.name;
			gameObject.name = name + "(Singleton)";

			GameObject duplicater = GameObject.Find (name);
			if (duplicater != null) {
				Destroy (gameObject);
			} else {
				gameObject.name = name;
			}
		}else{
			Destroy (gameObject);
		}
	}

}

/*
LogInシーンに空のGame Objectを作成し、「UserAuth」にリネームします。
その後、同名のC#スクリプト作成し、以下の内容を記述してアタッチしてください。

ログイン、新規登録、ログアウトはそれぞれ「NCMBUser.LogInAsync」
「NCMBUser.SignUpAsync」「NCMBUser.LogOutAsync」メソッドを使います。
ここでは、ログイン中はプレイヤーIDを自身のフィールドに格納するようにし、
ログインしていない場合はnullをセットするようにしています。

LogInAsyncメソッドのように末尾に「Async」が付いているメソッドは、
その名のとおり「非同期処理」を行っています。
そのため、接続に成功してプレイヤーIDをフィールドに格納するまでの間、
その他の処理が止まることはありません。

なお、SignUpAsyncメソッドでメールアドレスの入力は必須ではありません。
しかし、メールアドレスを登録すると、以下のような利点が得られます。
•パスワードのリセットができる
•登録時に本人確認メールの送信ができる
*/