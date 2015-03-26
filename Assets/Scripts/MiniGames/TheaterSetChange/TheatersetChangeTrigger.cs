using UnityEngine;
using System.Collections;

public class TheatersetChangeTrigger : MonoBehaviour
{
	public bool displayGameMenu;
	public bool displayCanvas;
	public bool playerIsInGame;

	public GameObject player;
	public GameObject canvas;
	public GameObject leftLightControl;
	public GameObject rightLightControl;

	public AudioSource gameInstructions;

	public float menuSpace;
	public float menuHeight;
	public float lightButtonPosX;
	public float lightButtonPosY;

	void Start ()
	{
		displayGameMenu = false;
	}

	void OnGUI ()
	{
		if (displayGameMenu == true && !gameInstructions.isPlaying)
		{
			Screen.lockCursor = false;
			MovementFreeze.FreezePlayer ();

			if (GUI.Button (new Rect (Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Help arrange the theater"))
			{
				displayCanvas = true;
				GameControl ();

				player.GetComponent <TheaterSetChange> ().SwitchToGameCam ();
				displayGameMenu = false;
			}
			
			// This option exits the chatting minigame
			else if (GUI.Button (new Rect (Screen.width / 2 - 90 - menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Walk away"))
			{
				Screen.lockCursor = true;
				MovementFreeze.UnFreezePlayer ();
				displayGameMenu = false;
			}
		}

		if (playerIsInGame == true)
		{
			if (GUI.Button(new Rect(Screen.width / 2 - 90 + lightButtonPosX, Screen.height / 2 - lightButtonPosY, 200, 50), "Move Right Light"))
			{
				rightLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = true;
			}

			if (GUI.Button(new Rect(Screen.width / 2 - 90 + lightButtonPosX, Screen.height / 2 - (lightButtonPosY + 50), 200, 50), "Move Left Light"))
			{
				leftLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = true;
			}
			
			if (GUI.Button (new Rect (Screen.width / 2 - 90 - lightButtonPosX, Screen.height / 2 - lightButtonPosY, 200, 50), "Lock Right Light"))
			{
				rightLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = false;
				rightLightControl.GetComponent <TheaterSetChangeLightRotationControl>().KeepLightInPlace ();
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 90 - lightButtonPosX, Screen.height / 2 - (lightButtonPosY + 50), 200, 50), "Lock Left Light"))
			{
				leftLightControl.GetComponent <TheaterSetChangeLightRotationControl>().canMoveLights = false;
				leftLightControl.GetComponent <TheaterSetChangeLightRotationControl>().KeepLightInPlace ();
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameInstructions.Play ();

			displayGameMenu = true;
		}
	}

	public void GameControl ()
	{
		if (displayCanvas == true)
		{
			canvas.active = true;

			playerIsInGame = true;
		}
		else
		{
			canvas.active = false;

			playerIsInGame = false;
		}


	}
}