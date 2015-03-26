using UnityEngine;
using System.Collections;

/*This script is controls the fly swatter and
 * determines what happens when a wasp is killed.
 * 
 * */

public class WaspSwatter : MonoBehaviour
{
	//will eventually be used to lock the player in place:
	//public GameObject waspGameCenter;

	public GameObject swatter;
	public GameObject swatterInitialPosition;
	public GameObject swatterSlapPosition;

	public GameObject swatZone;

	public AudioSource bugWhack;
	public AudioSource bugSquish;

	// swatNow is used in collision detection, allows the player to kill wasps
	//private bool swatNow = false;

	// used to determine wether or not the player has killed a wasp
	//private bool deadWasp;
	private bool waspIsDead;
	public static bool gameIsRunning;
	public static bool canSwatNow;

	public Material glow;
	public Material original;

	public static int killCount = 0;

	void Start ()
	{
		//starts the swatter at the initial position
		swatter.transform.rotation = swatterInitialPosition.transform.rotation;
	}

	void Update ()
	{
		if (killCount == 10)
		{
			AchievementController.UnlockAchievement (AchievementController.Achievements.SwatTeam);
			killCount++;
		}

		if (gameIsRunning == true)
		{
			if (Input.GetMouseButtonDown (0))
			{
				Debug.Log ("you clicked!");
				SwatterSlapPosition ();
			}
		}


		/*
		if (canSwatNow == true)
		{
			Debug.Log ("You can take a swing now");

			if (Input.GetMouseButtonUp (0))
			{
				swatter.transform.rotation = swatterSlapPosition.transform.rotation;
			}

			else
			{
				swatter.transform.rotation = swatterInitialPosition.transform.rotation;
			}
		}
		else
		{
			swatter.transform.rotation = swatterInitialPosition.transform.rotation;
		}
		*/





		/*
		if (Input.GetMouseButtonUp (0))
		{
			swatter.transform.rotation = swatterInitialPosition.transform.rotation;

			deadWasp = false;
		}

		if (Input.GetMouseButtonDown (0) && swatNow == true)
		{
			deadWasp = true;

			bugWhack.Play ();
			bugSquish.Play ();

			swatter.transform.rotation = swatterSlapPosition.transform.rotation;
		}
		else if (Input.GetMouseButtonDown (0) && swatNow == false)
		{
			deadWasp = false;

			bugWhack.Play ();

			swatter.transform.rotation = swatterInitialPosition.transform.rotation;
		}
		*/
	}

	void SwatterSlapPosition ()
	{
		Debug.Log("SwatterSlapPosition was invoked");

		swatter.transform.rotation = swatterSlapPosition.transform.rotation;

		bugWhack.Play ();

		Invoke ("SwatterNormalPosition", .1f);
	}

	void SwatterNormalPosition ()
	{
		Debug.Log ("SwatterNormalPosition Invoked");

		swatter.transform.rotation = swatterInitialPosition.transform.rotation;
	}

	/*
	void OnCollisionEnter (Collision other)
	{
		Debug.Log ("swatter is connecting");

		if (other.gameObject.name == "wasp")
		{
			Debug.Log ("You successfully smacked a wasp");

			//other.gameObject.active = false;
			//killCount++;
			//bugSquish.Play();
		}
		*/

		/*
		if (other.gameObject.tag == "Wasp")
		{
			swatNow = true;

			swatter.renderer.material = glow;
		} 
		else if (other.gameObject.tag != "Wasp" || other.gameObject == null)
		{
			swatNow = false;

			swatter.renderer.material = original;
		}

		if (other.gameObject.tag == "Wasp" && deadWasp == true)
		{
			other.gameObject.active = false;
			killCount++;
		}
		else if (other.gameObject.tag == "Wasp" && deadWasp == false)
		{
			other.gameObject.active = true;
		}
		*/
	}
//}