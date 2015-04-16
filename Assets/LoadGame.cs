using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadGame : MonoBehaviour {

	public Image fadeImage;
	public float fadeTime;
	private float timeFaded = 0;
	private bool isFading = false;

	void OnTriggerEnter(Collider other) {
		GameController.ClearNotification ("tutorialMovement");
		if(other.tag.Equals("Player")) {
			isFading = true;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("HarveyWithLighting");
		}
		if (isFading) {
			timeFaded += Time.deltaTime;
			fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, timeFaded/fadeTime);
			if(timeFaded >= fadeTime) {
				Application.LoadLevel("HarveyWithLighting");

			}
		}
	}
}
