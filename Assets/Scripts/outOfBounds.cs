using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class outOfBounds : MonoBehaviour {

	public Text updateText;

	public GameObject prefabGameManager;
	private theGameManager theGM;

	void Start(){
		theGM = prefabGameManager.GetComponent<theGameManager> ();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player1")) {
			Destroy (other.gameObject);
			updateText.text = "Player 2 Wins";
			theGM.stopTimer = false;
		}
		if (other.gameObject.CompareTag ("Player2")) {
			Destroy (other.gameObject);
			updateText.text = "Player 1 Wins";
			theGM.stopTimer = false;
		}
	}
}
