using UnityEngine;
using System.Collections;

/**********************************
 * Class: DioramaRotation.cs
 * Author: Benjamin Pease
 * Description: Rotates the camera object 
 * on the Y-axis around it's origin point 
 * on a GUI button click
 **********************************/

public class DioramaRotation : MonoBehaviour
{
    public float rotationSpeed; //Speed to rotate around the camera
    private bool isRotating = false; //Is the camera rotating
    private Quaternion currentRotation; //Current angle of rotation
    private Quaternion newRotation; //Intended angle of rotation
    private float rawLerp;
    private float lerp;
    private static Side currentView;

	public Texture2D rotLeftTexture;
	public Texture2D rotLeftLightTexture;
	public Texture2D rotRightTexture;
	public Texture2D rotRightLightTexture;
	private GUIStyle leftStyle;
	private GUIStyle rightStyle;

    public enum Side {
        Front,
        Left,
        Right
    };

    
    void Start()
    {
		leftStyle = new GUIStyle();
		GUIStyleState leftStyleSS = new GUIStyleState();
		GUIStyleState leftLightStyleSS = new GUIStyleState();
		leftStyleSS.background = rotLeftTexture;
		leftLightStyleSS.background = rotLeftLightTexture;
		leftStyle.normal = leftStyleSS;
		leftStyle.hover = leftLightStyleSS;

		rightStyle = new GUIStyle();
		GUIStyleState rightStyleSS = new GUIStyleState();
		GUIStyleState rightLightStyleSS = new GUIStyleState ();
		rightStyleSS.background = rotRightTexture;
		rightLightStyleSS.background = rotRightLightTexture;
		rightStyle.normal = rightStyleSS;
		rightStyle.hover = rightLightStyleSS;

        if (PlayerPrefs.HasKey("temp_dioramRot"))
        {
            switch(PlayerPrefs.GetString("temp_dioramRot")) {
                case "Front" :
                    currentRotation = transform.rotation;
                    currentView = Side.Front;
                 break;
                case "Right" :
                    transform.Rotate(0, -90, 0);
                    currentRotation = transform.rotation;
                    currentView = Side.Right;
                    break;
                case "Left" :
                    transform.Rotate(0, 90, 0);
                    currentRotation = transform.rotation;
                    currentView = Side.Left;
                    break;
            }
        } 
        else
        {
            currentRotation = transform.rotation;
            currentView = Side.Front;
            SaveController.CacheDiorama();
            //PlayerPrefs.SetString("currentView", currentView.ToString());
        }
        Debug.Log( currentView.ToString());

    }
    
    void Update()
    {
        //If isRotating == true, rotateCamera is called
        if (isRotating)
        {
            rotateCamera();
        } else
        {
            rawLerp = 0;
        }
    }
    public static Side GetDioramRot() {
        return currentView;
    }
    //Rotates the camera to the intended angle of rotation if it is outside of the ending angle range
    void rotateCamera()
    {
        //Checks how close the current rotation is to the ending rotation and sets it to the end if it is close enough
        if ((currentRotation.eulerAngles.y < newRotation.eulerAngles.y + 1) && (currentRotation.eulerAngles.y > newRotation.eulerAngles.y - 1))
        {
            transform.rotation = newRotation;
            isRotating = false;
        }
        //If it is not close enough, it continues slerping between the current rotation and the new rotation at the speed of deltaTime*rotationSpeed
        //Also sets currentRotation to the updated rotation of the camera
        else
        {
            rawLerp += Time.deltaTime * rotationSpeed;
            lerp = Mathf.Min(rawLerp, 1);
            transform.rotation = Quaternion.Slerp(currentRotation, newRotation, lerp * Time.timeScale);    
            currentRotation = transform.rotation;
        }
    }

    void OnGUI()
    {
		//This Line must be in all OnGUI methods to allow for correct pausing of the game
		GUI.enabled = GameController.GetPauseState () ? false : true;

        //Checks for the click of the rotate to the left button and if the camera is currently rotating
        //If it succeeds, currentRotation is updated, the transform is rotated to destination, newRotation is set to the new transform rotation, and is rotating is set as true
        if (GUI.Button(new Rect(Screen.width/2 - 155, TimeSlider.calcVerticalPosition - 110, 150, 100), "", leftStyle) && !isRotating)
        {
            Debug.Log("Clicked rotate left");
            currentRotation = transform.rotation;
            isRotating = true;
            switch(currentView) {
                case Side.Front:
                    currentView = Side.Left;
                    transform.Rotate(0, 90, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                break;
                case Side.Left:
                    currentView = Side.Right;
                    transform.Rotate(0, -180, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                    break;
                case Side.Right:
                    currentView = Side.Front;
                    transform.Rotate(0, 90, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                    break;
            }
            SaveController.CacheDiorama();
        }
        //Checks for the click of the rotate to the right button and if the camera is currently rotating
        //If it succeeds, currentRotation is updated, the transform is rotated to destination, newRotation is set to the new transform rotation, and is rotating is set as true
        if (GUI.Button(new Rect(Screen.width/2+5, TimeSlider.calcVerticalPosition - 110, 150, 100), "", rightStyle) && !isRotating)
        {
            Debug.Log("Clicked rotate right");
            currentRotation = transform.rotation;
            isRotating = true;
            switch(currentView) {
                case Side.Front:
                    currentView = Side.Right;
                    transform.Rotate(0, -90, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                    break;
                case Side.Right:
                    currentView = Side.Left;
                    transform.Rotate(0, 180, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                    break;
                case Side.Left:
                    currentView = Side.Front;
                    transform.Rotate(0, -90, 0);
                    newRotation = transform.rotation;
                    //PlayerPrefs.SetString("currentView", currentView.ToString());
                    break;
            }
            SaveController.CacheDiorama();
        }
    }
}