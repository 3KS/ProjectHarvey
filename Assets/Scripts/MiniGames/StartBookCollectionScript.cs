using UnityEngine;
using System.Collections;

public class StartBookCollectionScript : MonoBehaviour
{
	public GameObject player;
	public GameObject bookMiniGameTrigger;
	private bool showText = false;
	private bool weInBusiness = false; //checks to see if the player is in the collider or not
	public static bool canStartBookQuest = false;
	public bool bookQuestIsStarted = false;
	public float menuHeight;
	public float menuSpace;

	public string labelText = "";

	//ADD THAT YOU CANT START THE BOOK QUEST YET in other script
	/*(void OnGUI() {
		GUILayout.Label(labelText);
	}*/

	void Start()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (AchievementController.CheckAchievement (AchievementController.Achievements.ObjectCollection)) 
		{
			//if the player has the achievement don't let the librarian talk to you!!
			labelText = "";
			weInBusiness = false;
		} 
		else 
		{
			//trigger the screen lock and the button options
			Debug.Log ("We in this");
			//bookQuestCheck = true;
			weInBusiness = true;
			//labelText = "I need you to help me find my five missing books! They're hidden around the library.";
			OnGUI ();
		}
}
	void OnTriggerExit(Collider other)
	{
		//not colliding with the collider, don't let the librarian talk to you!!
		labelText = "";
		Debug.Log ("we out");
	}

	void OnGUI()
	{
		if (weInBusiness == true) 
		{
			if(!bookQuestIsStarted)
			MovementFreeze.FreezePlayer ();
			Screen.lockCursor = false;

			//if we havent started the quest put the buttons up
			//set boolean to true or false within each of the following statemetns
			if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start book quest"))
			{
				bookQuestIsStarted = true;
				canStartBookQuest = true;
				weInBusiness = false;
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				labelText = "I need you to help me find my five missing books! They're hidden around the library.";
				GUILayout.Label(labelText);
			}

			else if (GUI.Button(new Rect(Screen.width / 2 - 190 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				bookQuestIsStarted = false;
				canStartBookQuest = false;
				weInBusiness = false;
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
			}
		}
	}
}