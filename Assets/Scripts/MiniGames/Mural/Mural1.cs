/*
 * This script goes in the same room with the first mural
 * SETS THE VISIBILITY OF MURALS ONCE THEYVE BEEN PICKED UP
 * R00nn13 SMYTHE
 * #SWAG
 */

using UnityEngine;
using System.Collections;

public class Mural1 : MonoBehaviour 
{
	public static bool mural1Null = false;

	void Start () 
	{
	}

	void Update () 
	{
		if (PlayerPrefs.GetInt ("mural1Visible") == 2)
		{
			mural1Null = true;
			MuralCheck.mural1Found = true;
		}

		else if(PlayerPrefs.GetInt ("mural1Visible") == 0)
		{
			if(GameObject.Find("Mural 1") != null)
			{
				GameObject.Find("Mural 1").renderer.enabled = false;
				Debug.Log ("Mural 1 is not visible");
			}
		}
		
		else if (PlayerPrefs.GetInt ("mural1Visible") == 1)
		{
			if(GameObject.Find("Mural 1") != null)
			{
				GameObject.Find("Mural 1").renderer.enabled = true;
				Debug.Log ("Mural 1 is visible");
			}
		}

		//If the player finds the first mural and the quest is NOT turned in
		//Set the mural2Int to 2 (null)
		//Set the other 2 murals to invisible if they're in the game.

		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 1") == null && !MuralCheck.mural1IsTurnedIn)
		{
			PlayerPrefs.SetInt ("mural1Visible", 2); //set to a global null

			if(PlayerPrefs.GetInt ("mural2Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural2Visible", 0);
			}

			if(PlayerPrefs.GetInt ("mural3Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural3Visible", 0);
			}

			Debug.Log ("Mural 1 is null and the others are not visible");
		}
	}
}
