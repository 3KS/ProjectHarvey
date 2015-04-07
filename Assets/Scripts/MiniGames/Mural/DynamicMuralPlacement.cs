using UnityEngine;
using System.Collections;

public class DynamicMuralPlacement : MonoBehaviour 
{
	public GameObject CalsMural;
	public GameObject Imposter1;
	public GameObject Imposter2;

	private bool muralsAreAdded = false;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		AddMuralsToScene ();
	}
	
	void AddMuralsToScene()
	{
		if(MuralCollection.muralQuestIsStarted == true && muralsAreAdded == false)
		{
			//mural1
			Vector3 position = new Vector3(-10.56F , 43.46F , -70.236F);
			Quaternion rotation = Quaternion.Euler(0, 82.75108F, 0);
			GameObject mural1 = Instantiate(CalsMural, position, rotation) as GameObject;
			
			//mural2
			Vector3 position2 = new Vector3(-10.429F , 43.535F , -72.41F);
			Quaternion rotation2 = Quaternion.Euler(0, 0, 0);
			GameObject mural2 = Instantiate(Imposter1, position2, rotation2) as GameObject;
			
			//mural3
			Vector3 position3 = new Vector3(-10.641F , 43.535F , -72.41F);
			Quaternion rotation3 = Quaternion.Euler(0, 0, 0);
			GameObject mural3 = Instantiate(Imposter2, position3, rotation3) as GameObject;

			muralsAreAdded = true;
		}
	}
}
