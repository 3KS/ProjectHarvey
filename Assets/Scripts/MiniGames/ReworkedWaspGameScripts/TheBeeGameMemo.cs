using UnityEngine;
using System.Collections;

public class TheBeeGameMemo : MonoBehaviour
{
	public GameObject memo;
	public GameObject memoPickUp;
	public GameObject memoSetDown;

	private bool showPickup;
	private bool showSetDown;
	public float setDownDelay;

	void Start ()
	{
		memo.active = false;
		memoPickUp.active = false;
		memoSetDown.active = false;
		showPickup = false;
		showSetDown = false;
	}

	void Update ()
	{
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 1)
		{
			if (Input.GetButtonDown("Select") && showPickup == true)
			{
				Debug.Log("GotHere 2");
				memo.active = true;
				memoPickUp.active = false;
				Invoke ("ShowSetDown", setDownDelay);
			}
			
			if (Input.GetButtonDown("Select") && showSetDown == true)
			{
				Debug.Log("GotHere 4");
				PlayerPrefs.SetInt(SaveController.GetPrefix () + "canPlayWasps", 2);
				memo.active = false;
				memoSetDown.active = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 1)
		{
			if (other.collider.gameObject.tag == "Player")
			{
				memoPickUp.active = true;
				showPickup = true;
			}
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.collider.gameObject.tag == "Player")
		{
			memo.active = false;
			memoPickUp.active = false;
			memoSetDown.active = false;
			showPickup = false;
			showSetDown = false;
		}
	}

	void ShowSetDown ()
	{
		memoSetDown.active = true;
		Debug.Log("GotHere 3");
		showSetDown = true;
		showPickup = false;
	}
}
