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
	
	// Look at the playbill variables
	public GameObject playbill;
	public GameObject playbillPickUp;
	public GameObject playbillSetDown;
	
	private bool showPickup;
	private bool showSetDown;
	public float setDownDelay;

	void Start ()
	{
		displayGameMenu = false;
		
		playbill.active = false;
		playbillPickUp.active = false;
		playbillSetDown.active = false;
		showPickup = false;
		showSetDown = false;
	}
	
	void Update ()
	{
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayTheater") == 1)
		{
			if (Input.GetButtonDown("Select") && showPickup == true)
			{
				//Debug.Log("GotHere 2");
				playbill.active = true;
				playbillPickUp.active = false;
				Invoke ("ShowSetDown", setDownDelay);
			}
			
			if (Input.GetButtonDown("Select") && showSetDown == true)
			{
				//Debug.Log("GotHere 4");
				PlayerPrefs.SetInt(SaveController.GetPrefix () + "canPlayTheater", 2);
				playbill.active = false;
				playbillSetDown.active = false;
				
				displayCanvas = true;
				GameControl ();
				player.GetComponent <TheaterSetChange> ().SwitchToGameCam ();
			}
		}
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
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayTheater") == 1)
		{
			if (other.gameObject.tag == "Player")
			{
				//Debug.Log("Player entered trigger");
				gameInstructions.Play ();
				playbillPickUp.active = true;
				showPickup = true;
				
				//displayGameMenu = true;
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if (other.collider.gameObject.tag == "Player")
		{
			displayGameMenu = false;
			playbill.active = false;
			playbillPickUp.active = false;
			playbillSetDown.active = false;
			showPickup = false;
			showSetDown = false;
		}
	}
	
	void ShowSetDown ()
	{
		playbillSetDown.active = true;
		//Debug.Log("GotHere 3");
		showSetDown = true;
		showPickup = false;
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