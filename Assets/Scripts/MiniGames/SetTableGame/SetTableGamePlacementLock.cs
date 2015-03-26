using UnityEngine;
using System.Collections;

/*Author: Justin Schmidt
 * Where:
 * 		This script needs to be attatched to all placement gameObjects in the scene.
 * Description: 
 * 		This script checks the reset controller in the SetTableGameObjectControl.
 * 		When the reset variable there is changed, the table placement options will 
 * 		reset their tag so they are accesible again. The materials also reset to
 * 		show where objects should be placed.
 * */

public class SetTableGamePlacementLock : MonoBehaviour
{
	public GameObject dropPlacementHere;

	//public Material normalPlacementMaterial;

	void Update ()
	{
		if (SetTableGameObjectControl.reset == true)
		{
			ResetPlacement ();
		}
	}

	void HidePlacements ()
	{
		dropPlacementHere.renderer.enabled = false;
	}

	void ShowPlacements ()
	{
		dropPlacementHere.renderer.enabled = true;
	}

	void ResetPlacement ()
	{
		dropPlacementHere.renderer.enabled = true;
		//dropPlacementHere.renderer.material = normalPlacementMaterial;
		dropPlacementHere.tag = "TableSetPlacement";
	}
}
