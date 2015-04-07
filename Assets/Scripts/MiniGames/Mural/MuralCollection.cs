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
	public static bool weInBusiness = false;

	public static bool mural1Found = false;
	public static bool mural2Found = false;
	public static bool mural3Found = false;

	public float menuHeight;
	public float menuSpace;

	/*public GameObject CalsMural;
	public GameObject Imposter1;
	public GameObject Imposter2;*/

	public string labelText = "";

	void Start () 
	{
	
	}

	void Update () 
	{
	
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
					Screen.lockCursor = true;
					//hide the mouse
					Screen.showCursor = false;
					MovementFreeze.UnFreezePlayer ();
					
				}
				
				else if (GUI.Button(new Rect(Screen.width / 2 - 250 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "No one cares, walk away"))
				{
					muralQuestIsStarted = false;
					weInBusiness = false;
					Screen.lockCursor = true;
					MovementFreeze.UnFreezePlayer ();
				}
			}
			else
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
			}
		}

		//If the quest is started and you're colliding with the collider
		if(muralQuestIsStarted && weInBusiness)
		{
			//DISPLAY TEXT TO THE PLAYER TO PICK UP THE BOOKS
			labelText = "My favorite mural went missing! Can you help me find it? I'm sure it's around here somewhere... Come back right away if you find it!";
			GUILayout.Label(labelText);
		}
		else if(muralQuestIsStarted && !weInBusiness)
		{
			labelText = "";
		}
	}



	/*public static void UpdateMuralsCollected()
	{
		//If Mural 1 is not in the scene
		if(GameObject.Find("Mural 1") == null)
		{
			//You found the real mural\
			mural1Found = true;
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
		}
		else
		{
			mural3Found = false;
		}
	}*/

	/*public static void TurnInMurals()
	{
		//If mural1 is found and the player is within the hitbox
		if (mural1Found && weInBusiness) 
		{
			/* player gets achievement
			 * If mural 2 or 3 is still in the scene delete those
			 * maybe add a boolean that's only true after you've gotten the achievement so you can't start quest again
			 */
			/*if(mural3Found)
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
		}
	}*/
}
