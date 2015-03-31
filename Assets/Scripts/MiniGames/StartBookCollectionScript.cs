using UnityEngine;
using System.Collections;

public class StartBookCollectionScript : MonoBehaviour
{
	public GameObject player;
	public GameObject bookMiniGameTrigger;
	private bool showText = false;
	private bool weInBusiness = false; //checks to see if the player is in the collider or not
	public static bool canStartBookQuest = false;
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
			MovementFreeze.FreezePlayer ();
			Screen.lockCursor = false;

			if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start book quest"))
			{
				canStartBookQuest = true;
				weInBusiness = false;
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				labelText = "I need you to help me find my five missing books! They're hidden around the library.";
			}

			else if (GUI.Button(new Rect(Screen.width / 2 - 190 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				canStartBookQuest = false;
				weInBusiness = false;
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
			}
		}
	}
}