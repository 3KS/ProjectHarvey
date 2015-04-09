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
	
	public static int muralSwitch = 0;

	public float menuHeight;
	public float menuSpace;

	public string labelText = "";

	void Start () 
	{
	
	}

	void Update () 
	{
		switch(muralSwitch)
		{
			/*
			 * Case 0
			 * No murals have been collected, triggered after the player accepts the quest
			 * dialogue trigger
			 */
		case 0:
			if(muralSwitch == 1)
			{
				if(weInBusiness)
				{
					labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
				}
			}
			break;
			
			/*
			 * Case 1
			 * if mural 1 has been collected
			 * prompt user to go back to Cal
			 * prevent the user to pick up any other murals
			 * 
			 * if player is talking to Cal
			 * achievement earned
			 * delete the other murals from the game
			 */
		case 1:
			if(muralSwitch == 2)
			{
				if(weInBusiness)
				{
					labelText = "You collected the real mural, great job.";
				}
			}
			break;
			
			/*
			 * Case 2
			 * if mural 2 has been collected
			 * prompt the user to go back to Cal
			 * prevent the user from picking up any other murals
			 * 
			 * if the player is talking to Cal
			 * print "this isnt my mural, go look for the real one"
			 */
		case 2:
			if(muralSwitch == 3)
			{
				if(weInBusiness)
				{
					labelText = "You collected mural2 which is an imposter.";
				}
			}
			break;
			
			/*
			 * Case 3
			 * if mural 3 has been collected
			 * prompt the user to go back to Cal
			 * prevent the user from picking up any other murals
			 * 
			 * if the player is Talking to Cal
			 * print "I didn't make this imposter!"
			 */
		case 3:
			if(muralSwitch == 4)
			{
				if(weInBusiness)
				{
					labelText = "You collected mural3 which is an imposter.";
				}
			}
			break;
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
			
			if(!muralQuestIsStarted)
			{
				//if we havent started the quest put the buttons up
				//set boolean to true or false within each of the following statemetns
				if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start mural quest"))
				{
					muralQuestIsStarted = true;
					weInBusiness = true;
					//hide the mouse
					Screen.showCursor = false;
					labelText = "YOU STARTED THE QUEST GOOD JOB YOU PRESSED A BUTTON";
				}
				
				else if (GUI.Button(new Rect(Screen.width / 2 - 250 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "No one cares, walk away"))
				{
					muralQuestIsStarted = false;
					weInBusiness = false;
					Screen.lockCursor = true;
					MovementFreeze.UnFreezePlayer ();
				}
			}
			else //If you choose to start the quest
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				GUILayout.Label(labelText);
				Debug.Log ("label text should appear now because quest is started");
			}
		}



		//If the quest is started and you're colliding with the collider
		/*if(muralQuestIsStarted && weInBusiness)
		{
			//DISPLAY TEXT TO THE PLAYER TO PICK UP THE BOOKS
			labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
			GUILayout.Label(labelText);
		}
		else if(muralQuestIsStarted && !weInBusiness)
		{
			labelText = "";
		}*/
	}



	public static void UpdateMuralsCollected()
	{
		//If Mural 1 is not in the scene
		if(GameObject.Find("Mural 1") == null)
		{
			//You found the real mural
			mural1Found = true;
			muralSwitch = 2;
			//Debug.Log ("The mural 1 has been collected");
		}
		else
		{
			mural1Found = false;
			//Debug.Log ("Mural 1 has not been found yet");
		}
		
		//If Mural 2 is not in the scene
		if(GameObject.Find("Mural 2") == null)
		{
			//You found an imposter
			mural2Found = true;
			muralSwitch = 3;
		}
		else
		{
			mural2Found = false;
		}
		//If Mural 3 is not in the scene
		if(GameObject.Find("Mural 3") == null)
		{
			//You found an imposter
			mural3Found = true;
			muralSwitch = 4;
		}
		else
		{
			mural3Found = false;
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
}
