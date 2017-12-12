using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class theGameManager : MonoBehaviour {

	public Text timeLeftText;
	public Text countPlayer1;
	public Text countPlayer2;
	public Text updateText;


	public Button resetButton;
	public GameObject Player1;
	public GameObject Player2;
	private PlayerController playerController1;
	private PlayerController2 playerController2;

	private string minutes;
	private string seconds;
	public float theCountDown;
	public bool stopTimer;

	// Use this for initialization
	void Start () {
		stopTimer = true;
		Player1 = GameObject.Find ("Player1");
		Player2 = GameObject.Find ("Player2");
		playerController1 = Player1.GetComponent<PlayerController> ();
		playerController2 = Player2.GetComponent<PlayerController2> ();
		timeLeftText.text = "Time Left: ";
		resetButton.onClick.AddListener(()=>{SceneManager.LoadScene(1);});
	}
	
	// Update is called once per frame
	void Update () {
		if (stopTimer) {
			theCountDown -= Time.deltaTime;
			minutes = Mathf.Floor (theCountDown / 60).ToString ();
			seconds = Mathf.Floor (theCountDown % 60).ToString ("00");
			timeLeftText.text = "Time Left: " + minutes + " : " + seconds;
			if (theCountDown <= 60) {
				updateText.text = "Half the time is remaining!";
			}
			if (theCountDown <= 10) {
				updateText.text = "Time is almost up!";
			}
			if (theCountDown <= 0) {
				timeLeftText.text = "Time Left: 0 : 00";
				if (playerController1.count > playerController2.count) {
					updateText.text = "Player 1 Wins!";
				} 
				if (playerController1.count < playerController2.count) {
					updateText.text = "Player 2 Wins!";
				}
				if (playerController1.count == playerController2.count) {
					updateText.text = "It's a Draw!";
				}
				enabled = false;
			}
		}
	}
}

