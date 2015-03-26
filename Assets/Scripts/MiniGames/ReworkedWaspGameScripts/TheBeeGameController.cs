using UnityEngine;
using System.Collections;

public class TheBeeGameController : MonoBehaviour
{
	public bool canPlayGame;
	public bool canSeeSwatter;

	private bool playerCanSwing;

	public GameObject player;


	void Start ()
	{
		canPlayGame = true;
		playerCanSwing = false;
		canSeeSwatter = true;
	}


	void OnTriggerEnter (Collider other)
	{
		if (canPlayGame == true)
		{
			player.GetComponent <TheBeeGame>().showMenu = true;
		}

		if (canSeeSwatter == true)
		{
			player.GetComponent <TheBeeGame>().gameIsPlaying = true;
		}
		player.GetComponent <TheBeeGame>().SwatterVisible ();
	}


	void OnTriggerStay (Collider other)
	{
		//player.GetComponent <TheBeeGame>().gameIsPlaying = true;
		player.GetComponent <TheBeeGame>().Swing ();
	}


	void OnTriggerExit (Collider other)
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
