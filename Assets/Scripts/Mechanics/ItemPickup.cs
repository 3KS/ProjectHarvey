using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
	public GameObject player;								//Used to freeze the player
	public GameObject playerCam;							//Used to freeze the player's view
	private bool playerFreeze;								//Used to freeze the player

	public static Transform selectedObject;					//Used to access the object the player clicks on
	public static Vector3 selectedObjectOriginalPosition;	//Used to set an object down
	public static Quaternion selectedObjectOriginalRotation;//Used to set an object down
	public float objectMoveSpeed;							//Used to determine the speed that the selected object moves into view

	public Transform selectedObjectStandIn;					//Used to avoid a null reference exception when the player puts an object down

	private bool moveToContainer;							//Used to start moving the object into view
	private bool keepMoving;								//Used to keep the object moving into view
	private bool rotate;									//Used to make the selected object rotate

	private bool moveToOriginalPosition;					//Used to start moving the object back to its original position
	private bool movingBack;								//Used to keep the object moving back to its original position

	public GameObject examineContainer;						//Used to position the selected object
	public GameObject examineObjectContainer;				//Used to position the player's view
	private Quaternion examineObjectContainerRotation;

	public Texture2D crosshair;								//Used to display the crosshair
	private int crosshairPositionX = Screen.width / 2;		//Used to center the crosshair
	private int crosshairPositionY = Screen.height / 2;		//Used to center the crosshair

	void Start()
	{
		selectedObject = selectedObjectStandIn;
	}

	void OnGUI ()
	{

//DISPLAYS THE CROSSHAIR

		GUI.DrawTexture (new Rect (crosshairPositionX, crosshairPositionY, crosshair.width / 4, crosshair.height / 4), crosshair);
	}

	void Update () 
	{
//CALLS
		ObjectInteraction ();


//MAKES SURE THERE ISN'T A NULL REFERENCE ERROR
		if (selectedObject == null)
		{
			selectedObject = selectedObjectStandIn;
		}

//CONTROLS THE SMOOTH MOVEMENT OF THE SELECTED OBJECT FROM originalPosition TO examineObject POSITION
		if (moveToContainer == true)
		{
			keepMoving = true;
		}

		if (keepMoving == true)
		{
			moveToContainer = false;

			selectedObject.transform.position = Vector3.MoveTowards (selectedObject.transform.position, examineContainer.transform.position, objectMoveSpeed * Time.deltaTime);
			Camera.main.transform.LookAt(selectedObject.transform.position);
		
			Invoke("PutDown", 0.01f);
		}

		if (selectedObject.transform.position == examineContainer.transform.position)
		{
			keepMoving = false;
			examineObjectContainerRotation = Quaternion.LookRotation(examineObjectContainer.transform.position - examineContainer.transform.position);

			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, examineObjectContainerRotation, objectMoveSpeed * Time.deltaTime);
			//Camera.main.transform.LookAt(examineObjectContainer.transform.position);
		}

//CONTROLS THE SMOOTH MOVEMENT OF THE SELECTED OBJECT FROM examineObject POSITION TO originalPosition



//CONTROLS OBJECT ROTATION
		
		if (rotate == true)
		{
			selectedObject.transform.Rotate (Vector3.up/4);
		}
		if (rotate == false)
		{
			selectedObject.transform.rotation = selectedObjectOriginalRotation;
		}
		//Debug.Log (selectedObject);
	}

	public void ObjectInteraction ()
	{
//PICKS UP THE OBJECT IN THE CROSSHAIRS
//GETS THE OBJECTS ORIGINAL POSITION AND ROTATION
//STARTS ROTATION
//RESTRICTS PLAYER CONTROL

		Ray checkObjectInSight = Camera.main.ScreenPointToRay (new Vector3(Screen.width / 2, Screen.height / 2));
		RaycastHit objectInSight;

		if (Physics.Raycast (checkObjectInSight, out objectInSight, 1.1f))
		{
			selectedObject = objectInSight.transform;


			if (selectedObject.tag == "InspectableObject" && Input.GetMouseButtonDown(0))
			{
				OriginalObjectAttributes.getPosition = true;
				OriginalObjectAttributes.getRotation = true;

				moveToContainer = true;
				rotate = true;

				player.GetComponent <CharacterMotor> ().enabled = false;
				player.GetComponent <MouseLook> ().enabled = false;
				playerCam.GetComponent <MouseLook> ().enabled = false;
			}
			else if (selectedObject.tag != "InspectableObject")
			{
				selectedObject = selectedObjectStandIn;
			}

			if (selectedObject.name == "Sphere" && selectedObject.transform.position == examineContainer.transform.position)
			{
				GameObject.Find("Sphere_Description").guiTexture.enabled = true;
				//Camera.main.transform.LookAt (examineObjectContainer.transform.position);
			}

			else if (selectedObject.name == "Capsule" && selectedObject.transform.position == examineContainer.transform.position)
			{
				GameObject.Find("Capsule_Description").guiTexture.enabled = true;
			}

			else
			{
				GameObject.Find("Sphere_Description").guiTexture.enabled = false;
			}
		}
	}

	void PutDown()
	{
//STOPS THE ROTATION
//PUTS DOWN CURRENT OBJECT
//RESTORES PLAYER CONTROL
//SETS THE "selectedObject" TO A STAND IN TO AVOID NULL ERROR

		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log ("Putting object down");
			moveToContainer = false;
			rotate = false;
			//keepMoving = false;
			
			selectedObject.transform.position = selectedObjectOriginalPosition;
			////////moveToOriginalPosition = true;

			//Debug.Log(selectedObject);
			//Debug.Log(OriginalObjectAttributes.originalPosition);
			//Debug.Log(selectedObjectOriginalPosition);
			Debug.Log (selectedObject.name + selectedObjectOriginalPosition);
			
			player.GetComponent<CharacterMotor> ().enabled = true;
			player.GetComponent<MouseLook> ().enabled = true;
			playerCam.GetComponent<MouseLook> ().enabled = true;

			selectedObject = selectedObjectStandIn;
		}
	}
}