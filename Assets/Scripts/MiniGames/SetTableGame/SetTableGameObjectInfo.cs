using UnityEngine;
using System.Collections;

/*Author: Justin Schmidt
 * Where:
 * 		This script goes on each of the objects that are being "set" in the game.
 * Description:
 * 		This script records the initial position and rotation of each object that 
 * 		gets "set" in the game. It checks to see when the variable "reset" in the 
 * 		script "SetTableGameObjectControl" script. When "reset" is true, each object 
 * 		with this script attatched gets moved back to its original position and rotation.
 * */

public class SetTableGameObjectInfo : MonoBehaviour
{
	public GameObject dropObjectHere;
	public GameObject thisObject;

	public Vector3 originalPosition;
	public Quaternion originalRotation;

	public static bool reset;

//	public Material normal;
//	public Material hover;
//	public Material selected;


	void Start ()
	{
		thisObject = dropObjectHere;
		originalPosition = thisObject.transform.position;
		originalRotation = thisObject.transform.rotation;
	}

	void Update ()
	{
		if (SetTableGameObjectControl.reset == true)
		{
			ResetObject ();
		}
	}

	void ResetObject ()
	{
		thisObject.tag = "TableSetObject";
		thisObject.transform.position = originalPosition;
	}

}

	/*

	void Update ()
	{
		if (reset == true)
		{
			MoveObjects ();
		}
	}

	public static void ResetTable ()
	{
		Debug.Log ("You have talked to this many objects: ");
		//Debug.Log ("object name: " + thisObject.name);
		//Debug.Log ("object new location: " + thisObject.transform.position);

		reset = true;
		//Debug.Log ("object new location: " + thisObject.transform.position);
	}

	void MoveObjects ()
	{
		Debug.Log ("reset has been set to true");
		thisObject.tag = "TableSetObject";

		thisObject.transform.position = originalPosition;
		thisObject.transform.rotation = originalRotation;

		reset = false;
	}
}
*/


// Crap for later

/*
	public void NormalMaterial ()
	{

	}

	public void HoverMaterial ()
	{

	}

	public void SelectedMaterial ()
	{

	}
	*/