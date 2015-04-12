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
	public static bool startBool = false;

	public static bool mural1Found = false;
	public static bool mural2Found = false;
	public static bool mural3Found = false;
	

	//Plays after the user pressed the button to start the quest
	public static bool startPromptHasPlayed = false;
	//Plays if the user picks up mural 2
	//public static bool secondPromptHasPlayed = false;
	//Plays if the user picks up mural 3
	//public static bool thirdPromptHasPlayed = false;
	//Plays if the user picks up mural 1
	//public static bool winningPromptHasPlayed = false;
	
	public static int muralSwitch = 0;

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
				//You found the real mural
				mural1Found = true;
				//Debug.Log ("The mural 1 has been collected");
			}
			else
			{
				mural1Found = false;
				//Debug.Log ("Mural 1 has not been found yet");
			}
			
			//If Mural 2 is not in the scene
			if(GameObject.Find("Mural 2(Clone)") == null)
			{
				//You found an imposter
				mural2Found = true;
				//Debug.Log ("Mural 2 has been found");
			}
			else
			{
				mural2Found = false;
			}
			//If Mural 3 is not in the scene
			if(GameObject.Find("Mural 3(Clone)") == null)
			{
				//You found an imposter
				mural3Found = true;
				//Debug.Log ("Mural 3 has been found");
			}
			else
			{
				mural3Found = false;
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		//If we already haven the achievement, don't let any text pop up
		if (AchievementController.CheckAchievement (AchievementController.Achievements.FindCalsMural)) 
		{
			Debug.Log ("We out");
			weInBusiness = false;
		} 
		//If we're in the hit box and don't have the achievement then do this stuff
		else
		{
			Debug.Log("We in this");
			weInBusiness = true;
		}
	}

	//not colliding with the hitbox
	void OnTriggerExit(Collider other)
	{
		//labelText = "";
		Debug.Log ("we out");
		weInBusiness = false;
	}

	void OnGUI()
	{
		if (weInBusiness == true) 
		{
			MovementFreeze.FreezePlayer ();
			Screen.lockCursor = false;
			
			if(!muralQuestIsStarted && !startBool)
			{
				//if we havent started the quest put the buttons up
				//set boolean to true or false within each of the following statemetns
				if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start mural quest"))
				{
					muralQuestIsStarted = true;
					weInBusiness = true;
					//hide the mouse
					Screen.showCursor = false;
					labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
					startPromptHasPlayed = true;
					startBool = true;

				}
				
				else if (GUI.Button(new Rect(Screen.width / 2 - 250 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "No one cares, walk away"))
				{
					muralQuestIsStarted = false;
					weInBusiness = false;
					Screen.lockCursor = true;
					MovementFreeze.UnFreezePlayer ();
				}
			}
			else if (muralQuestIsStarted && !startBool) //If you choose to start the quest
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				GUILayout.Label(labelText);
				//Debug.Log ("label text should appear now because quest is started");
			}
		}
		//If the quest is started and you're colliding with the collider
		if(muralQuestIsStarted && weInBusiness && startBool)
		{
			/*if(startPromptHasPlayed && !secondPromptHasPlayed && !thirdPromptHasPlayed && !winningPromptHasPlayed)
		{
			//DISPLAY TEXT TO THE PLAYER TO PICK UP THE Murals
			labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
			GUILayout.Label(labelText);
		}*/
			
			if(mural2Found && !mural3Found && !mural1Found)
			{
				labelText = "This isn't my mural!";
				GUILayout.Label(labelText);
				Debug.Log ("Mural 2 is found, mural 3 isnt found neither is mural 1");
			}
			else if(mural2Found && mural3Found && !mural1Found)
			{
				labelText = "This isn't my mural!";
				GUILayout.Label(labelText);
				Debug.Log ("Mural 2 and 3 have been found");
			}
			else if(mural3Found && !mural1Found && !mural2Found)
			{
				labelText = "This is definitely not my mural!";
				GUILayout.Label(labelText);
				Debug.Log ("Mural3  is found, mural 1 and mural 2 are not");
			}
			else if(mural1Found)
			{
				MovementFreeze.FreezePlayer ();
				//Screen.lockCursor = false;
				Screen.showCursor = true;

				if(GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Thanks you found my mural!"))
				{
					//give achivement
					Debug.Log ("You found the mural");
					//Screen.lockCursor = true;
					//MovementFreeze.UnFreezePlayer ();
					Screen.showCursor = false;
				}
				else
				{
				}
			}
		}
		else if(muralQuestIsStarted && !weInBusiness)
		{
			labelText = "";
		}
	}
}


	/*public static void TurnInMurals()
	{
		//If mural1 is found and the player is within the hitbox
		if (mural1Found && weInBusiness) 
		{
			/* player gets achievement
			 * If mural 2 or 3 is still in the scene delete those
			 * maybe add a boolean that's only true after you've gotten the achievement so you can't start quest again
			 */
			/*labelText = "You collected the real mural, great job.";
			GUILayout.Label(labelText);

			//If the first mural is the only one to be found, destroy the other 2
			if(mural3Found)
			{
				Destroy (GameObject.Find( "Mural 3" ));
			}
			else if(mural2Found)
			{
				Destroy (GameObject.Find( "Mural 2" ));
			}
		}
		//ELSE IF mural2 is found and the player is within the hitbox of Cal **Might have to add something for mural1 not found yet
		else if (mural2Found && weInBusiness)
		{
			//Cal says "WHAT IS THIS?! AN IMPOSTER? Nonono, this isn't my mural. Keep looking"
				//Off of this, set count ++ and if count == 2 (or 1) then change what he says

		}
		//ELSE IF mural3 is found and the player is within the hitbox of Cal
		else if(mural3Found && weInBusiness)
		{
			//Cal says "WHAT IS THIS?! AN IMPOSTER? Nonono, this isn't my mural. Keep looking"
				//Off of this, set count ++ and if count == 2 (or 1) then change what he says
			labelText = "You collected mural3 which is an imposter.";
			GUILayout.Label(labelText);
		}
	}*/

