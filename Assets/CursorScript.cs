using UnityEngine;
using System.Collections;

public class CursorScript : MonoBehaviour {
    public Texture2D crosshair;                                                     //Used to display the crosshair
    private int crosshairPositionX = Screen.width / 2;                              //Used to center the crosshair
    private int crosshairPositionY = Screen.height / 2;                             //Used to center the crosshair
    void OnGUI ()
    {
        GUI.DrawTexture (new Rect (crosshairPositionX, crosshairPositionY, crosshair.width / 4, crosshair.height / 4), crosshair);
    }
    
    void Start ()
    {
        Screen.lockCursor = true;

    }
	// Update is called once per frame
	void Update () {
	
	}
}
