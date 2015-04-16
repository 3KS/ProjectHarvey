using UnityEngine;
using System.Collections;

public class MinniesText : MonoBehaviour
{
	public GameObject talkOption;
	public GameObject walkAwayOption;
	public GameObject decision1AOption;
	public GameObject decision1BOption;
	public GameObject decision2AOption;
	public GameObject decision2BOption;

	public GameObject talkDialogue;
	public GameObject walkAwayDialogue;
	public GameObject decision1ADialogue;
	public GameObject decision1BDialogue;
	public GameObject decision2ADialogue;
	public GameObject decision2BDialogue;

	void Start ()
	{
		talkOption.active = false;
		walkAwayOption.active = false;
		decision1AOption.active = false;
		decision1BOption.active = false;
		decision2AOption.active = false;
		decision2BOption.active = false;
		
		talkDialogue.active = false;
		walkAwayDialogue.active = false;
		decision1ADialogue.active = false;
		decision1BDialogue.active = false;
		decision2ADialogue.active = false;
		decision2BDialogue.active = false;
	}

	void Update ()
	{
		
	}
}
