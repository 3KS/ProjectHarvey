using UnityEngine;
using System.Collections;

/*
 * Checks to see if the quest is started
 * Checks to see what murals have been collected
 * Goes in Cal's Room
 * #SWAG
 */

public class MuralCheck : MonoBehaviour 
{
	public GameObject player;
	public GameObject muralMiniGameTrigger;

	public static bool muralQuestIsStarted = false;
	public static bool muralsAreAdded = false;
	public static bool weInBusiness = false;

	//Plays after the user pressed the button to start the quest
	public static bool startPromptIsPlaying = false;
	public static bool muralIsTurnedIn = false;
	public static bool muralIsTurnedInTwice = false;

	public static bool mural1Found = false;
	public static bool mural2Found = false;
	public static bool mural3Found = false;

	public static bool buttonHit = false; //checks to see if you pressed the button after going back to Cal
	public static bool multipleButtonsHit = false; //checks to see if you pressed the button after collecting murals 2 and 3 and going back to Cal
	public static bool correctButtonHit = false; //Checks to see if mural 1 has been collected
	
	public float menuHeight;
	public float menuSpace;
	
	public string labelText = "";
	public static bool muralsFound = false;

	void Start () 
	{
		if(PlayerPrefs.GetInt ("muralsAddedPrefs") == 0)
		{
			MuralCollection.muralQuestIsStarted = false;
		}

		else if (PlayerPrefs.GetInt ("muralsAddedPrefs") == 1)
		{
			if (PlayerPrefs.GetInt ("mural1Visible") == 0) 
			{
				Debug.Log ("Mural 1 not visible");
			}
			else if (PlayerPrefs.GetInt ("mural1Visible") == 1)
			{
				Debug.Log ("Mural 1 visible");
			}
			else if (PlayerPrefs.GetInt ("mural1Visible") == 2)
			{
				//GameObject.Find ("Mural 1").SetActive = false;
				Debug.Log("Mural 1 is null");
			}

			//#SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG 
			if (PlayerPrefs.GetInt ("mural2Visible") == 0) 
			{
				Debug.Log ("Mural 2 not visible");
			}
			else if (PlayerPrefs.GetInt ("mural2Visible") == 1)
			{
				Debug.Log ("Mural 2 visible");
			}
			else if (PlayerPrefs.GetInt ("mural2Visible") == 2)
			{
				//GameObject.Find ("Mural 1").SetActive = false;
				Debug.Log("Mural 2 is null");
			}

			//#SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG #SWAG 
			if (PlayerPrefs.GetInt ("mural3Visible") == 0) 
			{
				Debug.Log ("Mural 3 not visible");
			}
			else if (PlayerPrefs.GetInt ("mural3Visible") == 1)
			{
				Debug.Log ("Mural 3 visible");
			}
			else if (PlayerPrefs.GetInt ("mural3Visible") == 2)
			{
				//GameObject.Find ("Mural 1").SetActive = false;
				Debug.Log("Mural 3 is null");
			}
		}
	}

	void Update () 
	{
		if(muralsAreAdded)
		{
			//If the player finds mural 1
			if(PlayerPrefs.GetInt ("mural1Visible") == 2)
			{
				//If mural 2 is in the scene, don't render it
				if(PlayerPrefs.GetInt ("mural2Visible") == 1)
				{
					PlayerPrefs.SetInt ("mural2Visible", 0);
				}
				//If mural 3 is in the scene, don't render it
				if(PlayerPrefs.GetInt ("mural3Visible") == 1)
				{
					PlayerPrefs.SetInt ("mural3Visible", 0);
				}
				//You found the real mural
				mural1Found = true;
				PlayerPrefs.SetInt ("mural1Visible", 2);
			}
			
			//If Mural 2 is not in the scene but mural 3 is and it's not turned in yet
			else if(PlayerPrefs.GetInt ("mural2Visible") == 2 && PlayerPrefs.GetInt ("mural3Visible") == 1 && !muralIsTurnedIn)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
				PlayerPrefs.SetInt ("mural3Visible", 0);
				PlayerPrefs.SetInt ("mural2Visible", 2);
				//You found an imposter
				mural2Found = true;
				mural3Found = false;
				//Debug.Log ("Mural 2 has been found");
			}
			
			else if(PlayerPrefs.GetInt ("mural2Visible") == 2 && PlayerPrefs.GetInt ("mural3Visible") == 1 && muralIsTurnedIn) //once you turn in the second one, you dont want the others to appear again
			{
				PlayerPrefs.SetInt ("mural1Visible", 1);
				PlayerPrefs.SetInt ("mural3Visible", 1);				
				PlayerPrefs.SetInt ("mural2Visible", 2);
				
				mural2Found = true;
				mural3Found = false;
			}
			
			//If Mural 3 is not in the scene and mural 2 is in the scene and the murals haven't been turned in to Cal
			else if(PlayerPrefs.GetInt ("mural3Visible") == 2 && PlayerPrefs.GetInt ("mural2Visible") == 1 && !muralIsTurnedIn)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
				PlayerPrefs.SetInt ("mural2Visible", 0);	
				PlayerPrefs.SetInt ("mural3Visible", 2);
				
				//You found an imposter
				mural2Found = false;
				mural3Found = true;
				//Debug.Log ("Mural 3 has been found");
			}
			
			else if(PlayerPrefs.GetInt ("mural3Visible") == 2 && PlayerPrefs.GetInt ("mural2Visible") == 1 && muralIsTurnedIn)
			{
				PlayerPrefs.SetInt ("mural1Visible", 1);
				PlayerPrefs.SetInt ("mural2Visible", 1);	
				PlayerPrefs.SetInt ("mural3Visible", 2);
				
				mural2Found = false;
				mural3Found = true;
			}
			
			//if mural 2 and 3 are out of the scene
			else if(PlayerPrefs.GetInt ("mural3Visible") == 2 && PlayerPrefs.GetInt ("mural2Visible") == 2 && !muralIsTurnedInTwice)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
				PlayerPrefs.SetInt ("mural2Visible", 2);
				PlayerPrefs.SetInt ("mural3Visible", 2);
				
				mural2Found = true;
				mural3Found = true;
			}
			
			else if(PlayerPrefs.GetInt ("mural3Visible") == 2 && PlayerPrefs.GetInt ("mural2Visible") == 2 && muralIsTurnedInTwice)
			{
				PlayerPrefs.SetInt ("mural1Visible", 1);
				PlayerPrefs.SetInt ("mural2Visible", 2);
				PlayerPrefs.SetInt ("mural3Visible", 2);
				
				
				mural2Found = true;
				mural3Found = true;
			}

		}
	}

	//Make sure to set muralsAreAdded to true with the conditions
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
			if(!muralQuestIsStarted && PlayerPrefs.GetInt ("muralsAddedPrefs") == 0)
			{
				MovementFreeze.FreezePlayer ();
				Screen.lockCursor = false;
				//if we havent started the quest put the buttons up
				if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start mural quest"))
				{
					muralQuestIsStarted = true;
					muralsAreAdded = true;
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
				//If the first mural has been found (and is therefore null)
				if(PlayerPrefs.GetInt ("mural1Visible") == 2)
				{
					muralsFound = true;
					if(correctButtonHit == false)
					{
						MovementFreeze.FreezePlayer ();
						Screen.lockCursor = false;
						Screen.showCursor = true;
					}
					//Trigger the button to pop up. When the player presses it then...
					if (GUI.Button(new Rect(Screen.width / 2 - 150 + menuSpace, Screen.height / 2 - menuHeight, 300, 50), "You found my mural, thank you so much!"))
					{
						//Display achievement
						AchievementController.UnlockAchievement(AchievementController.Achievements.FindCalsMural);
						
						correctButtonHit = true;
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
						muralIsTurnedInTwice = true;
					}
				}
			}
		}
	}
}
