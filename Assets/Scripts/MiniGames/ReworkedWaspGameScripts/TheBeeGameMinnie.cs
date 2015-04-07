using UnityEngine;
using System.Collections;

public class TheBeeGameMinnie : MonoBehaviour
{
	private bool inTrigger;

	void OnGUI()
	{
		if (inTrigger == true)
		{
			GUI.Label(new Rect( Screen.width / 2, Screen.height / 2, 200, 50), "Press E to speak with Minnie");
		}
	}

	void Start ()
	{
		inTrigger = false;
		PlayerPrefs.SetInt (SaveController.GetPrefix () + "canPlayWasps", 0);
	}


	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 0)
			{
				inTrigger = true;

				if (Input.GetButtonUp("Select"))
				{
					PlayerPrefs.SetInt(SaveController.GetPrefix () + "canPlayWasps", 1);
					inTrigger = false;
					//Debug.Log( PlayerPrefs.GetInt(SaveController.GetPrefix () + "canPlayWasps"));
				}
			}
		}
	}


	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			inTrigger = false;
		}
	}
}
