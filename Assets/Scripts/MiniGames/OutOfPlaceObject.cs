/*
 * The goal of this game is to find the books that are not from this time period
 * To encounter the game the player will walk up to a book and have the option to collect it
 * There are five books that are out of place for the player to find
 * When the player has found five books they will receieve and achievement
 * MIGHT also want to make the object inspectable/rotatable
 */

using UnityEngine;
using System.Collections;

public class OutOfPlaceObject : MonoBehaviour 
{
	//Variable initialization;
	public int books = 0;
	//private GameObject visibleObject;
	public GameObject book;
	private bool isViewing;
	private Transform lastTransform;
	private bool playerIsViewing;
	private bool canInteract = false;
	private bool bookIsCollected = false;
	private string objectTitle;
	private string objectDescription;
	public Transform objectTransform;
	public Texture2D crosshair; //Displaying the crosshair

	// Use this for initialization
	void Start () 
	{
		book = GameObject.FindGameObjectWithTag ("OutOfPlaceObject");
	}
	
	// Update is called once per frame
	void Update()
	{
		Transform cam = Camera.main.transform;
		Ray cast = new Ray(cam.position, cam.forward);
		//Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2, 1));
		RaycastHit hit = new RaycastHit();
		if (isViewing && (Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E)))
		{
			isViewing = false;
		} 
		else if (Physics.Raycast (cast, out hit, 4.0f)) 
		{
			if (hit.transform.tag.Equals ("OutOfPlaceObject")) 
			{

				//Debug.Log ("hitting");
				if (lastTransform == null) 
				{
					lastTransform = hit.transform;
				}
				
				if (!isViewing) 
				{
					canInteract = true;
				}
				//If the key is down and you're no longer viewing the object
				if ((Input.GetMouseButtonUp(0) || Input.GetKeyDown(KeyCode.E)) && !isViewing)
				{
					//ViewObject(hit);
					// ALSO NEED TO ADD ONE TO BOOKS HERE.
					//destroy it and add 1 to books.
					//isViewing = true;
					books++;
					bookIsCollected = true;
					Debug.Log (books);
					if (books ==5)
					{
						Debug.Log("you've collected 5 books");
						//trigger an achievement
						//get rid of the pop up
						bookIsCollected = false;
						AchievementController.UnlockAchievement(AchievementController.Achievements.ObjectCollection);
					}
					Destroy (hit.transform.gameObject);

				}
			} 
			else 
			{
				canInteract = false;
			}

			if (lastTransform != null && !lastTransform.Equals (hit.transform)) 
			{
				//lastTransform.gameObject.renderer.material.SetColor("_RimColor", Color.black);
				lastTransform = null;
			}
		}
		else if (lastTransform != null) 
		{
			//lastTransform.gameObject.renderer.material.SetColor("_RimColor", Color.black);
			lastTransform = null;
			canInteract = false;
		} 
		else 
		{
			canInteract = false;
		}
	}
	
	void OnGUI() 
	{
		GUI.DrawTexture (new Rect (Screen.width/2, Screen.height/2, crosshair.width / 4, crosshair.height / 4), crosshair);

		if (bookIsCollected) 
		{
			Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Press 'E' to collect object"));
			MenuTools.DrawSmallMenu(Screen.width - 310, Screen.height-560, (int)size.x - 45, (int)size.y + 20);
			GUI.Label(new Rect(Screen.width- 280, Screen.height/2 - (int)size.y/2 + -235 + 0, 0, 0), "Books Collected: " + books, MenuTools.dioramaLabel);
		}
		if (canInteract)
		{
			Vector2 size = MenuTools.dioramaLabel.CalcSize(new GUIContent("Press 'E' to collect object"));
			MenuTools.DrawSmallMenu(Screen.width/2 - (int)size.x/2 + 10, Screen.height/2 - (int)size.y/2 + 10, (int)size.x + 20, (int)size.y + 20);
			GUI.Label(new Rect(Screen.width/2 - (int)size.x/2 + 10 + 10, Screen.height/2 - (int)size.y/2 + 10 + 10, 150, 50), "Press 'E' to collect object", MenuTools.dioramaLabel);
		}
	}
}
	