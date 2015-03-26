using UnityEngine;
using System.Collections;

public class Swatter_Visible : MonoBehaviour
{
	public GameObject killStick;
	public static bool killStickVisible;

	void Start ()
	{
		killStickVisible = false;
	}
	
	void Update ()
	{
		if (killStickVisible == true)
		{
			killStick.renderer.enabled = true;
		}
		
		if (killStickVisible == false)
		{
			killStick.renderer.enabled = false;
		}
	}
}
