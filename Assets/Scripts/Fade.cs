using UnityEngine;
using System.Collections;

/**********************************
 * Class: Fade.cs
 * Author: Justin Schmidt
 * Description: Adds a fade in/ fade
 * out effect for when the game
 * begins, ends and possibly when
 * zooming into and out of a room
 **********************************/

public class Fade : MonoBehaviour
{
	public float fadeSpeed = 1.5f;
	public bool sceneStarting = true;

	void Awake ()
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}

	void Update ()
	{
		if (sceneStarting)
		{
			StartScene ();
		}
	}

	void StartScene ()
	{
		FadeIn();

		if(guiTexture.color.a <= 0.05f)
		{
			guiTexture.color = Color.clear;
			guiTexture.enabled = false;

			sceneStarting = false;
		}
	}
	
	public void EndScene ()
	{
		guiTexture.enabled = true;

		FadeOut();

		if (guiTexture.color.a >= 0.95f) 
		{
			Application.LoadLevel (0);
		}
	}

	void FadeIn ()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
	}
	
	void FadeOut ()
	{
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, fadeSpeed * Time.deltaTime);
	}
}