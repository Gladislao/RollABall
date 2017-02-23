using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
	}

	void FixedUpdate(){
		float moveHorizontal = Input.acceleration.x;
		float moveVertical = -Input.acceleration.z;

		Vector3 movement = new Vector3 (moveHorizontal,0.0f,moveVertical);
		rb.AddForce (movement);

		rb.AddForce (movement*speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text="Count: " +count.ToString();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}
