using UnityEngine;
using System.Collections;

public class TheBeeGame : MonoBehaviour
{

	public int waspkills;

	public bool gameIsPlaying;
	public bool showMenu;
	public bool playGame;
	public bool killTheWasp;
	public bool stopPlayer;


	public GameObject player;
	public GameObject playerSwatter;
	public GameObject swatterInitialPosition;
	public GameObject swatterSwatPosition;
	public GameObject waspGameTrigger;
	public GameObject killTrigger;


	public AudioSource swatSound;
	public bool playKillSound;
	public AudioSource swatKill;

	void Update ()
	{
		Debug.Log ("WaspKills : " + waspkills);
	}

// The Start function sets all bools to false, sets the number of dead wasps to 0 and sets the swatter's resting position and rotation
	void Start ()
	{
		playerSwatter.active = false;
		waspkills = 0;
		gameIsPlaying = false;
		playKillSound = false;
		stopPlayer = false;

		playerSwatter.transform.position = swatterInitialPosition.transform.position;
		playerSwatter.transform.rotation = swatterInitialPosition.transform.rotation;
	}


	void OnGUI ()
	{

// This if statement controls the current menu for playing the wasp game
// If the player walks into the game zone, the player is frozen and the menu appears
// When the player chooses an option, the game is turned on or the game is turned off
		if (showMenu == true)
		{
			MovementFreeze.FreezePlayer();
			Screen.lockCursor = false;

			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 - 50, 200, 50), "Play Wasp Game"))
			{
				playGame = true;
				MovementFreeze.UnFreezePlayer ();
				Screen.lockCursor = true;

				waspGameTrigger.GetComponent<TheBeeGameController>().canPlayGame = false;
				showMenu = false;
			}
			if (GUI.Button(new Rect(Screen.width / 2 - 90, Screen.height / 2 + 50, 200, 50), "Don't Play the Wasp Game"))
			{
				playGame = false;
				MovementFreeze.UnFreezePlayer ();
				Screen.lockCursor = true;
				showMenu = false;
			}
		}

// This if statement controls the GUI for number of wasps killed as well as telling the player when all wasps have been killed
		if (gameIsPlaying == true)
		{
			if (waspkills <= 10)
			{
				GUILayout.Label ("Wasps Killed: " + waspkills + " / 10");
			}
			
			if (waspkills >= 10)
			{
				//if (!AchievementController.CheckAchievement(AchievementController.Achievements.SwatTeam))
				//{
				//	AchievementController.UnlockAchievement (AchievementController.Achievements.SwatTeam);
					GUILayout.Label ("Wasps have been exterminated");
					Invoke ("DisableWaspGame", 2.5f);
				//}

			}
		}
	}

	
// This function is called by the TheBeeGameController script.
// It is used to make the swatter invisible when the player isn't playing the game.
	public void SwatterVisible ()
	{

		if (gameIsPlaying == true)
		{
			Debug.Log ("Swatter should be visible");
			playerSwatter.active = true;
		} 
		else
		{
			playerSwatter.active = false;
		}
	}

// This function is called by the TheBeeGameController script.
// This function is active only when the player is standing in the minigame area.
// This script controls the movement and rotation of the swatter, allows for wasps to be killed, the kill sound plays
// The kill sound is played through the Invoke ("KillSound", .3f); where KillSound is the function that plays the sound and .3f is the delay before it plays
	public void Swing ()
	{
		if (Input.GetMouseButton (0))
		{
			swatSound.Play ();

			playerSwatter.transform.position = swatterSwatPosition.transform.position;
			playerSwatter.transform.rotation = swatterSwatPosition.transform.rotation;

			killTrigger.GetComponent <TheBeeGameKillTrigger>().beeDestroyed = true;

			if (playKillSound == true)
			{
				Invoke ("KillSound", .3f);
				playKillSound = false;
			}
		}
		else
		{
			playerSwatter.transform.position = swatterInitialPosition.transform.position;
			playerSwatter.transform.rotation = swatterInitialPosition.transform.rotation;

			killTrigger.GetComponent <TheBeeGameKillTrigger>().beeDestroyed = false;
		}
	}

// This function is called by Swing () .3 seconds after the player kills a wasp
	void KillSound ()
	{
		swatKill.Play ();
	}


	void DisableWaspGame ()
	{
		waspGameTrigger.GetComponent <TheBeeGameController> ().canSeeSwatter = false;
		waspGameTrigger.GetComponent <TheBeeGameController>().enabled = false;
		killTrigger.GetComponent <TheBeeGameKillTrigger>().enabled = false;
		player.GetComponent <TheBeeGame>().enabled = false;
	}
}
