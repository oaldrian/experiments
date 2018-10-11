using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControl : MonoBehaviour 
{
	public float speed;
	public Text countText;
	public Text WinText;

	private Rigidbody rigidbody;
	private int count;

	void Start()
	{
		count = 0;
		countText.text = "Count: " + count.ToString ();
		WinText.text = "";
		rigidbody = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			countText.text = "Count: " + count.ToString ();
			if (count > 4) {
				WinText.text = "wint";
			}
		}
	}
}