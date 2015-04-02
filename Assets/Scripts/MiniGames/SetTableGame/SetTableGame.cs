using UnityEngine;
using System.Collections;

/*Author: Justin Schmidt
 * Where:
 * 		This script goes on the First Person Controller.
 * Description:
 * 		This script.......does stuff......and thaaaaangs. Coming soon
 * */

public class SetTableGame : MonoBehaviour
{
	public bool canMoveObjects;
	public bool objectIsSelected;
	public bool canClearTable;
	public static bool gameIsOver;
	public static bool showPlacements;

	public float menuSpace;
	public float menuHeight;
	private int tablePiecesSet;
	public int numberOfObjectsToPlace;

	public GameObject selectedObject;
	public static GameObject staticSelectedObject;
	public GameObject selectedPlacement;
	public static GameObject staticSelectedPlacement;
	public GameObject gameOver;
	public GameObject firstPersonItemContainer;

	public GameObject playerCamera;
	public GameObject gameCamera;

	public Material emptyPlacementGlow;
	public Material wrongPlacementGlow;
	public Material correctPlacementGlow;

// This Ray information is for hovering
	private Ray ray;
	private RaycastHit hit;

//This ray is for selecting the placement
	private Ray placementRay;
	private RaycastHit placementHit;


	void Start ()
	{
		canMoveObjects = false;
		objectIsSelected = false;
		canClearTable = false;
		gameCamera.camera.active = false;
		gameOver.renderer.enabled = false;
	}


	void OnGUI ()
	{
		if (canMoveObjects == true)
		{
			if (GUI.Button (new Rect(Screen.width / 2 - 90 + menuSpace, Screen.height / 2 - menuHeight, 200, 50), "Stop Setting the Table"))
			{
				MovementFreeze.UnFreezePlayer ();
				GameOver ();
				canMoveObjects = false;
			}

			if (canClearTable == true)
			{
			//	Debug.Log("The table can be cleared");
				if (GUI.Button (new Rect(Screen.width / 2 + 150, Screen.height / 2 - menuHeight, 200, 50), "Clear the table"))
				{
					SetTableGameObjectControl.reset = true;
					tablePiecesSet = 0;
					canClearTable = false;
				}
			}
		}
	}


	void Update ()
	{
		if (canMoveObjects == true)
		{
// This section is for selecting an object to place on the table
			if (Input.GetMouseButtonDown(0) && objectIsSelected == false)
			{
				SelectObject ();
			}
// This section is for selecting a placement and transporting thge selected object to that location
			if (Input.GetMouseButtonDown(0) && objectIsSelected == true)
			{
				Invoke ("SelectPlacement", .01f);
			}
		}

		if (tablePiecesSet == numberOfObjectsToPlace)
		{
			gameOver.renderer.enabled = true;
			Invoke ("GameOver", 1);
		}

		if (SetTableTrigger.gameIsPlaying == true)
		{
			ChangeToGameCam ();
			showPlacements = true;
		}

		if (SetTableTrigger.gameIsPlaying == false)
		{
			showPlacements = false;
		}

		staticSelectedObject = selectedObject;
		staticSelectedPlacement = selectedPlacement;
	}


	void SelectObject ()
	{
		
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (ray.origin, hit.point);
		
		if (Physics.Raycast (ray, out hit, 20))
		{
			selectedObject = hit.collider.gameObject;
		}


		if (selectedObject.tag == "TableSetObject")
		{
			objectIsSelected = true;
		}
	}


	void SelectPlacement ()
	{
		canClearTable = true;

		placementRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (placementRay.origin, placementHit.point);
		
		if (Physics.Raycast (placementRay, out placementHit, 20))
		{
			selectedPlacement = placementHit.collider.gameObject;
		}

		if (selectedPlacement.tag == "TableSetPlacement")
		{
			selectedObject.transform.position = selectedPlacement.transform.position;
			selectedObject.transform.rotation = selectedPlacement.transform.rotation;
			selectedPlacement.renderer.enabled = false;
			selectedObject.tag = "TableSetLock";
			selectedPlacement.tag = "TableSetLock";

			tablePiecesSet ++;

			objectIsSelected = false;
		}
	}

	void GameOver ()
	{
		tablePiecesSet ++;
		SetTableTrigger.gameIsPlaying = false;
		gameOver.renderer.enabled = false;
		firstPersonItemContainer.active = true;
		gameCamera.camera.active = false;
		playerCamera.camera.active = true;
		MovementFreeze.UnFreezePlayer ();
		canMoveObjects = false;
	}

	void ChangeToGameCam ()
	{
		firstPersonItemContainer.active = false;
		gameCamera.camera.active = true;
		playerCamera.camera.active = false;
	}
}
