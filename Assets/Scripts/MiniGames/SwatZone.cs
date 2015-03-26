using UnityEngine;
using System.Collections;

public class SwatZone : MonoBehaviour
{
	private bool waspInSights = false;

	void Start ()
	{

	}

	void Update ()
	{
		if (waspInSights == true)
		{
			WaspSwatter.canSwatNow = true;
		}
		else
		{
			WaspSwatter.canSwatNow = false;
		}
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.name == "wasp")
		{
			waspInSights = true;
		}
	}

	void OnCollisionExit (Collision other)
	{
		waspInSights = false;
	}
}
