using UnityEngine;
using System.Collections;
/*
 * Murals don't appear until you accept the quest
 * 3 murals but only one real one - have to check if it's the right one
 * If player finds the real one they get the achievement for the quest
 * If you don't get it on the first try and go back to Cal to turn the quest in, 
 * he'll give you another clue hinting to the location of the mural
 */


public class MuralCollection : MonoBehaviour 
{	
	public GameObject player;
	public GameObject muralMiniGameTrigger;

	public static bool muralQuestIsStarted = false;
	public static bool weInBusiness = false; //checks for collision with hitbox the first time

	public static bool mural1Found = false;
	public static bool mural2Found = false;
	public static bool mural3Found = false;

	public static bool muralsFound = false; //checks to see if a mural is found
	public static bool muralIsTurnedIn = false; //checks to see if you've gone back to Cal yet
	public static bool buttonHit = false; //checks to see if you pressed the button after going back to Cal
	public static bool multipleButtonsHit = false; //checks to see if you pressed the button after collecting murals 2 and 3 and going back to Cal
	
	//Plays after the user pressed the button to start the quest
	public static bool startPromptIsPlaying = false;

	public float menuHeight;
	public float menuSpace;

	public string labelText = "";

	void Start () 
	{
	
	}

	void Update () 
	{
		if(DynamicMuralPlacement.muralsAreAdded)
		{
			//If Mural 1 is not in the scene
			if(GameObject.Find("Mural 1(Clone)") == null)
			{
				if(GameObject.Find("Mural 2(Clone)") != null)
				{
					GameObject.Find("Mural 2(Clone)").renderer.enabled = false;
				}

				if(GameObject.Find("Mural 3(Clone)") != null)
				{
					GameObject.Find("Mural 3(Clone)").renderer.enabled = false;
				}
				//You found the real mural
				mural1Found = true;
			}
			//If Mural 2 is not in the scene
			else if(GameObject.Find("Mural 2(Clone)") == null && GameObject.Find("Mural 3(Clone)") != null && !muralIsTurnedIn)
			{
				GameObject.Find("Mural 1(Clone)").renderer.enabled = false;
				GameObject.Find("Mural 3(Clone)").renderer.enabled = false;
				//You found an imposter
				mural2Found = true;
				mural3Found = false;
				//Debug.Log ("Mural 2 has been found");
			}
			else if(GameObject.Find("Mural 2(Clone)") == null && GameObject.Find("Mural 3(Clone)") != null && muralIsTurnedIn) //once you turn in the second one, you dont want the others to appear again
			{
				GameObject.Find("Mural 1(Clone)").renderer.enabled = true;
				GameObject.Find("Mural 3(Clone)").renderer.enabled = true;

				mural2Found = true;
				mural3Found = false;
			}
			//If Mural 3 is not in the scene
			else if(GameObject.Find("Mural 3(Clone)") == null && GameObject.Find("Mural 2(Clone)") != null && !muralIsTurnedIn)
			{
				GameObject.Find("Mural 1(Clone)").renderer.enabled = false;
				GameObject.Find("Mural 2(Clone)").renderer.enabled = false;
				//You found an imposter
				mural2Found = false;
				mural3Found = true;
				//Debug.Log ("Mural 3 has been found");
			}
			else if(GameObject.Find("Mural 3(Clone)") == null && GameObject.Find("Mural 2(Clone)") != null && muralIsTurnedIn)
			{
				GameObject.Find("Mural 1(Clone)").renderer.enabled = true;
				GameObject.Find("Mural 2(Clone)").renderer.enabled = true;
				mural2Found = false;
				mural3Found = true;
			}
			//if mural 2 and 3 are out of the scene
			else if(GameObject.Find("Mural 3(Clone)") == null && GameObject.Find ("Mural 2(Clone)") == null && !muralIsTurnedIn)
			{
				mural2Found = true;
				mural3Found = true;
				GameObject.Find("Mural 1(Clone)").renderer.enabled = false;
			}
			else if(GameObject.Find("Mural 3(Clone)") == null && GameObject.Find ("Mural 2(Clone)") == null && muralIsTurnedIn)
			{
				mural2Found = true;
				mural3Found = true;
				GameObject.Find("Mural 1(Clone)").renderer.enabled = true;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//If we already haven the achievement, don't let any text pop up
		if (AchievementController.CheckAchievement (AchievementController.Achievements.FindCalsMural)) 
		{
			weInBusiness = false;
		} 
		//If we're in the hit box and don't have the achievement then do this stuff
		else
		{
			weInBusiness = true;
		}
	}

	//not colliding with the hitbox
	void OnTriggerExit(Collider other)
	{
		weInBusiness = false;
	}

	void OnGUI()
	{
		if (weInBusiness == true) 
		{
			if(!muralQuestIsStarted)
			{
				MovementFreeze.FreezePlayer ();
				Screen.lockCursor = false;
				//if we havent started the quest put the buttons up
				if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start mural quest"))
				{
					muralQuestIsStarted = true;
					weInBusiness = true;
					//hide the mouse
					Screen.showCursor = false;
					startPromptIsPlaying = true;
					Screen.lockCursor = true;
					MovementFreeze.UnFreezePlayer ();

					if(!muralsFound)
					{
						labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
					}
					else
					{
						labelText = "";
					}
				}
				
				else if (GUI.Button(new Rect(Screen.width / 2 - 250 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
				{
					muralQuestIsStarted = false;
					weInBusiness = false;
					Screen.lockCursor = true;
					MovementFreeze.UnFreezePlayer ();
				}
			}
			//If the first prompt has already played then move onto these next dialogue options
			if(startPromptIsPlaying)
			{
				//If the first mural has been found
				if(mural1Found == true)
				{
					muralsFound = true;
					if(buttonHit == false)
					{
						MovementFreeze.FreezePlayer ();
						Screen.lockCursor = false;
						Screen.showCursor = true;
					}
					//Trigger the button to pop up. When the player presses it then...
					if (GUI.Button(new Rect(Screen.width / 2 - 150 + menuSpace, Screen.height / 2 - menuHeight, 300, 50), "You found my mural, thank you so much!"))
					{
						/*
						 * 
						 * 
						 * FIX THIS PART AND IN ACHIEVEMENT CONTROLLER SO IT ACTUALLY DISPLAYS ACHIEVEMENT NOW
						 * 
						 * 
						 */
						AchievementController.achievementEarned = true;
						//Debug.Log ("You found Cal's Mural!");
						buttonHit = true;
						Screen.showCursor = false;
						Screen.lockCursor = true;
						MovementFreeze.UnFreezePlayer ();
						muralIsTurnedIn = true;
					}
				}
				else if(mural2Found && !mural3Found)
				{
					muralsFound = true;
					if(buttonHit == false)
					{
						MovementFreeze.FreezePlayer ();
						Screen.lockCursor = false;
						Screen.showCursor = true;
					}
					if (GUI.Button(new Rect(Screen.width / 2 - 150 + menuSpace, Screen.height / 2 - menuHeight, 300, 50), "What is this? This isn't a Peters' original!"))
					{
						Debug.Log ("You found mural 2");
						buttonHit = true;
						Screen.showCursor = false;
						Screen.lockCursor = true;
						MovementFreeze.UnFreezePlayer ();
						muralIsTurnedIn = true;
					}
				}
				else if(mural3Found && !mural2Found)
				{
					muralsFound = true;
					if(buttonHit == false)
					{
						MovementFreeze.FreezePlayer ();
						Screen.lockCursor = false;
						Screen.showCursor = true;
					}
					if (GUI.Button(new Rect(Screen.width / 2 - 150 + menuSpace, Screen.height / 2 - menuHeight, 300, 50), "What is this? This isn't a Peters' original!"))
					{
						Debug.Log ("You found mural 3");
						buttonHit = true;
						Screen.showCursor = false;
						Screen.lockCursor = true;
						MovementFreeze.UnFreezePlayer ();
						muralIsTurnedIn = true;
					}
				}
				else if(mural2Found && mural3Found)
				{
					muralsFound = true;
					if(multipleButtonsHit == false)
					{
						MovementFreeze.FreezePlayer ();
						Screen.lockCursor = false;
						Screen.showCursor = true;
					}
					if (GUI.Button(new Rect(Screen.width / 2 - 150 + menuSpace, Screen.height / 2 - menuHeight, 400, 50), "Another imposter? This is most certainly not my mural!"))
					{
						Debug.Log ("You found mural 2 and 3!");
						multipleButtonsHit = true;
						Screen.showCursor = false;
						Screen.lockCursor = true;
						MovementFreeze.UnFreezePlayer ();
						muralIsTurnedIn = true;
					}
				}
			}
		}
	}
}
