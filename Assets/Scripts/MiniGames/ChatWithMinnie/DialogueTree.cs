using UnityEngine;
using System.Collections;

public class DialogueTree : MonoBehaviour
{
	public GameObject minnieCharacter;
	public GameObject player;
	public GameObject playerDialogueChoices;

	private float distanceFromMinnieX;
	private float distanceFromMinnieZ;
	public float menuHeight;
	public float menuSpace;

	public bool greetingIsOver;
	public bool minnieHasGreetedPlayer;
	public bool talkWithMinnieMenu;
	public bool decision1;
	public bool decision2;
	public bool decision3;
	public bool decision4;
	public bool decisionB;
	public bool decisionC;
	public bool decisionD;


	void Start ()
	{
		minnieHasGreetedPlayer = false;
		greetingIsOver = false;
		talkWithMinnieMenu = false;
	}


	void OnGUI ()
	{
		if (minnieHasGreetedPlayer == true && greetingIsOver == true)
		{
			MovementFreeze.FreezePlayer ();
			Screen.lockCursor = false;
//THIS KEEPS BREAKING			//player.transform.LookAt(minnieCharacter.transform.position);

			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Chat with Minnie"))
			{
				decision1 = true;
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				minnieHasGreetedPlayer = false;
				greetingIsOver = false;
			}
		}

		if (decision1 == true)
		{
			minnieHasGreetedPlayer = false;
			greetingIsOver = false;

			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option1"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option1 ();
			}
			
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionA"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionA ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decision1 = false;
			}
		}

		if (decision2 == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option2"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option2 ();
			}

			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option3"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option3 ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decision2 = false;
			}
		}

		if (decision3 == true) 
		{
			if (GUI.Button (new Rect (Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option4"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option4 ();
			}

			else if (GUI.Button (new Rect (Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option5")) {
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option5 ();
			}

// This option exits the chatting minigame
			else if (GUI.Button (new Rect (Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decision3 = false;
			}
		}

		if (decision4 == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option6"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option6 ();
			}
			
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "option7"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().Option7 ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decision4 = false;
			}
		}

		if (decisionB == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionB"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionB ();
			}
			
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionC"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionC ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decisionB = false;
			}
		}

		if (decisionC == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionD"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionD ();
			}
			
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionE"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionE ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decisionC = false;
			}
		}

		if (decisionD == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionF"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionF ();
			}
			
			else if (GUI.Button(new Rect(Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "optionG"))
			{
				playerDialogueChoices.GetComponent <DialogueTreeOptions>().OptionG ();
			}

// This option exits the chatting minigame
			else if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				decisionD = false;
			}
		}
	}


	void Update ()
	{
		//PlayerDistanceCheck ();
	}


	void PlayerDistanceCheck ()
	{
		Debug.Log ("The player's x distance from minnie is: " + distanceFromMinnieX);
		Debug.Log ("The player's z distance from minnie is: " + distanceFromMinnieZ);

		distanceFromMinnieX = (player.transform.position.x - minnieCharacter.transform.position.x);
		distanceFromMinnieZ = (player.transform.position.z - minnieCharacter.transform.position.z);
	}
}
