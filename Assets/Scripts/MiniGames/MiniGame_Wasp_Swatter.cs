using UnityEngine;
using System.Collections;

public class MiniGame_Wasp_Swatter : MonoBehaviour
{
	public GameObject swatter;
	public GameObject swatterInitialPosition;
	public GameObject swatterSwingPosition;
	
	public AudioSource swatterSwing;
	public AudioSource swatterKill;
	
	public static bool audioCanPlay;
	public static bool swatterActive;
	public static bool swatterVisible;

	void Start ()
	{
		Application.targetFrameRate = 60;
		swatter.renderer.enabled = false;
	}
	
	void Update ()
	{
		if (Minigame_Wasp_Start.gameHasStarted == true)
		{
			swatterActive = true;
		}
		
		if (swatterVisible == true)
		{
			//swatter.renderer.enabled = true;
			//swatter.rigidbody.active = true;
			rigidbody.detectCollisions = true;
			audioCanPlay = true;
			Swatter_Visible.killStickVisible = true;
		}
		else 
		{
			//swatter.renderer.enabled = false;
			//swatter.rigidbody.active = false;
			rigidbody.detectCollisions = false;
			Swatter_Visible.killStickVisible = false;
		}
		
		if (swatterActive == true)
		{
			//if (Input.GetMouseButtonUp (0))
			//{
				//swatter.transform.position = swatterInitialPosition.transform.position;
				//swatter.transform.rotation = swatterInitialPosition.transform.rotation;
			//}
		
			if (Input.GetMouseButtonUp(0))
			{
				swatter.transform.position = swatterSwingPosition.transform.position;
				swatter.transform.rotation = swatterSwingPosition.transform.rotation;
				
				if (audioCanPlay == true)
				{
					swatterSwing.Play ();				
				}
				
				Invoke("SwatterNormalPosition", .1f);
			}
		}
	}
	
	void SwatterNormalPosition ()
	{
		swatter.transform.position = swatterInitialPosition.transform.position;
		swatter.transform.rotation = swatterInitialPosition.transform.rotation;
	}
	
	void OnCollisionEnter(Collision col)
	{
	
		 if (col.gameObject.name == "wasp")
		 {
		 	swatterKill.Play();
		 	Destroy(col.gameObject);
		 	Minigame_Wasp_Start.killCount++;
		 }
	}
}
