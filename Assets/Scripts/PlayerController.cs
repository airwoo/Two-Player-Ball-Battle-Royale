using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed;
	public float jumpForce;
	public bool isGrounded;
	public Text countText;
	public Text updateText;

	private Rigidbody rb;
	public int count;


	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		updateText.text = "";
		isGrounded = true;
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");


		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);


	}

	void Update(){
			if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
				isGrounded = false;
				Vector3 jump = new Vector3 (0, 1, 0);
				rb.AddForce (jump * jumpForce);

			}
			SetCountText ();
		}	

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Player1 Count: " + count.ToString ();
		//if (count >= 9) {
		//	updateText.text = "Player 1 Wins!";
		//}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("ground")){
			isGrounded = true;
		}
		if(other.gameObject.CompareTag("wall")){
			//Debug.Log ("Touched wall");
			count -= 1;
		}
		if(other.gameObject.CompareTag("Player2")){
			if (transform.position.y > other.gameObject.transform.position.y  + 0.25) {
				count += 3;
				updateText.text = "Player 1 wins the collision!";
			}
			if (transform.position.y + 0.25 < other.gameObject.transform.position.y  ) {
				count -= 2;
			}
		}
	}

}
