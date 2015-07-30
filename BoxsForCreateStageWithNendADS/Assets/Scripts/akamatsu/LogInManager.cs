﻿using UnityEngine;
using System.Collections;

public class LogInManager : MonoBehaviour {
	
	private GameObject guiTextLogIn;   // ログインテキスト
	private GameObject guiTextSignUp;  // 新規登録テキスト
	
	// ログイン画面のときtrue, 新規登録画面のときfalse
	private bool isLogIn;
	
	// ボタンが押されると対応する変数がtrueになる
	private bool logInButton;
	private bool signUpMenuButton;
	private bool signUpButton;
	private bool backButton;
	
	// テキストボックスで入力される文字列を格納
	public string id;
	public string pw;
	public string mail;
	
	void Start () {
		
		FindObjectOfType<testUserAuth>().logOut();
		
		// ゲームオブジェクトを検索し取得する
		guiTextLogIn  = GameObject.Find ("GUITextLogIn");
		guiTextSignUp = GameObject.Find ("GUITextSignUp");  
		
		isLogIn = true;
		guiTextSignUp.SetActive (false);
		guiTextLogIn.SetActive (true);
		
	}
	
	void OnGUI () {
		
		// ログイン画面 
		if( isLogIn ){
			
			drawLogInMenu();
			
			// ログインボタンが押されたら
			if( logInButton )
				FindObjectOfType<testUserAuth>().logIn( id, pw );
			
			// 新規登録画面に移動するボタンが押されたら
			if( signUpMenuButton )
				isLogIn = false;
		}
		
		// 新規登録画面
		else {
			
			drawSignUpMenu();  
			
			// 新規登録ボタンが押されたら
			if( signUpButton )
				FindObjectOfType<testUserAuth>().signUp( id, mail, pw );
			
			// 戻るボタンが押されたら
			if( backButton )
				isLogIn = true;
		}
		
		// currentPlayerを毎フレーム監視し、ログインが完了したら
		if( FindObjectOfType<testUserAuth>().currentPlayer() != null )
			Application.LoadLevel("stage01");
		
	}
	
	private void drawLogInMenu()
	{
		// テキスト切り替え
		guiTextSignUp.SetActive (false);
		guiTextLogIn.SetActive (true);
		
		// テキストボックスの設置と入力値の取得
		GUI.skin.textField.fontSize = 20;
		int txtW = 150, txtH = 40;
		id = GUI.TextField     (new Rect(Screen.width*1/2, Screen.height*1/3 - txtH*1/2, txtW, txtH), id);
		pw = GUI.PasswordField (new Rect(Screen.width*1/2, Screen.height*1/2 - txtH*1/2, txtW, txtH), pw, '*');
		
		// ボタンの設置
		int btnW = 180, btnH = 50;
		GUI.skin.button.fontSize = 20;
		logInButton      = GUI.Button( new Rect(Screen.width*1/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Log In" );
		signUpMenuButton = GUI.Button( new Rect(Screen.width*3/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Sign Up" );
		
	}
	
	private void drawSignUpMenu()
	{
		// テキスト切り替え
		guiTextLogIn.SetActive (false);
		guiTextSignUp.SetActive (true);
		
		// テキストボックスの設置と入力値の取得
		int txtW = 150, txtH = 35;
		GUI.skin.textField.fontSize = 20;
		id = GUI.TextField     (new Rect(Screen.width*1/2, Screen.height*1/4 - txtH*1/2, txtW, txtH), id);
		pw = GUI.PasswordField (new Rect(Screen.width*1/2, Screen.height*2/5 - txtH*1/2, txtW, txtH), pw, '*');
		mail = GUI.TextField   (new Rect(Screen.width*1/2, Screen.height*11/20 - txtH*1/2, txtW, txtH), mail);
		
		// ボタンの設置
		int btnW = 180, btnH = 50;
		GUI.skin.button.fontSize = 20;
		signUpButton = GUI.Button( new Rect(Screen.width*1/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Sign Up" );
		backButton   = GUI.Button( new Rect(Screen.width*3/4 - btnW*1/2, Screen.height*3/4 - btnH*1/2, btnW, btnH), "Back" ); 
	}
	
}
/*
 * ログイン画面と新規登録画面を切り替えられるようにします。
LogInシーンに空のGame Objectを作成し、「LogInManager」にリネームします。
その後、同名のC#スクリプト作成し、以下の内容を記述してアタッチしてください。
これによって、ログイン画面と新規登録画面をボタンで切り替えることができるようになります。

OnGUIメソッド内では drawLogInMenu() または drawSignUpMenu() を実行しており、
それぞれログイン画面と新規登録画面のテキストボックスとボタンを定義しています.

ボタンが押されると、押されたボタンに対応したフラグがtrueになります。
ですので、例えばログインボタンが押されたときの処理は、OnGUIメソッド内の「if( logInButton )」以下に実装されています。

OnGUIメソッドの最下部で、UserAuth.currentPlayerの値を監視しています。
先ほど実装したログインや新規登録は非同期処理でしたので、
処理が完了するまで画面が固まることはありません。処理が完了し、
UserAuth.currentPlayerに値が入ったタイミングで、メインゲームシーンに遷移します。
*/