using UnityEngine;
using System.Collections;

public class DialogueTreeTrigger : MonoBehaviour
{
	public GameObject player;
	public GameObject chatMiniGameTrigger;
	public AudioSource farewell;

	void OnTriggerEnter (Collider other)
	{
		//player.GetComponent <DialogueTree>().MinnieGreeting ();
		chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses> ().PlayRandomGreeting ();
		player.GetComponent <DialogueTree> ().minnieHasGreetedPlayer = true;
	}

	void OnTriggerExit (Collider other)
	{
		chatMiniGameTrigger.GetComponent <DialogueTreeRandomResponses> ().PlayRandomFarewell ();
	}
}