using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{	
	public static bool scriptActive;
	
	public static Transform selectedObject;											//Used to access the object the player clicks on
	public static Vector3 selectedObjectOriginalPosition;							//Used to set an object down
	public static Quaternion selectedObjectOriginalRotation;						//Used to set an object down
	public float objectMoveSpeed;													//Used to determine the speed that the selected object moves into view
	
	public Transform selectedObjectStandIn;											//Used to avoid a null reference exception when the player puts an object down
	
	private bool canPickStuffUp;													//Used to determine when the player can or can't pick up and examine an object
	
	public static bool moveToContainer;													//Used to start moving the object into view
	public static bool keepMoving;														//Used to keep the object moving into view
	private bool moveToOriginalPosition;											//Used to start moving the object back to its original position
	private bool movingBack;														//Used to keep the object moving back to its original position
	
	public static bool rotate;															//Used to make the selected object rotate
	
	private bool lookAtSelectedObject;												//Used to make the camera follow an object in the process of being examined
	private bool lookAtCenter;														//Used to make the camera look between an examined object and its description
	
	public static bool tooBig;
	public static bool stopMoving;
	
	public GameObject examineContainer;												//Used to position the selected object
	public GameObject examineObjectContainer;										//Used to position the player's view
	private Quaternion examineObjectContainerRotation;//
	
	public Texture2D crosshair;														//Used to display the crosshair
	private int crosshairPositionX = Screen.width / 2;								//Used to center the crosshair
	private int crosshairPositionY = Screen.height / 2;								//Used to center the crosshair
	
	void OnGUI ()
	{
		GUI.DrawTexture (new Rect (crosshairPositionX, crosshairPositionY, crosshair.width / 4, crosshair.height / 4), crosshair);
	}
	
	void Start ()
	{
		Screen.lockCursor = true;
		selectedObject = selectedObjectStandIn;
		scriptActive = true;
		canPickStuffUp = true;
	}
	
	void Update ()
	{
		//Debug.Log (selectedObject.name);
		//Debug.Log ("scriptActive" + scriptActive);
		//Debug.Log ("canPickStuffUp" + canPickStuffUp);
		//Debug.Log ("moveToContainer" + moveToContainer);
		//Debug.Log ("keepMoving" + keepMoving);
		//Debug.Log ("lookAtSelectedObject" + lookAtSelectedObject);
		//Debug.Log ("rotate" + rotate);
		//Debug.Log ("lookAtCenter" + lookAtCenter);
		//Debug.Log ("moveToOriginalPosition" + moveToOriginalPosition);
		//Debug.Log ("movingBack" + movingBack);
		//Debug.Log ("tooBig " + tooBig);
		//Debug.Log ("stopMoving" + stopMoving);
		
		if (scriptActive == true)
		{
			
			if (selectedObject == null)
			{
				selectedObject = selectedObjectStandIn;
			}
			
			if (canPickStuffUp == true)
			{
				
				PickUp();
			}
			
			if (moveToContainer == true)
			{
				keepMoving = true;
			}
			
			if (keepMoving == true)
			{
				//selectedObject.transform.position = examineContainer.transform.position;
				selectedObject.transform.position = Vector3.MoveTowards (selectedObject.transform.position, examineContainer.transform.position, objectMoveSpeed * Time.deltaTime);
				lookAtSelectedObject = true;
				
				Invoke("PutDown", .01f);												//Used to ensure that the player doesn't pick up and set down an object at the same time
			}
			
			
			if (selectedObject.transform.position == examineContainer.transform.position)
			{
				MovementFreeze.FreezePlayer();
				lookAtSelectedObject = false;
				rotate = true;
				lookAtCenter = true;
				ObjectShimmer.flashPause = true;										//Used to turn off the glow on the selected object (turns off glow for all objects)
			}
			
			
			if (rotate == true)															//Used to make the selected object rotate
			{
				
				selectedObject.transform.Rotate (Vector3.up/4);
			}
			if (rotate == false)														//Used to make the selected object stop rotating
			{
				selectedObject.transform.rotation = selectedObjectOriginalRotation;
			}
			
			
			if (lookAtSelectedObject == true)											//Used to make the camera follow the selected object as it moves
			{
				
				Camera.main.transform.LookAt (selectedObject.transform.position);
			}
			
			if (lookAtCenter == true)													//Used to move the camera to the left of the object, so that the object and description can both be seen
			{
				Camera.main.transform.LookAt (examineObjectContainer.transform.position);
				
				//the following two lines are for smooth camera transition from the object to the center, between the description and the object DOES WIERD CAMERA STUFF
				//examineObjectContainerRotation = Quaternion.LookRotation(examineObjectContainer.transform.position - examineContainer.transform.position);
				//Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, examineObjectContainerRotation, objectMoveSpeed * Time.deltaTime);
			}

			/*
			if (stopMoving == true)
			{
				moveToContainer = false;
				keepMoving = false;
				rotate = false;
				MovementFreeze.playerFrozen = true;
				ObjectShimmer.flashPause = true;
				lookAtSelectedObject = false;
				selectedObject.transform.position = selectedObjectOriginalPosition;
				
				Invoke ("PutDown", .01f);
			}
			*/

			if (moveToOriginalPosition == true)
			{
				movingBack = true;
			}
			
			if (movingBack == true)
			{
				moveToOriginalPosition = false;
				selectedObject.transform.position = Vector3.MoveTowards (examineContainer.transform.position, selectedObjectOriginalPosition, objectMoveSpeed * Time.deltaTime);
			}
			
			if (selectedObject.transform.position == selectedObjectOriginalPosition)
			{
				movingBack = false;
			}

		}
	}
	
	void PickUp ()
	{
		Ray checkObjectInSight = Camera.main.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2));
		RaycastHit objectInSight;

		if (Physics.Raycast (checkObjectInSight, out objectInSight, 1.5f))
		{
			selectedObject = objectInSight.transform;

		//	Debug.Log ("ray shot");

			if (selectedObject.tag == "InspectableObject")
			{
				Debug.Log (selectedObject.tag);
				
				InteractableItemController.getPosition = true;					//Used to store the original position of the selected object so it can be reset
				InteractableItemController.getRotation = true;					//Used to store the original rotation of the selected object so it can be reset
				
				moveToContainer = true;
				
				MovementFreeze.FreezePlayer();
				
				Scrapbook.canReadScrapbook = false;
				
				canPickStuffUp = false;
				
				InteractableItemController.turnOff = false;
			}
			
			if (selectedObject.tag != "InspectableObject" )
			{
				selectedObject = selectedObjectStandIn;
			}
		}
	}
	
	void PutDown ()
	{
		
		if (Input.GetMouseButtonDown (0))
		{
			moveToContainer = false;
			keepMoving = false;
			lookAtSelectedObject = false;
			lookAtCenter = false;
			rotate = false;
			canPickStuffUp = true;
			//stopMoving = false;
			
			//Camera.main.transform.LookAt (examineObjectContainer.transform.position);
			
			InteractableItemController.turnOff = true;
			
			ObjectShimmer.flashPause = false;									//Used to turn on the glow on the selected object (turns off glow for all objects)
			
			selectedObject.transform.position = selectedObjectOriginalPosition;
			
			selectedObject = selectedObjectStandIn;
			
			MovementFreeze.UnFreezePlayer();
			
			Scrapbook.canReadScrapbook = true;
		}
	}
}
