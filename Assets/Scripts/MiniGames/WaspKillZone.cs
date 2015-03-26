using UnityEngine;
using System.Collections;

public class WaspKillZone : MonoBehaviour
{
	void Update ()
	{

	}

	void OnCollisionEnter (Collision wasp)
	{
		Debug.Log ("killbox collided");
		Debug.Log (wasp.gameObject.name);

		//if (wasp.gameObject.name == "wasp")
		//{
		//	wasp.gameObject.active = false;

		//	Debug.Log (wasp.gameObject.name);
		//}
	}
}
