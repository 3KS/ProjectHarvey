using UnityEngine;
using System.Collections;

public class MinnieTextTree : MonoBehaviour
{
	public GameObject player;
	public GameObject Minnie;
	public GameObject talkingPosition;

	public float textAvailableTime;

	public bool textTreeStart;

	public bool hoveringOverOption;
	public GameObject currentOption;

	public string talk;
	public string walkAway;
	public string decision1A;
	public string decision1B;
	public string decision2A;
	public string decision2B;
	public string decision3A;
	public string decision3B;

	private Ray detectRay;
	private Ray selectRay;
	private RaycastHit detectHit;
	private RaycastHit selectHit;


	void Start ()
	{
		hoveringOverOption = false; 
	}

	void Update ()
	{
		if (textTreeStart == true)
		{
			Minnie.GetComponent<BoxCollider> ().enabled = false;
			Option1Display ();
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

	void Option1Display ()
		// this is the talk or walk decision
	{
		textTreeStart = false;

		talkingPosition.GetComponent<MinniesText> ().talkOption.active = true;
		talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = true;
	}

	void Option2Display ()
		// this is the weather dinosaurs decision
	{
		talkingPosition.GetComponent<MinniesText> ().talkDialogue.active = false;
		talkingPosition.GetComponent<MinniesText> ().walkAwayDialogue.active = false;

		talkingPosition.GetComponent<MinniesText> ().decision1AOption.active = true;
		talkingPosition.GetComponent<MinniesText> ().decision1BOption.active = true;
		talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = true;
	}

	void Option3Display ()
		// this is the agree disagree choice
	{
		Debug.Log("Option3 is being called");

		talkingPosition.GetComponent<MinniesText> ().decision1ADialogue.active = false;
		talkingPosition.GetComponent<MinniesText> ().decision1BDialogue.active = false;

		talkingPosition.GetComponent<MinniesText> ().decision2AOption.active = true;
		talkingPosition.GetComponent<MinniesText> ().decision2BOption.active = true;
		talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = true;
	}

	void EndOptions ()
	{
		talkingPosition.GetComponent<MinniesText> ().decision2AOption.active = false;
		talkingPosition.GetComponent<MinniesText> ().decision2BOption.active = false;
		talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;
	}

	void DecisionCheck()
	{
		Debug.Log ("Called Decision Check");
		if (currentOption.name == talk) //decision1
		{
			talkingPosition.GetComponent<MinniesText> ().talkOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<MinniesText> ().talkDialogue.active = true;
			Invoke ("Option2Display", textAvailableTime);
		}
		else if (currentOption.name == walkAway) //decision1
		{
			talkingPosition.GetComponent<MinniesText> ().talkOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision1AOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision1BOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision2AOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision2BOption.active = false;

			EndTextTree ();
		}
		else if (currentOption.name == decision1A) //decision2
		{
			talkingPosition.GetComponent<MinniesText> ().decision1AOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision1BOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<MinniesText> ().decision1ADialogue.active = true;
			Invoke ("Option3Display", textAvailableTime);
		}
		else if (currentOption.name == decision1B) //decision2
		{
			talkingPosition.GetComponent<MinniesText> ().decision1AOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision1BOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<MinniesText> ().decision1BDialogue.active = true;
			Invoke ("Option3Display", textAvailableTime);
		}
		else if (currentOption.name == decision2A) //decision3
		{

			EndOptions ();
			Debug.Log("here1");
			talkingPosition.GetComponent<MinniesText> ().decision2AOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().decision2BOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;

			talkingPosition.GetComponent<MinniesText> ().decision2ADialogue.active = true;
			Invoke ("EndTextTree", textAvailableTime);
		}
		else if (currentOption.name == decision2B) //decision3
		{

			talkingPosition.GetComponent<MinniesText> ().decision2AOption.active = false;Debug.Log("here2");
			talkingPosition.GetComponent<MinniesText> ().decision2BOption.active = false;
			talkingPosition.GetComponent<MinniesText> ().walkAwayOption.active = false;
			
			talkingPosition.GetComponent<MinniesText> ().decision2BDialogue.active = true;
			Invoke ("EndTextTree", textAvailableTime); 
		}
	}

	void EndTextTree ()
	{
		Debug.Log ("Text tree has ended");
		MovementFreeze.UnFreezePlayer ();
		Screen.lockCursor = true;
		talkingPosition.GetComponent<MinniesText> ().decision2ADialogue.active = false;
		talkingPosition.GetComponent<MinniesText> ().decision2BDialogue.active = false;

		talkingPosition.GetComponent<MinniesText> ().walkAwayDialogue.active = true;
		Minnie.GetComponent<BoxCollider> ().enabled = true;
		Invoke ("TurnOffGoodbye", textAvailableTime);
	}

	void TurnOffGoodbye ()
	{
		talkingPosition.GetComponent<MinniesText> ().walkAwayDialogue.active = false;
	}
}
