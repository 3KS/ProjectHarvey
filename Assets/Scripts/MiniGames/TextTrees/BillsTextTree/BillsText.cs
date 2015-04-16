using UnityEngine;
using System.Collections;

public class BillsText : MonoBehaviour
{
	public GameObject talkOption;
	public GameObject walkAwayOption;
	public GameObject decisionA;
	public GameObject decisionB;
	public GameObject decisionC;
	
	public GameObject billGreeting;
	public GameObject billFarewell;
	public GameObject decisionADialogue;
	public GameObject decisionBDialogue;
	public GameObject decisionCDialogue1;
	public GameObject decisionCDialogue2;
	
	void Start ()
	{
		talkOption.active = false;
		walkAwayOption.active = false;
		decisionA.active = false;
		decisionB.active = false;
		decisionC.active = false;
		
		billGreeting.active = false;
		billFarewell.active = false;
		decisionADialogue.active = false;
		decisionBDialogue.active = false;
		decisionCDialogue1.active = false;
		decisionCDialogue2.active = false;
	}
}