using UnityEngine;
using System.Collections;

public class PlayTimeRight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("time is :" + Time.timeScale);
		if (Time.timeScale != 1) {
						Time.timeScale = 1;
				}
		Debug.Log ("time is :" + Time.timeScale);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
