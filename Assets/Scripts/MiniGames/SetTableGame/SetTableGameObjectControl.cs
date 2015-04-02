using UnityEngine;
using System.Collections;

/*Author: Justin Schmidt
 * Where:
 * 		This script goes on the "PlacementPoints" object.
 * Description:
 * 		This script is called by the "SetTableGame" script 
 * 		when the player clicks the "clear table" button. 
 * 		It changes the variable "reset" to true then invokes 
 * 		a function that changes "reset" back to false;
 * */

public class SetTableGameObjectControl : MonoBehaviour
{

	public static bool reset;

	void Start ()
	{
		reset = false;
	}

	void Update ()
	{

		if (reset == true)
		{
			Invoke ("ResetTheReset", 1);
		}
	}

	public static void Reset ()
	{
		reset = true;
	}

	void ResetTheReset ()
	{
		reset = false;
	}
}
