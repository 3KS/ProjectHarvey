
using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

	public float speed = 5.0f;
	public bool grounded = false;

	// FixedUpdate is called once per physical step
	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);

		if (grounded == true)
		{
			rigidbody.AddForce (movement * speed);
		}
	}

	void OnCollisionEnter()
	{
		grounded = true;
	}
	void OnCollisionExit()
	{
		grounded = false;
	}
}
