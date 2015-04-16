using UnityEngine;
using System.Collections;

public class TextTree : MonoBehaviour
{
	public static bool textTreeActive;
	private bool characterHasGreetedPlayer;
	public bool showInteractPrompt;

	private bool greeting;
	private bool option1;
	private bool option2;
	private bool option3;
	private bool option4;

	public float textHeight;

	public float menuHeight;
	public float menuSpace;

	//options
	public GameObject talk;
	public GameObject walkAway;
	public GameObject weather;
	public GameObject dinosaurs;
	public GameObject agree;
	public GameObject disagree;
	//responses
	public GameObject hello;
	public GameObject goodbye;
	public GameObject itsLovely;
	public GameObject allosaurus;
	public GameObject yup;
	public GameObject thatsALie;
	public GameObject ohReally;

	public Ray ray;
	public RaycastHit hit;


	void Start ()
	{
		textTreeActive = false;
	}

	void Update ()
	{
		Debug.Log ("TextTreeActive = " + textTreeActive);

		if (textTreeActive == true)
		{
			Greeting ();
		}

		if (option1 == true)
		{
			Option1 ();
		}
		else if (option2 == true)
		{
			Option2 ();
		}
		else if (option3 == true)
		{
			Option3 ();
		}
		else if (option4 == true)
		{
			Option4 ();
		}
	}

	void OnGUI ()
	{
		if (showInteractPrompt == true)
		{
			GUI.Label(new Rect( Screen.width / 2, Screen.height / 2, 200, 50), "Press E to speak with Harvey");
		}
	}

	void Greeting ()
	{
		Debug.Log ("GettingToGreeting");

		showInteractPrompt = true;
		hello.active = true;

		if (Input.GetButtonUp ("Select"))
		{
			showInteractPrompt = false;
			MovementFreeze.FreezePlayer();
			textTreeActive = false;
			option1 = true;
		}
	}

	void Option1 ()
	{
		Debug.Log ("gettingToOption1");

		walkAway.active = true;
		talk.active = true;

		if (Input.GetMouseButtonDown (0))
		{
			Debug.Log("Player did click");

			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Debug.DrawLine(ray.origin, hit.point);



			if (Physics.Raycast(ray, 100))
			{

				if (hit.collider.gameObject.name == walkAway.name)
				{
					goodbye.active = true;
					option1 = false;
					Invoke ("HideAll", 3.0f);
				}

				else if (hit.collider.gameObject.name == talk.name)
				{
					Debug.Log("Got This");
					talk.active = false;
					option1 = false;
					option2 = true;
				}
			}
		}
	}

	void Option2 ()
	{
		Debug.Log ("GettingToOption2");

		walkAway.active = true;
		weather.active = true;
		dinosaurs.active = true;
	}

	void Option3 ()
	{
		agree.active = true;
		disagree.active = true;
	}

	void Option4 ()
	{
		agree.active = true;
		disagree.active = true;
	}

	void HideAll ()
	{
		MovementFreeze.UnFreezePlayer ();

		talk.active = false;
		walkAway.active = false;
		weather.active = false;
		dinosaurs.active = false;
		agree.active = false;
		disagree.active = false;

		hello.active = false;
		goodbye.active = false;
		itsLovely.active = false;
		allosaurus.active = false;
		yup.active = false;
		thatsALie.active = false;
		ohReally.active = false;
	}

}
