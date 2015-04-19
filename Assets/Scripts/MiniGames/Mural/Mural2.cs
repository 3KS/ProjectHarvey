/*
 * This script goes in the same room with the second mural
 * Ronnie Smith
 * #SWAG
 */

using UnityEngine;
using System.Collections;

public class Mural2 : MonoBehaviour 
{
	public static bool mural2Null = false;
	
	void Start () 
	{
	}
	
	void Update () 
	{
		if (PlayerPrefs.GetInt ("mural2Visible") == 2)
		{
			mural2Null = true;
			MuralCheck.mural2Found = true;
		}

		else if(PlayerPrefs.GetInt ("mural2Visible") == 0)
		{
			if(GameObject.Find("Mural 2") != null)
			{
				GameObject.Find("Mural 2").renderer.enabled = false;
				Debug.Log ("Mural 2 is NOT visible");
			}
		}
		
		else if (PlayerPrefs.GetInt ("mural2Visible") == 1)
		{
			if(GameObject.Find("Mural 2") != null)
			{
				GameObject.Find("Mural 2").renderer.enabled = true;
				Debug.Log ("Mural 2 is visible");
			}
		}

		//If the murals have been added, number 2 is picked up, and it hasn't been turned in yet
		//Set mural 2 to null and hide the others
		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 2") == null && !MuralCheck.mural2IsTurnedIn)
		{
			PlayerPrefs.SetInt ("mural2Visible", 2); //set to a global null

			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
			}
			
			if(PlayerPrefs.GetInt ("mural3Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural3Visible", 0);
			}
			Debug.Log ("Mural 2 is null");
		}

		//If the murals are added, number 2 is null and number 3 is null, and it hasn't been turned in
		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 2") == null && Mural3.mural3Null == true && !MuralCheck.muralIsTurnedInTwice)
		{
			PlayerPrefs.SetInt ("mural2Visible", 2); //set to a global null
			
			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
			}
			//Debug.Log ("murals 2 and 3 are null");
		}
	}
}
