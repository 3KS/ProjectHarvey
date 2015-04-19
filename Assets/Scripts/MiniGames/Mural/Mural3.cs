/*
 * This script goes in the same room with the third mural
 * smith script #swiggity swooggity
 * #SWAG
 */

using UnityEngine;
using System.Collections;

public class Mural3 : MonoBehaviour 
{
	public static bool mural3Null = false;
	
	void Start () 
	{
	}
	
	void Update () 
	{
		if (PlayerPrefs.GetInt ("mural3Visible") == 2)
		{
			mural3Null = true;
			MuralCheck.mural3Found = true;
		}

		if(PlayerPrefs.GetInt ("mural3Visible") == 0)
		{
			if(GameObject.Find("Mural 3") != null)
			{
				GameObject.Find("Mural 3").renderer.enabled = false;
				Debug.Log ("Mural 3 is NOT visible");
			}
		}
		
		else if (PlayerPrefs.GetInt ("mural3Visible") == 1)
		{
			if(GameObject.Find("Mural 3") != null)
			{
				GameObject.Find("Mural 3").renderer.enabled = true;
				Debug.Log ("Mural 3 is visible");
			}
		}

		//If mural 3 is missing and has not been turned in
		// Set the other 2 murals to invisible
		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 3") == null && !MuralCheck.mural3IsTurnedIn)
		{
			PlayerPrefs.SetInt ("mural3Visible", 2); //set to a global null
			
			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
			}
			
			if(PlayerPrefs.GetInt ("mural2Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural2Visible", 0);
			}
			Debug.Log ("Mural 3 is null");
		}

		//if murals 2 and 3 are null and they have't been turned in twice
		//set them to invisible (until muralCheck handles it)
		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 3") == null && Mural2.mural2Null == true && !MuralCheck.muralIsTurnedInTwice)
		{
			mural3Null = true;
			PlayerPrefs.SetInt ("mural3Visible", 2); //set to a global null
			
			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
			}
		}
	}
}
