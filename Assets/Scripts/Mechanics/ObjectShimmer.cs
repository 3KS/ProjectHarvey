using UnityEngine;
using System.Collections;

/**********************************
 * Class: ObjectShimmer.cs
 * Author: Justin Schmidt
 * Description: This script is applied 
 *to an object to give it an occasional 
 *shimmer effect, alerting the player to 
 *its interactivity
 **********************************/

public class ObjectShimmer : MonoBehaviour
{
public GameObject objectName;

	public Shader normalShader;
	public Shader glow;

private float fade = 6.0f;

private bool normal = true;
private bool shimmering = false;
public static bool flashPause = false;


	void FixedUpdate ()
	{
		if (flashPause == true)
		{
			objectName.renderer.material.shader = normalShader;

			StopCoroutine("Normal");
			StopCoroutine("Shimmer");

			//fade = 6.0f;
			objectName.renderer.material.SetFloat ("_RimPower", fade);
			//objectName.renderer.material.SetColor ("_RimColor", Color.white);
		}
		else if (flashPause == false)
		{
			if (normal == true && fade < 10.0f)
			{
				StartCoroutine("Normal");

				fade += 0.075f;

				objectName.renderer.material.shader = glow;
				objectName.renderer.material.SetFloat ("_RimPower", fade);
			}
			
			if (shimmering == true && fade > 2.0f)
			{
				StartCoroutine("Shimmer");

				fade -= 0.075f;

				objectName.renderer.material.shader = glow;
				objectName.renderer.material.SetFloat ("_RimPower", fade);
			}
		}
		OnMouseEnter ();
		OnMouseExit ();
	}

	IEnumerator Normal ()
	{
		yield return new WaitForSeconds (2.0f);
		shimmering = true;
		normal = false;
	}

	IEnumerator Shimmer ()
	{
		yield return new WaitForSeconds (2.0f);
		normal = true;
		shimmering = false;
	}

	//The following three functions control the color of the fade when the mouse is hovering and isn't hovering over an interactive object
	public void OnMouseEnter ()
	{
		objectName.renderer.material.SetColor ("_RimColor", Color.blue);
	}

	public void OnMouseOver ()
	{
		objectName.renderer.material.SetColor ("_RimColor", Color.blue);
	}

	public void OnMouseExit ()
	{
		objectName.renderer.material.SetColor ("_RimColor", Color.white);
	}
}
