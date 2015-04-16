using UnityEngine;
using System.Collections;

public class TheBeeGameMinnie : MonoBehaviour
{
	public GameObject player;
	public GameObject minnie;

	private bool inTrigger;

	private bool lookingAtCharacter;
	public GameObject faceCharacterPosition;

	void OnGUI()
	{
		if (inTrigger == true)
		{
			GUI.Label(new Rect( Screen.width / 2, Screen.height / 2, 200, 50), "Press E to speak with Minnie");
		}
	}

	void Update ()
	{
		if (lookingAtCharacter == true)
		{
			player.transform.LookAt(minnie.transform.position);
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
					TextTreeKicker ();
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

			// used to turn off the text tree when the player leaves.
		//	player.GetComponent<MinniesText> ().walkAwayDialogue.active = false;
		}
	}

	void TextTreeKicker ()
		// This kicks off the dialogue tree when the player presses E after entering minnies trigger
	{
		MovementFreeze.FreezePlayer ();
		Screen.lockCursor = false;
		player.transform.position = faceCharacterPosition.transform.position;
		player.transform.rotation = faceCharacterPosition.transform.rotation;


		player.GetComponent<MinnieTextTree> ().textTreeStart = true;
	}
}
