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

		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 3") == null && !MuralCheck.muralIsTurnedIn)
		{
			mural3Null = true;
			PlayerPrefs.SetInt ("mural3Visible", 2); //set to a global null
			
			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural2Visible", 0);
			}
			
			if(PlayerPrefs.GetInt ("mural2Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural2Visible", 0);
			}
			Debug.Log ("Mural 3 is null");
		}
		
		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 3") == null && !MuralCheck.muralIsTurnedInTwice)
		{
			mural3Null = true;
			PlayerPrefs.SetInt ("mural3Visible", 2); //set to a global null
			
			if(PlayerPrefs.GetInt ("mural1Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural1Visible", 0);
			}
			
			if(PlayerPrefs.GetInt ("mural2Visible") != 2)
			{
				PlayerPrefs.SetInt ("mural2Visible", 0);
			}
			//Debug.Log ("murals 2 and 3 are null");
		}
		
		if (MuralCheck.muralsAreAdded == false && mural3Null == false) 
		{
			//GameObject.Find("Mural 3").renderer.enabled = false;
			PlayerPrefs.SetInt ("mural3Visible", 0);
			Debug.Log ("Mural 3 is not visible");
		}
		
		else if (MuralCheck.muralsAreAdded == true && mural3Null == false)
		{
			//GameObject.Find("Mural 3").renderer.enabled = true;
			PlayerPrefs.SetInt ("muralsAddedPrefs", 1);
			PlayerPrefs.SetInt ("mural3Visible", 1);
			Debug.Log ("Mural 3 is visible");
		}

		if(PlayerPrefs.GetInt ("mural3Visible") == 0)
		{
			GameObject.Find("Mural 3").renderer.enabled = false;
		}
		
		else if (PlayerPrefs.GetInt ("mural3Visible") == 1)
		{
			GameObject.Find("Mural 3").renderer.enabled = true;
		}

	}
}
