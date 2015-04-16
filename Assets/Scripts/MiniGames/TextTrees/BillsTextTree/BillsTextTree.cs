using UnityEngine;
using System.Collections;

public class BillsTextTree : MonoBehaviour
{
	public GameObject player;
	public GameObject Bill;
	public GameObject invisibleWalls;
	public GameObject talkingPosition;
	
	public float textAvailableTime;
	
	public bool textTreeStart;
	private bool textTreeCompleted;
	
	public bool hoveringOverOption;
	public GameObject currentOption;
	
	public string talk;
	public string walkAway;
	public string optionA;
	public string optionB;
	public string optionC;
	
	private Ray detectRay;
	private Ray selectRay;
	private RaycastHit detectHit;
	private RaycastHit selectHit;
	
	
	void Start ()
	{
		textTreeCompleted = false;
		hoveringOverOption = false; 
	}
	
	void Update ()
	{
		if (textTreeStart == true)
		{
			Bill.GetComponent<BoxCollider> ().enabled = false;
			invisibleWalls.active = false;
			TalkDisplay ();
		}
		
		if (Input.GetMouseButtonDown (0))
		{
			Raycasts ();
		}
	}
	
	void Raycasts ()
	{
		selectRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (selectRay.origin, selectHit.point);
		
		if (Physics.Raycast(selectRay, out selectHit, 10))
		{
			currentOption = selectHit.collider.gameObject;
			
			if (currentOption.tag == "TextTreeOption")
			{
				Debug.Log("player selected " + currentOption.name);
				DecisionCheck ();
			}
		}
		
	}
	
	void TalkDisplay ()
		// this is the talk or walk decision
	{
		textTreeStart = false;
		
		talkingPosition.GetComponent<BillsText> ().talkOption.active = true;
		talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = true;
		}
	
	void Decision1Display ()
		// this displays option A and B
	{
		talkingPosition.GetComponent<BillsText> ().billGreeting.active = false;

		talkingPosition.GetComponent<BillsText> ().decisionA.active = true;
		talkingPosition.GetComponent<BillsText> ().decisionB.active = true;
		talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = true;
	}
	
	void Option2Display ()
		// if A is picked, this displays B
	{
		//Debug.Log("Option3 is being called");
		talkingPosition.GetComponent<BillsText> ().billGreeting.active = false;
		talkingPosition.GetComponent<BillsText> ().decisionADialogue.active = false;
	
		talkingPosition.GetComponent<BillsText> ().decisionB.active = true;
		talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = true;
	}

	void Option3Display ()
		//this displays option C
	{
		talkingPosition.GetComponent<BillsText> ().decisionBDialogue.active = false;

		talkingPosition.GetComponent<BillsText> ().decisionC.active = true;
		talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = true;
	}
	
	void DisplayOptionCDialogueTwo () 
	{
		talkingPosition.GetComponent<BillsText> ().decisionCDialogue1.active = false;

		talkingPosition.GetComponent<BillsText> ().decisionCDialogue2.active = true;
		Invoke ("EndTextTree", textAvailableTime);
	}
	
	void DecisionCheck()
	{
		Debug.Log ("Called Decision Check");
		if (currentOption.name == talk) //Talk
		{
			talkingPosition.GetComponent<BillsText> ().talkOption.active = false;
			talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<BillsText> ().billGreeting.active = true;
			Invoke ("Decision1Display", textAvailableTime);
		}
		else if (currentOption.name == walkAway) //WalkAway
		{
			talkingPosition.GetComponent<BillsText> ().talkOption.active = false;
			talkingPosition.GetComponent<BillsText> ().decisionA.active = false;
			talkingPosition.GetComponent<BillsText> ().decisionB.active = false;
			talkingPosition.GetComponent<BillsText> ().decisionC.active = false;
			talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = false;

			EndTextTree ();
		}
		else if (currentOption.name == optionA) //OptionA
		{
			talkingPosition.GetComponent<BillsText> ().decisionA.active = false;
			talkingPosition.GetComponent<BillsText> ().decisionB.active = false;
			talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<BillsText> ().decisionADialogue.active = true;
			Invoke ("Option2Display", textAvailableTime);
		}
		else if (currentOption.name == optionB) //OptionB
		{
			talkingPosition.GetComponent<BillsText> ().decisionA.active = false;
			talkingPosition.GetComponent<BillsText> ().decisionB.active = false;
			talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<BillsText> ().decisionBDialogue.active = true;
			Invoke ("Option3Display", textAvailableTime);
		}
		else if (currentOption.name == optionC) //OptionC
		{
			talkingPosition.GetComponent<BillsText> ().decisionC.active = false;
			talkingPosition.GetComponent<BillsText> ().walkAwayOption.active = false;

			textTreeCompleted = true;

			talkingPosition.GetComponent<BillsText> ().decisionCDialogue1.active = true;
			Invoke ("DisplayOptionCDialogueTwo", textAvailableTime);
		}
	}
	
	void EndTextTree ()
		//Farewell dialogue should be turned on, everything else is off
	{
		Debug.Log ("Text tree has ended");
		MovementFreeze.UnFreezePlayer ();

		talkingPosition.GetComponent<BillsText> ().decisionCDialogue2.active = false;

		talkingPosition.GetComponent<BillsText> ().billFarewell.active = true;
		Bill.GetComponent<BoxCollider> ().enabled = true;
		invisibleWalls.active = true;

		Invoke ("TurnOffGoodbye", textAvailableTime);
	}
	
	void TurnOffGoodbye ()
	{
		talkingPosition.GetComponent<BillsText> ().billFarewell.active = false;
		if (textTreeCompleted == true)
		{
			player.GetComponent<BillsTextTree> ().enabled = false;
		}
	}
}
