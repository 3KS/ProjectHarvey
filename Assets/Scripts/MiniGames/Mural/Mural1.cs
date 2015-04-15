/*
 * This script goes in the same room with the first mural
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

		if(MuralCheck.muralsAreAdded && GameObject.Find("Mural 1") == null && !MuralCheck.muralIsTurnedIn)
		{
			mural1Null = true;
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

		if (MuralCheck.muralsAreAdded == false && mural1Null == false) 
		{
			//GameObject.Find("Mural 1").renderer.enabled = false;
			PlayerPrefs.SetInt ("mural1Visible", 0);
			Debug.Log ("Mural 1 is not visible");
		}

		else if (MuralCheck.muralsAreAdded == true && mural1Null == false)
		{
			//GameObject.Find("Mural 1").renderer.enabled = true;
			PlayerPrefs.SetInt ("muralsAddedPrefs", 1);
			PlayerPrefs.SetInt ("mural1Visible", 1);
			Debug.Log ("Mural 1 is visible");
		}

		if(PlayerPrefs.GetInt ("mural1Visible") == 0)
		{
			GameObject.Find("Mural 1").renderer.enabled = false;
		}
		
		else if (PlayerPrefs.GetInt ("mural1Visible") == 1)
		{
			GameObject.Find("Mural 1").renderer.enabled = true;
		}

	}
}
