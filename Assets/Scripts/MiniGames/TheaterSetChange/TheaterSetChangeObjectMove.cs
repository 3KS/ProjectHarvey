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

// These objects are the object being moved, the objects start position and the objects end position (Could be changed to Vector3's later if need be).
	public GameObject thisObject;
	public GameObject thisObjectStart;
	public GameObject thisObjectEnd;

// These are used for getting the position of the start and end positions of an object (The piano in this case).
	private Vector3 thisObjectInitialPosition;
	private Vector3 thisObjectEndingPosition;
	private Quaternion thisObjectInitialRotation;
	private Quaternion thisObjectEndingRotation;


	void Start ()
	{
// Start and end positions are set here.
		thisObjectInitialPosition = thisObjectStart.transform.position;
		thisObjectEndingPosition = thisObjectEnd.transform.position;
		thisObjectInitialRotation = thisObjectStart.transform.rotation;
		thisObjectEndingRotation = thisObjectEnd.transform.rotation;

		//thisObject.transform.position = thisObjectInitialPosition;
		//thisObject.transform.rotation = thisObjectInitialRotation;
	}

	void Update ()
	{
// Calls the position change for an object. SHOULD PROBABLY BE CHANGED LATER TO ONLY BE ACTIVE WHILE THE GAME IS PLAYING.
		PianoPositionChange ();
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
// Grabs the slider value and stores it. Also accesed by the slider in editor.
		sliderValue = slider.value;
	}
}