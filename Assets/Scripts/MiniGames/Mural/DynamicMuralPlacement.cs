/*
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * #SWAG
 * we dont need this script anymore
 */
using UnityEngine;
using System.Collections;

public class DynamicMuralPlacement : MonoBehaviour 
{
	public GameObject CalsMural;
	public GameObject Imposter1;
	public GameObject Imposter2;

	public static bool muralsAreAdded = false;
	
	void Start () 
	{

	}

	void Update () 
	{
		AddMuralsToScene ();
	}
	
	void AddMuralsToScene()
	{
		if(MuralCollection.muralQuestIsStarted == true && muralsAreAdded == false)
		{
			GameObject.Find("Mural 1").renderer.enabled = true;
			GameObject.Find("Mural 2").renderer.enabled = true;
			GameObject.Find("Mural 3").renderer.enabled = true;
			muralsAreAdded = true;
			PlayerPrefs.SetInt ("muralsAddedPrefs", 1);

			//all of the murals are added, so set the value to 1 which equals true
			PlayerPrefs.SetInt ("mural1Visible", 1);
			PlayerPrefs.SetInt ("mural2Visible", 1);
			PlayerPrefs.SetInt ("mural3Visible", 1);
			

			//mural1
			if(PlayerPrefs.GetInt ("mural1Visible") == 1)
			{
				Vector3 position = new Vector3(-10.56F , 43.46F , -70.236F);
				Quaternion rotation = Quaternion.Euler(0, 82.75108F, 0);
				GameObject mural1 = Instantiate(CalsMural, position, rotation) as GameObject;
			}
			
			//mural2
			if(PlayerPrefs.GetInt ("mural2Visible") == 1)
			{
				Vector3 position2 = new Vector3(-10.429F , 43.535F , -72.41F);
				Quaternion rotation2 = Quaternion.Euler(0, 0, 0);
				GameObject mural2 = Instantiate(Imposter1, position2, rotation2) as GameObject;
			}
				
			//mural3
			if(PlayerPrefs.GetInt ("mural3Visible") == 1)
			{
				Vector3 position3 = new Vector3(-10.641F , 43.535F , -74.41F);
				Quaternion rotation3 = Quaternion.Euler(0, 0, 0);
				GameObject mural3 = Instantiate(Imposter2, position3, rotation3) as GameObject;
			}
		}

		else if (MuralCollection.muralQuestIsStarted == false && muralsAreAdded == false)
		{
			PlayerPrefs.SetInt ("mural1Visible", 2);
			PlayerPrefs.SetInt ("mural1Visible", 2);
			PlayerPrefs.SetInt ("mural1Visible", 2);
		}
		else if(MuralCollection.muralQuestIsStarted == false)
		{
			GameObject.Find("Mural 1").renderer.enabled = false;
			GameObject.Find("Mural 2").renderer.enabled = false;
			GameObject.Find("Mural 3").renderer.enabled = false;
		}
	}
}

