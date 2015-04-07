using UnityEngine;
using System.Collections;

public class TheBeeGameKillTrigger : MonoBehaviour
{
	public GameObject player;
	public bool beeDestroyed;
	

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Wasp" && beeDestroyed == true)
		{
			Debug.Log("Killed a wasp");
			other.gameObject.active = false;
			player.GetComponent <TheBeeGame>(). waspkills++;
			player.GetComponent <TheBeeGame>(). playKillSound = true;
		}
	}
}