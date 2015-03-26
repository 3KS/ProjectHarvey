using UnityEngine;
using System.Collections;

public class BackToDiorama : MonoBehaviour
{

	public Texture backToDiorama;


    void OnGUI() 
	{
        if ((GUI.Button(new Rect(0, Screen.height-100, 100, 100), backToDiorama) || Input.GetKey(KeyCode.Backspace)) && !GameController.GetPauseState())
        {
            SaveController.ResetFPC();
            Screen.lockCursor = false;
            Application.LoadLevel("HarveyWithLighting");
        }
    }
}
