using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public ScriptedStep[] tutorialSteps;

	private Quaternion currentRotationPlayer; //Current angle of rotation
	private Quaternion currentRotationCamera; //Current angle of rotation
	private float newRotationCamera;
	private float newRotationPlayer;
	private float rotationLeftPlayer;


	private float degreesLeftPlayer;
	private float degreesLeftCamera;
	private float timeRotated = 0;

	public Transform playerCamera;
	public Transform player;
	public Image fillImage;
	public int currentStep = 0;
	private float waitedTime = 0;
	private bool isRotating = false;
	private bool isRotatingPlayer = false;
	private bool isMovingPlayer = false;
	private bool isFading = false;
	private float timeFaded = 0;

	private bool isDone = false;
	// Use this for initialization
	void Start () {
		//newRotationCamera = new Quaternion ();
	}
	
	// Update is called once per frame
	void Update () {
		if (tutorialSteps.Length > 0 && currentStep < tutorialSteps.Length) {
			UpdateCurrent();
		} else {
			isDone = true;
		}
	}

	private void UpdateCurrent() {
		if (!tutorialSteps [currentStep].GetStarted () && !tutorialSteps[currentStep].GetCompleted()) {
			StartCurrent();
		}

		if (!tutorialSteps [currentStep].GetCompleted ()) {

			if(tutorialSteps[currentStep].waitForTime && ! tutorialSteps[currentStep].waitTillDone) {
				waitedTime+=Time.deltaTime;
				if(waitedTime >= tutorialSteps[currentStep].waitTime) {
					tutorialSteps[currentStep].SetCompleted();
				}
			} else if(tutorialSteps[currentStep].waitTillDone) {
				bool completed  = true;
				if(tutorialSteps[currentStep].playVideo) {
					completed = tutorialSteps[currentStep].video.isPlaying ? false : completed;
				}
				if(tutorialSteps[currentStep].playAudio) {
					completed = tutorialSteps[currentStep].audio.isPlaying ? false : completed;
				}
				if(tutorialSteps[currentStep].moveCameraRotation) {
					if(isRotating || isRotatingPlayer) {
						completed = false;
					}
				}
				if(tutorialSteps[currentStep].fadeFromColor) {
					completed = timeFaded > 0 ? false :completed;
				}
				if(tutorialSteps[currentStep].moveCameraPosition) {
					completed = isMovingPlayer ? false : completed;
				}
				if(completed) {
					tutorialSteps[currentStep].SetCompleted();
				}
			} else {
				tutorialSteps[currentStep].SetCompleted();
			}

			if(tutorialSteps[currentStep].fadeFromColor) {
				fillImage.color = new Color(fillImage.color.r, fillImage.color.g, fillImage.color.b, timeFaded/tutorialSteps[currentStep].fadeLength);
				timeFaded -= Time.deltaTime;
			}

			if(tutorialSteps[currentStep].moveCameraRotation && (isRotating || isRotatingPlayer)) {
				RotateCamera();
			} else if(tutorialSteps[currentStep].lookAt) {
				playerCamera.LookAt(tutorialSteps[currentStep].objectLookingAt.position);
			}
		} else {
			ExecuteNext();
		}
	}

	void OnGUI () {
		try {
		if (!isDone && tutorialSteps [currentStep].playVideo) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tutorialSteps [currentStep].video, ScaleMode.StretchToFill, false, 0.0f);
		}
		} catch {

		}
	}

	private void RotateCamera() {
		if(isRotating) {
			float rotationLeft =	newRotationCamera - currentRotationCamera.eulerAngles.x;
			float timeLeft = tutorialSteps[currentStep].cameraMoveTime - timeRotated;
			float stepRotation = (rotationLeft/timeLeft)*Time.deltaTime;
			
			if ((currentRotationCamera.eulerAngles.x < newRotationCamera + .01) && (currentRotationCamera.eulerAngles.x > newRotationCamera - .01)) {
				playerCamera.localRotation = Quaternion.Euler(newRotationCamera, playerCamera.localRotation.y, playerCamera.localRotation.z);
				isRotating = false;
			} else {
				playerCamera.Rotate(stepRotation, 0, 0);    
				currentRotationCamera = playerCamera.localRotation;
			}
		}
		if(isRotatingPlayer) {
			//float rotationLeft =	newRotationPlayer - currentRotationPlayer.eulerAngles.y;
			float timeLeft = tutorialSteps[currentStep].cameraMoveTime - timeRotated;
			float stepRotation = (rotationLeftPlayer/timeLeft)*Time.deltaTime;
			Debug.Log("Rotation Left: " + rotationLeftPlayer + " Time Left: " + timeLeft + " Step Rotation: " + stepRotation);
			if (((currentRotationPlayer.eulerAngles.y < newRotationPlayer + .1) && (currentRotationPlayer.eulerAngles.y > newRotationPlayer - .1)) || timeLeft <= 0) {
				player.localRotation = Quaternion.Euler(player.localRotation.x, newRotationPlayer, player.localRotation.z);
				isRotatingPlayer = false;
			} else {
				player.Rotate(0,stepRotation,0);    
				currentRotationPlayer = player.localRotation;
			}
			rotationLeftPlayer -= stepRotation;
		}
		timeRotated += Time.deltaTime;
	}
	private void StartCurrent() {
		if(tutorialSteps[currentStep].playVideo) { //Play the video
			tutorialSteps[currentStep].video.loop = false;
			tutorialSteps[currentStep].video.Play();
		}

		if(tutorialSteps[currentStep].playAudio) { //Play the audio
			tutorialSteps[currentStep].audio.Play();
		}

		if (tutorialSteps [currentStep].displayNotification) {
			GameController.DisplayTimedNotification("tutorialMovement", tutorialSteps[currentStep].notificationText, tutorialSteps[currentStep].notificationTime);
		}

		if(tutorialSteps[currentStep].enableFPC) {//freeze or unfreeze the player
			MovementFreeze.UnFreezePlayer();
		} else {
			MovementFreeze.FreezePlayer();
		}

		if(tutorialSteps[currentStep].fadeFromColor) {
			fillImage.color = tutorialSteps[currentStep].fadeColor;
			isFading = true;
			timeFaded = tutorialSteps[currentStep].fadeLength;
		}

		if(tutorialSteps[currentStep].moveCameraRotation) {//Starts camera rotation
			isRotating = true;
			isRotatingPlayer = true;
			currentRotationCamera = playerCamera.localRotation;
			currentRotationPlayer = player.localRotation;
			newRotationPlayer = currentRotationPlayer.eulerAngles.y + tutorialSteps[currentStep].cameraRotationAmount.y;
			newRotationCamera = currentRotationCamera.eulerAngles.x + tutorialSteps[currentStep].cameraRotationAmount.x;
			rotationLeftPlayer = newRotationPlayer - currentRotationPlayer.eulerAngles.y;
			timeRotated = 0;
		}

		if (tutorialSteps [currentStep].playAnimation) {
			tutorialSteps[currentStep].animation.SetBool("animate", true);
		}

		tutorialSteps[currentStep].SetStarted(); //Sets step as started
	}
	private void ExecuteNext() {
		waitedTime = 0;
		currentStep += 1;
	}
}
