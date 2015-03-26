using UnityEngine;
using System.Collections;

public class BeginFader : MonoBehaviour {

    private static bool zooming;
    private static bool zoomRoom;
    public GUITexture flashTexture;
    private float currentOpacity = 1f;
    public float flashSpeed;
    private static string destination;
	private static GameObject gameObj;

	// Use this for initialization
	void Start () {
        zooming = true;
        zoomRoom = false;
		gameObj = this.transform.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        LoadLevel();
        LoadRoom();
	}

    void LoadLevel() {
        if(zooming){
            if(!flashTexture.guiTexture.enabled) {
                flashTexture.guiTexture.enabled = true;
                flashTexture.guiTexture.color = new Color(1f,1f,1f,0f);
            }
            currentOpacity = Mathf.Lerp(currentOpacity, 0f, Time.deltaTime * flashSpeed);
            flashTexture.guiTexture.color = new Color(1f,1f,1f,currentOpacity);
            if(currentOpacity < 0.1f) {
                flashTexture.guiTexture.enabled = false;
                zooming = false;
            }
        }
        //Application.LoadLevel("HarveyWithLighting");
    }

    public static void StartRoomZoom(string input) {
        zoomRoom = true;
        destination = input;
		gameObj.GetComponent<AudioSource> ().Play();
    }

    public static bool GetDoneLoad() {
        return !zooming;
    }

    void LoadRoom() {
        if(zoomRoom){
            if(!flashTexture.guiTexture.enabled) {
                currentOpacity = 0f;
                flashTexture.guiTexture.enabled = true;
                flashTexture.guiTexture.color = new Color(1f,1f,1f,0f);
            }
            currentOpacity = Mathf.Lerp(currentOpacity, 1f, Time.deltaTime * flashSpeed);
            flashTexture.guiTexture.color = new Color(1f,1f,1f,currentOpacity);
            if(currentOpacity > 0.7f) {
                    Application.LoadLevel(destination);
            }
        }
    }
}
