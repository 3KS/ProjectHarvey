using UnityEngine;
using System.Collections;

public class LoadMenu : MonoBehaviour {
    public float loadTime;
    public Texture stoutLogo;
    private float elapsedTime;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= loadTime)
        {
            Application.LoadLevel("MainMenu");
        }
	}

    void OnGUI() {
        GUI.DrawTexture (new Rect((Screen.width/2) - (Screen.height/4),Screen.height/4, Screen.height/2, Screen.height/2), stoutLogo);
    }
}
