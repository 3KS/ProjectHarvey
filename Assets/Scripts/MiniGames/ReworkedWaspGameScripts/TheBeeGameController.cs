using UnityEngine;
using System.Collections;

public class TheBeeGameController : MonoBehaviour
{
	public bool canPlayGame;
	public bool canSeeSwatter;

	private bool playerCanSwing;

	public GameObject player;
	public GameObject directions;


	void Start ()
	{
		directions.renderer.enabled = false;
		canPlayGame = true;
		playerCanSwing = false;
		canSeeSwatter = true;
	}


	void OnTriggerEnter (Collider other)
	{
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 2)
		{
			if (other.gameObject.tag == "Player")
			{
				if (canPlayGame == true)
				{
					//player.GetComponent <TheBeeGame>().showMenu = true;
					player.GetComponent<TheBeeGame> ().playGame = true;;
					canPlayGame = false;
				}
				
				if (canSeeSwatter == true)
				{
					player.GetComponent <TheBeeGame>().gameIsPlaying = true;
				}
				player.GetComponent <TheBeeGame>().SwatterVisible ();
			}
		}
	}


	void OnTriggerStay (Collider other)
	{
		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 2)
		{
			if (other.gameObject.tag == "Player")
			{
				//player.GetComponent <TheBeeGame>().gameIsPlaying = true;
				directions.renderer.enabled = true;
				player.GetComponent <TheBeeGame>().Swing ();
			}
		}
	}


	void OnTriggerExit (Collider other)
	{
		directions.renderer.enabled = false;

		if (PlayerPrefs.GetInt (SaveController.GetPrefix () + "canPlayWasps") == 2)
		{
			if (other.gameObject.tag == "Player");
			{
				playerCanSwing = false;

				player.GetComponent <TheBeeGame>().gameIsPlaying = false;
				player.GetComponent <TheBeeGame>().SwatterVisible ();
				player.GetComponent <TheBeeGame>().showMenu = false;
			}
		}
	}
}
