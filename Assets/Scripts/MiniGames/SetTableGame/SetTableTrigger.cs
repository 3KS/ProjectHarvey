using UnityEngine;
using System.Collections;

/*Author: Justin Schmidt
 * Where:
 * 		This script gets attached to the "SetTableGameTrigger" object.
 * Description:
 * 		This script controls the start of the Set thye Table for Tea game. 
 * 		When the player collides with the trigger, the game menu shows up 
 * 		and allows the player to eithe rstart the game or leave the game.
 * */

public class SetTableTrigger : MonoBehaviour
{
	public GameObject player;

	public bool menuIsShowing;
	public static bool gameIsPlaying;

	public float menuSpace;
	public float menuHeight;

	void Start ()
	{
		menuIsShowing = false;
	}

	/*
	void Update ()
	{
		if (SetTableGame.gameIsOver == true)
		{
			gameIsPlaying = false;
		}
	}
	*/

	void OnGUI ()
	{
		if (menuIsShowing == true)
		{
			MovementFreeze.FreezePlayer ();

			// This option enters the minigame
			if (GUI.Button (new Rect (Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Help set the table"))
			{
				player.GetComponent<SetTableGame>().canMoveObjects = true;
				gameIsPlaying = true;
				menuIsShowing = false;
			}
			
			// This option exits the minigame
			else if (GUI.Button (new Rect (Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				player.GetComponent<SetTableGame>().canMoveObjects = false;
				MovementFreeze.UnFreezePlayer ();
				menuIsShowing = false;
			}
		}
	}


	void OnTriggerEnter (Collider player)
	{
		menuIsShowing = true;
	}
}
