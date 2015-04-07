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

	public GameObject AnnesHouseBook;
	public GameObject PicadillyJimBook;
	public GameObject SummerEdithBook;
	public GameObject UniversityOfHardKnocksBook;
	public GameObject SigmundFreudBook;
	

	public string labelText = "";

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
		}
}
	void OnTriggerExit(Collider other)
	{
		//not colliding with the collider, don't let the librarian talk to you!!
		labelText = "";
		Debug.Log ("we out");
		weInBusiness = false;
	}

	void AddBooksToTheScene()
	{
		//Anne's House of Dreams
		Vector3 position = new Vector3(-67.8F , 1.40F , -30.2F);
		Quaternion rotation = Quaternion.Euler(0, 30, 0);
		GameObject book1 = Instantiate(AnnesHouseBook, position, rotation) as GameObject;

		//Picadilly Jim
		Vector3 position2 = new Vector3(-72.938F , 1.407F , -32.389F);
		Quaternion rotation2 = Quaternion.Euler(0, 195.132F, 0);
		GameObject book2 = Instantiate(PicadillyJimBook, position2, rotation2) as GameObject;

		//Summer Edith
		Vector3 position3 = new Vector3(-77.574F , 1.36F , -17.978F);
		Quaternion rotation3 = Quaternion.Euler(359.2479F, 185.4311F, 19.74367F);
		GameObject book3 = Instantiate(SummerEdithBook, position3, rotation3) as GameObject;

		//University of Hard Knocks
		Vector3 position4 = new Vector3(-69.665F , 1.333F , -8.232F);
		Quaternion rotation4 = Quaternion.Euler(0.376144F, 195.9142F, 0.6376517F);
		GameObject book4 = Instantiate(UniversityOfHardKnocksBook, position4, rotation4) as GameObject;

		//Sigmund Freud
		Vector3 position5 = new Vector3(-68.942F , 1.327F , -15.968F);
		Quaternion rotation5 = Quaternion.Euler(0, 226.1464F, 0);
		GameObject book5 = Instantiate(SigmundFreudBook, position5, rotation5) as GameObject;
	}
	                   

	void OnGUI()
	{
		if (weInBusiness == true) 
		{
			MovementFreeze.FreezePlayer ();
			Screen.lockCursor = false;

			if(!bookQuestIsStarted)
			{
				//if we havent started the quest put the buttons up
				//set boolean to true or false within each of the following statemetns
				if (GUI.Button(new Rect(Screen.width / 2 + 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Start book quest"))
				{
					bookQuestIsStarted = true;
					canStartBookQuest = true;
					weInBusiness = true;
					Screen.lockCursor = true;
					//hide the mouse
					Screen.showCursor = false;
					MovementFreeze.UnFreezePlayer ();
					AddBooksToTheScene();
				}

				else if (GUI.Button(new Rect(Screen.width / 2 - 250 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
				{
					bookQuestIsStarted = false;
					canStartBookQuest = false;
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

		if(bookQuestIsStarted && weInBusiness)
		{
			//DISPLAY TEXT TO THE PLAYER TO PICK UP THE BOOKS
			labelText = "I need you to help me find my five missing books! They're hidden around the library. The titles of the five books are: Anne's House of Dreams, Summer, Piccadilly Jim, Introductory Lectures on Psychoanalysis, and the University of Hard Knocks";
			GUILayout.Label(labelText);
		}
		else if(bookQuestIsStarted && !weInBusiness)
		{
			labelText = "";
		}
	}
}