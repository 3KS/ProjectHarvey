using UnityEngine;
using System.Collections;

[System.Serializable]
public class ScriptedStep {

	//public StepType stepType;
	public bool playVideo;
	public bool playAudio;
	public bool playAnimation;
	public bool moveCameraPosition;
	public bool moveCameraRotation;
	public bool enableFPC;
	public bool lookAt;
	public bool fadeFromColor;
	public bool displayNotification;
	public bool waitForTime;
	public bool waitTillDone;


	public MovieTexture video;
	public AudioSource audio;
	public Animator animation;
	public Vector3 newCameraPosition;
	public Vector3 cameraRotationAmount;
	public float cameraMoveTime;
	public Transform objectLookingAt;
	public Color fadeColor = Color.black;
	public float fadeLength;
	public string notificationText;
	public float notificationTime;
	public float waitTime;

	private bool started = false;
	private bool completed = false;

	public enum StepType {
		VIDEO,
		ANIMATION,
		AUDIO,
		WAIT,
		CAM_MOV,
		ENABLE_FPC
	};

	public bool GetStarted() {
		return started;
	}

	public bool GetCompleted() {
		return completed;
	}

	public void SetStarted() {
		started = true;
	}

	public void SetCompleted() {
		completed = true;
	}
}
