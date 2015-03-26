using UnityEngine;
using System.Collections;

/*This script is the main script for the theater set dressing mini-game.
 *It controls the functions necessary for changing cameras and displays the quit button whilst playing the minigame.
 *
 *More To Come
 * 
 * */

public class TheaterSetChange : MonoBehaviour
{
// These variables are necessary for accessing the TheaterChangeTrigger script, as well as getting the two different cameras in the scene.
	public GameObject player;
	public GameObject playerCam;	// This variable holds the camera from the first person controller.
	public GameObject gameCam;		// This variable holds the camera that overlooks the stage.
	public GameObject theaterGameTrigger;

	public GameObject rightLightControl;
	public GameObject leftLightControl;

// These two variables are exposed in the editor to allow moving the quit button easily.
	public float quitPosX;	//Controls the quit button's horizontal position.
	public float quitPosY;	//Controls the quit button's vertical position.

// This variable is used to determine wether or not the quit button is displayed.
	public bool displayQuit;

	void Start ()
	{
		playerCam.camera.active = true;
		gameCam.camera.active = false;
		displayQuit = false;
	}

	void OnGUI ()
	{
		if (displayQuit == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + quitPosX, Screen.height / 2 - quitPosY, 200, 50), "Quit"))
			{
				theaterGameTrigger.GetComponent <TheatersetChangeTrigger>().displayCanvas = false;
				theaterGameTrigger.GetComponent <TheatersetChangeTrigger>().GameControl ();

				rightLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = false;
				leftLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = false;

				SwitchToPlayerCam ();
			}
		}
	}

	public void SwitchToGameCam ()
	{
		playerCam.camera.active = false;
		gameCam.camera.active = true;
		displayQuit = true;
	}

	void SwitchToPlayerCam ()
	{
		gameCam.camera.active = false;
		playerCam.camera.active = true;
		displayQuit = false;

		Screen.lockCursor = true;
		MovementFreeze.UnFreezePlayer ();
	}
}
