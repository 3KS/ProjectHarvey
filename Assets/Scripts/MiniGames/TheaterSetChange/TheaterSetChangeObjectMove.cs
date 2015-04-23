using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TheaterSetChangeObjectMove : MonoBehaviour
{
// This Slider variable is necessary for getting the value of the slider.
	public Slider slider;

// These two variables are used for getting and interpretting the slider value.
	public float smooth;
	public float sliderValue;

	public float currentSliderValue;

// These objects are the object being moved, the objects start position and the objects end position (Could be changed to Vector3's later if need be).
	public GameObject thisObject;
	public GameObject thisObjectStart;
	public GameObject thisObjectEnd;

// These are used for getting the position of the start and end positions of an object (The piano in this case).
	private Vector3 thisObjectInitialPosition;
	private Vector3 thisObjectEndingPosition;
	private Quaternion thisObjectInitialRotation;
	private Quaternion thisObjectEndingRotation;

	private Vector3 thisObjectCurrentPosition;
	private Quaternion thisObjectCurrentRotation;

	public bool collision;


	void Start ()
	{
		slider.value = 0.1f;

// Start and end positions are set here.
		thisObjectInitialPosition = thisObjectStart.transform.position;
		thisObjectEndingPosition = thisObjectEnd.transform.position;
		thisObjectInitialRotation = thisObjectStart.transform.rotation;
		thisObjectEndingRotation = thisObjectEnd.transform.rotation;

		//thisObject.transform.position = thisObjectInitialPosition;
		//thisObject.transform.rotation = thisObjectInitialRotation;

		collision = false;
	}

	void Update ()
	{
		Debug.Log (collision);
		if (collision == false)
		{
			PianoPositionChange ();
		}


		if (collision == true)
		{

			if (sliderValue < currentSliderValue)
			{
				collision = false;
			}
			else if (sliderValue != 0)
			{
				slider.value = currentSliderValue;
			}
		}
	}

	public void PianoPositionChange ()
	{
// Sets the movement of the object to equal the movement of the slider.
		smooth = (sliderValue) / (2.0f);

// Creates an even sliding motion between the start and end position of a specified object.
		thisObject.transform.position = Vector3.Lerp (thisObjectInitialPosition, thisObjectEndingPosition, smooth);
		thisObject.transform.rotation = Quaternion.Lerp (thisObjectInitialRotation, thisObjectEndingRotation, smooth);
	}

	public void GetSliderValueChanged ()
	{
// Grabs the slider value and stores it. Also accessed by the slider in editor.
		sliderValue = slider.value;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "TheaterSetPeice")
		{
			collision = true;
			currentSliderValue = sliderValue;
		}
	}

	void OnCollisionStay (Collision other)
	{
		if (other.gameObject.tag == "TheaterSetPeice")
		{
			thisObjectCurrentPosition = thisObject.transform.position;

			thisObject.transform.position = Vector3.Lerp (thisObjectCurrentPosition, thisObjectInitialPosition, 0);

		}
	}

	void OnCollisionExit (Collision other)
	{
		if (other.gameObject.tag == "TheaterSetPeice")
		{
			collision = false;
		}
	}
}