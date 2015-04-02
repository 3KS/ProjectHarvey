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

	public bool show;

	public Material normal;
	public Material hoverCorrect;
	public Material hoverWrong;

	void Awake ()
	{
		dropPlacementHere.renderer.enabled = false;
	}

	void Update ()
	{
		if (SetTableGameObjectControl.reset == true)
		{
			ResetPlacement ();
		}

		if (SetTableGame.showPlacements == true)
		{
			dropPlacementHere.renderer.enabled = true;
		}
		else
		{
			dropPlacementHere.renderer.enabled = false;
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
		dropPlacementHere.tag = "TableSetPlacement";
	}

	void OnMouseEnter ()
	{
		if (SetTableGame.staticSelectedObject.name == "Plate" && dropPlacementHere.name == "PlatePlacement")
		{
			dropPlacementHere.renderer.material = hoverCorrect;
			Debug.Log(SetTableGame.staticSelectedObject.name);
		}

		if (SetTableGame.staticSelectedObject.name == "Plate" && dropPlacementHere.name == "CupPlacement")
		{
			dropPlacementHere.renderer.material = hoverWrong;
			
			Debug.Log(SetTableGame.staticSelectedObject.name);
		}

		if (SetTableGame.staticSelectedObject.name == "Cup" && dropPlacementHere.name == "PlatePlacement")
		{
			dropPlacementHere.renderer.material = hoverCorrect;
			
			Debug.Log(SetTableGame.staticSelectedObject.name);
		}

		if (SetTableGame.staticSelectedObject.name == "Cup" && dropPlacementHere.name == "CupPlacement")
		{
			dropPlacementHere.renderer.material = hoverWrong;
			
			Debug.Log(SetTableGame.staticSelectedObject.name);
		}
	}

	void OnMouseExit ()
	{
		dropPlacementHere.renderer.material = normal;
	}

	void HoverColor ()
	{

	}
}
